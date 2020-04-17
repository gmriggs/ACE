using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class MutationOutcome
    {
        public MutationOutcome()
        {
            MutationEffectList = new HashSet<MutationEffectList>();
        }

        public uint Id { get; set; }
        public uint MutationId { get; set; }

        public virtual Mutation Mutation { get; set; }
        public virtual ICollection<MutationEffectList> MutationEffectList { get; set; }
    }
}
