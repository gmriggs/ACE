using System.Collections.Generic;

namespace ACE.Entity
{
    public class InArchiveVersionStack: ArchiveVersionStack
    {
        public static VersionRowHolder DefaultRow;

        public Dictionary<uint, VersionRowHolder> Versions;
        public uint LastSerialNum;

        static InArchiveVersionStack()
        {
            DefaultRow = new VersionRowHolder();
        }

        public InArchiveVersionStack()
        {
            Versions = new Dictionary<uint, VersionRowHolder>();
        }
    }
}
