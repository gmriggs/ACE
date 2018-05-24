using ACE.Database.Models.Shard;
using ACE.Database.Models.World;
using ACE.Entity;
using ProtoBuf;

namespace ACE.Server.WorldObjects
{
    [ProtoContract]
    public class Switch : WorldObject
    {
        public Switch() { }

        /// <summary>
        /// A new biota be created taking all of its values from weenie.
        /// </summary>
        public Switch(Weenie weenie, ObjectGuid guid) : base(weenie, guid)
        {
            SetEphemeralValues();
        }

        /// <summary>
        /// Restore a WorldObject from the database.
        /// </summary>
        public Switch(Biota biota) : base(biota)
        {
            SetEphemeralValues();
        }

        private void SetEphemeralValues()
        {
        }
    }
}
