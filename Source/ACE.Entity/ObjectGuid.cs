using ProtoBuf;

namespace ACE.Entity
{
    public enum GuidType
    {
        Undef,
        Player,
        Static,
        Dynamic,
    }

    [ProtoContract]
    public class ObjectGuid
    {
        public static readonly ObjectGuid Invalid = new ObjectGuid(0);

        /* These are not GUIDs
        public static uint WeenieMin { get; } = 0x00000001;
        public static uint WeenieMax { get; } = 0x000F423F; // 999,999 */

        // 0x01000001 and 0x422C91BC Only PCAP'd 9 GUID's found in this range 

        public static uint PlayerMin { get; } = 0x50000001;
        public static uint PlayerMax { get; } = 0x5FFFFFFF;

        // 0x60000000 No PCAP'd GUID's in this range

        // PY 16 has these ranges 0x70003000 - 0x7FADA053
        // They are organized by landblock where 0x7AABB000 is landblock AABB
        // These represent items that come from the World db
        public static uint StaticObjectMin { get; } = 0x70000000;
        public static uint StaticObjectMax { get; } = 0x7FFFFFFF;

        // These represent items are generated in the world. Some of them will be saved to the Shard db.
        public static uint DynamicMin { get; } = 0x80000000;
        public static uint DynamicMax { get; } = 0xFFFFFFFE; // Ends at E because uint.Max is reserved for "invalid"

        [ProtoMember(1)]
        public uint Full { get; }
        public uint Low => Full & 0xFFFFFF;
        public uint High => (Full >> 24);

        [ProtoMember(2)]
        public GuidType Type { get; }

        public ObjectGuid() { }

        public ObjectGuid(uint full)
        {
            Full = full;

            if (Full >= PlayerMin && Full <= PlayerMax)
                Type = GuidType.Player;
            else if (Full >= StaticObjectMin && Full <= StaticObjectMax)
                Type = GuidType.Static;
            else if (Full >= DynamicMin && Full <= DynamicMax)
                Type = GuidType.Dynamic;
            else
                Type = GuidType.Undef;
        }

        public bool IsPlayer()
        {
            return Type == GuidType.Player;
        }

        public static bool operator ==(ObjectGuid g1, ObjectGuid g2)
        {
            return g1.Full == g2.Full;
        }

        public static bool operator !=(ObjectGuid g1, ObjectGuid g2)
        {
            return g1.Full != g2.Full;
        }

        public override bool Equals(object obj)
        {
            return obj is ObjectGuid && ((ObjectGuid)obj).Full == this.Full;
        }

        public bool Equals(ObjectGuid guid)
        {
            return Full.Equals(guid.Full);
        }

        public override int GetHashCode()
        {
            return Full.GetHashCode();
        }
    }
}
