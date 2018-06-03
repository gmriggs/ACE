using ACE.Database.Models.Shard;
using ACE.Database.Models.World;
using ACE.Entity;
using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;
using System.IO;
using ProtoBuf;

namespace ACE.Server.WorldObjects
{
    [ProtoContract]
    public class SpellComponent : Stackable
    {
        public SpellComponent() { }

        /// <summary>
        /// A new biota be created taking all of its values from weenie.
        /// </summary>
        public SpellComponent(Weenie weenie, ObjectGuid guid) : base(weenie, guid)
        {
            SetEphemeralValues();
        }

        /// <summary>
        /// Restore a WorldObject from the database.
        /// </summary>
        public SpellComponent(Biota biota) : base(biota)
        {
            SetEphemeralValues();
        }

        private void SetEphemeralValues()
        {
        }
    }
}
