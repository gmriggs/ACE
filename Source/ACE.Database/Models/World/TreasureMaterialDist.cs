using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureMaterialDist
    {
        public uint Id { get; set; }
        public int? Group { get; set; }
        public int? Tier { get; set; }
        public int? Material { get; set; }
        public double? Chance { get; set; }
    }
}
