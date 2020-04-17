using System.Collections.Generic;

using ACE.Common;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Struct
{
    public class MutationFilter
    {
        public List<Mutation> Mutations;

        public bool TryMutate(WorldObject item, int tier)
        {
            var roll = ThreadSafeRandom.Next(0.0f, 1.0f);

            var success = true;

            foreach (var mutation in Mutations)
                success &= mutation.TryMutate(item, tier, roll);

            return success;
        }
    }
}
