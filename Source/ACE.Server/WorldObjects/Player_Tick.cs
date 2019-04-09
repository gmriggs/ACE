using System;
using System.Linq;

using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;
using ACE.Server.Managers;
using ACE.Server.Physics;
using ACE.Server.Physics.Common;
using ACE.Server.Entity.Actions;
using ACE.Server.Network.GameMessages.Messages;

namespace ACE.Server.WorldObjects
{
    partial class Player
    {
        private readonly ActionQueue actionQueue = new ActionQueue();

        private int initialAge;
        private DateTime initialAgeTime;

        private const double ageUpdateInterval = 7;
        private double nextAgeUpdateTime;

        public void Player_Tick(double currentUnixTime)
        {
            actionQueue.RunActions();

            if (nextAgeUpdateTime <= currentUnixTime)
            {
                nextAgeUpdateTime = currentUnixTime + ageUpdateInterval;

                if (initialAgeTime == DateTime.MinValue)
                {
                    initialAge = Age ?? 1;
                    initialAgeTime = DateTime.UtcNow;
                }

                Age = initialAge + (int)(DateTime.UtcNow - initialAgeTime).TotalSeconds;

                // In retail, this is sent every 7 seconds. If you adjust ageUpdateInterval from 7, you'll need to re-add logic to send this every 7s (if you want to match retail)
                Session.Network.EnqueueSend(new GameMessagePrivateUpdatePropertyInt(this, PropertyInt.Age, Age ?? 1));
            }
        }

        /// <summary>
        /// Called every ~5 seconds for Players
        /// </summary>
        public override void Heartbeat(double currentUnixTime)
        {
            NotifyLandblocks();

            ManaConsumersTick();

            HandleTargetVitals();

            LifestoneProtectionTick();

            PK_DeathTick();

            // Check if we're due for our periodic SavePlayer
            if (LastRequestedDatabaseSave == DateTime.MinValue)
                LastRequestedDatabaseSave = DateTime.UtcNow;

            if (LastRequestedDatabaseSave + PlayerSaveInterval <= DateTime.UtcNow)
                SavePlayerToDatabase();

            base.Heartbeat(currentUnixTime);
        }

        /// <summary>
        /// Prepare new action to run on this player
        /// </summary>
        public override void EnqueueAction(IAction action)
        {
            actionQueue.EnqueueAction(action);
        }

        /// <summary>
        /// Called every ~5 secs for equipped mana consuming items
        /// </summary>
        public void ManaConsumersTick()
        {
            if (!EquippedObjectsLoaded)
                return;

            var EquippedManaConsumers = EquippedObjects.Where(k =>
                (k.Value.IsAffecting ?? false) &&
                k.Value.ManaRate.HasValue &&
                k.Value.ItemMaxMana.HasValue &&
                k.Value.ItemCurMana.HasValue &&
                k.Value.ItemCurMana.Value > 0).ToList();

            foreach (var k in EquippedManaConsumers)
            {
                var item = k.Value;
                var rate = item.ManaRate.Value;

                if (LumAugItemManaUsage != 0)
                    rate *= GetNegativeRatingMod(LumAugItemManaUsage);

                if (!item.ItemManaConsumptionTimestamp.HasValue) item.ItemManaConsumptionTimestamp = DateTime.Now;
                DateTime mostRecentBurn = item.ItemManaConsumptionTimestamp.Value;

                var timePerBurn = -1 / rate;

                var secondsSinceLastBurn = (DateTime.Now - mostRecentBurn).TotalSeconds;

                var delta = secondsSinceLastBurn / timePerBurn;

                var deltaChopped = (int)Math.Floor(delta);
                var deltaExtra = delta - deltaChopped;

                if (deltaChopped <= 0)
                    continue;

                var timeToAdd = (int)Math.Floor(deltaChopped * timePerBurn);
                item.ItemManaConsumptionTimestamp = mostRecentBurn + new TimeSpan(0, 0, timeToAdd);
                var manaToBurn = Math.Min(item.ItemCurMana.Value, deltaChopped);
                deltaChopped = Math.Clamp(deltaChopped, 0, 10);
                item.ItemCurMana -= deltaChopped;

                if (item.ItemCurMana < 1 || item.ItemCurMana == null)
                {
                    item.IsAffecting = false;
                    var msg = new GameMessageSystemChat($"Your {item.Name} is out of Mana.", ChatMessageType.Magic);
                    var sound = new GameMessageSound(Guid, Sound.ItemManaDepleted);
                    Session.Network.EnqueueSend(msg, sound);
                    if (item.WielderId != null)
                    {
                        if (item.Biota.BiotaPropertiesSpellBook != null)
                        {
                            // unsure if these messages / sounds were ever sent in retail,
                            // or if it just purged the enchantments invisibly
                            // doing a delay here to prevent 'SpellExpired' sounds from overlapping with 'ItemManaDepleted'
                            var actionChain = new ActionChain();
                            actionChain.AddDelaySeconds(2.0f);
                            actionChain.AddAction(this, () =>
                            {
                                for (int i = 0; i < item.Biota.BiotaPropertiesSpellBook.Count; i++)
                                {
                                    RemoveItemSpell(item, (uint)item.Biota.BiotaPropertiesSpellBook.ElementAt(i).Spell);
                                }
                            });
                            actionChain.EnqueueChain();
                        }
                    }
                }
                else
                {
                    // get time until empty
                    var secondsUntilEmpty = ((item.ItemCurMana - deltaExtra) * timePerBurn);
                    if (secondsUntilEmpty <= 120 && (!item.ItemManaDepletionMessageTimestamp.HasValue || (DateTime.Now - item.ItemManaDepletionMessageTimestamp.Value).TotalSeconds > 120))
                    {
                        item.ItemManaDepletionMessageTimestamp = DateTime.Now;
                        Session.Network.EnqueueSend(new GameMessageSystemChat($"Your {item.Name} is low on Mana.", ChatMessageType.Magic));
                    }
                }
            }
        }

        public static float MaxSpeed = 50;
        public static float MaxSpeedSq = MaxSpeed * MaxSpeed;

        /// <summary>
        /// Used by physics engine to actually update a player position
        /// Automatically notifies clients of updated position
        /// </summary>
        /// <param name="newPosition">The new position being requested, before verification through physics engine</param>
        /// <returns>TRUE if object moves to a different landblock</returns>
        public bool UpdatePlayerPhysics(ACE.Entity.Position newPosition, bool forceUpdate = false)
        {
            //Console.WriteLine($"UpdatePlayerPhysics: {newPosition.Cell:X8}, {newPosition.Pos}");

            // possible bug: while teleporting, client can still send AutoPos packets from old landblock
            if (Teleporting && !forceUpdate) return false;

            if (PhysicsObj != null)
            {
                var distSq = Location.SquaredDistanceTo(newPosition);

                if (distSq > PhysicsGlobals.EpsilonSq)
                {
                    if (newPosition.Landblock == 0x18A && Location.Landblock != 0x18A)
                        log.Info($"{Name} is getting swanky");

                    if (!Teleporting)
                    {
                        // verify movement
                        if (distSq > MaxSpeedSq && PhysicsObj.GetBlockDist(Location.Cell, newPosition.Cell) > 1)
                        {
                            //Session.Network.EnqueueSend(new GameMessageSystemChat("Movement error", ChatMessageType.Broadcast));
                            log.Warn($"MOVEMENT SPEED: {Name} trying to move from {Location} to {newPosition}, speed: {Math.Sqrt(distSq)}");
                            return false;
                        }
                    }

                    var curCell = LScape.get_landcell(newPosition.Cell);
                    if (curCell != null)
                    {
                        PhysicsObj.set_request_pos(newPosition.Pos, newPosition.Rotation, curCell, Location.LandblockId.Raw);
                        PhysicsObj.update_object_server();

                        if (PhysicsObj.CurCell == null)
                            PhysicsObj.CurCell = curCell;

                        CheckMonsters();
                    }
                }
            }

            // double update path: landblock physics update -> updateplayerphysics() -> update_object_server() -> Teleport() -> updateplayerphysics() -> return to end of original branch
            if (Teleporting && !forceUpdate) return true;

            var landblockUpdate = Location.Cell >> 16 != newPosition.Cell >> 16;
            Location = newPosition;

            SendUpdatePosition();

            if (!InUpdate)
                LandblockManager.RelocateObjectForPhysics(this, true);

            return landblockUpdate;
        }
    }
}
