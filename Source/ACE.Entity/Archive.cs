using System;
using System.Collections.Generic;
using ACE.Entity.Enum;

namespace ACE.Entity
{
    public class Archive
    {
        public ArchiveFlag Flags;
        public TResult Error;
        public byte[] Buffer;
        public uint CurrOffset;
        public Dictionary<ulong, byte[]> Data;
        public ArchiveVersionStack VersionStack;

        public void CheckAlignment(uint objSize)
        {
            if (!Flags.HasFlag(ArchiveFlag.WordAligned))
                return;

            var bytes = 0;

            if ((objSize & 3) != 0)
            {
                if ((objSize & 3) != 2)
                    return;
                bytes = 2;
            }
            else
                bytes = 4;

            // uses memory address in original version
            var offset = (int)CurrOffset % bytes;
            if (offset == 0)
                return;

            var nextAlign = (uint)(bytes - offset);
            if (PeekBytes(CurrOffset, nextAlign) != null)
            {
                CurrOffset += nextAlign;
                if (Flags.HasFlag(ArchiveFlag.Flag1))
                {
                    // memset(Buffer, 0, diff)
                    // no need to initialize memory in c# version
                }
            }
            else
            {
                Flags |= ArchiveFlag.Error;
                Error = new TResult(0x80004005);
            }
        }

        public InArchiveVersionStack CreateVersionStack()
        {
            return new InArchiveVersionStack();
        }

        public byte[] GetRemainingBuffer()
        {
            var sizeLeft = GetSizeLeft();
            var result = new byte[sizeLeft];

            Array.Copy(Buffer, CurrOffset, result, 0, sizeLeft);

            return result;
        }

        public byte[] GetSerialiedBuffer()
        {
            var result = new byte[CurrOffset];
            Array.Copy(Buffer, result, CurrOffset);

            return result;
        }

        public uint GetSizeLeft()
        {
            return (uint)Buffer.Length - CurrOffset;
        }

        public uint GetSizeUsed()
        {
            return CurrOffset;
        }

        public byte[] GetBytes(uint size)
        {
            var result = PeekBytes(CurrOffset, size);
            if (result != null)
                CurrOffset += size;
            return result;
        }

        public int GetVersionByToken()
        {
            if (VersionStack == null)
                return -1;

            // VersionStack->vfptr[1]
            return 1;
        }

        public ArchiveVersionRow GetVersionRowByHandle(uint version)
        {
            if (VersionStack == null)
                return null;

            // return VersionStack->vfptr[1].Release(version);
            return new ArchiveVersionRow();
        }

        public void InitForPacking(ArchiveInitializer initializer, byte[] buffer)
        {
            ReleaseUserData();
            Buffer = buffer;
            Flags &= ~ArchiveFlag.NoVersion;
            Flags |= ArchiveFlag.Flag1;
            CurrOffset = 0;
            Error = null;
            InitVersionStack();
            initializer.InitializeArchive(this);
        }

        public void InitForUnpacking(ArchiveInitializer initializer, byte[] buffer)
        {
            ReleaseUserData();
            Buffer = buffer;
            Flags &= ~(ArchiveFlag.NoVersion | ArchiveFlag.Flag1);
            CurrOffset = 0;
            Error = null;
            InitVersionStack();
            initializer.InitializeArchive(this);
        }

        public bool IsWordAligned()
        {
            return Flags.HasFlag(ArchiveFlag.WordAligned);
        }

        public byte[] PeekBytes(uint pos, uint size)
        {
            if (Flags.HasFlag(ArchiveFlag.NoVersion))
                return null;

            var endPos = pos + size;

            if (Flags.HasFlag(ArchiveFlag.Flag1))   // buffer full?
            {
                // if (SmartBuffer::CanGrow(buffer))
                var newBuffer = new byte[endPos];
                Array.Copy(Buffer, newBuffer, Buffer.Length);

                // should return pointer into new buffer at pos
                //return new byte[size];
                return Buffer;
            }
            else if (Buffer.Length > endPos)
            {
                // should return pointer into new buffer at pos
                //return new byte[size];
                return Buffer;
            }
            else
            {
                Flags |= ArchiveFlag.Error;
                Error = new TResult(0x80004005);

                return null;
            }
        }

        public string PushVersionRow()
        {
            if (Flags.HasFlag(ArchiveFlag.NoVersion))
                return "INVALID_VERSIONHANDLE_0";   // fix type

            if (VersionStack == null)
            {
                Flags |= ArchiveFlag.NoVersion;
                Error = new TResult(0x80004005);
                return "INVALID_VERSIONHANDLE_0";   // fix type
            }

            //return VersionStack->vfptr[1].QueryInterface()
            return "true";  // fix type
        }

        public string PushVersionRow(ArchiveVersionRow initialData)
        {
            if (Flags.HasFlag(ArchiveFlag.NoVersion))
                return "INVALID_VERSIONHANDLE_0";   // fix type

            if (VersionStack == null)
            {
                Flags |= ArchiveFlag.NoVersion;
                Error = new TResult(0x80004005);
                return "INVALID_VERSIONHANDLE_0";   // fix type
            }

            //return VersionStack->vfptr[1].IUnknown_Release(initialData);
            return "true";  // fix type
        }

        public void RaiseError()
        {
            Flags |= ArchiveFlag.Error;
            Error = new TResult(0x80004005);
        }

        public void ReleaseUserData()
        {
            Data.Clear();
        }

        public void SetCheckpointing(bool checkpointing)
        {
            if (checkpointing)
                Flags |= ArchiveFlag.Checkpointing;
            else
                Flags &= ~ArchiveFlag.Checkpointing;
        }

        public void SetCurrentPosition(uint pos)
        {
            CurrOffset = pos;
        }

        public void SetDBLoader(bool usingDBLoader)
        {
            if (usingDBLoader)
                Flags |= ArchiveFlag.UsingDBLoader;
            else
                Flags &= ~ArchiveFlag.UsingDBLoader;
        }

        public void SetWordAligned(bool wordAligned)
        {
            if (wordAligned)
                Flags |= ArchiveFlag.WordAligned;
            else
                Flags &= ArchiveFlag.WordAligned;
        }

        public bool SetVersionByToken(uint tokVersion, uint version)
        {
            if (Flags.HasFlag(ArchiveFlag.NoVersion))
                return false;

            if (VersionStack == null /*|| !VersionStack->vfrptr[1].IUnknown_AddRef(tokVersion, version)*/)
            {
                Flags |= ArchiveFlag.NoVersion;
                Error = new TResult(0x80004005);
                return false;
            }
            return true;
        }

        public bool UsingDBLoader()
        {
            return Flags.HasFlag(ArchiveFlag.UsingDBLoader);
        }

        public void InitVersionStack()
        {
            if (VersionStack == null)
                VersionStack = CreateVersionStack();
        }

        private class tagSetCurrentCoreVersion : ArchiveInitializer
        {
            public bool InitializeArchive(Archive archive)
            {
                if (archive.Flags.HasFlag(ArchiveFlag.NoVersion))
                    return false;

                archive.PushVersionRow();   // archive param?
                archive.SetVersionByToken(0x436F7265, 2);

                return true;
            }
        }

        public class SetVersionRow : ArchiveInitializer
        {
            public ArchiveVersionRow InitialData;

            public bool InitializeArchive(Archive archive)
            {
                if (archive.Flags.HasFlag(ArchiveFlag.NoVersion))
                    return false;

                var result = archive.PushVersionRow(InitialData);
                return result != "INVALID_VERSIONHANDLE_0";
            }
        }
    }
}
