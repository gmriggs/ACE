using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class MutationEffectList
    {
        public MutationEffectList()
        {
            MutationEffect = new HashSet<MutationEffect>();
        }

        public uint Id { get; set; }
        public uint MutationOutcomeId { get; set; }
        public uint Idx { get; set; }
        public double Probability { get; set; }

        public virtual MutationOutcome MutationOutcome { get; set; }
        public virtual ICollection<MutationEffect> MutationEffect { get; set; }
    }
}
