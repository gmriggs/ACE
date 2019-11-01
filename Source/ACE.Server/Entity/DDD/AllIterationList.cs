using System.Collections.Generic;

namespace ACE.Entity
{
    public class AllIterationList
    {
        public List<TaggedIterationList> Lists;

        public AllIterationList()
        {
            Lists = new List<TaggedIterationList>();
        }

        public AllIterationList(Archive archive)
        {
            Serialize(archive);
        }

        public void AddIterationList(ulong idDatFile)
        {
            Lists.Add(new TaggedIterationList(idDatFile));
        }

        public void Serialize(Archive archive)
        {
            if (archive.IsPacked)
                Pack(archive);
            else
                Unpack(archive);
        }

        public void Pack(Archive archive)
        {
            archive.Write(Lists.Count);

            foreach (var list in Lists)
                list.Pack(archive);
        }

        public void Unpack(Archive archive)
        {
            var size = archive.ReadInt32().Value;

            Lists = new List<TaggedIterationList>(size);

            for (var i = 0; i < size; i++)
                Lists.Add(new TaggedIterationList(archive));
        }

        public class TaggedIterationList
        {
            // align 8
            public ulong IDDatFile;
            public MostlyConsecutiveIntSet List;

            public TaggedIterationList()
            {
                List = new MostlyConsecutiveIntSet();
            }

            public TaggedIterationList(Archive archive)
            {
                Serialize(archive);
            }

            public TaggedIterationList(ulong idDatFile)
            {
                IDDatFile = idDatFile;
                List = new MostlyConsecutiveIntSet();
            }

            public void Serialize(Archive archive)
            {
                if (archive.IsPacked)
                    Pack(archive);
                else
                    Unpack(archive);
            }

            public void Pack(Archive archive)
            {
                archive.Write(IDDatFile);
                List.Pack(archive);
            }

            public void Unpack(Archive archive)
            {
                IDDatFile = archive.ReadUInt64().Value;

                List = new MostlyConsecutiveIntSet();
                List.Unpack(archive);
            }
        }
    }
}
