using System;
using System.IO;

namespace ACE.DatLoader.FileTypes
{
    [DatFileType(DatFileType.PortalIterations)]
    public class IterationList: FileType
    {
        internal const uint FILE_ID = 0xFFFF0001;

        public int Iteration { get; set; }
        public int NegFirstGap { get; set; }

        // not sure if this is a 'sorted' bool, or first iteration
        public int FirstIteration { get; set; }
        public bool Sorted => FirstIteration != 0;

        public override void Unpack(BinaryReader reader)
        {
            // hardcoded?
            Id = FILE_ID;

            Iteration = reader.ReadInt32();
            NegFirstGap = reader.ReadInt32();
            FirstIteration = reader.ReadInt32();
        }
    }
}
