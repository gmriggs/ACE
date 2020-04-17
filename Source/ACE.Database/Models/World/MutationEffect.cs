using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class MutationEffect
    {
        public MutationEffect()
        {
            MutationEffectArgument = new HashSet<MutationEffectArgument>();
        }

        public uint Id { get; set; }
        public uint MutationEffectListId { get; set; }
        public uint EffectType { get; set; }

        public virtual MutationEffectList MutationEffectList { get; set; }
        public virtual ICollection<MutationEffectArgument> MutationEffectArgument { get; set; }
    }
}
