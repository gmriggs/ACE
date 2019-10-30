namespace ACE.Entity
{
    // what is a version row holder?
    // how does this relate to ArchiveVersionRow?
    public class VersionRowHolder
    {
        public ArchiveVersionRow Row;

        public VersionRowHolder()
        {

        }

        public VersionRowHolder(ArchiveVersionRow row)
        {
            Row = row;
        }
    }
}
