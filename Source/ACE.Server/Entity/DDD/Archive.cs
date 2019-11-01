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
        public InArchiveVersionStack VersionStack;

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
                if (Flags.HasFlag(ArchiveFlag.IsPacked))
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

        public byte[] GetSerializedBuffer()
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

        public uint? GetVersionByToken(uint tokVersion)
        {
            return VersionStack?.GetVersionByToken(tokVersion);
        }

        public ArchiveVersionRow.VersionEntry GetVersionRowByHandle(uint version)
        {
            // verify
            return VersionStack?.GetRowByHandle(version);
        }

        public void InitForPacking(ArchiveInitializer initializer, byte[] buffer)
        {
            ReleaseUserData();
            Buffer = buffer;
            Flags &= ~ArchiveFlag.NoVersion;
            Flags |= ArchiveFlag.IsPacked;
            CurrOffset = 0;
            Error = null;
            InitVersionStack();
            initializer.InitializeArchive(this);
        }

        public void InitForUnpacking(ArchiveInitializer initializer, byte[] buffer)
        {
            ReleaseUserData();
            Buffer = buffer;
            Flags &= ~(ArchiveFlag.NoVersion | ArchiveFlag.IsPacked);
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

            if (Flags.HasFlag(ArchiveFlag.IsPacked))   // buffer full?
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

        public bool PushVersionRow()
        {
            if (Flags.HasFlag(ArchiveFlag.NoVersion))
                return false;   // INVALID_VERSIONHANDLE_0

            if (VersionStack == null)
            {
                Flags |= ArchiveFlag.NoVersion;
                Error = new TResult(0x80004005);
                return false;   // INVALID_VERSIONHANDLE_0
            }

            VersionStack.PushVersionRow();
            return true;
        }

        public bool PushVersionRow(ArchiveVersionRow initialData)
        {
            if (Flags.HasFlag(ArchiveFlag.NoVersion))
                return false;   // INVALID_VERSIONHANDLE_0


            if (VersionStack == null)
            {
                Flags |= ArchiveFlag.NoVersion;
                Error = new TResult(0x80004005);
                return false;   // INVALID_VERSIONHANDLE_0
            }

            VersionStack.PushVersionRow(initialData);
            return true;
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

            if (VersionStack == null || !VersionStack.SetVersion(tokVersion, version))
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

                return archive.PushVersionRow(InitialData);
            }
        }

        // custom methods
        public bool IsPacked => (Flags & ArchiveFlag.IsPacked) != 0;

        public int? ReadInt32()
        {
            CheckAlignment(4);
            var data = GetBytes(4);
            if (data != null)
                return BitConverter.ToInt32(data, 0);
            else
                return null;
        }

        public uint? ReadUInt32()
        {
            CheckAlignment(4);
            var data = GetBytes(4);
            if (data != null)
                return BitConverter.ToUInt32(data, 0);
            else
                return null;
        }

        public ulong? ReadUInt64()
        {
            CheckAlignment(8);
            var data = GetBytes(8);
            if (data != null)
                return BitConverter.ToUInt64(data, 0);
            else
                return null;
        }

        public bool? ReadBool()
        {
            CheckAlignment(1);
            var data = GetBytes(1);
            if (data != null)
                return BitConverter.ToBoolean(data, 0);
            else
                return null;
        }

        public List<uint> ReadUInt32List()
        {
            var result = new List<uint>();

            var size = ReadUInt32();
            if (size == null)
                return result;

            for (var i = 0; i < size; i++)
            {
                var value = ReadUInt32();
                if (value != null)
                    result.Add(value.Value);
                else
                    break;
            }
            return result;
        }

        public byte[] ReadBytes(uint size)
        {
            return GetBytes(size);
        }

        public bool Write(int value)
        {
            CheckAlignment(4);
            var data = GetBytes(4);
            if (data == null)
                return false;
            data = BitConverter.GetBytes(value);
            return true;
        }

        public bool Write(uint value)
        {
            CheckAlignment(4);
            var data = GetBytes(4);
            if (data == null)
                return false;
            data = BitConverter.GetBytes(value);
            return true;
        }

        public bool Write(ulong value)
        {
            CheckAlignment(8);
            var data = GetBytes(8);
            if (data == null)
                return false;
            data = BitConverter.GetBytes(value);
            return true;
        }

        public bool Write(bool value)
        {
            CheckAlignment(1);
            var data = GetBytes(1);
            if (data == null)
                return false;
            data = BitConverter.GetBytes(value);
            return true;
        }

        public bool Write(byte[] data)
        {
            // todo
            Array.Copy(data, 0, Buffer, CurrOffset, data.Length);
            return true;
        }

        public bool Write(List<uint> data)
        {
            if (!Write(data.Count))
                return false;

            foreach (var val in data)
            {
                if (!Write(val))
                    return false;
            }
            return true;
        }
    }
}
