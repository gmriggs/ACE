using System;
using System.Linq;

using ACE.Common;
using ACE.Database.Models.World;
using ACE.Entity.Enum;
using ACE.Server.Factories.Entity;
using ACE.Server.Factories.Tables;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories
{
    public static partial class LootGenerationFactory
    {
        private static WorldObject CreateGem(TreasureDeath profile, bool isMagical, bool mutate = true)
        {
            var idx = profile.Tier - 1;

            if (idx < 4) idx = 4;

            var rng = ThreadSafeRandom.Next(0, LootTables.GemsMatrix[idx].Length - 1);

            var wcid = (uint)LootTables.GemsMatrix[idx][rng];

            var wo = WorldObjectFactory.CreateNewWorldObject(wcid) as Gem;

            if (wo != null && mutate)
                MutateGem(wo, profile, isMagical);

            return wo;
        }

        private static void MutateGem(WorldObject wo, TreasureDeath profile, bool isMagical, TreasureRoll roll = null)
        {
            // workmanship
            wo.ItemWorkmanship = WorkmanshipChance.Roll(profile.Tier);

            // item color
            MutateColor(wo);

            if (!isMagical)
            {
                // TODO: verify if this is needed
                wo.ItemUseable = Usable.No;
                wo.SpellDID = null;
                wo.ItemManaCost = null;
                wo.ItemMaxMana = null;
                wo.ItemCurMana = null;
                wo.ItemSpellcraft = null;
                wo.ItemDifficulty = null;
                wo.ItemSkillLevelLimit = null;
                wo.ManaRate = null;
            }
            else
            {
                AssignMagic_Gem(wo, profile, roll);

                wo.UiEffects = UiEffects.Magical;
                wo.ItemUseable = Usable.Contained;
            }

            // item value, review
            var gemValue = LootTables.gemValues[(int)wo.MaterialType];
            wo.Value = gemValue + ThreadSafeRandom.Next(1, gemValue);
        }

        private static void AssignMagic_Gem(WorldObject wo, TreasureDeath profile, TreasureRoll roll)
        {
            // TODO: move to standard AssignMagic() pipeline

            var spellLevelIdx = ThreadSafeRandom.Next(0, 1);
            var spellLevel = LootTables.GemSpellIndexMatrix[profile.Tier - 1][spellLevelIdx];

            var magicSchool = ThreadSafeRandom.Next(0, 1);

            var table = magicSchool == 0 ? GemSpells.GemCreatureSpellMatrix[spellLevel] : GemSpells.GemLifeSpellMatrix[spellLevel];

            var rng = ThreadSafeRandom.Next(0, table.Length - 1);

            var spell = table[rng];

            wo.SpellDID = (uint)spell;

            if (roll == null)
            {
                // old method
                var baseMana = spellLevel * 50;

                wo.ItemSpellcraft = RollSpellcraft(wo);

                wo.ItemMaxMana = ThreadSafeRandom.Next(baseMana, baseMana + 50);
                wo.ItemCurMana = wo.ItemMaxMana;

                wo.ItemManaCost = baseMana;
            }
            else
            {
                // new method
                var _spell = new Server.Entity.Spell(spell);

                // retail spellcraft was capped at 370
                wo.ItemSpellcraft = Math.Min((int)_spell.Power, 370);

                var castableMana = (int)_spell.BaseMana * 5;

                wo.ItemMaxMana = RollItemMaxMana_New(wo, roll, castableMana);
                wo.ItemCurMana = wo.ItemMaxMana;

                // verified
                wo.ItemManaCost = castableMana;
            }
        }

        private static bool GetMutateGemData(uint wcid)
        {
            for (var gemLootMatrixIndex = 0; gemLootMatrixIndex < LootTables.GemsWCIDsMatrix.Length; gemLootMatrixIndex++)
            {
                if (LootTables.GemsWCIDsMatrix[gemLootMatrixIndex].Contains((int)wcid))
                    return true;
            }
            return false;
        }

        private static void MutateValue_Gem(WorldObject wo)
        {
            wo.Value = (int)(wo.Value * MaterialTable.GetValueMod(wo.MaterialType) * wo.ItemWorkmanship);
        }
    }
}
