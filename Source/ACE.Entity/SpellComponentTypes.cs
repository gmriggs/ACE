using System;
using System.Collections.Generic;

using ACE.Entity.Enum;

namespace ACE.Entity
{
    public class SpellComponentTypes: IEquatable<SpellComponentTypes>
    {
        public List<SpellComponentType> ComponentTypes { get; set; }

        public SpellComponentTypes(List<SpellComponentType> componentTypes)
        {
            ComponentTypes = componentTypes;
        }

        public bool Equals(SpellComponentTypes other)
        {
            if (ComponentTypes.Count != other.ComponentTypes.Count)
                return false;

            for (var i = 0; i < ComponentTypes.Count; i++)
            {
                if (ComponentTypes[i] != other.ComponentTypes[i])
                    return false;
            }
            return true;
        }

        public override int GetHashCode()
        {
            int hash = 0;

            foreach (var component in ComponentTypes)
                hash = (hash * 397) ^ component.GetHashCode();

            return hash;
        }

        public override string ToString()
        {
            return string.Join(", ", ComponentTypes);
        }
    }
}
