using System;

namespace ACE.Entity.Enum
{
    [Flags]
    public enum LongDescDecoration
    {
        Undef              = 0x0,
        PrependWorkmanship = 0x1,
        PrependMaterial    = 0x2,
        AppendGemInfo      = 0x4,
    }
}
