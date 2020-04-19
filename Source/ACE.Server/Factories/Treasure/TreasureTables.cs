using System;
using System.Collections.Generic;

using ACE.Common;
using ACE.Database;
using ACE.Database.Models.World;
using ACE.Entity.Enum;
using ACE.Server.Factories.Treasure.Struct;

namespace ACE.Server.Factories.Treasure
{
    public class TreasureTables
    {
        private static List<TreasureTable> deathTreasure;
        private static List<TreasureTable> treasureGroup;
        private static Dictionary<int, int> heritageSubtype;
        private static List<TreasureTable> heritageDist;
        private static List<TreasureTable> gemClass;
        private static Dictionary<int, int> gemClassValue;
        private static List<TreasureTable> gemWcid;
        private static List<TreasureTable> jewelryWcid;
        private static List<TreasureTable> artWcid;
        private static List<TreasureTable> manaStoneWcid;
        private static List<TreasureTable> consumableWcid;
        private static List<TreasureTable> healKitWcid;
        private static List<TreasureTable> lockpickWcid;
        private static List<TreasureTable> spellCompWcid;
        private static List<TreasureTable> scrollWcid;
        private static List<TreasureTable> spellLevel;
        private static Dictionary<int, List<int>> spellProgression;
        private static List<SpellDescriptor> spellDesc;
        private static List<TreasureTable> weaponDist;
        private static Dictionary<int, List<TreasureTable>> weaponAxeWcid;
        private static Dictionary<int, List<TreasureTable>> weaponBowWcid;
        private static Dictionary<int, List<TreasureTable>> weaponDaggerWcid;
        private static Dictionary<int, List<TreasureTable>> weaponMaceWcid;
        private static Dictionary<int, List<TreasureTable>> weaponSpearWcid;
        private static Dictionary<int, List<TreasureTable>> weaponStaffWcid;
        private static Dictionary<int, List<TreasureTable>> weaponSwordWcid;
        private static Dictionary<int, List<TreasureTable>> weaponUAWcid;
        private static List<TreasureTable> weaponCrossbowWcid;
        private static List<TreasureTable> weaponAtlatlWcid;
        private static List<TreasureTable> weaponTwoHandedWcid;
        private static List<TreasureTable> casterWcid;
        private static List<TreasureTable> armorDist;
        private static List<TreasureTable> leatherArmorWcid;
        private static List<TreasureTable> studdedLeatherArmorWcid;
        private static List<TreasureTable> chainmailArmorWcid;
        private static Dictionary<int, List<TreasureTable>> platemailArmorWcid;
        private static Dictionary<int, List<TreasureTable>> heritageLowArmorWcid;
        private static Dictionary<int, List<TreasureTable>> heritageHighArmorWcid;
        private static List<TreasureTable> covenantArmorWcid;
        private static Dictionary<int, List<TreasureTable>> clothingWcid;
        private static List<TreasureTable> qualityFilter;
        private static List<TreasureTable> workmanshipDist;
        private static Dictionary<int, List<TreasureTable>> materialCodeDist;
        private static List<TreasureTable> materialCeramic;
        private static List<TreasureTable> materialCloth;
        private static List<TreasureTable> materialGem;
        private static List<TreasureTable> materialLeather;
        private static List<TreasureTable> materialMetal;
        private static List<TreasureTable> materialStone;
        private static List<TreasureTable> materialWood;
        private static Dictionary<int, List<TreasureTable>> gemCodeDist;
        private static List<TreasureTable> gemMaterialChance;
        private static Dictionary<int, List<double>> qualityMod;
        private static List<TreasureTable> qualityLevel;
        private static Dictionary<int, List<TreasureTable>> materialColorCode;
        private static List<TreasureTable> clothingPalette;
        private static List<TreasureTable> leatherPalette;
        private static List<TreasureTable> metalPalette;
        private static List<TreasureTable> meleeWeaponItemSpell;
        private static List<TreasureTable> missileWeaponItemSpell;
        private static List<TreasureTable> casterItemSpell;
        private static List<TreasureTable> armorItemSpell;
        private static List<TreasureTable> spellCodeDist;
        private static List<TreasureTable> orbCastableSpell;
        private static List<TreasureTable> wandStaffCastableSpell;
        private static List<TreasureTable> armorClothingCantrip;
        private static List<TreasureTable> casterCantrip;
        private static List<TreasureTable> missileCantrip;
        private static List<TreasureTable> shieldCantrip;
        private static List<TreasureTable> meleeCantrip;
        private static List<TreasureTable> jewelryCantrip;
        private static Dictionary<int, List<int>> cantripProgression;
        private static Dictionary<int, int> materialValueMod;
        private static Dictionary<int, List<int>> scrollWcidProgression;

        public static bool LoadTables()
        {
            deathTreasure = TreasureDatabase.GetDeathTreasure();
            treasureGroup = TreasureDatabase.GetTreasureGroup();
            heritageSubtype = TreasureDatabase.GetHeritageSubtype();
            heritageDist = TreasureDatabase.GetHeritageDist();
            gemClass = TreasureDatabase.GetGemClass();
            gemClassValue = TreasureDatabase.GetGemClassValue();
            gemWcid = TreasureDatabase.GetGemWcid();
            jewelryWcid = TreasureDatabase.GetJewelryWcid();
            artWcid = TreasureDatabase.GetArtWcid();
            manaStoneWcid = TreasureDatabase.GetManaStoneWcid();
            consumableWcid = TreasureDatabase.GetConsumableWcid();
            healKitWcid = TreasureDatabase.GetHealKitWcid();
            lockpickWcid = TreasureDatabase.GetLockpickWcid();
            spellCompWcid = TreasureDatabase.GetSpellCompWcid();
            scrollWcid = TreasureDatabase.GetScrollWcid();
            spellLevel = TreasureDatabase.GetSpellLevel();
            spellProgression = TreasureDatabase.GetSpellProgression();
            spellDesc = TreasureDatabase.GetSpellDescriptor();
            weaponDist = TreasureDatabase.GetWeaponDist();
            weaponAxeWcid = TreasureDatabase.GetWeaponAxeWcid();
            weaponBowWcid = TreasureDatabase.GetWeaponBowWcid();
            weaponDaggerWcid = TreasureDatabase.GetWeaponDaggerWcid();
            weaponMaceWcid = TreasureDatabase.GetWeaponMaceWcid();
            weaponSpearWcid = TreasureDatabase.GetWeaponSpearWcid();
            weaponStaffWcid = TreasureDatabase.GetWeaponStaffWcid();
            weaponUAWcid = TreasureDatabase.GetWeaponUAWcid();
            weaponCrossbowWcid = TreasureDatabase.GetWeaponCrossbowWcid();
            weaponAtlatlWcid = TreasureDatabase.GetWeaponAtlatlWcid();
            weaponTwoHandedWcid = TreasureDatabase.GetTwoHandedWcid();
            casterWcid = TreasureDatabase.GetCasterWcid();
            armorDist = TreasureDatabase.GetArmorDist();
            leatherArmorWcid = TreasureDatabase.GetLeatherArmorWcid();
            studdedLeatherArmorWcid = TreasureDatabase.GetStuddedLeatherArmorWcid();
            chainmailArmorWcid = TreasureDatabase.GetChainmailArmorWcid();
            platemailArmorWcid = TreasureDatabase.GetPlatemailArmorWcid();
            heritageLowArmorWcid = TreasureDatabase.GetHeritageLowArmorWcid();
            heritageHighArmorWcid = TreasureDatabase.GetHeritageHighArmorWcid();
            covenantArmorWcid = TreasureDatabase.GetCovenantArmorWcid();
            clothingWcid = TreasureDatabase.GetClothingWcid();
            qualityFilter = TreasureDatabase.GetQualityFilter();
            workmanshipDist = TreasureDatabase.GetWorkmanshipDist();
            materialCodeDist = TreasureDatabase.GetMaterialCodeDist();
            materialCeramic = TreasureDatabase.GetMaterialCeramic();
            materialCloth = TreasureDatabase.GetMaterialCloth();
            materialGem = TreasureDatabase.GetMaterialGem();
            materialLeather = TreasureDatabase.GetMaterialLeather();
            materialMetal = TreasureDatabase.GetMaterialMetal();
            materialStone = TreasureDatabase.GetMaterialStone();
            materialWood = TreasureDatabase.GetMaterialWood();
            gemCodeDist = TreasureDatabase.GetGemCodeDist();
            gemMaterialChance = TreasureDatabase.GetGemMaterialChance();
            qualityMod = TreasureDatabase.GetQualityMod();
            qualityLevel = TreasureDatabase.GetQualityLevel();
            materialColorCode = TreasureDatabase.GetMaterialColorCode();
            clothingPalette = TreasureDatabase.GetClothingPalette();
            leatherPalette = TreasureDatabase.GetLeatherPalette();
            metalPalette = TreasureDatabase.GetMetalPalette();
            meleeWeaponItemSpell = TreasureDatabase.GetMeleeWeaponItemSpell();
            missileWeaponItemSpell = TreasureDatabase.GetMissileWeaponItemSpell();
            casterItemSpell = TreasureDatabase.GetCasterItemSpell();
            armorItemSpell = TreasureDatabase.GetArmorItemSpell();
            spellCodeDist = TreasureDatabase.GetSpellCodeDist();
            orbCastableSpell = TreasureDatabase.GetOrbCastableSpell();
            wandStaffCastableSpell = TreasureDatabase.GetWandStaffCastableSpell();
            armorClothingCantrip = TreasureDatabase.GetArmorClothingCantrip();
            casterCantrip = TreasureDatabase.GetCasterCantrip();
            missileCantrip = TreasureDatabase.GetMissileCantrip();
            shieldCantrip = TreasureDatabase.GetShieldCantrip();
            meleeCantrip = TreasureDatabase.GetMeleeCantrip();
            jewelryCantrip = TreasureDatabase.GetJewelryCantrip();
            cantripProgression = TreasureDatabase.GetCantripProgression();
            materialValueMod = TreasureDatabase.GetMaterialValueMod();
            scrollWcidProgression = TreasureDatabase.GetScrollWcidProgression();

            return false;
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

            foreach (var tt in table)
            {
                if (tt.Index == index)
                {
                    chanceTotal += tt.Chance;

                    if (reverse ? chanceTotal < luck : luck < chanceTotal)
                    {
                        retVal = tt.Lookup;
                        break;
                    }
                }
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

        public static bool GetMutationQualityFilter(uint mutateFilter, int statType, int idx)
        {
            // 1 = PropertyInt
            // 2 = PropertyFloat
            // 3 = PropertyDataId
            // 4 = PropertyString
            foreach (var filter in qualityFilter)
            {
                if (filter.Index == mutateFilter && filter.Lookup == statType && filter.Chance == idx)
                    return true;
            }
            return false;
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
