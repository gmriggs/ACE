using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureCantripLevelProgression
    {
        public uint Id { get; set; }
        public int Minor { get; set; }
        public int Major { get; set; }
        public int Epic { get; set; }
        public int Lego { get; set; }
    }
}
