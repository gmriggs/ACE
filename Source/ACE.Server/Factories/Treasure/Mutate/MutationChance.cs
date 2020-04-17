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

            // this is opposite from most rolls, 1.0 here means 100%
            // we'll use 1 - chance to accomodate

            // TODO: verify order
            return 1.0 - chances.ElementAt(tier).Chance < roll;
        }
    }
}
