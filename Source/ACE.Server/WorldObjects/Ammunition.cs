using System;
using System.IO;
using ACE.Database.Models.Shard;
using ACE.Database.Models.World;
using ACE.Entity;
using ACE.Entity.Enum;
using ACE.Server.Network.GameMessages.Messages;
using ProtoBuf;

namespace ACE.Server.WorldObjects
{
    [ProtoContract]
    public class Ammunition : Stackable
    {
        public Ammunition() { }

        /// <summary>
        /// A new biota be created taking all of its values from weenie.
        /// </summary>
        public Ammunition(Weenie weenie, ObjectGuid guid) : base(weenie, guid)
        {
            SetEphemeralValues();
        }

        /// <summary>
        /// Restore a WorldObject from the database.
        /// </summary>
        public Ammunition(Biota biota) : base(biota)
        {
            SetEphemeralValues();
        }

        private void SetEphemeralValues()
        {
        }

        public override void SerializeIdentifyObjectResponse(BinaryWriter writer, bool success, IdentifyResponseFlags flags = IdentifyResponseFlags.None)
        {
            flags |= IdentifyResponseFlags.WeaponProfile;

            base.SerializeIdentifyObjectResponse(writer, success, flags);

            WriteIdentifyObjectWeaponsProfile(writer, this, success);
        }

        public override void OnCollideObject(WorldObject target)
        {
            if (!PhysicsObj.is_active()) return;

            Console.WriteLine(string.Format("Projectile.OnCollideObject({0} - {1} with {2} - {3})", Guid.Full.ToString("X8"), Name, target.Guid.Full.ToString("X8"), target.Name));

            if (ProjectileTarget == null || !ProjectileTarget.Equals(target))
            {
                Console.WriteLine("Unintended projectile target! (should be " + ProjectileTarget.Guid.Full.ToString("X8") + " - " + ProjectileTarget.Name + ")");
                OnCollideEnvironment();
                return;
            }

            // take damage
            var player = ProjectileSource as Player;
            if (player != null)
            {
                var damage = player.DamageTarget(target, this);

                if (damage > 0)
                    player.Session.Network.EnqueueSend(new GameMessageSound(Guid, Sound.Collision, 1.0f));    // todo: landblock broadcast?
            }

            CurrentLandblock.RemoveWorldObject(Guid, false);
            PhysicsObj.set_active(false);
        }

        public override void OnCollideEnvironment()
        {
            if (!PhysicsObj.is_active()) return;

            Console.WriteLine("Projectile.OnCollideEnvironment(" + Guid.Full.ToString("X8") + ")");

            CurrentLandblock.RemoveWorldObject(Guid, false);
            PhysicsObj.set_active(false);

            var player = ProjectileSource as Player;
            if (player != null)
                player.Session.Network.EnqueueSend(new GameMessageSystemChat("Your missile attack hit the environment.", ChatMessageType.Broadcast));
        }
    }
}
