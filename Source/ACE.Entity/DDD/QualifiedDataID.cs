namespace ACE.Entity
{
    public class QualifiedDataID
    {
        public uint Type;
        public uint ID;

        public QualifiedDataID()
        {

        }

        public QualifiedDataID(uint type, uint id)
        {
            Type = type;
            ID = id;
        }
    }
}
