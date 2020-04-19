using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureMaterialMod
    {
        public uint Id { get; set; }
        public int Material { get; set; }
        public double Multiplier { get; set; }
        public string Name { get; set; }
    }
}
