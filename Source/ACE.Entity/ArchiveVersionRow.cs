using System;
using System.Collections.Generic;
using System.Linq;

using ACE.Entity.Enum;

namespace ACE.Entity
{
    public class ArchiveVersionRow
    {
        public List<VersionEntry> Versions;

        public ArchiveVersionRow()
        {
            Versions = new List<VersionEntry>();
        }

        public uint GetVersionByToken(uint tokVersion)
        {
            var existing = Versions.FirstOrDefault(i => i.TokVersion == tokVersion);

            if (existing != null)
                return existing.Version;
            else
                return 0;
        }

        public bool SetVersion(uint tokVersion, uint version)
        {
            var existing = Versions.FirstOrDefault(i => i.TokVersion == tokVersion);

            if (existing != null)
                return existing.Version == version;

            Versions.Add(new VersionEntry(tokVersion, version));

            return true;
        }

        public int SerializeHeader(Archive archive)
        {
            if (archive.Flags.HasFlag(ArchiveFlag.NoVersion))
                return -1;

            var size = archive.GetSizeUsed();

            var magic = 1298622819;
            archive.CheckAlignment(4);

            var bytes = archive.GetBytes(4);
            if (bytes != null)
            {
                if (archive.Flags.HasFlag(ArchiveFlag.IsPacked))
                    bytes = BitConverter.GetBytes(magic);
                else
                    magic = BitConverter.ToInt32(bytes, 0);
            }

            if (!archive.Flags.HasFlag(ArchiveFlag.IsPacked))
            {
                if (magic < 0)
                {
                    var newSize = archive.GetSizeUsed();
                    archive.SetCurrentPosition((uint)magic & 0x3FFFFFFF);
                    SerializeRow(archive);
                    archive.SetCurrentPosition(newSize);
                }
                else if (!SetVersion(0x436F7265, (uint)magic & 0x3FFFFFFF))
                    archive.RaiseError();
            }
            return (int)size;
        }

        public void SerializeRow(Archive archive)
        {
            var size = Versions.Count;
            archive.CheckAlignment(4);
            var bytes = archive.GetBytes(4);
            if (bytes != null)
            {
                if (archive.Flags.HasFlag(ArchiveFlag.IsPacked))
                    bytes = BitConverter.GetBytes(size);
                else
                    size = BitConverter.ToInt32(bytes, 0);
            }
            if (archive.Flags.HasFlag(ArchiveFlag.NoVersion))
                return;

            var versions = new List<VersionEntry>(Versions);

            if (!archive.Flags.HasFlag(ArchiveFlag.IsPacked))
            {
                // SetNElements(Versions, size, 1)
                // truncate to first version?
                versions.RemoveRange(1, versions.Count - 1);
            }

            // sends in reverse order?
            for (var i = versions.Count - 1; i >= 0; i--)
            {
                var version = versions[i];

                archive.CheckAlignment(8);

                var rowBytes = archive.GetBytes(8);

                if (rowBytes == null)
                    continue;

                // these AC serialize methods are weird --
                // not sure where the data is going, are they pulling pointers from archive,
                // and modifying the data in-place there?

                if (archive.Flags.HasFlag(ArchiveFlag.IsPacked))
                {
                    Array.Copy(BitConverter.GetBytes(version.TokVersion), rowBytes, 4);
                    Array.Copy(BitConverter.GetBytes(version.Version), 0, rowBytes, 4, 4);
                }
                else
                {
                    // modify originals?
                    version.TokVersion = BitConverter.ToUInt32(rowBytes, 0);
                    version.Version = BitConverter.ToUInt32(rowBytes, 4);
                }
            }
        }

        public bool SerializeFooter(int serialize, Archive archive)
        {
            if (archive.Flags.HasFlag(ArchiveFlag.NoVersion) || serialize == -1)
                return false;

            var bytes = archive.PeekBytes((uint)serialize, 4);

            var dword = BitConverter.ToUInt32(bytes, 0);

            if (!archive.Flags.HasFlag(ArchiveFlag.IsPacked))
            {
                if (dword >= 0)
                    return true;

                if (archive.GetSizeUsed() == (dword & 0x3FFFFFFF))
                {
                    // passing in a memory address?
                    uint result = 0;
                    Serializer.SerializeObject(ref result, archive);
                    archive.GetBytes(8 * result);
                    return true;
                }

                // checking changed memory from pointer?
                if (dword >= 0)
                    return true;

                archive.RaiseError();

                return true;
            }

            if (dword != 1298622819 || Versions.Count == 0 || Versions.Count == 1 && Versions[0].TokVersion != 1131377253)
            {
                archive.RaiseError();
                return !archive.Flags.HasFlag(ArchiveFlag.IsPacked);
            }

            if (Versions.Count == 1)
            {
                // write to memory
                dword = 224880995;
                dword = Versions[0].Version & 0x3FFFFFFF;   // ??
            }
            else
            {
                dword = 2372364643;
                dword ^= (archive.GetSizeUsed() ^ dword) & 0x3FFFFFFF;

            }
            return !archive.Flags.HasFlag(ArchiveFlag.IsPacked);
        }

        public class VersionEntry
        {
            public uint TokVersion;
            public uint Version;

            public VersionEntry(uint tokVersion, uint version)
            {
                TokVersion = tokVersion;
                Version = version;
            }
        }
    }
}
