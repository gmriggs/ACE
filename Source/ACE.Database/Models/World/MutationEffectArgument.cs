using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class MutationEffectArgument
    {
        public uint Id { get; set; }
        public uint MutationEffectId { get; set; }
        public uint ArgType { get; set; }
        public uint? EffectType { get; set; }
        public double? DoubleVal { get; set; }
        public int? IntVal { get; set; }
        public int? StatType { get; set; }
        public int? StatIdx { get; set; }
        public float? MinVal { get; set; }
        public float? MaxVal { get; set; }

        public virtual MutationEffect MutationEffect { get; set; }
    }
}
