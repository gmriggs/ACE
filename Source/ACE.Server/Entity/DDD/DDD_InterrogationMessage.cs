using System.Collections.Generic;

namespace ACE.Entity
{
    public class DDD_InterrogationMessage: FakeDataMessage
    {
        public uint ServersRegion;
        public uint NameRuleLanguage;
        public uint ProductID;
        public List<uint> SupportedLanguages;

        public DDD_InterrogationMessage()
        {
            SupportedLanguages = new List<uint>();
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
            archive.Write(ServersRegion);
            archive.Write(NameRuleLanguage);
            archive.Write(ProductID);
            archive.Write(SupportedLanguages);
        }

        public void Unpack(Archive archive)
        {
            Et = archive.ReadUInt32().Value;
            ServersRegion = archive.ReadUInt32().Value;
            NameRuleLanguage = archive.ReadUInt32().Value;
            ProductID = archive.ReadUInt32().Value;
            SupportedLanguages = archive.ReadUInt32List();
        }
    }
}
