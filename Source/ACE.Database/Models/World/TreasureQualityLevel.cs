using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureQualityLevel
    {
        public uint Id { get; set; }
        public int? Tier { get; set; }
        public int? QualityLevel { get; set; }
        public double? Chance { get; set; }
    }
}
