using System.Collections.Generic;

using ACE.Database.Models.World;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure
{
    public class DeathTreasureRoll
    {
        public TreasureDeath TreasureDeath;

        public int ItemCount;
        public int MagicCount;
        public int MundaneCount;

        public Dictionary<uint, WorldObject> Items;
        public Dictionary<uint, List<string>> ItemsModLog;
        public Dictionary<uint, WorldObject> Magic;
        public Dictionary<uint, List<string>> MagicModLog;
        public Dictionary<uint, WorldObject> Mundae;

        public void SetDeathTreasure(TreasureDeath treasureDeath)
        {
            TreasureDeath = treasureDeath;
        }
    }
}
