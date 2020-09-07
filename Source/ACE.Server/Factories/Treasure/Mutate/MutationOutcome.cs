using System.Collections.Generic;
using System.Linq;

using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Mutate
{
    public class MutationOutcome
    {
        //public List<MutationEffectList> EffectLists;

        public static bool TryMutate(Database.Models.World.MutationOutcome outcome, WorldObject item, double roll)
        {
            var mutated = false;

            // FIXME
            var idx = 0;
            do
            {
                var currentList = outcome.MutationEffectList.Where(i => i.Idx == idx);
                if (currentList.Count() == 0)
                    return mutated;
                foreach (var effectList in currentList)
                {
                    if (roll >= effectList.Probability)
                        continue;

                    mutated &= MutationEffectList.TryMutate(effectList, item);
                    return mutated;
                }
                idx++;
            }
            while (true);
        }
    }
}
