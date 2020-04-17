using System.Collections.Generic;

namespace ACE.Server.Factories.Treasure.Struct
{
    public class MutationChance
    {
        public List<double> Chances;

        public bool Success(int tier, double roll)
        {
            if (tier < 0 || tier >= Chances.Count)
                return false;

            // this is opposite from most rolls, 1.0 here means 100%
            // we'll use 1 - chance to accomodate
            return 1.0 - Chances[tier] < roll;
        }
    }
}
