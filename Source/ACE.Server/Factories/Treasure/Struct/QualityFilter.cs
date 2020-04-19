using System;
using System.Collections.Generic;

using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;

namespace ACE.Server.Factories.Treasure.Struct
{
    public class QualityFilter
    {
        // property type => property indices
        public readonly Dictionary<QualityFilterType, HashSet<int>> Filters = new Dictionary<QualityFilterType, HashSet<int>>();

        public bool Add(QualityFilterType propType, int propIdx)
        {
            if (!Filters.TryGetValue(propType, out var filter))
            {
                filter = new HashSet<int>();
                Filters.Add(propType, filter);
            }
            return filter.Add(propIdx);
        }

        public void Output()
        {
            foreach (var kvp in Filters)
            {
                var propType = kvp.Key;

                foreach (var idx in kvp.Value)
                {
                    switch (propType)
                    {
                        case QualityFilterType.PropertyInt:
                            Console.WriteLine($"- PropertyInt.{(PropertyInt)idx}");
                            break;

                        case QualityFilterType.PropertyFloat:
                            Console.WriteLine($"- PropertyFloat.{(PropertyFloat)idx}");
                            break;

                        case QualityFilterType.PropertyDataId:
                            Console.WriteLine($"- PropertyDataId.{(PropertyDataId)idx}");
                            break;

                        case QualityFilterType.PropertyString:
                            Console.WriteLine($"- PropertyString.{(PropertyString)idx}");
                            break;
                    }
                }
            }
        }
    }
}
