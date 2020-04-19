using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureArmor
    {
        public uint Id { get; set; }
        public int Tier { get; set; }
        public int ArmorSubtable { get; set; }
        public double Chance { get; set; }
    }
}
