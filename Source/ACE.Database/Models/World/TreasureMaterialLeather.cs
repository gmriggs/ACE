using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureMaterialLeather
    {
        public uint Id { get; set; }
        public int? Tier { get; set; }
        public int? Material { get; set; }
        public double? Chance { get; set; }
    }
}
