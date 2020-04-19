using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureArmorStuddedLeather
    {
        public uint Id { get; set; }
        public int Tier { get; set; }
        public int Wcid { get; set; }
        public double Chance { get; set; }
    }
}
