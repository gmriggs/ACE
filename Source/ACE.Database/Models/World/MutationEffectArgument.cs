using System;
using System.Collections.Generic;

namespace ACE.Database.Models.World
{
    public partial class MutationEffectArgument
    {
        public uint Id { get; set; }
        public int? EffectType { get; set; }
        public double? DoubleVal { get; set; }
        public int? IntVal { get; set; }
        public int? StatType { get; set; }
        public int? StatIdx { get; set; }
        public float? MinVal { get; set; }
        public float? MaxVal { get; set; }

        public virtual MutationEffect Id1 { get; set; }
        public virtual MutationEffect Id2 { get; set; }
        public virtual MutationEffect IdNavigation { get; set; }
    }
}
