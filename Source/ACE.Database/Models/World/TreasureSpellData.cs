using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureSpellData
    {
        public uint Id { get; set; }
        public int? SpellID { get; set; }
        public string Name { get; set; }
        public int? Family { get; set; }
        public int? FamilyOverride { get; set; }
        public string Words { get; set; }
        public int? Duration { get; set; }
        public int? Diff { get; set; }
        public int? IsFellow { get; set; }
        public int? IsOff { get; set; }
        public int? IsUntargeted { get; set; }
        public int? IsInstant { get; set; }
        public int? SchoolID { get; set; }
        public int? TurnTo { get; set; }
    }
}
