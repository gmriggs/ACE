using ACE.Server.WorldObjects;

namespace ACE.Server.Entity
{
    public class WindupParams
    {
        public uint TargetGuid;
        public uint SpellId;
        //public bool BuiltInSpell;
        public WorldObject CasterItem;
        public long TurnTries;

        public WindupParams(uint targetGuid, uint spellId, WorldObject casterItem)
        {
            TargetGuid = targetGuid;
            SpellId = spellId;
            //BuiltInSpell = builtInSpell;
            CasterItem = casterItem;
            TurnTries = 0;
        }

        public override string ToString()
        {
            return $"TargetGuid: {TargetGuid:X8}, SpellID: {SpellId}, CasterItem: {CasterItem?.Name}";
        }
    }
}
