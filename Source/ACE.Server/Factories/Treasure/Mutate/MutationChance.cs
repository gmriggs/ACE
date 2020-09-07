using System.Collections.Generic;
using System.Linq;

namespace ACE.Server.Factories.Treasure.Mutate
{
    public class MutationChance
    {
        public static bool Success(ICollection<Database.Models.World.MutationChance> chances, int tier, double roll)
        {
            if (tier < 0 || tier >= chances.Count)
                return false;

            return roll < chances.ElementAt(tier).Chance;
        }
    }
}
