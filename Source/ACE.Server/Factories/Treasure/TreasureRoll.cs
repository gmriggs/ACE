using ACE.Entity.Enum;

namespace ACE.Server.Factories.Treasure
{
    public class TreasureRoll
    {
        public uint MutateFilter;

        public uint WeenieClassId;
        public double LuckBonus;    // LootQualityMod from DeathTreasure
        public bool HasStandardMods;
        public bool HasMagic;
        public uint TSysMutationData;
        public int Tier;
        public TreasureItemClass TreasureItemClass;
        public MaterialType Material;
        public int GemCount;
        public MaterialType GemType;
        public int GemValue;
        public double BulkMod;
        public double SizeMod;
        public int CastableSpellLevel;
        public int SpellBookMaxLevel;
        public int QLWeaponOffense;
        public int QLWeaponDamageInt;
        public int QLWeaponDamageMod;
        public int QLWeaponDefense;
        public int QLWeaponSpeed;
        public int QLArmorLevel;
        public int QLShieldLevel;
        public int QLArmorEncumbrance;
        public int QLArmorVsFire;
        public int QLArmorVsCold;
        public int QLArmorVsAcid;
        public int QLArmorVsLightning;
        public double QualityModifier;
        public int Workmanship;
        public float WorkmanshipMod;
    }
}
