using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureMaterialColorDist
    {
        public uint Id { get; set; }
        public int Material { get; set; }
        public int Group { get; set; }
        public int Color { get; set; }
        public double Chance { get; set; }
    }
}
