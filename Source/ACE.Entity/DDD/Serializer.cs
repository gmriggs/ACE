using System;

namespace ACE.Entity
{
    public class Serializer
    {
        public static void SerializeObject(ref uint obj, Archive archive)
        {
            // template class, uint version
            archive.CheckAlignment(4);
            var bytes = archive.GetBytes(4);
            if (bytes != null)
            {
                if (archive.IsPacked)
                    bytes = BitConverter.GetBytes(obj);
                else
                    obj = BitConverter.ToUInt32(bytes, 0);
            }
        }

        public static void SerializeObject(ref bool obj, Archive archive)
        {
            archive.CheckAlignment(1);
            var bytes = archive.GetBytes(1);
            if (bytes != null)
            {
                if (archive.IsPacked)
                    bytes = BitConverter.GetBytes(obj);
                else
                    obj = BitConverter.ToBoolean(bytes, 0);
            }

            // set bl and zf to 0?
            // check some kind of overflow flags?
        }

        public static void SerializePrimitive(ref double obj, Archive archive)
        {
            archive.CheckAlignment(8);
            var bytes = archive.GetBytes(8);
            if (bytes != null)
            {
                if (archive.IsPacked)
                    bytes = BitConverter.GetBytes(obj);
                else
                    obj = BitConverter.ToDouble(bytes, 0);
            }
        }

        public static void SerializePrimitive(ref ulong obj, Archive archive)
        {
            archive.CheckAlignment(8);
            var bytes = archive.GetBytes(8);
            if (bytes != null)
            {
                if (archive.IsPacked)
                    bytes = BitConverter.GetBytes(obj);
                else
                    obj = BitConverter.ToUInt64(bytes, 0);
            }
        }
    }
}
