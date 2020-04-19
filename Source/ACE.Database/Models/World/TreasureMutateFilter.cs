using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureMutateFilter
    {
        public uint Pid { get; set; }
        public int Id { get; set; }
        public int QualityType { get; set; }
        public int QualityID { get; set; }
    }
}
