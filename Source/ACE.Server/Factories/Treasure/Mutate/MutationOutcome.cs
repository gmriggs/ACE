using System.Collections.Generic;

using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Struct
{
    public class MutationOutcome
    {
        public List<MutationEffectList> EffectLists;

        public bool TryMutate(WorldObject item, double roll)
        {
            var mutated = false;

            foreach (var effectList in EffectLists)
            {
                if (effectList.Probability < roll)
                    continue;

                mutated = effectList.TryMutate(item);
                break;
            }
            return mutated;
        }
    }
}
