using System.Collections.Generic;

using ACE.Common;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Mutate
{
    public class Mutation
    {
        //public MutationChance Chance;
        //public List<MutationOutcome> Outcomes;

        public static bool TryMutate(Database.Models.World.Mutation mutation, WorldObject item, int tier, double roll)
        {
            // does it pass the roll to mutate for the tier?
            if (!MutationChance.Success(mutation.MutationChance, tier, roll))
                return false;

            // roll again to select the mutations
            roll = ThreadSafeRandom.Next(0.0f, 1.0f);

            var success = true;
            foreach (var outcome in mutation.MutationOutcome)
                success &= MutationOutcome.TryMutate(outcome, item, roll);

            return success;
        }
    }
}
