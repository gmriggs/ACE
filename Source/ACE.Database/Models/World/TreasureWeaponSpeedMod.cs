﻿using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureWeaponSpeedMod
    {
        public uint Id { get; set; }
        public int? QualityLevel { get; set; }
        public double? Min { get; set; }
        public double? Max { get; set; }
    }
}