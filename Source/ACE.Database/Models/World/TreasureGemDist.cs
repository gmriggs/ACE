using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureGemDist
    {
        public uint Id { get; set; }
        public int? Group { get; set; }
        public int? Tier { get; set; }
        public int? Count { get; set; }
        public double? Chance { get; set; }
    }
}
