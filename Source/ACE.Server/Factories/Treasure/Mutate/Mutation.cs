using System.Collections.Generic;

using ACE.Common;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Struct
{
    public class Mutation
    {
        public MutationChance Chance;
        public List<MutationOutcome> Outcomes;

        public bool TryMutate(WorldObject item, int tier, double roll)
        {
            // does it pass the roll to mutate for the tier?
            if (!Chance.Success(tier, roll))
                return false;

            // roll again to select the mutations
            roll = ThreadSafeRandom.Next(0.0f, 1.0f);

            var success = true;
            foreach (var outcome in Outcomes)
                success &= outcome.TryMutate(item, roll);

            return success;
        }
    }
}
