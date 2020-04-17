using System.Collections.Generic;

using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Struct
{
    public class MutationEffectList
    {
        public double Probability;
        public List<MutationEffect> Effects;

        public bool TryMutate(WorldObject item)
        {
            var success = true;

            foreach (var effect in Effects)
                success &= effect.TryMutate(item);      // stop completely on failure?

            return success;
        }
    }
}
