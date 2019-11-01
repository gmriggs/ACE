using System;
using System.Collections.Generic;
using System.IO;

using ACE.DatLoader.Entity;

namespace ACE.DatLoader.FileTypes
{
    [DatFileType(DatFileType.PortalIterations)]
    public class IterationList: FileType
    {
        internal const uint FILE_ID = 0xFFFF0001;

        /*public int Iteration { get; set; }
        public List<ConsecutiveSpan> Spans { get; set; } = new List<ConsecutiveSpan>();*/

        /// <summary>
        /// The number of entries in the unpacked list
        /// </summary>
        public int Size;

        public List<int> Ints { get; set; }

        public override void Unpack(BinaryReader reader)
        {
            // hardcoded?
            Id = FILE_ID;

            var size = reader.BaseStream.Length;

            /*if (size < 12 || (size - 4) % 8 != 0)
            {
                Console.WriteLine($"IterationList.Unpack(): unexpected size {size}");
                return;
            }*/

            if (size < 12 || size % 4 != 0)
            {
                Console.WriteLine($"IterationList.Unpack(): unexpected size {size}");
                return;
            }

            /*Iteration = reader.ReadInt32();

            // usually 1, unless there are gaps
            var numSpans = (size - 4) % 8;
            for (var i = 0; i < numSpans; i++)
                Spans.Add(new ConsecutiveSpan(reader.ReadInt32(), reader.ReadInt32()));*/

            Size = reader.ReadInt32();

            var numInts = (size - 4) / 4;
            Ints = new List<int>();
            for (var i = 0; i < numInts; i++)
                Ints.Add(reader.ReadInt32());
        }
    }
}
