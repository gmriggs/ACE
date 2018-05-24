using ACE.Database.Models.Shard;
using ACE.Database.Models.World;
using ACE.Entity;
using ACE.Entity.Enum.Properties;
using ProtoBuf;

namespace ACE.Server.WorldObjects
{
    [ProtoContract]
    [ProtoInclude(103, typeof(Ammunition))]
    [ProtoInclude(110, typeof(Coin))]
    [ProtoInclude(119, typeof(Gem))]
    [ProtoInclude(116, typeof(Food))]
    [ProtoInclude(127, typeof(Missile))]
    [ProtoInclude(137, typeof(SpellComponent))]

    public class Stackable : WorldObject
    {
        public Stackable() { }

        /// <summary>
        /// A new biota be created taking all of its values from weenie.
        /// </summary>
        public Stackable(Weenie weenie, ObjectGuid guid) : base(weenie, guid)
        {
            SetEphemeralValues();
        }

        /// <summary>
        /// Restore a WorldObject from the database.
        /// </summary>
        public Stackable(Biota biota) : base(biota)
        {
            SetEphemeralValues();
        }

        private void SetEphemeralValues()
        {
        }

        public override int? EncumbranceVal
        {
            get
            {
                var value = ((StackUnitEncumbrance ?? 0) * (StackSize ?? 1));

                base.EncumbranceVal = value;

                return value;
            }
        }

        public override int? Value
        {
            get
            {
                var value = ((StackUnitValue ?? 0) * (StackSize ?? 1));

                base.Value = value;

                return value;
            }
        }
    }
}
