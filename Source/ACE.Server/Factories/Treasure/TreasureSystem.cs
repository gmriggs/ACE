using System;
using System.Collections.Generic;
using System.Linq;

using log4net;

using ACE.Common;
using ACE.Database;
using ACE.Database.Models.World;
using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;
using ACE.Server.Factories.Treasure.Mutate;
using ACE.Entity.Models;
using ACE.Server.Managers;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure
{
    public class TreasureSystem
    {
        // port from moro's original system

        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static readonly int MaxEnchantments = 3;
        public static readonly int MaxCantrips = 5;

        public static TreasureDeath GetDeathTreasureInfo(int deathTreasureValue)
        {
            return TreasureTables.GetDeathTreasureData(deathTreasureValue);
        }

        public static void CalculateChances(DeathTreasureRoll roll)
        {
            var deathTreasure = roll.TreasureDeath;

            int luck = ThreadSafeRandom.Next(1, 100);

            if (luck <= deathTreasure.ItemChance)
            {
                roll.ItemCount = ThreadSafeRandom.Next(deathTreasure.ItemMinAmount, deathTreasure.ItemMaxAmount);
            }

            log.Info($"ItemChance: {deathTreasure.ItemChance}, ItemMinAmount: {deathTreasure.ItemMinAmount}, ItemMaxAmount: {deathTreasure.ItemMaxAmount}, Luck: {luck}, Count: {roll.ItemCount}");

            luck = ThreadSafeRandom.Next(1, 100);

            if (luck <= deathTreasure.MagicItemChance)
            {
                roll.MagicCount = ThreadSafeRandom.Next(deathTreasure.MagicItemMinAmount, deathTreasure.MagicItemMaxAmount);
            }

            log.Info($"MagicItemChance: {deathTreasure.MagicItemChance}, MagicItemMinAmount: {deathTreasure.MagicItemMinAmount}, MagicItemMaxAmount: {deathTreasure.MagicItemMaxAmount}, Luck: {luck}, Count: {roll.MagicCount}");

            luck = ThreadSafeRandom.Next(1, 100);

            if (luck <= deathTreasure.MundaneItemChance)
            {
                roll.MundaneCount = ThreadSafeRandom.Next(deathTreasure.MundaneItemMinAmount, deathTreasure.MundaneItemMaxAmount);
            }

            log.Info($"MundaneItemChance: {deathTreasure.MundaneItemChance}, MundaneItemMinAmount: {deathTreasure.MundaneItemMinAmount}, MundaneItemMaxAmount: {deathTreasure.MundaneItemMaxAmount}, Luck: {luck}, Count: {roll.MundaneCount}");
        }

        public static WorldObject RollLootItem(int group, int tier, int heritageDist, double qualityMod, out TreasureItemClass treasureClass)
        {
            int treasureTableType = TreasureTables.GetTreasureType(group);
            int heritage = TreasureTables.GetHeritage(heritageDist);
            WorldObject retval = null;
            int wcid = 0;

            treasureClass = TreasureItemClass.Undef;

            switch (treasureTableType)
            {
                case 1:
                    retval = WorldObjectFactory.CreateNewWorldObject(273);  // coinstack
                    retval.SetStackSize(tier * 100);    // TODO change value by tier to config
                    treasureClass = TreasureItemClass.Coins;
                    break;

                case 2:
                    wcid = TreasureTables.GetGemWcid(tier, qualityMod);
                    treasureClass = TreasureItemClass.Gem;
                    break;

                case 3:
                    wcid = TreasureTables.GetJewelryWcid(tier, qualityMod);
                    treasureClass = TreasureItemClass.Jewelry;
                    break;

                case 4:
                    wcid = TreasureTables.GetArtObjectWcid(tier, qualityMod);
                    treasureClass = TreasureItemClass.ArtObject;
                    break;

                case 5: // weapon
                    wcid = TreasureTables.GetWeaponWcid(tier, heritage, qualityMod, ref treasureClass);
                    break;

                case 6: // armor
                    wcid = TreasureTables.GetArmorWcid(tier, heritage, qualityMod, ref treasureClass);
                    break;

                case 7: // clothing
                    wcid = TreasureTables.GetClothingWcid(tier, heritage);
                    treasureClass = TreasureItemClass.Clothing;
                    break;

                case 8: // scroll
                    int spellLevel = TreasureTables.GetSpellLevel(tier, qualityMod);
                    wcid = TreasureTables.GetScrollWcid(tier, spellLevel);
                    treasureClass = TreasureItemClass.Scroll;
                    break;

                case 9: // caster (normally done in "weapon" above but allowing for custom tables)
                    wcid = TreasureTables.GetCasterWcid(tier, qualityMod);
                    treasureClass = TreasureItemClass.Caster;
                    break;

                case 10:
                    wcid = TreasureTables.GetManaStoneWcid(tier, qualityMod);
                    treasureClass = TreasureItemClass.ManaStone;
                    break;

                case 11:
                    wcid = TreasureTables.GetConsumableWcid(tier, qualityMod);
                    treasureClass = TreasureItemClass.FoodDrink;
                    break;

                case 12:
                    wcid = TreasureTables.GetHealKitWcid(tier, qualityMod);
                    treasureClass = TreasureItemClass.HealKit;
                    break;

                case 13:
                    wcid = TreasureTables.GetLockpickWcid(tier, qualityMod);
                    treasureClass = TreasureItemClass.Lockpick;
                    break;

                case 14:
                    wcid = TreasureTables.GetSpellCompWcid(tier, qualityMod);
                    treasureClass = TreasureItemClass.SpellComponent;
                    break;
            }

            if (wcid == 0)
            {
                log.Error($"No wcid found for treasureTableType: {treasureTableType}");
                return null;
            }

            retval = WorldObjectFactory.CreateNewWorldObject((uint)wcid);

            return retval;
        }

        public static List<WorldObject> GenerateTreasure(int death_treasure)
        {
            var retval = new List<WorldObject>();
            var roll = new DeathTreasureRoll();
            roll.TreasureDeath = GetDeathTreasureInfo(death_treasure);
            var treasureDeath = roll.TreasureDeath;
            CalculateChances(roll);

            for (int i = 0; i < roll.ItemCount; i++)
            {
                // roll item
                var item = RollLootItem(treasureDeath.ItemTreasureTypeSelectionChances, treasureDeath.Tier, treasureDeath.UnknownChances, treasureDeath.LootQualityMod, out var treasureClass);
                if (item != null)
                {
                    // mutate item
                    if (MutateItem(item, false, treasureDeath.Tier, treasureDeath.LootQualityMod, treasureClass))
                    {
                        var filterId = item.GetProperty(PropertyDataId.TsysMutationFilter) ?? 0;
                        var filter = DatabaseManager.World.GetCachedMutationFilter(filterId);
                        if (filter != null)
                        {
                            MutationFilter.TryMutate(filter, item, treasureDeath.Tier);
                        }
                        log.Info("Adding item");
                        retval.Add(item);
                    }
                }
            }

            for (int i = 0; i < roll.MagicCount; i++)
            {
                // roll magic item
                var item = RollLootItem(treasureDeath.MagicItemTreasureTypeSelectionChances, treasureDeath.Tier, treasureDeath.UnknownChances, treasureDeath.LootQualityMod, out var treasureClass);
                if (item != null)
                {
                    // mutate magic item
                    if (MutateItem(item, true, treasureDeath.Tier, treasureDeath.LootQualityMod, treasureClass))
                    {
                        var filterId = item.GetProperty(PropertyDataId.TsysMutationFilter) ?? 0;
                        var filter = DatabaseManager.World.GetCachedMutationFilter(filterId);
                        if (filter != null)
                        {
                            MutationFilter.TryMutate(filter, item, treasureDeath.Tier);
                        }
                        log.Info("Adding magic item");
                        retval.Add(item);
                    }
                }
            }

            for (int i = 0; i < roll.MundaneCount; i++)
            {
                // roll mundane item
                var item = RollLootItem(treasureDeath.MundaneItemTypeSelectionChances, treasureDeath.Tier, treasureDeath.UnknownChances, treasureDeath.LootQualityMod, out var treasureClass);
                if (item != null)
                {
                    // mutate mundane item?
                    log.Info("Adding mundane item");
                    retval.Add(item);
                }
            }

            return retval;
        }

        public static bool MutateItem(WorldObject item, bool isMagic, int tier, double qualityMod, TreasureItemClass treasureClass)
        {
            if (item.WeenieType == WeenieType.Scroll)
                return true;

            var roll = new TreasureRoll();
            roll.WeenieClassId = item.WeenieClassId;
            roll.HasMagic = isMagic;
            roll.HasStandardMods = true;
            roll.LuckBonus = qualityMod;
            roll.MutateFilter = 0;

            if (item.GetProperty(PropertyDataId.MutateFilter) == null)
            {
                log.Warn($"{item.Name} ({item.WeenieClassId}) missing PropertyDataId.MutateFilter");
                return false;
            }

            roll.Tier = tier;
            roll.TreasureItemClass = treasureClass;

            return MutateTreasure(item, roll);
        }

        public static bool MutateTreasure(WorldObject item, TreasureRoll roll)
        {
            var tSysMutationData = item.TsysMutationData ?? 0;

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 1, (int)PropertyInt.ItemWorkmanship))
            {
                if (!SelectWorkmanshipLevel(roll.WeenieClassId, roll.Tier, ref roll.Workmanship, ref roll.WorkmanshipMod, roll.LuckBonus))
                {
                    log.Error($"Unable to set Workmanship for {roll.WeenieClassId}");
                    return false;
                }
                item.ItemWorkmanship = roll.Workmanship;
            }

            if (roll.HasStandardMods)
            {
                if (roll.TreasureItemClass != TreasureItemClass.Gem)
                {
                    if (SelectMaterialType(roll))
                    {
                        item.MaterialType = roll.Material;
                    }

                    if (SelectGemCount(roll) && SelectGemType(roll))
                    {
                        item.GemCount = roll.GemCount;
                        item.GemType = roll.GemType;
                    }
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 2, (int)PropertyFloat.WeaponOffense))
            {
                if (!SetQualityLevel(ModQuality.Attack, roll, roll.LuckBonus, ref roll.QLWeaponOffense))
                {
                    log.Error($"Unable to set weapon attack quality. Defaulting to 0");
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 1, (int)PropertyInt.Damage))
            {
                if (!SetQualityLevel(ModQuality.DamageInt, roll, roll.LuckBonus, ref roll.QLWeaponDamageInt))
                {
                    log.Error($"Unable to set damage int quality. Defaulting to 0");
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 2, (int)PropertyFloat.WeaponDefense))
            {
                if (!SetQualityLevel(ModQuality.Defense, roll, roll.LuckBonus, ref roll.QLWeaponDefense))
                {
                    log.Error($"Unable to set weapon defense quality. Defaulting to 0");
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 1, (int)PropertyInt.ArmorLevel))
            {
                if (!SetQualityLevel(ModQuality.ArmorLevel, roll, roll.LuckBonus, ref roll.QLArmorLevel))
                {
                    log.Error($"Unable to set armor level quality. Defaulting to 0");
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 1, (int)PropertyInt.ShieldValue))
            {
                if (!SetQualityLevel(ModQuality.ArmorLevel, roll, roll.LuckBonus, ref roll.QLShieldLevel))
                {
                    log.Error($"Unable to set shield level quality. Defaulting to 0");
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 1, (int)PropertyInt.EncumbranceVal))
            {
                if (!SetQualityLevel(ModQuality.EncumbranceVal, roll, roll.LuckBonus, ref roll.QLArmorEncumbrance))
                {
                    log.Error($"Unable to set encumbrance quality. Defaulting to 0");
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 2, (int)PropertyFloat.ArmorModVsFire))
            {
                if (!SetQualityLevel(ModQuality.FireResistance, roll, roll.LuckBonus, ref roll.QLArmorVsFire))
                {
                    log.Error($"Unable to set armor mod vs fire quality. Defaulting to 0");
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 2, (int)PropertyFloat.ArmorModVsCold))
            {
                if (!SetQualityLevel(ModQuality.ColdResistance, roll, roll.LuckBonus, ref roll.QLArmorVsCold))
                {
                    log.Error($"Unable to set armor mod vs cold quality. Defaulting to 0");
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 2, (int)PropertyFloat.ArmorModVsAcid))
            {
                if (!SetQualityLevel(ModQuality.AcidResistance, roll, roll.LuckBonus, ref roll.QLArmorVsAcid))
                {
                    log.Error($"Unable to set armor mod vs acid quality. Defaulting to 0");
                }
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 2, (int)PropertyFloat.ArmorModVsElectric))
            {
                if (!SetQualityLevel(ModQuality.ElectricResistance, roll, roll.LuckBonus, ref roll.QLArmorVsLightning))
                {
                    log.Error($"Unable to set armor mod vs lightning quality. Defaulting to 0");
                }
            }

            if (!ApplyQualityEnhancements(item, roll))
            {
                log.Error($"Failed to apply quality enhancements. No changes made.");
                return false;
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 3, (int)PropertyDataId.Setup) && !Modify3DObject(item, roll))
            {
                log.Error($"Failed to update DID properties");
                return false;
            }

            if (roll.HasMagic && !AssignItemMagic(item, roll))
            {
                log.Error($"Failed to add magic. Aborting");
                return false;
            }

            if (TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 1, (int)PropertyInt.Value) && !SetNewItemValue(item, roll))
            {
                log.Error($"Failed to set item value. Aborting");
                return false;
            }

            if (!AdjustItemStrings(item, roll))
            {
                log.Error($"Failed to adjust item string");
                return false;
            }

            return true;
        }

        public static bool SelectWorkmanshipLevel(uint wcid, int tier, ref int workmanship, ref float wsMod, double qualityMod)
        {
            if (wcid == 2348)
                workmanship = 1;
            else
                workmanship = TreasureTables.GetWorkmanship(tier, qualityMod);

            if (workmanship == 0)
            {
                log.Error($"Unable to set workmanship on wcid {wcid}");
                return false;
            }

            wsMod = 1.0f + (workmanship / 9.0f);

            return true;
        }

        public static bool SelectMaterialType(TreasureRoll roll)
        {
            int materialIdx = GetMaterialCodeIndex((int)roll.TSysMutationData);

            if (materialIdx == 0)
            {
                log.Error($"No material found for {roll.TSysMutationData}");
                return false;
            }

            var baseMaterial = TreasureTables.GetMaterialDist(materialIdx, roll.Tier, 0);
            var material = MaterialType.Unknown;
            switch (baseMaterial)
            {
                case MaterialType.Ceramic:
                    material = TreasureTables.GetCeramicMaterial(roll.Tier, 0); break;
                case MaterialType.Cloth:
                    material = TreasureTables.GetClothMaterial(roll.Tier, 0); break;
                case MaterialType.Gem:
                    material = TreasureTables.GetGemMaterial(roll.Tier, 0); break;
                case MaterialType.Ivory:
                    material = baseMaterial; break;
                case MaterialType.Leather:
                    material = TreasureTables.GetLeatherMaterial(roll.Tier, 0); break;
                case MaterialType.Metal:
                    material = TreasureTables.GetMetalMaterial(roll.Tier, 0); break;
                case MaterialType.Stone:
                    material = TreasureTables.GetStoneMaterial(roll.Tier, 0); break;
                case MaterialType.Wood:
                    material = TreasureTables.GetWoodMaterial(roll.Tier, 0); break;
                default:
                    log.Error($"Invalid base material code: {baseMaterial}");
                    return false;
            }

            if (material == 0)
            {
                log.Error($"Invalid material: {baseMaterial}");
                return false;
            }

            roll.Material = material;
            return true;
        }

        public static bool SelectGemCount(TreasureRoll roll)
        {
            int gemIdx = GetGemCodeIndex((int)roll.TSysMutationData);
            if (gemIdx == 0)
            {
                log.Error($"No gem selection found");
                return false;
            }

            // Q: Should number of gems roll get death treasure luck mod?
            roll.GemCount = TreasureTables.GetGemDist(gemIdx, roll.Tier, 0);

            return true;
        }

        public static bool SelectGemType(TreasureRoll roll)
        {
            int gemClass = TreasureTables.GetGemClass(roll.Tier);
            if (gemClass == 0)
            {
                log.Error($"No gem class found");
                return false;
            }

            int gemValue = TreasureTables.GetGemValue(gemClass);
            if (gemValue == 0)
            {
                log.Error($"No gem value found");
                return false;
            }

            roll.GemValue = (int)Math.Ceiling(roll.GemCount * roll.WorkmanshipMod * roll.GemValue / 4.0f);

            var gemType = TreasureTables.GetGemMaterialByClass(gemClass);
            if (gemType == 0)
            {
                log.Error($"No gem found for class: {gemClass}");
                return false;
            }
            roll.GemType = gemType;

            return true;
        }

        public static bool SetQualityLevel(ModQuality quality, TreasureRoll roll, double modBonus, ref int qualityModifier)
        {
            double modChance = TreasureTables.GetQualityModChance((int)quality, roll.Tier);
            if (modChance == 0)
            {
                log.Error($"Unable to find ModQuality");
                return false;
            }

            double luck = ThreadSafeRandom.Next(0.0f, 1.0f) + modBonus;
            if (luck > 1.0f) luck = 1.0f;
            if (modChance >= luck)
            {
                qualityModifier = TreasureTables.GetQualityLevel(roll.Tier, modBonus);
            }
            return true;
        }

        public static bool ApplyQualityEnhancements(WorldObject item, TreasureRoll roll)
        {
            if (roll.QLWeaponOffense != 0)
            {
                item.WeaponOffense = (item.WeaponOffense ?? 0) + roll.QLWeaponOffense;
            }

            if (roll.QLWeaponDefense != 0)
            {
                item.WeaponDefense = (item.WeaponDefense ?? 0) + roll.QLWeaponDefense;
            }

            if (roll.QLWeaponDamageInt != 0)
            {
                if (item.Damage != null)
                {
                    item.Damage = GetDamageAddModifier(roll.QLWeaponDamageInt, item.Damage.Value);
                }
                else
                    log.Error($"Missing PropertyInt.Damage on weenie, no action taken.");
            }

            if (roll.QLWeaponDamageMod != 0)
            {
                double value = item.DamageMod ?? 1.0f;
                if (item.DamageMod == null)
                {
                    log.Warn($"No damage mod float found. Using 1.0 base");
                }
                value *= GetDamageModifier(roll.QLWeaponDamageMod);
                item.DamageMod = value;
            }

            if (roll.QLWeaponSpeed != 0)
            {
                if (item.WeaponTime != null)
                {
                    item.WeaponTime = (int)(item.WeaponTime * GetSpeedModifier(roll.QLWeaponSpeed));
                }
                else
                    log.Error($"No weapon speed found. Skipping.");
            }

            if (roll.QLArmorLevel != 0)
            {
                if (item.ArmorLevel != null)
                {
                    item.ArmorLevel = GetNewArmorLevel(roll.QLArmorLevel, item.ArmorLevel.Value);
                }
                else
                    log.Error($"No armor level found. Skipping.");
            }

            if (roll.QLArmorEncumbrance != 0)
            {
                if (item.EncumbranceVal != null)
                {
                    var encumbranceMod = GetEncumbranceMod(roll.QLArmorEncumbrance);
                    item.EncumbranceVal = (int)Math.Max(1, item.EncumbranceVal.Value * encumbranceMod);

                    var bulkMod = item.GetProperty(PropertyFloat.BulkMod) ?? 1.0;
                    bulkMod /= encumbranceMod;
                    item.SetProperty(PropertyFloat.BulkMod, bulkMod);
                }
                else
                    log.Error($"No encumbrance level found. Skipping.");
            }

            if (roll.QLArmorVsFire != 0)
            {
                if (item.ArmorModVsFire != null)
                {
                    item.ArmorModVsFire += GetResistModifier(roll.QLArmorVsFire);
                }
                else
                {
                    log.Error($"Missing PropertyFloat.ArmorModVsFire. Aborting {roll.WeenieClassId}");
                    return false;
                }
            }

            if (roll.QLArmorVsCold != 0)
            {
                if (item.ArmorModVsCold != null)
                {
                    item.ArmorModVsCold += GetResistModifier(roll.QLArmorVsCold);
                }
                else
                {
                    log.Error($"Missing PropertyFloat.ArmorModVsCold. Aborting {roll.WeenieClassId}");
                    return false;
                }
            }

            if (roll.QLArmorVsAcid != 0)
            {
                if (item.ArmorModVsAcid != null)
                {
                    item.ArmorModVsAcid += GetResistModifier(roll.QLArmorVsAcid);
                }
                else
                {
                    log.Error($"Missing PropertyFloat.ArmorModVsAcid. Aborting {roll.WeenieClassId}");
                    return false;
                }
            }

            if (roll.QLArmorVsLightning != 0)
            {
                if (item.ArmorModVsElectric != null)
                {
                    item.ArmorModVsElectric += GetResistModifier(roll.QLArmorVsLightning);
                }
                else
                {
                    log.Error($"Missing PropertyFloat.ArmorModVsElectric. Aborting {roll.WeenieClassId}");
                    return false;
                }
            }

            roll.QualityModifier = GetQualityModifier(roll.QLWeaponOffense + roll.QLWeaponDefense + roll.QLWeaponDamageInt +
                roll.QLWeaponDamageMod + roll.QLWeaponSpeed + roll.QLArmorLevel + roll.QLArmorEncumbrance +
                roll.QLArmorVsFire + roll.QLArmorVsCold + roll.QLArmorVsAcid + roll.QLArmorVsLightning +
                roll.QLShieldLevel);

            return true;
        }

        public static float GetAttackMod(int qualityLevel)
        {
            switch (qualityLevel)
            {
                case 1:
                    return 1.2f;
                case 2:
                    return 1.4f;
                case 3:
                    return 1.5f;
                case 4:
                case 5:
                    return 1.6f;
                case 6:
                case 7:
                case 8:
                    return 1.7f;
                case 9:
                case 10:
                case 11:
                case 12:
                    return 1.8f;
            }
            return 1.0f;
        }

        public static float GetDefenseMod(int qualityLevel)
        {
            return GetAttackMod(qualityLevel);
        }

        public static int GetDamageAddModifier(int qualityLevel, int currentValue)
        {
            var multiplier = GetDamageModifier(qualityLevel);

            return (int)Math.Ceiling(currentValue * multiplier);
        }

        public static float GetDamageModifier(int qualityLevel)
        {
            switch (qualityLevel)
            {
                case 1:
                    return 1.2f;
                case 2:
                    return 1.4f;
                case 3:
                    return 1.5f;
                case 4:
                case 5:
                    return 1.6f;
                case 6:
                case 7:
                case 8:
                    return 1.7f;
                case 9:
                case 10:
                case 11:
                case 12:
                    return 1.8f;
            }
            return 1.0f;
        }

        public static float GetSpeedModifier(int qualityLevel)
        {
            var roll = ThreadSafeRandom.Next(-1.0f, 1.0f);

            var retval = 1.0f - (0.05f * (qualityLevel / 2) + 0.025f * roll);

            return retval;
        }

        public static int GetNewArmorLevel(int qualityLevel, int currentValue)
        {
            int armorLevelIndex = GetArmorLevelIndex(currentValue);
            int armorLevelAdjust = ThreadSafeRandom.Next(-5, 5);
            return GetArmorLevel(armorLevelIndex + qualityLevel) + armorLevelAdjust;
        }

        public static int GetArmorLevelIndex(int value)
        {
            int index = 0;

            if (value < 20) index = 0;
            else if (value < 30) index = 1;
            else if (value < 40) index = 2;
            else if (value < 60) index = 3;
            else if (value < 80) index = 4;
            else if (value < 100) index = 5;
            else if (value < 120) index = 6;
            else if (value < 135) index = 7;
            else if (value < 150) index = 8;
            else if (value < 180) index = 9;
            else if (value < 220) index = 10;
            else if (value < 260) index = 11;
            else index = 12;

            return index;
        }

        public static int GetArmorLevel(int value)
        {
            int maxlevel = 12;
            int retVal = 0;

            if (value > maxlevel)
            {
                log.Warn($"New armor above max level. Adjusting to max: {maxlevel}");
                value = maxlevel;
            }

            switch (value)
            {
                case 0: retVal = 20; break;
                case 1: retVal = 30; break;
                case 2: retVal = 40; break;
                case 3: retVal = 60; break;
                case 4: retVal = 80; break;
                case 5: retVal = 100; break;
                case 6: retVal = 120; break;
                case 7: retVal = 135; break;
                case 8: retVal = 150; break;
                case 9: retVal = 180; break;
                case 10: retVal = 220; break;
                case 11: retVal = 260; break;
                case 12: retVal = 300; break;

                default:
                    log.Error($"New armor index invalid: {value}");
                    break;
            }

            return retVal;
        }

        public static float GetEncumbranceMod(int qualityLevel)
        {
            var roll = ThreadSafeRandom.Next(-1.0f, 1.0f);
            var retval = 1.0f - (0.1f * qualityLevel + 0.05f * roll);
            return retval;
        }

        public static float GetResistModifier(int qualityLevel)
        {
            var roll = ThreadSafeRandom.Next(-0.05f, 0.15f);
            var retval = 0.15f * (qualityLevel / 2.0f) + roll;
            return retval;
        }

        public static float GetQualityModifier(int qualityLevelSum)
        {
            return 1.0f + (qualityLevelSum / 500);
        }

        public static bool Modify3DObject(WorldObject item, TreasureRoll roll)
        {
            int newPalette = 0;

            var fancy = GetFancyArmorProb(roll.Workmanship);
            var luck = ThreadSafeRandom.Next(0.0f, 1.0f);

            switch (roll.TreasureItemClass)
            {
                case TreasureItemClass.Jewelry:
                case TreasureItemClass.ArtObject:
                case TreasureItemClass.Weapon:
                case TreasureItemClass.SwordWeapon:
                case TreasureItemClass.MaceWeapon:
                case TreasureItemClass.AxeWeapon:
                case TreasureItemClass.SpearWeapon:
                case TreasureItemClass.UnarmedWeapon:
                case TreasureItemClass.StaffWeapon:
                case TreasureItemClass.DaggerWeapon:
                case TreasureItemClass.BowWeapon:
                case TreasureItemClass.CrossbowWeapon:
                case TreasureItemClass.AtlatlWeapon:
                case TreasureItemClass.TwoHandedWeapon:
                case TreasureItemClass.Caster:

                    newPalette = TreasureTables.GetPalette((int)roll.Material, (int)GetColorCodeIndex(roll.TSysMutationData));
                    break;

                case TreasureItemClass.Gem:

                    var gemMaterial = MaterialType.Unknown;
                    if (item.MaterialType == null)
                    {
                        log.Error($"No material found for gem. Aborting");
                        return false;
                    }
                    newPalette = TreasureTables.GetPalette((int)gemMaterial, 8);
                    break;

                case TreasureItemClass.Clothing:

                    newPalette = TreasureTables.GetClothColor();
                    break;

                case TreasureItemClass.LeatherArmor:
                case TreasureItemClass.StuddedLeatherArmor:

                    if (luck > fancy)
                    {
                        newPalette = TreasureTables.GetPalette((int)roll.Material, (int)GetColorCodeIndex(roll.TSysMutationData));
                    }
                    else
                    {
                        newPalette = TreasureTables.GetLeatherColor();
                    }
                    break;

                case TreasureItemClass.ChainmailArmor:
                case TreasureItemClass.CovenantArmor:
                case TreasureItemClass.PlatemailArmor:
                case TreasureItemClass.HeritageLowArmor:
                case TreasureItemClass.HeritageHighArmor:

                    if (luck > fancy)
                    {
                        newPalette = TreasureTables.GetPalette((int)roll.Material, (int)GetColorCodeIndex(roll.TSysMutationData));
                    }
                    else
                    {
                        // some items behave as if they were leather, when it comes to fancy palette template selection.
                        if (BehavesLikeLeather(roll.WeenieClassId))
                        {
                            newPalette = TreasureTables.GetLeatherColor();
                        }
                        else
                        {
                            newPalette = TreasureTables.GetMetalColor();
                        }
                    }
                    break;

                default:

                    log.Error($"Invalid treasure class: {roll.TreasureItemClass}");
                    return false;
            }

            if (newPalette == 0)
            {
                log.Error($"Invalid palette on wcid: {roll.WeenieClassId}");
                return false;
            }

            if (item.PaletteTemplate != null)
                item.PaletteTemplate = newPalette;

            item.Shade = ThreadSafeRandom.Next(0.0f, 1.0f);

            return true;
        }

        public static float GetFancyArmorProb(int workmanship)
        {
            return workmanship / 2.0f / 10.0f;
        }

        public static bool AssignItemMagic(WorldObject item, TreasureRoll roll)
        {
            bool spellsAdded = false;
            int maxSpellPower = 0;
            float diffAdjust = 0.0f;

            if (SelectAndAddItemSpells(item, roll, ref maxSpellPower))
                spellsAdded = true;

            if (SelectAndAddEnchantments(item, roll, ref maxSpellPower, ref diffAdjust))
                spellsAdded = true;

            if (SelectAndAddCastable(item, roll, ref maxSpellPower))
                spellsAdded = true;

            if (SelectAndAddCantrip(item, roll, ref diffAdjust))
                spellsAdded = true;

            if (!spellsAdded)
            {
                log.Error($"Failed to add spells when flagged to. Aborting.");
                return false;
            }

            bool retval = true;

            if (!FinalizeMagicItemQualities(item, roll, maxSpellPower, (int)diffAdjust))
            {
                log.Error($"Failed to finalize magic item");
                retval = false;
            }

            if (item.SpellDID != null || item.Biota.PropertiesSpellBook.Count > 0)
            {
                item.UiEffects = (item.UiEffects ?? 0) | UiEffects.Magical;
            }

            return retval;
        }

        public static bool SelectAndAddItemSpells(WorldObject item, TreasureRoll roll, ref int maxSpellPower)
        {
            if (!IsWeapon(roll.TreasureItemClass) && !IsArmor(roll.TreasureItemClass))
            {
                log.Error($"Only weapons and armor get enchantments");
                return false;
            }

            var spellList = new List<int>();

            if (IsMeleeWeapon(roll.TreasureItemClass))
            {
                spellList = TreasureTables.GetMeleeWeaponItemSpells(roll.Tier, roll.LuckBonus);
            }
            else if (IsMissileWeapon(roll.TreasureItemClass))
            {
                spellList = TreasureTables.GetMissileWeaponItemSpells(roll.Tier, roll.LuckBonus);
            }
            else if (roll.TreasureItemClass == TreasureItemClass.Caster)
            {
                spellList = TreasureTables.GetCasterItemSpells(roll.Tier, roll.LuckBonus);
            }
            else
            {
                // armor
                spellList = TreasureTables.GetArmorItemSpells(roll.Tier, roll.LuckBonus);
            }

            bool retval = false;

            foreach (var spellId in spellList)
            {
                int spellLevel = TreasureTables.GetSpellLevel(roll.Tier, roll.LuckBonus);

                int finalSpellId = TreasureTables.GetFinalSpell(spellId, spellLevel);

                var spell = new Entity.Spell(finalSpellId);

                if (spell.Power > maxSpellPower)
                    maxSpellPower = (int)spell.Power;

                item.Biota.GetOrAddKnownSpell(finalSpellId, item.BiotaDatabaseLock, out _);

                retval = true;
            }
            return retval;
        }

        public static bool SelectAndAddEnchantments(WorldObject item, TreasureRoll roll, ref int maxSpellPower, ref float diffAdjust)
        {
            var numEnchantments = GetNumEnchantments(roll.TreasureItemClass, roll.Tier, roll.LuckBonus);

            if (numEnchantments <= 0)
                return false;

            if (numEnchantments > MaxEnchantments)
            {
                log.Error($"MaxEnchantments too low. Raise it ({numEnchantments})");
                numEnchantments = MaxEnchantments;
            }

            int numAttempts = numEnchantments * 3;
            int spellGroup = GetSpellSelectionTableIndex((int)roll.TSysMutationData);

            var spells = new List<Tuple<int, int>>();
            int spellsAssigned = 0;
            int highestSpellLevel = 0;
            int highestSpellLevelIndex = 0;

            while (spellsAssigned < numEnchantments && numAttempts > 0)
            {
                var luck = ThreadSafeRandom.Next(0.0f, 1.0f);
                int spellId = TreasureTables.GetSpellCompWcid(spellGroup, roll.QualityModifier);

                if (!spells.Any(i => i.Item1 == spellId))
                {
                    int spellLevel = TreasureTables.GetSpellLevel(roll.Tier, roll.LuckBonus);
                    if (spellLevel > highestSpellLevel)
                    {
                        highestSpellLevel = spellLevel;
                        highestSpellLevelIndex = spellsAssigned;
                    }

                    int finalSpellId = TreasureTables.GetFinalSpell(spellId, spellLevel);
                    var spell = new Entity.Spell(finalSpellId);
                    if (spell.PowerVariance > maxSpellPower)
                        maxSpellPower = (int)spell.Power;

                    spells.Add(new Tuple<int, int>(finalSpellId, spellLevel));
                    spellsAssigned++;
                }
                --numAttempts;
            }

            bool retval = false;
            for (var i = 0; i < spells.Count; i++)
            {
                var spell = spells[i];
                if (i != highestSpellLevelIndex)
                {
                    var luck = ThreadSafeRandom.Next(0.5f, 1.5f);
                    luck *= 5 * spell.Item2;
                    diffAdjust += luck;
                }

                if (roll.TreasureItemClass == TreasureItemClass.Gem)
                {
                    item.SpellDID = (uint)spell.Item1;
                    item.Usable = Usable.Contained;
                    retval = true;
                }
                else
                {
                    item.Biota.GetOrAddKnownSpell(spell.Item1, item.BiotaDatabaseLock, out _);
                    retval = true;
                }
            }
            return retval;
        }

        public static bool SelectAndAddCastable(WorldObject item, TreasureRoll roll, ref int maxSpellPower)
        {
            if (roll.TreasureItemClass != TreasureItemClass.Caster)
                return false;

            int castableSpellId = 0;
            if (roll.WeenieClassId == 2366) // TODO: find other orbs that fall into same category
            {
                castableSpellId = TreasureTables.GetOrbSpell(roll.Tier);
            }
            else
            {
                castableSpellId = TreasureTables.GetWandStaffSpell(roll.Tier);
            }

            int spellLevel = TreasureTables.GetSpellLevel(roll.Tier, roll.LuckBonus);
            int finalSpellId = TreasureTables.GetFinalSpell(castableSpellId, spellLevel);

            item.SpellDID = (uint)finalSpellId;

            item.Usable = (item.Usable ?? 0) | (Usable.Wielded | Usable.Remote | Usable.NeverWalk);

            // set maxSpellPower
            var spell = new Entity.Spell(finalSpellId);
            if (spell.Power > maxSpellPower)
                maxSpellPower = (int)spell.Power;

            return true;
        }

        public static int GetNumEnchantments(TreasureItemClass treasureClass, int tier, double qualityMod)
        {
            float chance = 0.0f;
            float roll = 0.0f;
            var wealthRating = (WealthRating)tier;

            if (treasureClass == TreasureItemClass.Caster)
            {
                switch (wealthRating)
                {
                    case WealthRating.Shoddy:
                        chance = 0.60f;
                        break;
                    case WealthRating.Poor:
                        chance = 0.60f;
                        break;
                    case WealthRating.Medium:
                        chance = 0.60f;
                        break;
                    case WealthRating.Good:
                        chance = 0.60f;
                        break;
                    case WealthRating.Rich:
                        chance = 0.60f;
                        break;
                    case WealthRating.Incomparable:
                        chance = 0.75f;
                        break;
                    case WealthRating.Exceptional:
                        chance = 0.80f;
                        break;
                    case WealthRating.Phenomenal:
                        chance = 0.85f;
                        break;
                    default:
                        log.Error($"Invalid Wealth Rating");
                        break;
                }
                return ThreadSafeRandom.Next(0.0f, 1.0f) - qualityMod < chance ?
                    1 : 0;
            }

            if (IsArmor(treasureClass) || IsPhysicalWeapon(treasureClass))
            {
                switch (wealthRating)
                {
                    case WealthRating.Shoddy:
                        chance = 0.00f;
                        break;
                    case WealthRating.Poor:
                        chance = 0.05f;
                        break;
                    case WealthRating.Medium:
                        chance = 0.10f;
                        break;
                    case WealthRating.Good:
                        chance = 0.20f;
                        break;
                    case WealthRating.Rich:
                        chance = 0.40f;
                        break;
                    case WealthRating.Incomparable:
                        chance = 0.60f;
                        break;
                    case WealthRating.Exceptional:
                        chance = 0.70f;
                        break;
                    case WealthRating.Phenomenal:
                        chance = 0.80f;
                        break;
                    default:
                        log.Error($"Invalid Wealth Rating");
                        break;
                }
                return ThreadSafeRandom.Next(0.0f, 1.0f) - qualityMod < chance ?
                    1 : 0;
            }

            if (treasureClass == TreasureItemClass.Jewelry || treasureClass == TreasureItemClass.Clothing || treasureClass == TreasureItemClass.ArtObject)
            {
                int retval = 1;

                switch (wealthRating)
                {
                    case WealthRating.Shoddy:
                    case WealthRating.Poor:
                    case WealthRating.Medium:
                    case WealthRating.Good:
                    case WealthRating.Rich:
                        if (ThreadSafeRandom.Next(0.0f, 1.0f) - qualityMod < 0.10f)
                            retval++;
                        break;
                    case WealthRating.Incomparable:
                        if (ThreadSafeRandom.Next(0.0f, 1.0f) - qualityMod < 0.10f)
                        {
                            retval++;
                            if (ThreadSafeRandom.Next(0.0f, 1.0f) - (qualityMod / 10.0f) < 0.05f)
                                retval++;
                        }
                        break;
                    case WealthRating.Exceptional:
                        if (ThreadSafeRandom.Next(0.0f, 1.0f) - qualityMod < 0.15f)
                        {
                            retval++;
                            if (ThreadSafeRandom.Next(0.0f, 1.0f) - (qualityMod / 10.0f) < 0.075f)
                                retval++;
                        }
                        break;
                    case WealthRating.Phenomenal:
                        if (ThreadSafeRandom.Next(0.0f, 1.0f) - qualityMod < 0.18f)
                        {
                            retval++;
                            if (ThreadSafeRandom.Next(0.0f, 1.0f) - (qualityMod / 10.0f) < 0.09f)
                                retval++;
                        }
                        break;
                    default:
                        log.Error($"Invalid Wealth Rating");
                        break;
                }
                return retval;
            }

            // This is some other sort of thing, like a geam.
            // It can only have one endowment spell.
            return 1;
        }

        public static bool SelectAndAddCantrip(WorldObject item, TreasureRoll roll, ref float diffAdjust)
        {
            int majorCantrips = 0;
            int epicCantrips = 0;
            int legendaryCantrips = 0;

            int totalCantrips = GetNumberOfCantrips(roll, ref majorCantrips, ref epicCantrips, ref legendaryCantrips);

            int maxAttempts = totalCantrips * 3;

            var cantrips = new List<int>();
            int cantripsAdded = 0;

            while (cantripsAdded < totalCantrips && maxAttempts > 0)
            {
                var luck = ThreadSafeRandom.Next(0.0f, 1.0f);
                int spellId = GetCantrip(item, roll);

                spellId = AdjustForWeaponMastery(item, roll, spellId);

                if (!cantrips.Contains(spellId))
                {
                    cantrips.Add(spellId);
                    cantripsAdded++;
                }
                --maxAttempts;
            }

            bool retval = false;

            foreach (var cantrip in cantrips)
            {
                int finalCantripId;

                if (legendaryCantrips > 0)
                {
                    finalCantripId = TreasureTables.GetFinalCantrip(cantrip, 3);
                    var diffRoll = ThreadSafeRandom.Next(10.0f, 20.0f);
                    diffAdjust += diffRoll;
                    legendaryCantrips--;
                }
                else if (epicCantrips > 0)
                {
                    finalCantripId = TreasureTables.GetFinalCantrip(cantrip, 2);
                    var diffRoll = ThreadSafeRandom.Next(10.0f, 20.0f);
                    diffAdjust += diffRoll;
                    epicCantrips--;
                }
                else if (majorCantrips > 0)
                {
                    finalCantripId = TreasureTables.GetFinalCantrip(cantrip, 1);
                    var diffRoll = ThreadSafeRandom.Next(10.0f, 20.0f);
                    diffAdjust += diffRoll;
                    majorCantrips--;
                }
                else
                {
                    finalCantripId = cantrip;
                    var diffRoll = ThreadSafeRandom.Next(5.0f, 10.0f);
                    diffAdjust += diffRoll;
                }

                item.Biota.GetOrAddKnownSpell(finalCantripId, item.BiotaDatabaseLock, out _);

                retval = true;
            }

            return retval;
        }

        public static int GetNumberOfCantrips(TreasureRoll roll, ref int numMajors, ref int numEpics, ref int numLegendaries)
        {
            int chances = 0;

            float chanceOfCantrip = 0.0f;
            float majorUpgradeChance = 0.0f;
            float epicUpgradeChance = 0.0f;
            float legendaryUpgradeChance = 0.0f;

            switch ((WealthRating)roll.Tier)
            {
                case WealthRating.Shoddy:
                case WealthRating.Poor:
                    break;

                case WealthRating.Medium:
                    chances = 1;
                    chanceOfCantrip = 0.01f;
                    break;

                case WealthRating.Good:
                case WealthRating.Rich:
                    chances = 3;
                    chanceOfCantrip = 0.03f;
                    majorUpgradeChance = 0.01f;
                    break;

                case WealthRating.Incomparable:
                    chances = 5;
                    chanceOfCantrip = 0.05f;
                    majorUpgradeChance = 0.03f;
                    break;

                case WealthRating.Exceptional:
                    chances = 5;
                    chanceOfCantrip = 0.05f;
                    majorUpgradeChance = 0.04f;
                    epicUpgradeChance = 0.03f;
                    break;

                case WealthRating.Phenomenal:
                    chances = 5;
                    chanceOfCantrip = 0.05f;
                    majorUpgradeChance = 0.04f;
                    epicUpgradeChance = 0.03f;
                    legendaryUpgradeChance = 0.02f;
                    break;
            }

            if (chances > MaxCantrips)
            {
                log.Error($"MaxCantrips too low. Boost it");
            }

            int numCantrips = 0;
            for (var i = 0; i < chances; i++)
            {
                if (CheckCantripRoll(chanceOfCantrip, roll.LuckBonus))
                {
                    numCantrips++;
                    if (CheckCantripRoll(majorUpgradeChance, roll.LuckBonus))
                    {
                        numMajors++;
                    }
                    else if (CheckCantripRoll(epicUpgradeChance, roll.LuckBonus))
                    {
                        numEpics++;
                    }
                    else if (CheckCantripRoll(legendaryUpgradeChance, roll.LuckBonus))
                    {
                        numLegendaries++;
                    }
                }
            }
            return numCantrips;
        }

        public static bool CheckCantripRoll(double chance, double luck)
        {
            var roll = ThreadSafeRandom.Next(0.0f, 1.0f) - (luck / 10);
            return roll <= chance;
        }

        public static int GetCantrip(WorldObject item, TreasureRoll roll)
        {
            if (IsArmor(roll.TreasureItemClass))
            {
                if (item.GetProperty(PropertyInt.ShieldValue) != null)
                    return TreasureTables.GetShieldCantrip(roll.Tier);
                else
                    return TreasureTables.GetArmorClothingCantrip(roll.Tier);
            }
            else if (roll.TreasureItemClass == TreasureItemClass.Caster)
            {
                return TreasureTables.GetCasterCantrip(roll.Tier);
            }
            else if (IsMissileWeapon(roll.TreasureItemClass))
            {
                return TreasureTables.GetMissileCantrip(roll.Tier);
            }
            else if (IsMeleeWeapon(roll.TreasureItemClass))
            {
                return TreasureTables.GetMeleeCantrip(roll.Tier);
            }
            else if (roll.TreasureItemClass == TreasureItemClass.Jewelry)
            {
                return TreasureTables.GetJewelryCantrip(roll.Tier);
            }
            return 0;
        }

        public static int AdjustForWeaponMastery(WorldObject item, TreasureRoll roll, int spellId)
        {
            if (spellId == 2539)    // only weapon-based cantrip in weapon table used as flag
            {
                if (item.WeaponSkill != Skill.None)
                {
                    return CantripToMasterySpell(item.WeaponSkill);
                }
            }
            return spellId;
        }

        public static int CantripToMasterySpell(Skill weaponSkill)
        {
            switch (weaponSkill)
            {
                case Skill.HeavyWeapons:
                    return 2566;
                case Skill.LightWeapons:
                    return 2557;
                case Skill.FinesseWeapons:
                    return 2544;
                case Skill.MissileWeapons:
                    return 2540;
                case Skill.TwoHandedCombat:
                    return 5072;
            }
            return (int)weaponSkill;    // ?
        }

        public static bool FinalizeMagicItemQualities(WorldObject item, TreasureRoll roll, int maxSpellPower, int diffAdjust)
        {
            // spellcraft
            var spellcraft = GetItemSpellcraft(maxSpellPower, roll.TreasureItemClass, roll.WeenieClassId);
            item.ItemSpellcraft = spellcraft;

            // item mana
            int castableMana = 0;

            int maxSpellMana = GetMaxSpellMana(item, ref castableMana);

            if (castableMana != 0)
            {
                var castableManaMod = 1.0;

                if (roll.TreasureItemClass == TreasureItemClass.Caster && roll.WeenieClassId != (int)WeenieClassName.W_ORB_CLASS)
                    castableManaMod = 0.5f;

                item.ItemManaCost = (int)(castableMana * castableManaMod);
            }

            if (maxSpellMana != 0)
            {
                item.ManaRate = GetManaRate(maxSpellMana);
            }

            if (maxSpellMana < castableMana)
                maxSpellMana = castableMana;

            var currentMana = GetItemMana(maxSpellMana, roll.Workmanship, roll.TreasureItemClass, roll.WeenieClassId);

            item.ItemMaxMana = currentMana;
            item.ItemCurMana = currentMana;

            // limits

            // allegiance
            var allegianceLimit = GetItemAllegianceLimit(spellcraft, roll.TreasureItemClass, roll.WeenieClassId);
            if (allegianceLimit != 0)
                item.ItemAllegianceRankLimit = allegianceLimit;

            // heritage
            var hasHeritage = false;
            string heritageLimit = null;
            if (GetItemHeritageLimit(roll.TreasureItemClass))
            {
                if (item.HeritageGroup != HeritageGroup.Invalid)
                {
                    hasHeritage = true;
                }
                else
                {
                    if (roll.TreasureItemClass == TreasureItemClass.Jewelry || roll.TreasureItemClass == TreasureItemClass.ArtObject)
                    {
                        int heritageRoll = ThreadSafeRandom.Next(1, 11);
                        switch (heritageRoll)
                        {
                            case 1:
                                heritageLimit = "Aluvian";
                                break;
                            case 2:
                                heritageLimit = "Gharu'ndim";
                                break;
                            case 3:
                                heritageLimit = "Sho";
                                break;
                            case 4:
                                heritageLimit = "Viamontian";
                                break;
                            case 5:
                                heritageLimit = "Shadowbound";
                                break;
                            case 6:
                                heritageLimit = "Gearknight";
                                break;
                            case 7:
                                heritageLimit = "Tumerok";
                                break;
                            case 8:
                                heritageLimit = "Lugian";
                                break;
                            case 9:
                                heritageLimit = "Empyrean";
                                break;
                            case 10:
                                heritageLimit = "Penumbraen";
                                break;
                            case 11:
                                heritageLimit = "Undead";
                                break;
                        }

                        hasHeritage = true;
                    }
                    if (hasHeritage)
                    {
                        item.HeritageGroupName = heritageLimit;
                        item.SetProperty(PropertyString.ItemHeritageGroupRestriction, heritageLimit);
                    }
                }
            }

            // skill
            int skillLimit = AssignItemSkillLimit(item, roll, spellcraft);

            // difficulty
            int difficulty = 0;
            if (roll.TreasureItemClass != TreasureItemClass.Gem)
            {
                difficulty = GetItemDifficulty(spellcraft, skillLimit, allegianceLimit, hasHeritage);
            }

            difficulty += diffAdjust;
            item.ItemDifficulty = difficulty;

            return true;
        }

        public static int GetItemSpellcraft(int maxSpellPower, TreasureItemClass treasureItemClass, uint wcid)
        {
            var roll = GetItemSpellcraftMod(treasureItemClass, wcid);
            int retval = (int)Math.Ceiling(maxSpellPower * roll);
            return retval;
        }

        public static float GetItemSpellcraftMod(TreasureItemClass treasureClass, uint wcid)
        {
            var min = 0.0f;
            var max = 0.0f;

            if (IsArmor(treasureClass) || IsWeapon(treasureClass) || treasureClass == TreasureItemClass.Clothing ||
                treasureClass == TreasureItemClass.ArtObject || treasureClass == TreasureItemClass.Jewelry)
            {
                min = 0.90f;
                max = 1.10f;
            }
            else if (treasureClass == TreasureItemClass.Gem)
            {
                min = 1.00f;
                max = 1.00f;
            }
            else
            {
                log.Warn($"Unknown treasure class. Defaulting to 1.0");
                return 1.0f;
            }
            return ThreadSafeRandom.Next(min, max);
        }

        public static int GetMaxSpellMana(WorldObject item, ref int castableMana)
        {
            if (item.SpellDID != null)
            {
                var spell = new Entity.Spell(item.SpellDID.Value);

                if (spell.NotFound)
                {
                    log.Error($"Unknown spell: {item.SpellDID}");
                }
                else
                {
                    castableMana = (int)spell.BaseMana * 5;
                }
            }

            int maxMana = 0;

            foreach (var spellId in item.Biota.PropertiesSpellBook.Keys)
            {
                var spell = new Entity.Spell(spellId);

                if (spell.NotFound)
                {
                    log.Error($"Unknown spell: {spellId}");
                }
                else
                {
                    if (spell.BaseMana > maxMana)
                        maxMana = (int)spell.BaseMana;
                }
            }
            return maxMana;
        }

        public static double GetManaRate(int maxSpellMana)
        {
            if (maxSpellMana <= 0)
                maxSpellMana = 1;

            return -1.0 / Math.Ceiling(1200.0 / maxSpellMana);
        }

        public static int GetItemMana(int maxSpellMana, int workmanship, TreasureItemClass treasureClass, uint wcid)
        {
            return (int)Math.Ceiling(maxSpellMana * GetItemWorkmanshipManaMod(workmanship) * GetItemManaChargeMod(treasureClass, wcid));
        }

        public static double GetItemWorkmanshipManaMod(int workmanship)
        {
            return 1.0f + ((workmanship - 1.0f) / 9.0f);
        }

        public static int GetItemManaChargeMod(TreasureItemClass treasureClass, uint wcid)
        {
            int min = 0;
            int max = 0;

            if (IsArmor(treasureClass) || treasureClass == TreasureItemClass.Clothing)
            {
                min = 6; max = 15;
            }
            else if (treasureClass == TreasureItemClass.Gem)
            {
                min = 1; max = 1;
            }
            else if (wcid == (int)WeenieClassName.W_CROWN_CLASS)
            {
                min = 6; max = 15;
            }
            else if (treasureClass == TreasureItemClass.Jewelry)
            {
                min = 12; max = 20;
            }
            else if (IsWeapon(treasureClass) || treasureClass == TreasureItemClass.ArtObject)
            {
                min = 6; max = 15;
            }
            else
            {
                log.Warn($"Unknown treasure type. Defaulting to 1");
                return 1;
            }

            return ThreadSafeRandom.Next(min, max);
        }

        public static int GetItemAllegianceLimit(int spellcraft, TreasureItemClass treasureItemClass, uint wcid)
        {
            var roll = ThreadSafeRandom.Next(0.0f, 1.0f);
            var rankChance = GetItemAllegianceLimitProbability(treasureItemClass);
            int allegianceLimit = 0;
            if (roll < rankChance)
            {
                allegianceLimit = 1 + (int)Math.Ceiling(spellcraft / 40.0f);
                if (allegianceLimit > 10) allegianceLimit = 10;
            }
            return allegianceLimit;
        }

        public static float GetItemAllegianceLimitProbability(TreasureItemClass treasureItemClass)
        {
            if (IsArmor(treasureItemClass) || IsWeapon(treasureItemClass) || treasureItemClass == TreasureItemClass.ArtObject || treasureItemClass == TreasureItemClass.Jewelry)
                return 0.1f;
            else
                return 0.0f;
        }

        public static bool GetItemHeritageLimit(TreasureItemClass treasureItemClass)
        {
            var roll = ThreadSafeRandom.Next(0.0f, 1.0f);
            var retval = roll < GetItemHeritageLimitProbability(treasureItemClass);
            return retval;
        }

        public static float GetItemHeritageLimitProbability(TreasureItemClass treasureItemClass)
        {
            if (IsArmor(treasureItemClass) || IsWeapon(treasureItemClass) || treasureItemClass == TreasureItemClass.Clothing
                || treasureItemClass == TreasureItemClass.ArtObject)
                return 0.33f;
            else if (treasureItemClass == TreasureItemClass.Jewelry)
                return 0.10f;
            else
                return 0.0f;
        }

        public static int AssignItemSkillLimit(WorldObject item, TreasureRoll roll, int spellcraft)
        {
            item.ItemSkillLevelLimit = GetItemSkillLimit(spellcraft, roll.TreasureItemClass);

            if (item.ItemSkillLevelLimit == 0)
                return 0;

            Skill didLimitSkill;
            if (IsPhysicalWeapon(roll.TreasureItemClass))
            {
                didLimitSkill = item.WeaponSkill;
            }
            else if (IsArmor(roll.TreasureItemClass))
            {
                var luck = ThreadSafeRandom.Next(0.0f, 1.0f);
                if (luck <= 0.5f)
                {
                    didLimitSkill = Skill.MeleeDefense;
                }
                else
                {
                    didLimitSkill = Skill.MissileDefense;
                    item.ItemSkillLevelLimit = (int)(item.ItemSkillLevelLimit *0.7f);   // missle defense is over 5 instead of 3 -- table mapping?
                }
            }
            else
            {
                log.Error($"Unknown treasure type for skill limit. Aborting");
                return 0;
            }

            item.ItemSkillLimit = (uint)didLimitSkill;

            return (int)item.ItemSkillLevelLimit;
        }

        public static int GetItemSkillLimit(int spellcraft, TreasureItemClass treasureItemClass)
        {
            var roll = ThreadSafeRandom.Next(0.0f, 1.0f);
            int retval = 0;
            if (roll < GetItemSkillLimitProbability(treasureItemClass))
                retval = spellcraft + 20;

            return retval;
        }

        public static float GetItemSkillLimitProbability(TreasureItemClass treasureItemClass)
        {
            if (IsPhysicalWeapon(treasureItemClass))
                return 1.0f;
            else if (IsArmor(treasureItemClass))
                return 0.55f;
            else
                return 0.0f;
        }

        public static int GetItemDifficulty(int spellcraft, int skillLimit, int allegianceLimit, bool heritage)
        {
            var heritageLimit = heritage ? 0.75f : 1.0f;
            if (allegianceLimit == 0)
                allegianceLimit = 1;

            var diff = spellcraft * heritageLimit * 2.0f;
            diff /= allegianceLimit + 1.0f;
            diff -= skillLimit / 2.0f;

            return (int)(diff < 0 ? 0 : Math.Floor(diff));
        }

        public static bool SetNewItemValue(WorldObject item, TreasureRoll roll)
        {
            int value = 0;
            if (item.Value == null)
            {
                log.Warn($"Item had no value but continuing with 0 value");
            }

            if (roll.TreasureItemClass == TreasureItemClass.Gem)
            {
                value = (int)(roll.Workmanship * GetGemModifiedBaseValue(roll.Material, value));
            }
            else if (IsArmor(roll.TreasureItemClass))
            {
                roll.BulkMod = item.GetProperty(PropertyFloat.BulkMod) ?? 1.0;
                roll.SizeMod = item.GetProperty(PropertyFloat.SizeMod) ?? 1.0;

                int armorLevel = 0;
                if (item.ArmorLevel == null)
                {
                    log.Error($"Armor with no armor value. Aborting");
                    return false;
                }
                value = GetNewArmorValue(roll, armorLevel);
            }
            else
                value = GetNewItemValue(roll, value);

            if (item.ItemMaxMana != null)
                value += item.ItemMaxMana.Value * 2;

            int spellSum = 0;
            if ((item.SpellDID ?? 0) > 0)
            {
                //spellSum += DetermineSpellLevel(item.SpellDID);  // TODO: fix for real spell level
                spellSum += roll.Tier;
            }

            foreach (var spellId in item.Biota.PropertiesSpellBook.Keys)
            {
                //spellSum += DetermineSpellLevel(spellId);  // TODO: fix for real spell level
                spellSum += roll.Tier;
            }

            value += spellSum * 10;
            item.Value = value;

            if (roll.TreasureItemClass == TreasureItemClass.Gem)
            {
                if (item.MaxStackSize != 1)
                {
                    log.Error($"Invalid stack size on gem. Should be 1");
                    return false;
                }
                item.StackUnitValue = value;    // check if this is needed in ace
            }

            return true;
        }

        public static int GetGemModifiedBaseValue(MaterialType material, int value)
        {
            var mod = TreasureTables.GetMaterialValueMod((int)material);
            return (int)(value * mod);
        }

        public static int GetNewArmorValue(TreasureRoll roll, int armorLevel)
        {
            var modVal = Math.Pow(armorLevel, 2.0) / 10.0 - 20.0f;
            if (modVal < 10) modVal = 10;
            modVal *= roll.SizeMod * roll.BulkMod;

            modVal /= 10.0;
            modVal += 0.5;
            modVal = (int)modVal;
            modVal *= 10.0;

            var materialMod = TreasureTables.GetMaterialValueMod((int)roll.Material);

            var newVal = modVal / 10 * materialMod * 0.016 + roll.GemValue;
            newVal *= (roll.WorkmanshipMod + roll.QualityModifier) / 2;
            newVal += modVal;
            newVal = Math.Ceiling(newVal);

            return (int)newVal;
        }

        public static int GetNewItemValue(TreasureRoll roll, int value)
        {
            var materialMod = TreasureTables.GetMaterialValueMod((int)roll.Material);

            var newValue = value / 3.0f + materialMod * GetTreasureValueFromWealthRating(roll.Tier) + roll.GemValue;

            var luck = ThreadSafeRandom.Next(0.7f, 1.25f);

            newValue *= (roll.WorkmanshipMod + roll.QualityModifier) * luck;
            newValue += 2.0f * value / 3.0f;

            int iValue = (int)Math.Ceiling(newValue);
            if (value > iValue)
                iValue = value;

            return iValue;
        }

        public static int GetTreasureValueFromWealthRating(int tier)
        {
            var wealthRating = (WealthRating)tier;

            switch (wealthRating)
            {
                case WealthRating.Shoddy:
                    return 25;
                case WealthRating.Poor:
                    return 50;
                case WealthRating.Medium:
                    return 100;
                case WealthRating.Good:
                    return 250;
                case WealthRating.Rich:
                    return 500;
                case WealthRating.Incomparable:
                    return 1000;
                case WealthRating.Exceptional:
                    return 2500;
                case WealthRating.Phenomenal:
                    return 5000;
                default:
                    log.Error($"Invalid wealth rating: {wealthRating}");
                    break;
            }
            return 0;
        }

        public static bool AdjustItemStrings(WorldObject item, TreasureRoll roll)
        {
            var modifyName = TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 4, (int)PropertyString.Name);
            var modifyLongDesc = TreasureTables.GetMutationQualityFilter(roll.MutateFilter, 4, (int)PropertyString.LongDesc);

            if (!modifyName && !modifyLongDesc)
                return true;

            var decoration = LongDescDecoration.Undef;

            if (item.Name == null)
            {
                log.Error($"TreasureSystem.AdjustItemStrings - item has no name");
            }

            string basename = item.Name ?? "";

            if (modifyName)
            {
                if (roll.TreasureItemClass != TreasureItemClass.Gem)
                {
                    if (roll.TreasureItemClass != TreasureItemClass.LeatherArmor && roll.TreasureItemClass != TreasureItemClass.StuddedLeatherArmor
                        || roll.Material != MaterialType.Leather)
                    {
                        var materialName = RecipeManager.GetMaterialName(roll.Material);

                        decoration |= LongDescDecoration.PrependMaterial;

                        item.Name = $"{materialName} {basename}";
                    }
                    else
                    {
                        log.Error($"TreasureSystem.AdjustItemStrings - Failed to get material name");
                    }
                }
            }

            if (modifyLongDesc)
            {
                decoration |= LongDescDecoration.PrependWorkmanship;

                string spellDesc = null;

                if (item.SpellDID != null)
                {
                    spellDesc = GetItemSpellDescription(item.SpellDID.Value);
                }
                else
                {
                    foreach (var spellId in item.Biota.PropertiesSpellBook.Keys)
                    {
                        var spell = new Entity.Spell(spellId);

                        if (spell.NotFound)
                        {
                            log.Error($"TreasureSystem.AdjustItemStrings - No spell found: {spellId}");
                        }
                        else if (spell.NonComponentTargetType == ItemType.Creature)
                        {
                            var tryDesc = GetItemSpellDescription((uint)spellId);

                            if (tryDesc != null)
                                spellDesc = tryDesc;
                        }
                    }
                }

                if (roll.GemCount != 0)
                    decoration |= LongDescDecoration.AppendGemInfo;

                var finalLongDesc = basename;
                if (spellDesc != null)
                    finalLongDesc += $" {spellDesc}";

                item.LongDesc = finalLongDesc;
            }

            if (decoration != LongDescDecoration.Undef)
                item.AppraisalLongDescDecoration = (int)decoration;

            return true;
        }

        public static string GetItemSpellDescription(uint spellId)
        {
            return TreasureTables.GetSpellDescriptor((int)spellId);
        }

        public static int GetMaterialCodeIndex(int uStandardModData)
        {
            return uStandardModData & 0x000000FF;
        }

        public static int GetGemCodeIndex(int uStandardModData)
        {
            return (uStandardModData >> 8) & 0x000000FF;
        }

        public static uint GetColorCodeIndex(uint uStandardModData)
        {
            return (uStandardModData >> 16) & 0x000000FF;
        }

        public static int GetSpellSelectionTableIndex(int uStandardModData)
        {
            return (uStandardModData >> 24) & 0x000000FF;
        }

        public static bool IsMeleeWeapon(TreasureItemClass treasureItemClass)
        {
            switch (treasureItemClass)
            {
                case TreasureItemClass.SwordWeapon:
                case TreasureItemClass.MaceWeapon:
                case TreasureItemClass.AxeWeapon:
                case TreasureItemClass.SpearWeapon:
                case TreasureItemClass.UnarmedWeapon:
                case TreasureItemClass.StaffWeapon:
                case TreasureItemClass.DaggerWeapon:
                case TreasureItemClass.TwoHandedWeapon:
                    return true;
            }
            return false;
        }

        public static bool IsPhysicalWeapon(TreasureItemClass treasureItemClass)
        {
            return IsMeleeWeapon(treasureItemClass) || IsMissileWeapon(treasureItemClass);
        }

        public static bool IsArmor(TreasureItemClass treasureItemClass)
        {
            switch (treasureItemClass)
            {
                case TreasureItemClass.Armor:
                case TreasureItemClass.LeatherArmor:
                case TreasureItemClass.StuddedLeatherArmor:
                case TreasureItemClass.ChainmailArmor:
                case TreasureItemClass.CovenantArmor:
                case TreasureItemClass.PlatemailArmor:
                case TreasureItemClass.HeritageLowArmor:
                case TreasureItemClass.HeritageHighArmor:
                    return true;
            }
            return false;
        }

        public static bool IsWeapon(TreasureItemClass treasureItemClass)
        {
            return treasureItemClass == TreasureItemClass.Weapon || treasureItemClass == TreasureItemClass.Caster ||
                IsMeleeWeapon(treasureItemClass) || IsMissileWeapon(treasureItemClass);
        }

        public static bool IsMissileWeapon(TreasureItemClass treasureItemClass)
        {
            switch (treasureItemClass)
            {
                case TreasureItemClass.BowWeapon:
                case TreasureItemClass.CrossbowWeapon:
                case TreasureItemClass.AtlatlWeapon:
                    return true;
            }
            return false;
        }

        public static bool BehavesLikeLeather(uint wcid)
        {
            switch ((WeenieClassName)wcid)
            {
                case WeenieClassName.W_BOOTSSTEELTOE_CLASS:
                case WeenieClassName.W_LEGGINGSAMULLIAN_CLASS:
                case WeenieClassName.W_SLEEVESKOUJIA_CLASS:
                    return true;
            }
            return false;
        }
    }
}
