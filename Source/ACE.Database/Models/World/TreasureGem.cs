using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureGem
    {
        public uint Id { get; set; }
        public int Class { get; set; }
        public int Material { get; set; }
        public double Chance { get; set; }
        public int Wcid { get; set; }
    }
}
