using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class MutationChance
    {
        public uint Id { get; set; }
        public uint MutationId { get; set; }
        public double Chance { get; set; }

        public virtual Mutation Mutation { get; set; }
    }
}
