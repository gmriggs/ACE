using System.Collections.Generic;
using System.Linq;

namespace ACE.Entity
{
    public class InArchiveVersionStack: ArchiveVersionStack
    {
        // VersionRowHolder, or ArchiveVersionRow?
        public static ArchiveVersionRow DefaultRow;

        // Dictionary or actual Stack?
        //public Dictionary<uint, VersionRowHolder> Versions;
        public Stack<ArchiveVersionRow> Versions;
        public uint LastSerialNumber;

        public static uint InterfaceType0;
        public static uint InterfaceType3;

        static InArchiveVersionStack()
        {
            DefaultRow = new ArchiveVersionRow();
        }

        public InArchiveVersionStack()
        {
            //Versions = new Dictionary<uint, VersionRowHolder>();
            Versions = new Stack<ArchiveVersionRow>();
            LastSerialNumber = 1;
        }

        public TResult QueryInterface(TResult result, uint interfaceType, object outInterface)
        {
            // return to this
            return null;
        }

        public ArchiveVersionRow.VersionEntry GetRowByHandle(uint version)
        {
            // verify
            var last = Versions.Peek();

            if (last != null)
                return last.Versions.FirstOrDefault(i => i.Version == version);
            else
                return null;
        }

        public ArchiveVersionRow GetVersionByHandle()
        {
            // verify
            return Versions.Peek();
        }

        public uint GetVersionByToken(uint tokVersion)
        {
            var last = Versions.Peek();

            if (last != null)
                return last.GetVersionByToken(tokVersion);
            else
                return 0;
        }

        public uint PushVersionRow()
        {
            LastSerialNumber += 2;

            var row = new ArchiveVersionRow();
            // hash id == LastSerialNumber
            Versions.Push(row);

            return LastSerialNumber;
        }

        public uint PushVersionRow(ArchiveVersionRow initialData)
        {
            LastSerialNumber += 2;

            // copy constructor?
            Versions.Push(initialData);

            return LastSerialNumber;
        }

        public ArchiveVersionRow PopVersionRow(uint version)
        {
            // remove a specific hash id, or pop from stack?
            return Versions.Pop();
        }

        public void Reset()
        {
            Versions.Clear();
        }

        public bool SetVersion(uint tokVersion, uint version)
        {
            var last = Versions.Peek();

            if (last != null)
                return last.SetVersion(tokVersion, version);
            else
                return false;
        }
    }
}
