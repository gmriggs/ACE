using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class MutationEffect
    {
        public uint Id { get; set; }
        public uint MutationEffectListId { get; set; }
        public uint ArgQuality { get; set; }
        public uint? EffectType { get; set; }
        public uint Arg1 { get; set; }
        public uint Arg2 { get; set; }

        public virtual MutationEffectList MutationEffectList { get; set; }
        public virtual MutationEffectArgument MutationEffectArgumentId1 { get; set; }
        public virtual MutationEffectArgument MutationEffectArgumentId2 { get; set; }
        public virtual MutationEffectArgument MutationEffectArgumentIdNavigation { get; set; }
    }
}
