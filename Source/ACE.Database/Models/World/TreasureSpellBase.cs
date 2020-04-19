using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureSpellBase
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Power { get; set; }
    }
}
