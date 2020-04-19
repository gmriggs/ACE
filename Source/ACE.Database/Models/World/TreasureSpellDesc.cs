using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureSpellDesc
    {
        public uint Id { get; set; }
        public int SpellID { get; set; }
        public string Name { get; set; }
        public int Diff { get; set; }
        public int Mana { get; set; }
        public int TargetType { get; set; }
        public string Descriptor { get; set; }
        public int NoDescEntry { get; set; }
    }
}
