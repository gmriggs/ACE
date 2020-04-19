using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureHeritage
    {
        public uint Id { get; set; }
        public int Dist { get; set; }
        public int Heritage { get; set; }
        public double Chance { get; set; }
    }
}
