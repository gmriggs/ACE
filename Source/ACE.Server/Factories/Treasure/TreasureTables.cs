using System;
using System.Collections.Generic;
using System.Linq;

using ACE.Common;
using ACE.Database;
using ACE.Database.Models.World;
using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;
using ACE.Server.Factories.Treasure.Struct;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure
{
    public class TreasureTables
    {
        private static List<TreasureDeath> deathTreasure { get; set; }
        private static List<TreasureTable> treasureGroup { get; set; }
        private static Dictionary<int, int> heritageSubtype { get; set; }
        private static List<TreasureTable> heritageDist { get; set; }
        private static List<TreasureTable> gemClass { get; set; }
        private static Dictionary<int, int> gemClassValue { get; set; }
        private static List<TreasureTable> gemWcid { get; set; }
        private static List<TreasureTable> jewelryWcid { get; set; }
        private static List<TreasureTable> artWcid { get; set; }
        private static List<TreasureTable> manaStoneWcid { get; set; }
        private static List<TreasureTable> consumableWcid { get; set; }
        private static List<TreasureTable> healKitWcid { get; set; }
        private static List<TreasureTable> lockpickWcid { get; set; }
        private static List<TreasureTable> spellCompWcid { get; set; }
        private static List<TreasureTable> scrollWcid { get; set; }
        private static List<TreasureTable> spellLevel { get; set; }
        private static Dictionary<int, List<int>> spellProgression { get; set; }
        private static List<SpellDescriptor> spellDesc { get; set; }
        private static List<TreasureTable> weaponDist { get; set; }
        private static Dictionary<int, List<TreasureTable>> weaponAxeWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> weaponBowWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> weaponDaggerWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> weaponMaceWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> weaponSpearWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> weaponStaffWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> weaponSwordWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> weaponUAWcid { get; set; }
        private static List<TreasureTable> weaponCrossbowWcid { get; set; }
        private static List<TreasureTable> weaponAtlatlWcid { get; set; }
        private static List<TreasureTable> weaponTwoHandedWcid { get; set; }
        private static List<TreasureTable> casterWcid { get; set; }
        private static List<TreasureTable> armorDist { get; set; }
        private static List<TreasureTable> leatherArmorWcid { get; set; }
        private static List<TreasureTable> studdedLeatherArmorWcid { get; set; }
        private static List<TreasureTable> chainmailArmorWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> platemailArmorWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> heritageLowArmorWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> heritageHighArmorWcid { get; set; }
        private static List<TreasureTable> covenantArmorWcid { get; set; }
        private static Dictionary<int, List<TreasureTable>> clothingWcid { get; set; }
        private static Dictionary<uint, QualityFilter> mutationFilters { get; set; }
        private static List<TreasureTable> workmanshipDist { get; set; }
        private static Dictionary<int, List<TreasureTable>> materialCodeDist { get; set; }
        private static List<TreasureTable> materialCeramic { get; set; }
        private static List<TreasureTable> materialCloth { get; set; }
        private static List<TreasureTable> materialGem { get; set; }
        private static List<TreasureTable> materialLeather { get; set; }
        private static List<TreasureTable> materialMetal { get; set; }
        private static List<TreasureTable> materialStone { get; set; }
        private static List<TreasureTable> materialWood { get; set; }
        private static Dictionary<int, List<TreasureTable>> gemCodeDist { get; set; }
        private static List<TreasureTable> gemMaterialChance { get; set; }
        private static Dictionary<int, List<double>> qualityMod { get; set; }
        private static List<TreasureTable> qualityLevel { get; set; }
        private static Dictionary<int, List<TreasureTable>> materialColorCode { get; set; }
        private static List<TreasureTable> clothingPalette { get; set; }
        private static List<TreasureTable> leatherPalette { get; set; }
        private static List<TreasureTable> metalPalette { get; set; }
        private static List<TreasureTable> meleeWeaponItemSpell { get; set; }
        private static List<TreasureTable> missileWeaponItemSpell { get; set; }
        private static List<TreasureTable> casterItemSpell { get; set; }
        private static List<TreasureTable> armorItemSpell { get; set; }
        private static List<TreasureTable> spellCodeDist { get; set; }
        private static List<TreasureTable> orbCastableSpell { get; set; }
        private static List<TreasureTable> wandStaffCastableSpell { get; set; }
        private static List<TreasureTable> armorClothingCantrip { get; set; }
        private static List<TreasureTable> casterCantrip { get; set; }
        private static List<TreasureTable> missileCantrip { get; set; }
        private static List<TreasureTable> shieldCantrip { get; set; }
        private static List<TreasureTable> meleeCantrip { get; set; }
        private static List<TreasureTable> jewelryCantrip { get; set; }
        private static Dictionary<int, List<int>> cantripProgression { get; set; }
        private static Dictionary<int, int> materialValueMod { get; set; }
        private static Dictionary<int, List<int>> scrollWcidProgression { get; set; }

        public static bool LoadTables()
        {
            try
            {
                using (var ctx = new WorldDbContext())
                {
                    deathTreasure = TreasureDatabase.GetDeathTreasure(ctx);
                    treasureGroup = TreasureDatabase.GetTreasureGroup(ctx);
                    heritageSubtype = TreasureDatabase.GetHeritageSubtype(ctx);
                    heritageDist = TreasureDatabase.GetHeritageDist(ctx);
                    gemClass = TreasureDatabase.GetGemClass(ctx);
                    gemClassValue = TreasureDatabase.GetGemClassValue(ctx);
                    gemWcid = TreasureDatabase.GetGemWcid(ctx);
                    jewelryWcid = TreasureDatabase.GetJewelryWcid(ctx);
                    artWcid = TreasureDatabase.GetArtWcid(ctx);
                    manaStoneWcid = TreasureDatabase.GetManaStoneWcid(ctx);
                    consumableWcid = TreasureDatabase.GetConsumableWcid(ctx);
                    healKitWcid = TreasureDatabase.GetHealKitWcid(ctx);
                    lockpickWcid = TreasureDatabase.GetLockpickWcid(ctx);
                    spellCompWcid = TreasureDatabase.GetSpellCompWcid(ctx);
                    scrollWcid = TreasureDatabase.GetScrollWcid(ctx);
                    spellLevel = TreasureDatabase.GetSpellLevel(ctx);
                    spellProgression = TreasureDatabase.GetSpellProgression(ctx);
                    spellDesc = TreasureDatabase.GetSpellDescriptor(ctx);
                    weaponDist = TreasureDatabase.GetWeaponDist(ctx);
                    weaponAxeWcid = TreasureDatabase.GetWeaponAxeWcid(ctx);
                    weaponBowWcid = TreasureDatabase.GetWeaponBowWcid(ctx);
                    weaponDaggerWcid = TreasureDatabase.GetWeaponDaggerWcid(ctx);
                    weaponMaceWcid = TreasureDatabase.GetWeaponMaceWcid(ctx);
                    weaponSpearWcid = TreasureDatabase.GetWeaponSpearWcid(ctx);
                    weaponStaffWcid = TreasureDatabase.GetWeaponStaffWcid(ctx);
                    weaponUAWcid = TreasureDatabase.GetWeaponUAWcid(ctx);
                    weaponCrossbowWcid = TreasureDatabase.GetWeaponCrossbowWcid(ctx);
                    weaponAtlatlWcid = TreasureDatabase.GetWeaponAtlatlWcid(ctx);
                    weaponTwoHandedWcid = TreasureDatabase.GetTwoHandedWcid(ctx);
                    casterWcid = TreasureDatabase.GetCasterWcid(ctx);
                    armorDist = TreasureDatabase.GetArmorDist(ctx);
                    leatherArmorWcid = TreasureDatabase.GetLeatherArmorWcid(ctx);
                    studdedLeatherArmorWcid = TreasureDatabase.GetStuddedLeatherArmorWcid(ctx);
                    chainmailArmorWcid = TreasureDatabase.GetChainmailArmorWcid(ctx);
                    platemailArmorWcid = TreasureDatabase.GetPlatemailArmorWcid(ctx);
                    heritageLowArmorWcid = TreasureDatabase.GetHeritageLowArmorWcid(ctx);
                    heritageHighArmorWcid = TreasureDatabase.GetHeritageHighArmorWcid(ctx);
                    covenantArmorWcid = TreasureDatabase.GetCovenantArmorWcid(ctx);
                    clothingWcid = TreasureDatabase.GetClothingWcid(ctx);
                    mutationFilters = TreasureDatabase.GetQualityFilter(ctx);
                    workmanshipDist = TreasureDatabase.GetWorkmanshipDist(ctx);
                    materialCodeDist = TreasureDatabase.GetMaterialCodeDist(ctx);
                    materialCeramic = TreasureDatabase.GetMaterialCeramic(ctx);
                    materialCloth = TreasureDatabase.GetMaterialCloth(ctx);
                    materialGem = TreasureDatabase.GetMaterialGem(ctx);
                    materialLeather = TreasureDatabase.GetMaterialLeather(ctx);
                    materialMetal = TreasureDatabase.GetMaterialMetal(ctx);
                    materialStone = TreasureDatabase.GetMaterialStone(ctx);
                    materialWood = TreasureDatabase.GetMaterialWood(ctx);
                    gemCodeDist = TreasureDatabase.GetGemCodeDist(ctx);
                    gemMaterialChance = TreasureDatabase.GetGemMaterialChance(ctx);
                    qualityMod = TreasureDatabase.GetQualityMod(ctx);
                    qualityLevel = TreasureDatabase.GetQualityLevel(ctx);
                    materialColorCode = TreasureDatabase.GetMaterialColorCode(ctx);
                    clothingPalette = TreasureDatabase.GetClothingPalette(ctx);
                    leatherPalette = TreasureDatabase.GetLeatherPalette(ctx);
                    metalPalette = TreasureDatabase.GetMetalPalette(ctx);
                    meleeWeaponItemSpell = TreasureDatabase.GetMeleeWeaponItemSpell(ctx);
                    missileWeaponItemSpell = TreasureDatabase.GetMissileWeaponItemSpell(ctx);
                    casterItemSpell = TreasureDatabase.GetCasterItemSpell(ctx);
                    armorItemSpell = TreasureDatabase.GetArmorItemSpell(ctx);
                    spellCodeDist = TreasureDatabase.GetSpellCodeDist(ctx);
                    orbCastableSpell = TreasureDatabase.GetOrbCastableSpell(ctx);
                    wandStaffCastableSpell = TreasureDatabase.GetWandStaffCastableSpell(ctx);
                    armorClothingCantrip = TreasureDatabase.GetArmorClothingCantrip(ctx);
                    casterCantrip = TreasureDatabase.GetCasterCantrip(ctx);
                    missileCantrip = TreasureDatabase.GetMissileCantrip(ctx);
                    shieldCantrip = TreasureDatabase.GetShieldCantrip(ctx);
                    meleeCantrip = TreasureDatabase.GetMeleeCantrip(ctx);
                    jewelryCantrip = TreasureDatabase.GetJewelryCantrip(ctx);
                    cantripProgression = TreasureDatabase.GetCantripProgression(ctx);
                    materialValueMod = TreasureDatabase.GetMaterialValueMod(ctx);
                    scrollWcidProgression = TreasureDatabase.GetScrollWcidProgression(ctx);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            return true;
        }

        public static TreasureDeath GetDeathTreasureData(int deathTreasureValue)
        {
            return DatabaseManager.World.GetCachedDeathTreasure((uint)deathTreasureValue);
        }


        public static int GetChance(List<TreasureTable> table, int index, double qualityMod = 0.0, bool reverse = false)
        {
            int retVal = 0;
            var luck = ThreadSafeRandom.Next(0.0f, 1.0f) + qualityMod;
            luck = Math.Clamp(luck, 0.0, 1.0);

            var chanceTotal = 0.0;

            // TODO: this should be converted into a dictionary
            // this temporary structure is slightly slower, but makes for easier debugging
            var pretable = table.Where(i => i.Index == index).ToList();

            foreach (var tt in pretable)
            {
                //if (tt.Index == index)
                //{
                    chanceTotal += tt.Chance;

                    if (reverse ? chanceTotal < luck : luck < chanceTotal)
                    {
                        retVal = tt.Lookup;
                        break;
                    }
                //}
            }
            return retVal;
        }

        public static int GetTreasureType(int group)
        {
            return GetChance(treasureGroup, group);
        }

        public static int GetHeritage(int dist)
        {
            return GetChance(heritageDist, dist);
        }

        public static int GetGemWcid(int tier, double qualityMod)
        {
            int _gemClass = GetChance(gemClass, tier);

            int retVal = GetChance(gemWcid, _gemClass, 0, true);

            return retVal;
        }

        public static int GetJewelryWcid(int tier, double qualityMod)
        {
            return GetChance(jewelryWcid, tier);
        }

        public static int GetArtObjectWcid(int tier, double qualityMod)
        {
            return GetChance(artWcid, tier);
        }

        public static int GetManaStoneWcid(int tier, double qualityMod)
        {
            return GetChance(manaStoneWcid, tier);
        }

        public static int GetConsumableWcid(int tier, double qualityMod)
        {
            return GetChance(consumableWcid, tier);
        }

        public static int GetHealKitWcid(int tier, double qualityMod)
        {
            return GetChance(healKitWcid, tier);
        }

        public static int GetLockpickWcid(int tier, double qualityMod)
        {
            return GetChance(lockpickWcid, tier);
        }

        public static int GetSpellCompWcid(int tier, double qualityMod)
        {
            return GetChance(spellCompWcid, tier);
        }

        public static int GetScrollWcid(int tier, double qualityMod)
        {
            var retval = GetChance(scrollWcid, tier);

            // ??
            retval = GetChance(spellLevel, tier);

            return retval;
        }

        public static string GetSpellDescriptor(int spellId)
        {
            foreach (var desc in spellDesc)
            {
                if (desc.SpellId == spellId)
                {
                    if (desc.IsHidden)
                        break;

                    return desc.Descriptor;
                }
            }
            return string.Empty;
        }

        public static int GetWeaponWcid(int tier, int heritage, double qualityMod, ref TreasureItemClass treasureClass)
        {
            int weaponsubtype = GetChance(weaponDist, tier);

            switch (weaponsubtype)
            {
                case 22:
                    treasureClass = TreasureItemClass.SwordWeapon;
                    return GetSwordWcid(tier, heritage, qualityMod);

                case 23:
                    treasureClass = TreasureItemClass.MaceWeapon;
                    return GetMaceWcid(tier, heritage, qualityMod);

                case 24:
                    treasureClass = TreasureItemClass.AxeWeapon;
                    return GetAxeWcid(tier, heritage, qualityMod);

                case 25:
                    treasureClass = TreasureItemClass.SpearWeapon;
                    return GetSpearWcid(tier, heritage, qualityMod);

                case 26:
                    treasureClass = TreasureItemClass.UnarmedWeapon;
                    return GetUnarmedWcid(tier, heritage, qualityMod);

                case 27:
                    treasureClass = TreasureItemClass.StaffWeapon;
                    return GetStaffWcid(tier, heritage, qualityMod);

                case 28:
                    treasureClass = TreasureItemClass.DaggerWeapon;
                    return GetDaggerWcid(tier, heritage, qualityMod);

                case 29:
                    treasureClass = TreasureItemClass.BowWeapon;
                    return GetBowWcid(tier, heritage, qualityMod);

                case 30:
                    treasureClass = TreasureItemClass.CrossbowWeapon;
                    return GetCrossbowWcid(tier, heritage, qualityMod);

                case 31:
                    treasureClass = TreasureItemClass.AtlatlWeapon;
                    return GetAtlatlWcid(tier, heritage, qualityMod);

                case 32:
                    treasureClass = TreasureItemClass.TwoHandedWeapon;
                    return GetTwoHandedWcid(tier, heritage, qualityMod);

                case 9:
                    treasureClass = TreasureItemClass.Caster;
                    return GetCasterWcid(tier, qualityMod);
            }
            return 0;
        }

        public static int GetAxeWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponAxeWcid[heritage], tier);
        }

        public static int GetBowWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponBowWcid[heritage], tier);
        }

        public static int GetDaggerWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponDaggerWcid[heritage], tier);
        }

        public static int GetMaceWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponMaceWcid[heritage], tier);
        }

        public static int GetSpearWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponSpearWcid[heritage], tier);
        }

        public static int GetStaffWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponStaffWcid[heritage], tier);
        }

        public static int GetSwordWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponSwordWcid[heritage], tier);
        }

        public static int GetUnarmedWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponUAWcid[heritage], tier);
        }

        public static int GetCrossbowWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponCrossbowWcid, tier);
        }

        public static int GetAtlatlWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponAtlatlWcid, tier);
        }

        public static int GetTwoHandedWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponTwoHandedWcid, tier);
        }

        public static int GetCasterWcid(int tier, double qualityMod)
        {
            return GetChance(casterWcid, tier);
        }

        public static int GetArmorWcid(int tier, int heritage, double qualityMod, ref TreasureItemClass treasureClass)
        {
            int armorsubtype = GetChance(armorDist, tier);

            switch (armorsubtype)
            {
                case 15:
                    treasureClass = TreasureItemClass.LeatherArmor;
                    return GetLeatherArmorWcid(tier);

                case 16:
                    treasureClass = TreasureItemClass.StuddedLeatherArmor;
                    return GetStuddedLeatherArmorWcid(tier);

                case 17:
                    treasureClass = TreasureItemClass.ChainmailArmor;
                    return GetChainmailArmorWcid(tier);

                case 18:
                    treasureClass = TreasureItemClass.CovenantArmor;
                    return GetCovenantArmorWcid(tier, qualityMod);

                case 19:
                    treasureClass = TreasureItemClass.PlatemailArmor;
                    return GetPlatemailArmorWcid(tier, heritage);

                case 20:
                    treasureClass = TreasureItemClass.HeritageLowArmor;
                    return GetHeritageLowArmorWcid(tier, heritage);

                case 21:
                    treasureClass = TreasureItemClass.HeritageHighArmor;
                    return GetHeritageHighArmorWcid(tier, heritage);
            }
            return 0;
        }

        public static int GetLeatherArmorWcid(int tier)
        {
            return GetChance(leatherArmorWcid, tier);
        }

        public static int GetStuddedLeatherArmorWcid(int tier)
        {
            return GetChance(studdedLeatherArmorWcid, tier);
        }

        public static int GetChainmailArmorWcid(int tier)
        {
            return GetChance(chainmailArmorWcid, tier);
        }

        public static int GetCovenantArmorWcid(int tier, double qualityMod)
        {
            return GetChance(covenantArmorWcid, tier);
        }

        public static int GetPlatemailArmorWcid(int tier, int heritage)
        {
            return GetChance(platemailArmorWcid[heritage], tier);
        }

        public static int GetHeritageLowArmorWcid(int tier, int heritage)
        {
            return GetChance(heritageLowArmorWcid[heritage], tier);
        }

        public static int GetHeritageHighArmorWcid(int tier, int heritage)
        {
            return GetChance(heritageHighArmorWcid[heritage], tier);
        }

        public static int GetClothingWcid(int tier, int heritage)
        {
            return GetChance(clothingWcid[heritage], tier);
        }

        public static QualityFilter GetMutationFilters(uint mutateFilterDID)
        {
            if (mutationFilters.TryGetValue(mutateFilterDID, out var filterTable))
                return filterTable;
            else
                return null;
        }

        public static bool GetMutationFilter(uint mutateFilterDID, QualityFilterType propType, int idx)
        {
            if (!mutationFilters.TryGetValue(mutateFilterDID, out var filters))
                return false;

            if (!filters.Filters.TryGetValue(propType, out var propFilter))
                return false;

            return propFilter.Contains(idx);
        }

        public static bool GetMutationFilter(uint mutateFilterDID, PropertyInt prop)
        {
            return GetMutationFilter(mutateFilterDID, QualityFilterType.PropertyInt, (int)prop);
        }

        public static bool GetMutationFilter(uint mutateFilterDID, PropertyFloat prop)
        {
            return GetMutationFilter(mutateFilterDID, QualityFilterType.PropertyFloat, (int)prop);
        }

        public static bool GetMutationFilter(uint mutateFilterDID, PropertyDataId prop)
        {
            return GetMutationFilter(mutateFilterDID, QualityFilterType.PropertyDataId, (int)prop);
        }

        public static bool GetMutationFilter(uint mutateFilterDID, PropertyString prop)
        {
            return GetMutationFilter(mutateFilterDID, QualityFilterType.PropertyString, (int)prop);
        }

        public static int GetWorkmanship(int tier, double qualityMod)
        {
            return GetChance(workmanshipDist, tier, -qualityMod);
        }

        public static MaterialType GetMaterialDist(int group, int tier, int qualityMod)
        {
            return (MaterialType)GetChance(materialCodeDist[group], tier);
        }

        public static MaterialType GetCeramicMaterial(int tier, double qualityMod)
        {
            return (MaterialType)GetChance(materialCeramic, tier, qualityMod);
        }

        public static MaterialType GetClothMaterial(int tier, double qualityMod)
        {
            return (MaterialType)GetChance(materialCloth, tier, qualityMod);
        }

        public static MaterialType GetGemMaterial(int tier, double qualityMod)
        {
            return (MaterialType)GetChance(materialGem, tier, qualityMod);
        }

        public static MaterialType GetLeatherMaterial(int tier, double qualityMod)
        {
            return (MaterialType)GetChance(materialLeather, tier, qualityMod);
        }

        public static MaterialType GetMetalMaterial(int tier, double qualityMod)
        {
            return (MaterialType)GetChance(materialMetal, tier, qualityMod);
        }

        public static MaterialType GetStoneMaterial(int tier, double qualityMod)
        {
            return (MaterialType)GetChance(materialStone, tier, qualityMod);
        }

        public static MaterialType GetWoodMaterial(int tier, double qualityMod)
        {
            return (MaterialType)GetChance(materialWood, tier, qualityMod);
        }

        public static int GetGemDist(int group, int tier, double qualityMod)
        {
            return GetChance(gemCodeDist[group], tier);
        }

        public static MaterialType GetGemMaterialByClass(int index)
        {
            return (MaterialType)GetChance(gemMaterialChance, index);
        }

        public static int GetGemClass(int tier)
        {
            return GetChance(gemClass, tier);
        }

        public static int GetGemValue(int index)
        {
            return gemClassValue[index];
        }

        public static double GetQualityModChance(int modifier, int tier)
        {
            return qualityMod[modifier][tier - 1];
        }

        public static int GetQualityLevel(int tier, double qualityMod)
        {
            return GetChance(qualityLevel, tier, qualityMod);
        }

        public static int GetPalette(int material, int group)
        {
            return GetChance(materialColorCode[material], group);
        }

        public static int GetClothColor()
        {
            return GetChance(clothingPalette, 1);
        }

        public static int GetLeatherColor()
        {
            return GetChance(leatherPalette, 2);
        }

        public static int GetMetalColor()
        {
            return GetChance(metalPalette, 3);
        }

        public static List<int> GetChanceList(List<TreasureTable> chances, int tier, double qualityMod)
        {
            var retval = new List<int>();
            foreach (var chance in chances)
            {
                if (chance.Index == tier)
                {
                    var luck = ThreadSafeRandom.Next(0.0f, 1.0f) + qualityMod;
                    luck = Math.Clamp(luck, 0.0f, 1.0f);
                    if (luck < chance.Chance)
                    {
                        retval.Add(chance.Lookup);
                    }
                }
            }
            return retval;
        }

        public static List<int> GetMeleeWeaponItemSpells(int tier, double qualityMod)
        {
            return GetChanceList(meleeWeaponItemSpell, tier, -qualityMod);
        }

        public static List<int> GetMissileWeaponItemSpells(int tier, double qualityMod)
        {
            return GetChanceList(missileWeaponItemSpell, tier, -qualityMod);
        }

        public static List<int> GetCasterItemSpells(int tier, double qualityMod)
        {
            return GetChanceList(casterItemSpell, tier, -qualityMod);
        }

        public static List<int> GetArmorItemSpells(int tier, double qualityMod)
        {
            return GetChanceList(armorItemSpell, tier, -qualityMod);
        }

        public static int GetSpellLevel(int tier, double qualityMod)
        {
            return GetChance(spellLevel, tier, qualityMod);
        }

        public static int GetProgression(Dictionary<int, List<int>> progression, int item, int level)
        {
            int retval = item;

            if (progression.TryGetValue(item, out var tt))
                retval = tt[level - 1];

            return retval;
        }

        public static int GetFinalSpell(int spellId, int level)
        {
            return GetProgression(spellProgression, spellId, level);
        }

        public static int GetSpell(int group)
        {
            return GetChance(spellCodeDist, group);
        }

        public static int GetOrbSpell(int tier)
        {
            return GetChance(orbCastableSpell, tier);
        }

        public static int GetWandStaffSpell(int tier)
        {
            return GetChance(wandStaffCastableSpell, tier);
        }

        public static int GetArmorClothingCantrip(int tier)
        {
            return GetChance(armorClothingCantrip, tier);
        }

        public static int GetShieldCantrip(int tier)
        {
            return GetChance(shieldCantrip, tier);
        }

        public static int GetJewelryCantrip(int tier)
        {
            return GetChance(jewelryCantrip, tier);
        }

        public static int GetMissileCantrip(int tier)
        {
            return GetChance(missileCantrip, tier);
        }

        public static int GetMeleeCantrip(int tier)
        {
            return GetChance(meleeCantrip, tier);
        }

        public static int GetCasterCantrip(int tier)
        {
            return GetChance(casterCantrip, tier);
        }

        public static int GetFinalCantrip(int cantrip, int level)
        {
            return GetProgression(cantripProgression, cantrip, level);
        }

        public static double GetMaterialValueMod(int material)
        {
            return materialValueMod[material];
        }

        public static int GetScrollWcid(int tier, int level)
        {
            int scroll = GetChance(scrollWcid, tier);

            return GetProgression(scrollWcidProgression, scroll, level);
        }
    }
}
