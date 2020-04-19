using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureTierAdjust
    {
        public uint Id { get; set; }
        public int Tier { get; set; }
        public int AdjustTier { get; set; }
        public double Chance { get; set; }
    }
}
