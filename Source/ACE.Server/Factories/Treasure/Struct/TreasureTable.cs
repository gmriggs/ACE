using ACE.Database.Models.World;

namespace ACE.Server.Factories.Treasure.Struct
{
    public class TreasureTable
    {
        public int Index;
        public int Lookup;
        public double Chance;

        public TreasureTable(TreasureArmor armor)
        {
            Index = armor.Tier;
            Lookup = armor.ArmorSubtable;
            Chance = armor.Chance;
        }

        public TreasureTable(TreasureArmorChainmail chainmail)
        {
            Index = chainmail.Tier;
            Lookup = chainmail.Wcid;
            Chance = chainmail.Chance;
        }

        public TreasureTable(TreasureArmorCovenant covenentArmor)
        {
            Index = covenentArmor.Tier;
            Lookup = covenentArmor.Wcid;
            Chance = covenentArmor.Chance;
        }

        public TreasureTable(TreasureArmorHeritageLow1 heritageArmor)
        {
            Index = heritageArmor.Tier;
            Lookup = heritageArmor.Wcid;
            Chance = heritageArmor.Chance;
        }

        public TreasureTable(TreasureArmorHeritageLow2 heritageArmor)
        {
            Index = heritageArmor.Tier;
            Lookup = heritageArmor.Wcid;
            Chance = heritageArmor.Chance;
        }

        public TreasureTable(TreasureArmorHeritageLow3 heritageArmor)
        {
            Index = heritageArmor.Tier;
            Lookup = heritageArmor.Wcid;
            Chance = heritageArmor.Chance;
        }

        public TreasureTable(TreasureArmorHeritageHigh1 heritageArmor)
        {
            Index = heritageArmor.Tier;
            Lookup = heritageArmor.Wcid;
            Chance = heritageArmor.Chance;
        }

        public TreasureTable(TreasureArmorHeritageHigh2 heritageArmor)
        {
            Index = heritageArmor.Tier;
            Lookup = heritageArmor.Wcid;
            Chance = heritageArmor.Chance;
        }

        public TreasureTable(TreasureArmorHeritageHigh3 heritageArmor)
        {
            Index = heritageArmor.Tier;
            Lookup = heritageArmor.Wcid;
            Chance = heritageArmor.Chance;
        }

        public TreasureTable(TreasureArmorLeather armorLeather)
        {
            Index = armorLeather.Tier;
            Lookup = armorLeather.Wcid;
            Chance = armorLeather.Chance;
        }

        public TreasureTable(TreasureArmorLeatherPalette palette)
        {
            Index = palette.Type;
            Lookup = palette.Color;
            Chance = palette.Chance;
        }

        public TreasureTable(TreasureArmorMetalPalette palette)
        {
            Index = palette.Type;
            Lookup = palette.Color;
            Chance = palette.Chance;
        }

        public TreasureTable(TreasureArmorPalette palette)
        {
            Index = palette.Type;
            Lookup = palette.Color;
            Chance = palette.Chance;
        }

        public TreasureTable(TreasureArmorPlatemail1 platemail)
        {
            Index = platemail.Tier;
            Lookup = platemail.Wcid;
            Chance = platemail.Chance;
        }

        public TreasureTable(TreasureArmorPlatemail2 platemail)
        {
            Index = platemail.Tier;
            Lookup = platemail.Wcid;
            Chance = platemail.Chance;
        }

        public TreasureTable(TreasureArmorPlatemail3 platemail)
        {
            Index = platemail.Tier;
            Lookup = platemail.Wcid;
            Chance = platemail.Chance;
        }

        public TreasureTable(TreasureArmorStuddedLeather studdedLeatherArmor)
        {
            Index = studdedLeatherArmor.Tier;
            Lookup = studdedLeatherArmor.Wcid;
            Chance = studdedLeatherArmor.Chance;
        }

        public TreasureTable(TreasureArt art)
        {
            Index = art.Tier;
            Lookup = art.Wcid;
            Chance = art.Chance;
        }

        public TreasureTable(TreasureCantripArmorDist cantripArmorDist)
        {
            Index = cantripArmorDist.Tier;
            Lookup = cantripArmorDist.Spell;
            Chance = cantripArmorDist.Chance;
        }

        public TreasureTable(TreasureCantripCasterDist cantripCasterDist)
        {
            Index = cantripCasterDist.Tier;
            Lookup = cantripCasterDist.Spell;
            Chance = cantripCasterDist.Chance;
        }

        public TreasureTable(TreasureCantripLevelChance cantripLevelChance)
        {
            Index = cantripLevelChance.Tier;
            Lookup = cantripLevelChance.Level;
            Chance = cantripLevelChance.Chance;
        }

        public TreasureTable(TreasureCantripMagicDist cantripMagicDist)
        {
            Index = cantripMagicDist.Tier;
            Lookup = cantripMagicDist.Spell;
            Chance = cantripMagicDist.Chance;
        }

        public TreasureTable(TreasureCantripMeleeDist cantripMeleeDist)
        {
            Index = cantripMeleeDist.Tier;
            Lookup = cantripMeleeDist.Spell;
            Chance = cantripMeleeDist.Chance;
        }

        public TreasureTable(TreasureCantripMissileDist cantripMissileDist)
        {
            Index = cantripMissileDist.Tier;
            Lookup = cantripMissileDist.Spell;
            Chance = cantripMissileDist.Chance;
        }

        public TreasureTable(TreasureCantripSpellTier cantripSpellTier)
        {
            Index = cantripSpellTier.Tier;
            Lookup = cantripSpellTier.Count;
            Chance = cantripSpellTier.Chance;
        }

        public TreasureTable(TreasureCaster caster)
        {
            Index = caster.Tier;
            Lookup = caster.Wcid;
            Chance = caster.Chance;
        }

        public TreasureTable(TreasureCasterOrbSpell orbSpell)
        {
            Index = orbSpell.Tier;
            Lookup = orbSpell.Spell;
            Chance = orbSpell.Chance;
        }

        public TreasureTable(TreasureCasterSpell casterSpell)
        {
            Index = casterSpell.Tier;
            Lookup = casterSpell.Spell;
            Chance = casterSpell.Chance;
        }

        public TreasureTable(TreasureCasterWandStaffSpell wandStaffSpell)
        {
            Index = wandStaffSpell.Tier;
            Lookup = wandStaffSpell.Spell;
            Chance = wandStaffSpell.Chance;
        }

        public TreasureTable(TreasureClothing1 clothing)
        {
            Index = clothing.Tier;
            Lookup = clothing.Wcid;
            Chance = clothing.Chance;
        }

        public TreasureTable(TreasureClothing2 clothing)
        {
            Index = clothing.Tier;
            Lookup = clothing.Wcid;
            Chance = clothing.Chance;
        }

        public TreasureTable(TreasureClothing3 clothing)
        {
            Index = clothing.Tier;
            Lookup = clothing.Wcid;
            Chance = clothing.Chance;
        }

        public TreasureTable(TreasureClothingPalette clothingPalette)
        {
            Index = clothingPalette.Type;
            Lookup = clothingPalette.Color;
            Chance = clothingPalette.Chance;
        }

        public TreasureTable(TreasureConsumable consumable)
        {
            Index = consumable.Tier;
            Lookup = consumable.Wcid;
            Chance = consumable.Chance;
        }

        public TreasureTable(TreasureGemDist dist)
        {
            Index = dist.Tier;
            Lookup = dist.Count;
            Chance = dist.Chance;
        }

        public TreasureTable(TreasureGemClass gem)
        {
            Index = gem.Tier;
            Lookup = gem.GemClass;
            Chance = gem.Chance;
        }

        public TreasureTable(TreasureGemMaterial gem, bool wcid = false)
        {
            Index = gem.Class;
            Lookup = wcid ? gem.Wcid : gem.Material;
            Chance = gem.Chance;
        }

        public TreasureTable(TreasureHealKit healKit)
        {
            Index = healKit.Tier;
            Lookup = healKit.Wcid;
            Chance = healKit.Chance;
        }

        public TreasureTable(TreasureHeritage heritage)
        {
            Index = heritage.Dist;
            Lookup = heritage.Heritage;
            Chance = heritage.Chance;
        }

        public TreasureTable(TreasureItemBaneSpell baneSpell)
        {
            Index = baneSpell.Tier;
            Lookup = baneSpell.Spell;
            Chance = baneSpell.Chance;
        }

        public TreasureTable(TreasureItemChance itemChance)
        {
            Index = itemChance.ItemTable;
            Lookup = itemChance.TreasureItemTable;
            Chance = itemChance.Chance;
        }

        public TreasureTable(TreasureJewelry jewelry)
        {
            Index = jewelry.Tier;
            Lookup = jewelry.Wcid;
            Chance = jewelry.Chance;
        }

        public TreasureTable(TreasureLockpick lockpick)
        {
            Index = lockpick.Tier;
            Lookup = lockpick.Wcid;
            Chance = lockpick.Chance;
        }

        public TreasureTable(TreasureMagic magic)
        {
            Index = magic.ItemTable;
            Lookup = magic.TreasureItemTable;
            Chance = magic.Chance;
        }

        public TreasureTable(TreasureManaStone manaStone)
        {
            Index = manaStone.Tier;
            Lookup = manaStone.Wcid;
            Chance = manaStone.Chance;
        }

        public TreasureTable(TreasureMaterialDist dist)
        {
            Index = dist.Tier;
            Lookup = dist.Material;
            Chance = dist.Chance;
        }

        public TreasureTable(TreasureMaterialColorDist dist)
        {
            Index = dist.Color;
            Lookup = dist.Material;
            Chance = dist.Chance;
        }

        public TreasureTable(TreasureMaterialCeramic ceramic)
        {
            Index = ceramic.Tier;
            Lookup = ceramic.Material;
            Chance = ceramic.Chance;
        }

        public TreasureTable(TreasureMaterialCloth cloth)
        {
            Index = cloth.Tier;
            Lookup = cloth.Material;
            Chance = cloth.Chance;
        }

        public TreasureTable(TreasureMaterialGem gem)
        {
            Index = gem.Tier;
            Lookup = gem.Material;
            Chance = gem.Chance;
        }

        public TreasureTable(TreasureMaterialLeather leather)
        {
            Index = leather.Tier;
            Lookup = leather.Material;
            Chance = leather.Chance;
        }

        public TreasureTable(TreasureMaterialMetal metal)
        {
            Index = metal.Tier;
            Lookup = metal.Material;
            Chance = metal.Chance;
        }

        public TreasureTable(TreasureMaterialStone stone)
        {
            Index = stone.Tier;
            Lookup = stone.Material;
            Chance = stone.Chance;
        }

        public TreasureTable(TreasureMaterialWood wood)
        {
            Index = wood.Tier;
            Lookup = wood.Material;
            Chance = wood.Chance;
        }

        public TreasureTable(TreasureMundane mundane)
        {
            Index = mundane.ItemTable;
            Lookup = mundane.TreasureItemTable;
            Chance = mundane.Chance;
        }

        public TreasureTable(TreasurePea pea)
        {
            Index = pea.Tier;
            Lookup = pea.Wcid;
            Chance = pea.Chance;
        }

        public TreasureTable(TreasureQualityLevel quality)
        {
            Index = quality.Tier;
            Lookup = quality.QualityLevel;
            Chance = quality.Chance;
        }

        public TreasureTable(TreasureScroll scroll)
        {
            Index = scroll.Tier;
            Lookup = scroll.Wcid;
            Chance = scroll.Chance;
        }

        public TreasureTable(TreasureSpellDist spellDist)
        {
            Index = spellDist.Group;
            Lookup = spellDist.Spell;
            Chance = spellDist.Chance;
        }

        public TreasureTable(TreasureSpellLevel spellLevel)
        {
            Index = spellLevel.Tier;
            Lookup = spellLevel.Level;
            Chance = spellLevel.Chance;
        }

        public TreasureTable(TreasureSpellLevelChance spellLevelChance)
        {
            Index = spellLevelChance.Tier;
            Lookup = spellLevelChance.Level;
            Chance = spellLevelChance.Chance;
        }

        public TreasureTable(TreasureTierAdjust adjustTier)
        {
            Index = adjustTier.Tier;
            Lookup = adjustTier.AdjustTier;
            Chance = adjustTier.Chance;
        }

        public TreasureTable(TreasureWeapon weapon)
        {
            Index = weapon.Tier;
            Lookup = weapon.WeaponSubtable;
            Chance = weapon.Chance;
        }

        public TreasureTable(TreasureWeaponAtlatl atlatl)
        {
            Index = atlatl.Tier;
            Lookup = atlatl.Wcid;
            Chance = atlatl.Chance;
        }

        public TreasureTable(TreasureWeaponAxe1 axe)
        {
            Index = axe.Tier;
            Lookup = axe.Wcid;
            Chance = axe.Chance;
        }

        public TreasureTable(TreasureWeaponAxe2 axe)
        {
            Index = axe.Tier;
            Lookup = axe.Wcid;
            Chance = axe.Chance;
        }

        public TreasureTable(TreasureWeaponAxe3 axe)
        {
            Index = axe.Tier;
            Lookup = axe.Wcid;
            Chance = axe.Chance;
        }

        public TreasureTable(TreasureWeaponBow1 bow)
        {
            Index = bow.Tier;
            Lookup = bow.Wcid;
            Chance = bow.Chance;
        }

        public TreasureTable(TreasureWeaponBow2 bow)
        {
            Index = bow.Tier;
            Lookup = bow.Wcid;
            Chance = bow.Chance;
        }

        public TreasureTable(TreasureWeaponBow3 bow)
        {
            Index = bow.Tier;
            Lookup = bow.Wcid;
            Chance = bow.Chance;
        }

        public TreasureTable(TreasureWeaponCrossbow crossBow)
        {
            Index = crossBow.Tier;
            Lookup = crossBow.Wcid;
            Chance = crossBow.Chance;
        }

        public TreasureTable(TreasureWeaponDagger1 dagger)
        {
            Index = dagger.Tier;
            Lookup = dagger.Wcid;
            Chance = dagger.Chance;
        }

        public TreasureTable(TreasureWeaponDagger2 dagger)
        {
            Index = dagger.Tier;
            Lookup = dagger.Wcid;
            Chance = dagger.Chance;
        }

        public TreasureTable(TreasureWeaponDagger3 dagger)
        {
            Index = dagger.Tier;
            Lookup = dagger.Wcid;
            Chance = dagger.Chance;
        }

        public TreasureTable(TreasureWeaponMace1 mace)
        {
            Index = mace.Tier;
            Lookup = mace.Wcid;
            Chance = mace.Chance;
        }

        public TreasureTable(TreasureWeaponMace2 mace)
        {
            Index = mace.Tier;
            Lookup = mace.Wcid;
            Chance = mace.Chance;
        }

        public TreasureTable(TreasureWeaponMace3 mace)
        {
            Index = mace.Tier;
            Lookup = mace.Wcid;
            Chance = mace.Chance;
        }

        public TreasureTable(TreasureWeaponMeleeSpell spellMelee)
        {
            Index = spellMelee.Tier;
            Lookup = spellMelee.Spell;
            Chance = spellMelee.Chance;
        }

        public TreasureTable(TreasureWeaponMissileSpell spellMissile)
        {
            Index = spellMissile.Tier;
            Lookup = spellMissile.Spell;
            Chance = spellMissile.Chance;
        }

        public TreasureTable(TreasureWeaponSpear1 spear)
        {
            Index = spear.Tier;
            Lookup = spear.Wcid;
            Chance = spear.Chance;
        }

        public TreasureTable(TreasureWeaponSpear2 spear)
        {
            Index = spear.Tier;
            Lookup = spear.Wcid;
            Chance = spear.Chance;
        }

        public TreasureTable(TreasureWeaponSpear3 spear)
        {
            Index = spear.Tier;
            Lookup = spear.Wcid;
            Chance = spear.Chance;
        }

        public TreasureTable(TreasureWeaponStaff1 staff)
        {
            Index = staff.Tier;
            Lookup = staff.Wcid;
            Chance = staff.Chance;
        }

        public TreasureTable(TreasureWeaponStaff2 staff)
        {
            Index = staff.Tier;
            Lookup = staff.Wcid;
            Chance = staff.Chance;
        }

        public TreasureTable(TreasureWeaponStaff3 staff)
        {
            Index = staff.Tier;
            Lookup = staff.Wcid;
            Chance = staff.Chance;
        }

        public TreasureTable(TreasureWeaponSword1 sword)
        {
            Index = sword.Tier;
            Lookup = sword.Wcid;
            Chance = sword.Chance;
        }

        public TreasureTable(TreasureWeaponSword2 sword)
        {
            Index = sword.Tier;
            Lookup = sword.Wcid;
            Chance = sword.Chance;
        }

        public TreasureTable(TreasureWeaponSword3 sword)
        {
            Index = sword.Tier;
            Lookup = sword.Wcid;
            Chance = sword.Chance;
        }

        public TreasureTable(TreasureWeaponUnarmed1 unarmed)
        {
            Index = unarmed.Tier;
            Lookup = unarmed.Wcid;
            Chance = unarmed.Chance;
        }

        public TreasureTable(TreasureWeaponUnarmed2 unarmed)
        {
            Index = unarmed.Tier;
            Lookup = unarmed.Wcid;
            Chance = unarmed.Chance;
        }

        public TreasureTable(TreasureWeaponUnarmed3 unarmed)
        {
            Index = unarmed.Tier;
            Lookup = unarmed.Wcid;
            Chance = unarmed.Chance;
        }

        public TreasureTable(TreasureWorkmanshipDist workmanship)
        {
            Index = workmanship.Tier;
            Lookup = workmanship.Workmanship;
            Chance = workmanship.Chance;
        }
    }
}
