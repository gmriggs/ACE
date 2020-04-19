using System.Collections.Generic;
using System.Linq;

using ACE.Database.Models.World;
using ACE.Entity.Enum;
using ACE.Server.Factories.Treasure.Struct;

namespace ACE.Server.Factories.Treasure
{
    public class TreasureDatabase
    {
        public static List<TreasureDeath> GetDeathTreasure(WorldDbContext ctx)
        {
            return ctx.TreasureDeath.ToList();
        }

        public static List<TreasureTable> GetTreasureGroup(WorldDbContext ctx)
        {
            return new List<TreasureTable>();
        }

        public static Dictionary<int, int> GetHeritageSubtype(WorldDbContext ctx)
        {
            return new Dictionary<int, int>();
        }

        public static List<TreasureTable> GetHeritageDist(WorldDbContext ctx)
        {
            return ctx.TreasureHeritage.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetGemClass(WorldDbContext ctx)
        {
            return ctx.TreasureGemClass.Select(i => new TreasureTable(i)).ToList();
        }

        public static Dictionary<int, int> GetGemValue(WorldDbContext ctx)
        {
            var gemValue = new Dictionary<int, int>();

            foreach (var result in ctx.TreasureGemValue)
            {
                gemValue.Add(result.Class, result.Value);
            }
            return gemValue;
        }

        public static List<TreasureTable> GetGemWcid(WorldDbContext ctx)
        {
            return ctx.TreasureGemMaterial.Select(i => new TreasureTable(i, true)).ToList();
        }

        public static List<TreasureTable> GetJewelryWcid(WorldDbContext ctx)
        {
            return ctx.TreasureJewelry.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetArtWcid(WorldDbContext ctx)
        {
            return ctx.TreasureArt.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetManaStoneWcid(WorldDbContext ctx)
        {
            return ctx.TreasureManaStone.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetConsumableWcid(WorldDbContext ctx)
        {
            return ctx.TreasureConsumable.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetHealKitWcid(WorldDbContext ctx)
        {
            return ctx.TreasureHealKit.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetLockpickWcid(WorldDbContext ctx)
        {
            return ctx.TreasureLockpick.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetSpellCompWcid(WorldDbContext ctx)
        {
            return new List<TreasureTable>();
        }

        public static List<TreasureTable> GetScrollWcid(WorldDbContext ctx)
        {
            return ctx.TreasureScroll.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetSpellLevel(WorldDbContext ctx)
        {
            return ctx.TreasureSpellLevel.Select(i => new TreasureTable(i)).ToList();
        }

        public static Dictionary<int, List<int>> GetSpellProgression(WorldDbContext ctx)
        {
            var spellProgression = new Dictionary<int, List<int>>();

            var results = ctx.TreasureSpellLevelProgression.ToList();

            // verify key
            foreach (var result in results)
                spellProgression.Add((int)result.Id, new List<int>() { result.Lvl1, result.Lvl2, result.Lvl3, result.Lvl4, result.Lvl5, result.Lvl6, result.Lvl7, result.Lvl8 });

            return spellProgression;
        }

        public static List<SpellDescriptor> GetSpellDescriptor(WorldDbContext ctx)
        {
            return new List<SpellDescriptor>();
        }

        public static List<TreasureTable> GetWeaponDist(WorldDbContext ctx)
        {
            return ctx.TreasureWeapon.Select(i => new TreasureTable(i)).ToList();
        }

        public static Dictionary<int, List<TreasureTable>> GetWeaponAxeWcid(WorldDbContext ctx)
        {
            var axes = new Dictionary<int, List<TreasureTable>>();

            axes[1] = ctx.TreasureWeaponAxe1.Select(i => new TreasureTable(i)).ToList();
            axes[2] = ctx.TreasureWeaponAxe2.Select(i => new TreasureTable(i)).ToList();
            axes[3] = ctx.TreasureWeaponAxe3.Select(i => new TreasureTable(i)).ToList();

            return axes;
        }

        public static Dictionary<int, List<TreasureTable>> GetWeaponBowWcid(WorldDbContext ctx)
        {
            var bows = new Dictionary<int, List<TreasureTable>>();

            bows[1] = ctx.TreasureWeaponBow1.Select(i => new TreasureTable(i)).ToList();
            bows[2] = ctx.TreasureWeaponBow2.Select(i => new TreasureTable(i)).ToList();
            bows[3] = ctx.TreasureWeaponBow3.Select(i => new TreasureTable(i)).ToList();

            return bows;
        }

        public static Dictionary<int, List<TreasureTable>> GetWeaponDaggerWcid(WorldDbContext ctx)
        {
            var daggers = new Dictionary<int, List<TreasureTable>>();

            daggers[1] = ctx.TreasureWeaponDagger1.Select(i => new TreasureTable(i)).ToList();
            daggers[2] = ctx.TreasureWeaponDagger2.Select(i => new TreasureTable(i)).ToList();
            daggers[3] = ctx.TreasureWeaponDagger3.Select(i => new TreasureTable(i)).ToList();

            return daggers;
        }

        public static Dictionary<int, List<TreasureTable>> GetWeaponMaceWcid(WorldDbContext ctx)
        {
            var maces = new Dictionary<int, List<TreasureTable>>();

            maces[1] = ctx.TreasureWeaponMace1.Select(i => new TreasureTable(i)).ToList();
            maces[2] = ctx.TreasureWeaponMace2.Select(i => new TreasureTable(i)).ToList();
            maces[3] = ctx.TreasureWeaponMace3.Select(i => new TreasureTable(i)).ToList();

            return maces;
        }

        public static Dictionary<int, List<TreasureTable>> GetWeaponSpearWcid(WorldDbContext ctx)
        {
            var spears = new Dictionary<int, List<TreasureTable>>();

            spears[1] = ctx.TreasureWeaponSpear1.Select(i => new TreasureTable(i)).ToList();
            spears[2] = ctx.TreasureWeaponSpear2.Select(i => new TreasureTable(i)).ToList();
            spears[3] = ctx.TreasureWeaponSpear3.Select(i => new TreasureTable(i)).ToList();

            return spears;
        }

        public static Dictionary<int, List<TreasureTable>> GetWeaponStaffWcid(WorldDbContext ctx)
        {
            var staves = new Dictionary<int, List<TreasureTable>>();

            staves[1] = ctx.TreasureWeaponStaff1.Select(i => new TreasureTable(i)).ToList();
            staves[2] = ctx.TreasureWeaponStaff2.Select(i => new TreasureTable(i)).ToList();
            staves[3] = ctx.TreasureWeaponStaff3.Select(i => new TreasureTable(i)).ToList();

            return staves;
        }

        public static Dictionary<int, List<TreasureTable>> GetWeaponSwordWcid(WorldDbContext ctx)
        {
            var swords = new Dictionary<int, List<TreasureTable>>();

            swords[1] = ctx.TreasureWeaponSword1.Select(i => new TreasureTable(i)).ToList();
            swords[2] = ctx.TreasureWeaponSword2.Select(i => new TreasureTable(i)).ToList();
            swords[3] = ctx.TreasureWeaponSword3.Select(i => new TreasureTable(i)).ToList();

            return swords;
        }

        public static Dictionary<int, List<TreasureTable>> GetWeaponUAWcid(WorldDbContext ctx)
        {
            var unarmed = new Dictionary<int, List<TreasureTable>>();

            unarmed[1] = ctx.TreasureWeaponUnarmed1.Select(i => new TreasureTable(i)).ToList();
            unarmed[2] = ctx.TreasureWeaponUnarmed2.Select(i => new TreasureTable(i)).ToList();
            unarmed[3] = ctx.TreasureWeaponUnarmed3.Select(i => new TreasureTable(i)).ToList();

            return unarmed;
        }

        public static List<TreasureTable> GetWeaponCrossbowWcid(WorldDbContext ctx)
        {
            return ctx.TreasureWeaponCrossbow.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetWeaponAtlatlWcid(WorldDbContext ctx)
        {
            return ctx.TreasureWeaponAtlatl.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetTwoHandedWcid(WorldDbContext ctx)
        {
            //return ctx.TreasureTwoHanded.Select(i => new TreasureTable(i)).ToList();
            return new List<TreasureTable>();
        }

        public static List<TreasureTable> GetCasterWcid(WorldDbContext ctx)
        {
            return ctx.TreasureCaster.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetArmorDist(WorldDbContext ctx)
        {
            return ctx.TreasureArmor.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetLeatherArmorWcid(WorldDbContext ctx)
        {
            return ctx.TreasureArmorLeather.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetStuddedLeatherArmorWcid(WorldDbContext ctx)
        {
            return ctx.TreasureArmorStuddedLeather.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetChainmailArmorWcid(WorldDbContext ctx)
        {
            return ctx.TreasureArmorChainmail.Select(i => new TreasureTable(i)).ToList();
        }

        public static Dictionary<int, List<TreasureTable>> GetPlatemailArmorWcid(WorldDbContext ctx)
        {
            var platemail = new Dictionary<int, List<TreasureTable>>();

            platemail[1] = ctx.TreasureArmorPlatemail1.Select(i => new TreasureTable(i)).ToList();
            platemail[2] = ctx.TreasureArmorPlatemail2.Select(i => new TreasureTable(i)).ToList();
            platemail[3] = ctx.TreasureArmorPlatemail3.Select(i => new TreasureTable(i)).ToList();

            return platemail;
        }

        public static Dictionary<int, List<TreasureTable>> GetHeritageLowArmorWcid(WorldDbContext ctx)
        {
            var heritageArmorLow = new Dictionary<int, List<TreasureTable>>();

            heritageArmorLow[1] = ctx.TreasureArmorHeritageLow1.Select(i => new TreasureTable(i)).ToList();
            heritageArmorLow[2] = ctx.TreasureArmorHeritageLow2.Select(i => new TreasureTable(i)).ToList();
            heritageArmorLow[3] = ctx.TreasureArmorHeritageLow3.Select(i => new TreasureTable(i)).ToList();

            return heritageArmorLow;
        }

        public static Dictionary<int, List<TreasureTable>> GetHeritageHighArmorWcid(WorldDbContext ctx)
        {
            var heritageArmorHigh = new Dictionary<int, List<TreasureTable>>();

            heritageArmorHigh[1] = ctx.TreasureArmorHeritageHigh1.Select(i => new TreasureTable(i)).ToList();
            heritageArmorHigh[2] = ctx.TreasureArmorHeritageHigh2.Select(i => new TreasureTable(i)).ToList();
            heritageArmorHigh[3] = ctx.TreasureArmorHeritageHigh3.Select(i => new TreasureTable(i)).ToList();

            return heritageArmorHigh;
        }

        public static List<TreasureTable> GetCovenantArmorWcid(WorldDbContext ctx)
        {
            return ctx.TreasureArmorCovenant.Select(i => new TreasureTable(i)).ToList();
        }

        public static Dictionary<int, List<TreasureTable>> GetClothingWcid(WorldDbContext ctx)
        {
            var clothing = new Dictionary<int, List<TreasureTable>>();

            clothing[1] = ctx.TreasureClothing1.Select(i => new TreasureTable(i)).ToList();
            clothing[2] = ctx.TreasureClothing2.Select(i => new TreasureTable(i)).ToList();
            clothing[3] = ctx.TreasureClothing3.Select(i => new TreasureTable(i)).ToList();

            return clothing;
        }

        public static Dictionary<uint, QualityFilter> GetQualityFilter(WorldDbContext ctx)
        {
            var qualityFilters = new Dictionary<uint, QualityFilter>();

            var results = ctx.TreasureMutateFilter.ToList();

            foreach (var result in results)
            {
                if (!qualityFilters.TryGetValue((uint)result.Id, out var qualityFilter))
                {
                    qualityFilter = new QualityFilter();
                    qualityFilters.Add((uint)result.Id, qualityFilter);
                }
                qualityFilter.Add((QualityFilterType)result.QualityType, result.QualityID);
            }
            return qualityFilters;
        }

        public static List<TreasureTable> GetWorkmanshipDist(WorldDbContext ctx)
        {
            return ctx.TreasureWorkmanshipDist.Select(i => new TreasureTable(i)).ToList();
        }

        public static Dictionary<int, List<TreasureTable>> GetMaterialCodeDist(WorldDbContext ctx)
        {
            var materialDist = new Dictionary<int, List<TreasureTable>>();

            var results = ctx.TreasureMaterialDist.ToList();

            foreach (var result in results)
            {
                if (!materialDist.TryGetValue(result.Group, out var group))
                {
                    group = new List<TreasureTable>();
                    materialDist.Add(result.Group, group);
                }
                group.Add(new TreasureTable(result));
            }
            return materialDist;
        }

        public static List<TreasureTable> GetMaterialCeramic(WorldDbContext ctx)
        {
            return ctx.TreasureMaterialCeramic.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMaterialCloth(WorldDbContext ctx)
        {
            return ctx.TreasureMaterialCloth.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMaterialGem(WorldDbContext ctx)
        {
            return ctx.TreasureMaterialGem.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMaterialLeather(WorldDbContext ctx)
        {
            return ctx.TreasureMaterialLeather.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMaterialMetal(WorldDbContext ctx)
        {
            return ctx.TreasureMaterialMetal.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMaterialStone(WorldDbContext ctx)
        {
            return ctx.TreasureMaterialStone.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMaterialWood(WorldDbContext ctx)
        {
            return ctx.TreasureMaterialWood.Select(i => new TreasureTable(i)).ToList();
        }

        public static Dictionary<int, List<TreasureTable>> GetGemCodeDist(WorldDbContext ctx)
        {
            var gemCodeDist = new Dictionary<int, List<TreasureTable>>();

            var results = ctx.TreasureGemDist.ToList();

            foreach (var result in results)
            {
                if (!gemCodeDist.TryGetValue(result.Group, out var group))
                {
                    group = new List<TreasureTable>();
                    gemCodeDist.Add(result.Group, group);
                }
                group.Add(new TreasureTable(result));
            }
            return gemCodeDist;
        }

        public static List<TreasureTable> GetGemMaterialChance(WorldDbContext ctx)
        {
            return ctx.TreasureGemMaterial.Select(i => new TreasureTable(i, false)).ToList();
        }

        public static Dictionary<int, List<double>> GetQualityMod(WorldDbContext ctx)
        {
            var qualityMod = new Dictionary<int, List<double>>();

            foreach (var result in ctx.TreasureQualityMod)
            {
                qualityMod.Add(result.QualityMod, new List<double>() { result._1, result._2, result._3, result._4, result._5, result._6, result._7, result._8 });
            }
            return qualityMod;
        }

        public static List<TreasureTable> GetQualityLevel(WorldDbContext ctx)
        {
            return ctx.TreasureQualityLevel.Select(i => new TreasureTable(i)).ToList();
        }

        public static Dictionary<int, List<TreasureTable>> GetMaterialColorCode(WorldDbContext ctx)
        {
            var materialColor = new Dictionary<int, List<TreasureTable>>();

            var results = ctx.TreasureMaterialColor.ToList();

            foreach (var result in results)
            {
                if (!materialColor.TryGetValue((int)result.MaterialId, out var group))
                {
                    group = new List<TreasureTable>();
                    materialColor.Add((int)result.MaterialId, group);
                }
                group.Add(new TreasureTable(result));
            }
            return materialColor;
        }


        public static Dictionary<int, List<TreasureTable>> GetMaterialColorDist(WorldDbContext ctx)
        {
            var materialColorDist = new Dictionary<int, List<TreasureTable>>();

            var results = ctx.TreasureMaterialColorDist.ToList();

            foreach (var result in results)
            {
                if (!materialColorDist.TryGetValue(result.Group, out var group))
                {
                    group = new List<TreasureTable>();
                    materialColorDist.Add(result.Group, group);
                }
                group.Add(new TreasureTable(result));
            }
            return materialColorDist;
        }

        public static List<TreasureTable> GetClothingPalette(WorldDbContext ctx)
        {
            return ctx.TreasureClothingPalette.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetLeatherPalette(WorldDbContext ctx)
        {
            return ctx.TreasureArmorLeatherPalette.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMetalPalette(WorldDbContext ctx)
        {
            return ctx.TreasureArmorMetalPalette.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMeleeWeaponItemSpell(WorldDbContext ctx)
        {
            return ctx.TreasureWeaponMeleeSpell.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMissileWeaponItemSpell(WorldDbContext ctx)
        {
            return ctx.TreasureWeaponMissileSpell.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetCasterItemSpell(WorldDbContext ctx)
        {
            return ctx.TreasureCasterSpell.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetArmorItemSpell(WorldDbContext ctx)
        {
            return ctx.TreasureItemBaneSpell.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetSpellCodeDist(WorldDbContext ctx)
        {
            return ctx.TreasureSpellDist.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetOrbCastableSpell(WorldDbContext ctx)
        {
            return ctx.TreasureCasterOrbSpell.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetWandStaffCastableSpell(WorldDbContext ctx)
        {
            return ctx.TreasureCasterWandStaffSpell.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetArmorClothingCantrip(WorldDbContext ctx)
        {
            return ctx.TreasureCantripArmorDist.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetCasterCantrip(WorldDbContext ctx)
        {
            return ctx.TreasureCantripCasterDist.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetMissileCantrip(WorldDbContext ctx)
        {
            return ctx.TreasureCantripMissileDist.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetShieldCantrip(WorldDbContext ctx)
        {
            return new List<TreasureTable>();
        }

        public static List<TreasureTable> GetMeleeCantrip(WorldDbContext ctx)
        {
            return ctx.TreasureCantripMeleeDist.Select(i => new TreasureTable(i)).ToList();
        }

        public static List<TreasureTable> GetJewelryCantrip(WorldDbContext ctx)
        {
            return new List<TreasureTable>();
        }

        public static Dictionary<int, List<int>> GetCantripProgression(WorldDbContext ctx)
        {
            var cantripProgression = new Dictionary<int, List<int>>();

            foreach (var result in ctx.TreasureCantripLevelProgression)
            {
                cantripProgression.Add((int)result.Id, new List<int>() { result.Minor, result.Major, result.Epic, result.Lego });
            }
            return cantripProgression;
        }

        public static Dictionary<MaterialType, double> GetMaterialValueMod(WorldDbContext ctx)
        {
            var materialValueMod = new Dictionary<MaterialType, double>();

            foreach (var kvp in LootTables.materialModifier)
                materialValueMod.Add((MaterialType)kvp.Key, kvp.Value);

            return materialValueMod;
        }

        public static Dictionary<int, List<int>> GetScrollWcidProgression(WorldDbContext ctx)
        {
            return new Dictionary<int, List<int>>();
        }
    }
}
