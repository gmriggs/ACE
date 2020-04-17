using System;
using System.Collections.Generic;

using ACE.Common;
using ACE.Database;
using ACE.Database.Models.World;
using ACE.Server.Factories.Treasure.Struct;

namespace ACE.Server.Factories.Treasure
{
    public class TreasureTables
    {
        private static List<TreasureChance> deathTreasure;
        private static List<TreasureChance> treasureGroup;
        private static List<TreasureChance> heritageSubtype;
        private static List<TreasureChance> heritageDist;
        private static List<TreasureChance> gemClass;
        private static List<int> gemClassValue;
        private static List<TreasureChance> gemWcid;
        private static List<TreasureChance> jewelryWcid;
        private static List<TreasureChance> artWcid;
        private static List<TreasureChance> manaStoneWcid;
        private static List<TreasureChance> consumableWcid;
        private static List<TreasureChance> healKitWcid;
        private static List<TreasureChance> lockpickWcid;
        private static List<TreasureChance> spellCompWcid;
        private static List<TreasureChance> scrollWcid;
        private static List<TreasureChance> spellLevel;
        private static List<TreasureProgression> spellProgression;
        private static List<SpellDesc> spellDesc;
        private static List<TreasureChance> weaponDist;
        private static List<TreasureChanceHeritage> weaponAxeWcid;
        private static List<TreasureChanceHeritage> weaponBowWcid;
        private static List<TreasureChanceHeritage> weaponDaggerWcid;
        private static List<TreasureChanceHeritage> weaponMaceWcid;
        private static List<TreasureChanceHeritage> weaponSpearWcid;
        private static List<TreasureChanceHeritage> weaponStaffWcid;
        private static List<TreasureChanceHeritage> weaponSwordWcid;
        private static List<TreasureChanceHeritage> weaponUAWcid;
        private static List<TreasureChanceHeritage> weaponCrossbowWcid;
        private static List<TreasureChanceHeritage> weaponAtlatlWcid;
        private static List<TreasureChanceHeritage> weaponTwoHandedWcid;
        private static List<TreasureChance> casterWcid;
        private static List<TreasureChance> armorDist;
        private static List<TreasureChance> leatherArmorWcid;
        private static List<TreasureChance> studdedLeatherArmorWcid;
        private static List<TreasureChance> chainmailArmorWcid;
        private static List<TreasureChanceHeritage> platemailArmorWcid;
        private static List<TreasureChanceHeritage> heritageLowArmorWcid;
        private static List<TreasureChanceHeritage> heritageHighArmorWcid;
        private static List<TreasureChance> covenantArmorWcid;
        private static List<TreasureChanceHeritage> clothingWcid;
        private static List<TreasureChance> qualityFilter;
        private static List<TreasureChance> workmanshipDist;
        private static List<TreasureChanceHeritage> materialCodeDist;
        private static List<TreasureChance> materialCeramic;
        private static List<TreasureChance> materialCloth;
        private static List<TreasureChance> materialGem;
        private static List<TreasureChance> materialLeather;
        private static List<TreasureChance> materialMetal;
        private static List<TreasureChance> materialStone;
        private static List<TreasureChance> materialWood;
        private static List<TreasureChanceHeritage> gemCodeDist;
        private static List<TreasureChance> gemMaterialChance;
        private static List<QualityMod> qualityMod;
        private static List<TreasureChance> qualityLevel;
        private static List<TreasureChanceHeritage> materialColorCode;
        private static List<TreasureChance> materialColorByCode;
        private static List<TreasureChance> clothingPalette;
        private static List<TreasureChance> bootPalette;
        private static List<TreasureChance> metalPalette;
        private static List<TreasureChance> meleeWeaponItemSpell;
        private static List<TreasureChance> missileWeaponItemSpell;
        private static List<TreasureChance> casterItemSpell;
        private static List<TreasureChance> armorItemSpell;
        private static List<TreasureChance> spellCodeDist;
        private static List<TreasureChance> orbCastableSpell;
        private static List<TreasureChance> wandStaffCastableSpell;
        private static List<TreasureChance> armorClothingCantrip;
        private static List<TreasureChance> casterCantrip;
        private static List<TreasureChance> missileCantrip;
        private static List<TreasureChance> shieldCantrip;
        private static List<TreasureChance> meleeCantrip;
        private static List<TreasureChance> jewelryCantrip;
        private static List<TreasureProgression> cantripProgression;
        private static List<double> materialValueMod;
        private static List<TreasureProgression> scrollWcidProgression;

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
            bootPalette = TreasureDatabase.GetBootPalette();
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


        public static int GetChance(List<TreasureChance> table, int index, double qualityMod = 0.0, bool reverse = false)
        {
            int retVal = 0;
            var luck = ThreadSafeRandom.Next(0.0f, 1.0f) + qualityMod;
            luck = Math.Clamp(luck, 0.0, 1.0);

            var chanceTotal = 0.0f;

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
            return GetChance(weaponAxeWcid[heritage].Chances, tier);
        }

        public static int GetBowWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponBowWcid[heritage].Chances, tier);
        }

        public static int GetDaggerWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponDaggerWcid[heritage].Chances, tier);
        }

        public static int GetMaceWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponMaceWcid[heritage].Chances, tier);
        }

        public static int GetSpearWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponSpearWcid[heritage].Chances, tier);
        }

        public static int GetStaffWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponStaffWcid[heritage].Chances, tier);
        }

        public static int GetSwordWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponSwordWcid[heritage].Chances, tier);
        }

        public static int GetUnarmedWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponUAWcid[heritage].Chances, tier);
        }

        public static int GetCrossbowWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponCrossbowWcid[heritage].Chances, tier);
        }

        public static int GetAtlatlWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponAtlatlWcid[heritage].Chances, tier);
        }

        public static int GetTwoHandedWcid(int tier, int heritage, double qualityMod)
        {
            return GetChance(weaponTwoHandedWcid[heritage].Chances, tier);
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
            return GetChance(platemailArmorWcid[heritage].Chances, tier);
        }

        public static int GetHeritageLowArmorWcid(int tier, int heritage)
        {
            return GetChance(heritageLowArmorWcid[heritage].Chances, tier);
        }

        public static int GetHeritageHighArmorWcid(int tier, int heritage)
        {
            return GetChance(heritageHighArmorWcid[heritage].Chances, tier);
        }

        public static int GetClothingWcid(int tier, int heritage)
        {
            return GetChance(clothingWcid[heritage].Chances, tier);
        }

        public static bool GetMutationQualityFilter(int mutateFilter, int statType, int idx)
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

        public static int GetMaterialDist(int group, int tier, int qualityMod)
        {
            return GetChance(materialCodeDist[group].Chances, tier);
        }

        public static int GetCeramicMaterial(int tier, double qualityMod)
        {
            return GetChance(materialCeramic, tier, qualityMod);
        }

        public static int GetClothMaterial(int tier, double qualityMod)
        {
            return GetChance(materialCloth, tier, qualityMod);
        }

        public static int GetGemMaterial(int tier, double qualityMod)
        {
            return GetChance(materialGem, tier, qualityMod);
        }

        public static int GetLeatherMaterial(int tier, double qualityMod)
        {
            return GetChance(materialLeather, tier, qualityMod);
        }

        public static int GetMetalMaterial(int tier, double qualityMod)
        {
            return GetChance(materialMetal, tier, qualityMod);
        }

        public static int GetStoneMaterial(int tier, double qualityMod)
        {
            return GetChance(materialStone, tier, qualityMod);
        }

        public static int GetWoodMaterial(int tier, double qualityMod)
        {
            return GetChance(materialWood, tier, qualityMod);
        }

        public static int GetGemDist(int group, int tier, double qualityMod)
        {
            return GetChance(gemCodeDist[group].Chances, tier);
        }

        public static int GetGemMaterialByClass(int index)
        {
            return GetChance(gemMaterialChance, index);
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
            return qualityMod[modifier].Modifiers[tier - 1];
        }

        public static int GetQualityLevel(int tier, double qualityMod)
        {
            return GetChance(qualityLevel, tier, qualityMod);
        }

        public static int GetPalette(int material, int group)
        {
            return GetChance(materialColorCode[material].Chances, group);
        }

        public static int GetClothColor()
        {
            return GetChance(clothingPalette, 1);
        }

        public static int GetBootColor()
        {
            return GetChance(bootPalette, 2);
        }

        public static int GetMetalColor()
        {
            return GetChance(metalPalette, 3);
        }

        public static List<int> GetChanceList(List<TreasureChance> chances, int tier, double qualityMod)
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

        public static int GetProgression(List<TreasureProgression> progression, int item, int level)
        {
            int retval = item;
            foreach (var tt in progression)
            {
                if (tt.First == item)
                {
                    retval = tt.Second[level - 1];
                    break;
                }
            }
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

        public static double GetMaterialValueByMod(int material)
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
