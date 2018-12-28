﻿using System;
using System.Collections.Generic;

namespace ACE.Database.Models.Shard
{
    public partial class HousePermission
    {
        public uint Id { get; set; }
        public uint HouseId { get; set; }
        public uint PlayerGuid { get; set; }
        public bool Storage { get; set; }

        public Biota House { get; set; }
    }
}
