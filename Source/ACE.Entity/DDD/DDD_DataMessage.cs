using ACE.Entity.Enum;

namespace ACE.Entity
{
    public class DDD_DataMessage: FakeDataMessage
    {
        public byte[] Data;

        public ulong IDDatFile;
        public QualifiedDataID QDID;
        public CachePack CPData;
        public int IDIteration;
        public bool Compressed;

        public uint GetCompressedSize()
        {
            if (Data != null && Data.Length > 4)
                return (uint)Data.Length - 4;
            else
                return 0;
        }

        public void Serialize(Archive archive)
        {
            if (archive.Flags.HasFlag(ArchiveFlag.IsPacked))
                Pack(archive);
            else
                Unpack(archive);
        }

        public void Pack(Archive archive)
        {
            archive.Write(Et);
            archive.Write(IDDatFile);
            archive.Write(QDID.Type);
            archive.Write(QDID.ID);
            archive.Write(IDIteration);
            archive.Write(Compressed);

            CPData.Pack(archive);
        }

        public void Unpack(Archive archive)
        {
            Et = archive.ReadUInt32().Value;

            IDDatFile = archive.ReadUInt64().Value;

            // verify ordering
            QDID = new QualifiedDataID();
            QDID.Type = archive.ReadUInt32().Value;
            QDID.ID = archive.ReadUInt32().Value;

            IDIteration = archive.ReadInt32().Value;
            Compressed = archive.ReadBool().Value;

            CPData = new CachePack(archive);
        }
    }
}
