using System;
using System.Collections.Generic;

using ACE.Entity.Enum;

namespace ACE.Entity
{
    public class MostlyConsecutiveIntSet
    {
        // align 4
        public List<int> Ints;
        public bool Sorted;

        public MostlyConsecutiveIntSet()
        {
            Ints = new List<int>();
            Sorted = true;
        }

        public void Add(int newInt)
        {
            Ints.Add(newInt);
            Sorted = false;
        }

        public void Sort()
        {
            if (Sorted)
                return;

            // default comparator?
            Ints.Sort();

            Sorted = true;
        }

        public void Serialize(Archive archive)
        {
            var isPacked = archive.Flags.HasFlag(ArchiveFlag.IsPacked);
            if (isPacked)
            {
                Sort();
                archive.CheckAlignment(4);
                var bytes = archive.GetBytes(4);
                var size = Ints.Count;
                if (bytes != null)
                {
                    if (isPacked)
                        bytes = BitConverter.GetBytes(size);
                    else
                        size = BitConverter.ToInt32(bytes, 0);
                }
                if (size == 0)
                    return;

                int i = 0;
                int j = 0;

                while (true)
                {
                    j = i;
                    if (i < size)
                    {
                        // navigate to the first gap, if any..
                        var curInt = Ints[i];
                        var consecutive = curInt;
                        do
                        {
                            if (consecutive != curInt)
                                break;
                            ++j;
                            ++consecutive;
                            curInt = Ints[j];
                        }
                        while (j < size);
                    }

                    var negFirstConsecutiveSpan = i - j;

                    if (negFirstConsecutiveSpan >= -2)
                    {
                        var prevInt = Ints[i++];
                        var masked = prevInt & 0x7FFFFFFF;

                        archive.CheckAlignment(4);

                        var nextBytes = archive.GetBytes(4);
                        if (nextBytes != null && isPacked)
                            nextBytes = BitConverter.GetBytes(masked);
                    }
                    else
                    {
                        archive.CheckAlignment(4);

                        var nextBytes = archive.GetBytes(4);
                        if (nextBytes != null)
                        {
                            if (isPacked)
                                nextBytes = BitConverter.GetBytes(negFirstConsecutiveSpan);
                            else
                                negFirstConsecutiveSpan = BitConverter.ToInt32(nextBytes, 0);
                        }

                        var aCurInt = Ints[i];
                        archive.CheckAlignment(4);
                        var lastBytes = archive.GetBytes(4);
                        if (lastBytes != null)
                        {
                            if (isPacked)
                            {
                                lastBytes = BitConverter.GetBytes(aCurInt);
                                i -= negFirstConsecutiveSpan;
                                // size
                                // goto LABEL_26
                            }
                            aCurInt = BitConverter.ToInt32(lastBytes, 0);
                        }
                        // size
                        i -= negFirstConsecutiveSpan;
                    }
                    // LABEL_26:
                    if (i >= size)
                        return;
                }
            }
            if (isPacked)
                return;

            var k = 0;
            var l = 0;
            var finalBytesVal = 0;

            archive.CheckAlignment(4);
            var finalBytes = archive.GetBytes(4);
            if (finalBytes != null)
            {
                if (isPacked)
                    finalBytes = BitConverter.GetBytes(0);
                else
                {
                    finalBytesVal = BitConverter.ToInt32(finalBytes, 0);

                    if (finalBytesVal > 100000)
                    {
                        // goto LABEL_55
                    }
                    k = finalBytesVal;
                }
            }
            // SmartArray::SetNElements(Ints, k, 1) -- truncate?
            Ints.RemoveRange(k - 1, Ints.Count - k);

            if (k == 0)
            {
                // LABEL_53:
                Sorted = true;
                return;
            }

            // flags?
            var prevBytes = new byte[4];
            Array.Copy(archive.Buffer, 0, prevBytes, 0, 4);

            var prevBytesVal = BitConverter.ToInt32(prevBytes, 0);
            var before = prevBytesVal;
            var lBytesVal = 0;
            var y = 0;

            while (true)
            {
                archive.CheckAlignment(4);
                var endBytes = archive.GetBytes(4);
                var endBytesVal = BitConverter.ToInt32(endBytes, 0);
                if (endBytesVal != 0)
                {
                    if (isPacked)
                        endBytes = prevBytes;
                    else
                        prevBytes = endBytes;

                    if ((prevBytesVal & 0x40000000) != 0)
                        prevBytesVal |= -2147483648;

                    Ints[l++] = (int)prevBytesVal;
                    // goto LABEL_52
                }

                prevBytesVal = -prevBytesVal;

                archive.CheckAlignment(4);

                var lBytes = archive.GetBytes(4);
                lBytesVal = BitConverter.ToInt32(lBytes, 0);

                if (lBytes != null)
                {
                    if (isPacked)
                        lBytes = BitConverter.GetBytes(before);
                    else
                        before = lBytesVal;
                }

                if (prevBytesVal > 0)
                    break;

                // LABEL_52:
                if (l >= finalBytesVal)
                {
                    // goto LABEL_53
                }
            }

            while (l < finalBytesVal)
            {
                Ints[l++] = lBytesVal;
                lBytesVal++;    // increment into archive buffer
                if (++y >= prevBytesVal)
                {
                    // goto LABEL_52
                }
            }
            // LABEL_55:
            archive.RaiseError();
        }
    }
}
