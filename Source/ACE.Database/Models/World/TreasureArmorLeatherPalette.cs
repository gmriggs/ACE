﻿using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureArmorLeatherPalette
    {
        public uint Id { get; set; }
        public int Type { get; set; }
        public int Color { get; set; }
        public double Chance { get; set; }
    }
}
