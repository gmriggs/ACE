namespace ACE.Entity
{
    public class DDD_InterrogationResponseMessage: FakeDataMessage
    {
        public uint ClientLanguage;
        public AllIterationList ItersWithKeys;
        public AllIterationList ItersWithoutKeys;
        public uint Flags;

        public void Serialize(Archive archive)
        {
            if (archive.IsPacked)
                Pack(archive);
            else
                Unpack(archive);
        }

        public void Pack(Archive archive)
        {
            archive.Write(Et);
            archive.Write(ClientLanguage);
            ItersWithKeys.Pack(archive);
            ItersWithoutKeys.Pack(archive);
            archive.Write(Flags);
        }

        public void Unpack(Archive archive)
        {
            ClientLanguage = archive.ReadUInt32().Value;
            ItersWithKeys = new AllIterationList(archive);
            ItersWithoutKeys = new AllIterationList(archive);
            Flags = archive.ReadUInt32().Value;

        }
    }
}
