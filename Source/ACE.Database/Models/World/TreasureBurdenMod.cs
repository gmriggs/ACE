using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureBurdenMod
    {
        public uint Id { get; set; }
        public int? QualityLevel { get; set; }
        public double? Chance { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
    }
}
