using ACE.Entity.Enum;

namespace ACE.Entity
{
    public class CachePack
    {
        // CachePackType?
        public int Offset;
        public uint Version;
        public byte[] Buffer;

        public CachePack()
        {

        }

        public CachePack(Archive archive)
        {
            SerializeOrWindow(archive);
        }

        public void SerializeOrWindow(Archive archive)
        {
            if (archive.IsPacked)
                Pack(archive);
            else
                Unpack(archive);
        }

        public void Pack(Archive archive)
        {
            archive.Write(Version);
            // 4 size?
            archive.Write(Buffer.Length);
            archive.Write(Buffer);
        }

        public void Unpack(Archive archive)
        {
            Version = archive.ReadUInt32().Value;

            var curPos = archive.GetSizeUsed();
            var size = archive.ReadUInt32().Value;

            if (archive.Flags.HasFlag(ArchiveFlag.NoVersion))
                return;

            archive.SetCurrentPosition(curPos);
            var buffer = archive.GetRemainingBuffer();

            Buffer = archive.GetBytes(size);
        }
    }
}
