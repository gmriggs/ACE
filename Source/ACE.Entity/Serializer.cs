using ACE.Entity.Enum;

namespace ACE.Entity
{
    public class Serializer
    {
        public static void SerializeObject(ref uint obj, Archive archive)
        {
            uint result = 0;

            // template class, ulong version
            archive.CheckAlignment(4);
            var bytes = archive.GetBytes(4);
            if (bytes != null)
            {
                if (archive.Flags.HasFlag(ArchiveFlag.IsPacked))
                    result = obj;   // ?
                else
                    obj = result;
            }
        }
    }
}
