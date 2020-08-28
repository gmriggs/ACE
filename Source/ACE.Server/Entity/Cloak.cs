using System;

using ACE.Common;
using ACE.Entity.Enum;
using ACE.Server.Network.GameMessages.Messages;
using ACE.Server.WorldObjects;

namespace ACE.Server.Entity
{
    public class Cloak
    {
        /// <summary>
        /// The maximum frequency of cloak procs, in seconds
        /// </summary>
        private static readonly float MinDelay = 5.0f;

        /// <summary>
        /// Rolls for a chance at procing a cloak spell
        /// If successful, casts the spell
        /// </summary>
        public static bool TryProcSpell(Creature defender, WorldObject attacker, WorldObject cloak, float damage_percent)
        {
            if (cloak == null) return false;

            if (!RollProc(cloak, damage_percent))
                return false;

            return HandleProcSpell(defender, attacker, cloak);
        }

        /// <summary>
        /// Rolls for a chance at procing a cloak spell
        /// </summary>
        /// <param name="damage_percent">The percent of MaxHealth inflicted by an enemy's hit</param>
        /// <returns></returns>
        public static bool RollProc(WorldObject cloak, float damage_percent)
        {
            // TODO: find retail formula

            var currentTime = Time.GetUnixTime();

            if (currentTime - cloak.UseTimestamp < MinDelay)
                return false;

            var itemLevel = cloak.ItemLevel ?? 0;

            var maxProcRate = 0.25f + itemLevel * 0.01f;

            var chance = Math.Min(damage_percent, maxProcRate);

            var rng = ThreadSafeRandom.Next(0.0f, 1.0f);

            if (rng < chance)
            {
                cloak.UseTimestamp = currentTime;
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Casts the cloak proc spell
        /// </summary>
        public static bool HandleProcSpell(Creature defender, WorldObject attacker, WorldObject cloak)
        {
            if (cloak.ProcSpell == null) return false;

            var spell = new Spell(cloak.ProcSpell.Value);

            if (spell.NotFound)
            {
                if (defender is Player player)
                    player.Session.Network.EnqueueSend(new GameMessageSystemChat($"{spell.Name} spell not implemented, yet!", ChatMessageType.System));

                return false;
            }

            var targetSelf = spell.Flags.HasFlag(SpellFlags.SelfTargeted);
            var untargeted = spell.NonComponentTargetType == ItemType.None;

            var target = attacker;
            if (untargeted)
                target = null;
            else if (targetSelf)
                target = defender;

            // cloak range?

            var msg = new GameMessageSystemChat($"The cloak of {defender.Name} weaves the magic of {spell.Name}!", ChatMessageType.Spellcasting);

            defender.EnqueueBroadcast(msg, WorldObject.LocalBroadcastRange, ChatMessageType.Magic);

            defender.TryCastSpell(spell, target, cloak, false, false);

            return true;
        }

        /// <summary>
        /// Returns TRUE if object is cloak
        /// </summary>
        public static bool IsCloak(WorldObject wo)
        {
            return wo.ValidLocations == EquipMask.Cloak;
        }

        /// <summary>
        /// The amount of damage reduced by a cloak proced with PropertyInt.CloakWeaveProc=2
        /// </summary>
        public static readonly int DamageReductionAmount = 200;

        /// <summary>
        /// Returns the reduced damage amount when a cloak procs
        /// with PropertyInt.CloakWeaveProc=2
        /// </summary>
        public static uint GetReducedAmount(uint damage)
        {
            if (damage > DamageReductionAmount)
                return (uint)(damage - DamageReductionAmount);
            else
                return 0;
        }

        public static int GetReducedAmount(int damage)
        {
            return Math.Max(0, damage - DamageReductionAmount);
        }

        public static float GetReducedAmount(float damage)
        {
            return Math.Max(0, damage - DamageReductionAmount);
        }

        /// <summary>
        /// Sends the message to attacker and defender when cloak is proced with PropertyInt.CloakWeaveProc=2
        /// </summary>
        public static void ShowMessage(Creature defender, WorldObject attacker, int origDamage, int reducedDamage)
        {
            var suffix = $"reduced the damage from {origDamage} down to {reducedDamage}!";

            if (defender is Player playerDefender)
                playerDefender.Session.Network.EnqueueSend(new GameMessageSystemChat($"Your cloak {suffix}", ChatMessageType.Magic));

            // send message to attacker?
            if (attacker is Player playerAttacker)
                playerAttacker.Session.Network.EnqueueSend(new GameMessageSystemChat($"The cloak of {defender.Name} {suffix}", ChatMessageType.Magic));
        }

        public static void ShowMessage(Creature defender, WorldObject attacker, float origDamage, float reducedDamage)
        {
            ShowMessage(defender, attacker, (int)Math.Round(origDamage), (int)Math.Round(reducedDamage));
        }

        /// <summary>
        /// Returns TRUE If cloak has a damage reduction proc
        /// Matches client logic
        /// </summary>
        public static bool HasDamageProc(WorldObject cloak)
        {
            return cloak?.CloakWeaveProc == 2;
        }

        /// <summary>
        /// Returns TRUE if cloak has a spell proc
        /// </summary>
        public static bool HasProcSpell(WorldObject cloak)
        {
            return cloak?.ProcSpell != null;
        }
    }
}
