using System.Collections.Generic;

using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Mutate
{
    public class MutationEffectList
    {
        //public double Probability;
        //public List<MutationEffect> Effects;

        public static bool TryMutate(Database.Models.World.MutationEffectList effects, WorldObject item)
        {
            var success = true;

            // probability?

            foreach (var effect in effects.MutationEffect)
                success &= MutationEffect.TryMutate(effect, item);      // stop completely on failure?

            return success;
        }
    }
}
