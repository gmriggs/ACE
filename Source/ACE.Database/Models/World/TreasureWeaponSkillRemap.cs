using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureWeaponSkillRemap
    {
        public uint Id { get; set; }
        public int? Wcid { get; set; }
        public int? Skill { get; set; }
        public int? Subskill { get; set; }
    }
}
