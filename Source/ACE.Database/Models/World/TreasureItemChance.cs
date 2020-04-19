using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureItemChance
    {
        public uint Id { get; set; }
        public int ItemTable { get; set; }
        public int TreasureItemTable { get; set; }
        public double Chance { get; set; }
    }
}
