using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class Mutation
    {
        public Mutation()
        {
            MutationChance = new HashSet<MutationChance>();
            MutationOutcome = new HashSet<MutationOutcome>();
        }

        public uint Id { get; set; }
        public uint MutationId { get; set; }
        public uint Idx { get; set; }

        public virtual ICollection<MutationChance> MutationChance { get; set; }
        public virtual ICollection<MutationOutcome> MutationOutcome { get; set; }
    }
}
