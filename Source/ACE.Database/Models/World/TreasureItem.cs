using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class TreasureItem
    {
        public int Id { get; set; }
        public string TreasureItemName { get; set; }
        public int RollType { get; set; }
        public string TreasureItemTableName { get; set; }
    }
}
