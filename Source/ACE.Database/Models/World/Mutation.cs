using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class Mutation
    {
        public Mutation()
        {
            MutationOutcome = new HashSet<MutationOutcome>();
        }

        public uint Id { get; set; }
        public float Chance { get; set; }

        public virtual ICollection<MutationOutcome> MutationOutcome { get; set; }
    }
}
