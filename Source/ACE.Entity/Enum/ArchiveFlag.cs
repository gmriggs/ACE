using System;

namespace ACE.Entity.Enum
{
    [Flags]
    public enum ArchiveFlag: uint
    {
        Flag1 = 0x1,  // guessed
        WordAligned = 0x2,
        NoVersion = 0x4,
        Error = 0x8,
        Flag5 = 0x10,
        Flag6 = 0x20,
        Flag7 = 0x40,
        Flag8 = 0x80,
        Flag9 = 0x100,
        Flag10 = 0x200,
        Flag11 = 0x400,
        Flag12 = 0x800,
        Flag13 = 0x1000,
        Flag14 = 0x2000,
        Checkpointing = 0x4000,
        UsingDBLoader = 0x8000,
    }
}
