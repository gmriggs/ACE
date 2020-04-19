using System.Collections.Generic;

namespace ACE.Server.Factories.Treasure.Struct
{
    public class QualityFilter
    {
        // quality type -> quality id
        public readonly Dictionary<int, HashSet<int>> Filters = new Dictionary<int, HashSet<int>>();

        public bool Add(int qualityType, int qualityId)
        {
            if (!Filters.TryGetValue(qualityType, out var filter))
            {
                filter = new HashSet<int>();
                Filters.Add(qualityType, filter);
            }
            return filter.Add(qualityId);
        }
    }
}
