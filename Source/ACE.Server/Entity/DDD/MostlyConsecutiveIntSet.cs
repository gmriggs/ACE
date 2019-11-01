using System;
using System.Collections.Generic;
using System.Linq;

using ACE.DatLoader.FileTypes;
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

        public MostlyConsecutiveIntSet(Archive archive)
        {
            Serialize(archive);
        }

        public MostlyConsecutiveIntSet(IterationList iterationList)
        {
            Unpack(iterationList);
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
            if (archive.Flags.HasFlag(ArchiveFlag.IsPacked))
                Pack(archive);
            else
                Unpack(archive);
        }

        public IterationList Pack()
        {
            var itList = new IterationList();

            Sort();

            var size = Ints.Count;
            itList.Iteration = size;

            var i = 0;
            var j = 0;

            // find gaps
            while (i < size)
            {
                j = i;
                var curInt = Ints[i];
                var consecutive = curInt;
                do
                {
                    if (consecutive != curInt)
                        break;
                    j++;
                    consecutive++;
                    if (j < size)
                        curInt = Ints[j];
                }
                while (j < size);

                var negConsecutiveSpan = i - j;

                if (negConsecutiveSpan >= -2)
                {
                    // does this keep adding to a list of gaps,
                    // ie. can this structure contain more than 3 elements?
                    var prevInt = Ints[i++];
                    var masked = prevInt & 0x7FFFFFFF;

                    itList.NegFirstGap = masked;
                }
                else
                {
                    itList.NegFirstGap = negConsecutiveSpan;

                    var aCurInt = Ints[i];
                    itList.FirstIteration = aCurInt;

                    // size
                    i -= negConsecutiveSpan;
                }
            }

            return itList;
        }

        public void Unpack(IterationList iterationList)
        {
            var iteration = iterationList.Iteration;
            if (iteration > 100000)     // client hardcoded limit?
                return;

            // original: set size, remove subset?
            Ints = Enumerable.Repeat(0, iteration).ToList();

            if (iteration == 0)
            {
                Sorted = true;
                return;
            }

            var negFirstGap = iterationList.NegFirstGap;
            var firstGap = -negFirstGap;

            var firstIteration = 0;

            if (negFirstGap >= 0)
            {
                // modify iteration?
            }
            else
            {
                firstIteration = iterationList.FirstIteration;

                if (firstGap <= 0 && iteration >= 0)
                {
                    Sorted = true;
                    return;
                }
            }

            var i = 0;
            var curIteration = firstIteration;

            while (i < iteration)
            {
                Ints[i++] = curIteration++;

                // check what this does here
                if (i >= firstGap && i >= iteration)
                {
                    Sorted = true;
                    return;
                }
            }
        }

        public void Pack(Archive archive)
        {
            Sort();
            archive.CheckAlignment(4);
            var bytes = archive.GetBytes(4);
            var size = Ints.Count;
            if (bytes != null)
                bytes = BitConverter.GetBytes(size);
            if (size == 0)
                return;

            int i = 0;
            int j = 0;

            while (i < size)
            {
                j = i;
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

                var negConsecutiveSpan = i - j;

                if (negConsecutiveSpan >= -2)
                {
                    var prevInt = Ints[i++];
                    var masked = prevInt & 0x7FFFFFFF;

                    archive.CheckAlignment(4);

                    var nextBytes = archive.GetBytes(4);
                    if (nextBytes != null)
                        nextBytes = BitConverter.GetBytes(masked);
                }
                else
                {
                    archive.CheckAlignment(4);

                    var nextBytes = archive.GetBytes(4);
                    if (nextBytes != null)
                        nextBytes = BitConverter.GetBytes(negConsecutiveSpan);

                    var aCurInt = Ints[i];
                    archive.CheckAlignment(4);
                    var lastBytes = archive.GetBytes(4);
                    if (lastBytes != null)
                    {
                        lastBytes = BitConverter.GetBytes(aCurInt);
                        i -= negConsecutiveSpan;
                        // size
                        continue;
                    }
                    // size
                    i -= negConsecutiveSpan;
                }
            }
        }

        public void Unpack(Archive archive)
        {
            var k = 0;
            var l = 0;
            var finalBytesVal = 0;

            archive.CheckAlignment(4);
            var finalBytes = archive.GetBytes(4);
            if (finalBytes != null)
            {
                finalBytesVal = BitConverter.ToInt32(finalBytes, 0);

                if (finalBytesVal > 100000)
                {
                    archive.RaiseError();
                    return;
                }
                k = finalBytesVal;
            }
            // SmartArray::SetNElements(Ints, k, 1) -- truncate?
            Ints.RemoveRange(k - 1, Ints.Count - k);

            if (k == 0)
            {
                Sorted = true;
                return;
            }

            // flags?
            var prevBytes = new byte[4];
            Array.Copy(archive.Buffer, 0, prevBytes, 0, 4);

            var prevBytesVal = BitConverter.ToInt32(prevBytes, 0);
            var before = prevBytesVal;
            var lBytesVal = 0;

            while (true)
            {
                archive.CheckAlignment(4);
                var endBytes = archive.GetBytes(4);
                var endBytesVal = BitConverter.ToInt32(endBytes, 0);
                if (endBytesVal >= 0)
                {
                    prevBytes = endBytes;

                    if ((prevBytesVal & 0x40000000) != 0)
                        prevBytesVal |= -2147483648;

                    Ints[l++] = (int)prevBytesVal;
                    if (l >= finalBytesVal)
                    {
                        Sorted = true;
                        return;
                    }
                }
                else
                {
                    prevBytesVal = -prevBytesVal;

                    archive.CheckAlignment(4);

                    var lBytes = archive.GetBytes(4);
                    lBytesVal = BitConverter.ToInt32(lBytes, 0);

                    if (lBytes != null)
                        before = lBytesVal;

                    if (prevBytesVal > 0)
                        break;

                    if (l >= finalBytesVal)
                    {
                        Sorted = true;
                        return;
                    }
                }
            }

            var y = 0;
            while (l < finalBytesVal)
            {
                Ints[l++] = lBytesVal;
                lBytesVal++;    // increment into archive buffer
                if (++y >= prevBytesVal && l > finalBytesVal)
                {
                    Sorted = true;
                    return;
                }
            }
            archive.RaiseError();
        }
    }
}
