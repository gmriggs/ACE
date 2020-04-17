using System.Collections.Generic;

using ACE.Common;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Mutate
{
    public class MutationFilter
    {
        //public List<Mutation> Mutations;

        public static bool TryMutate(List<Database.Models.World.Mutation> mutationFilter, WorldObject item, int tier)
        {
            var roll = ThreadSafeRandom.Next(0.0f, 1.0f);

            var success = true;

            foreach (var mutation in mutationFilter)
                success &= Mutation.TryMutate(mutation, item, tier, roll);

            return success;
        }
    }
}
