using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ACE.Database.Models.World
{
    public partial class WorldDbContext : DbContext
    {
        public WorldDbContext()
        {
        }

        public WorldDbContext(DbContextOptions<WorldDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CookBook> CookBook { get; set; }
        public virtual DbSet<Encounter> Encounter { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<HousePortal> HousePortal { get; set; }
        public virtual DbSet<LandblockInstance> LandblockInstance { get; set; }
        public virtual DbSet<LandblockInstanceLink> LandblockInstanceLink { get; set; }
        public virtual DbSet<Mutation> Mutation { get; set; }
        public virtual DbSet<MutationChance> MutationChance { get; set; }
        public virtual DbSet<MutationEffect> MutationEffect { get; set; }
        public virtual DbSet<MutationEffectArgument> MutationEffectArgument { get; set; }
        public virtual DbSet<MutationEffectList> MutationEffectList { get; set; }
        public virtual DbSet<MutationOutcome> MutationOutcome { get; set; }
        public virtual DbSet<PointsOfInterest> PointsOfInterest { get; set; }
        public virtual DbSet<Quest> Quest { get; set; }
        public virtual DbSet<Recipe> Recipe { get; set; }
        public virtual DbSet<RecipeMod> RecipeMod { get; set; }
        public virtual DbSet<RecipeModsBool> RecipeModsBool { get; set; }
        public virtual DbSet<RecipeModsDID> RecipeModsDID { get; set; }
        public virtual DbSet<RecipeModsFloat> RecipeModsFloat { get; set; }
        public virtual DbSet<RecipeModsIID> RecipeModsIID { get; set; }
        public virtual DbSet<RecipeModsInt> RecipeModsInt { get; set; }
        public virtual DbSet<RecipeModsString> RecipeModsString { get; set; }
        public virtual DbSet<RecipeRequirementsBool> RecipeRequirementsBool { get; set; }
        public virtual DbSet<RecipeRequirementsDID> RecipeRequirementsDID { get; set; }
        public virtual DbSet<RecipeRequirementsFloat> RecipeRequirementsFloat { get; set; }
        public virtual DbSet<RecipeRequirementsIID> RecipeRequirementsIID { get; set; }
        public virtual DbSet<RecipeRequirementsInt> RecipeRequirementsInt { get; set; }
        public virtual DbSet<RecipeRequirementsString> RecipeRequirementsString { get; set; }
        public virtual DbSet<Spell> Spell { get; set; }
        public virtual DbSet<TreasureArmor> TreasureArmor { get; set; }
        public virtual DbSet<TreasureArmorChainmail> TreasureArmorChainmail { get; set; }
        public virtual DbSet<TreasureArmorCovenant> TreasureArmorCovenant { get; set; }
        public virtual DbSet<TreasureArmorHeritageHigh1> TreasureArmorHeritageHigh1 { get; set; }
        public virtual DbSet<TreasureArmorHeritageHigh2> TreasureArmorHeritageHigh2 { get; set; }
        public virtual DbSet<TreasureArmorHeritageHigh3> TreasureArmorHeritageHigh3 { get; set; }
        public virtual DbSet<TreasureArmorHeritageLow1> TreasureArmorHeritageLow1 { get; set; }
        public virtual DbSet<TreasureArmorHeritageLow2> TreasureArmorHeritageLow2 { get; set; }
        public virtual DbSet<TreasureArmorHeritageLow3> TreasureArmorHeritageLow3 { get; set; }
        public virtual DbSet<TreasureArmorLeather> TreasureArmorLeather { get; set; }
        public virtual DbSet<TreasureArmorLeatherPalette> TreasureArmorLeatherPalette { get; set; }
        public virtual DbSet<TreasureArmorMetalPalette> TreasureArmorMetalPalette { get; set; }
        public virtual DbSet<TreasureArmorPalette> TreasureArmorPalette { get; set; }
        public virtual DbSet<TreasureArmorPlatemail1> TreasureArmorPlatemail1 { get; set; }
        public virtual DbSet<TreasureArmorPlatemail2> TreasureArmorPlatemail2 { get; set; }
        public virtual DbSet<TreasureArmorPlatemail3> TreasureArmorPlatemail3 { get; set; }
        public virtual DbSet<TreasureArmorResistance> TreasureArmorResistance { get; set; }
        public virtual DbSet<TreasureArmorStuddedLeather> TreasureArmorStuddedLeather { get; set; }
        public virtual DbSet<TreasureArt> TreasureArt { get; set; }
        public virtual DbSet<TreasureBurdenMod> TreasureBurdenMod { get; set; }
        public virtual DbSet<TreasureCantripArmorDist> TreasureCantripArmorDist { get; set; }
        public virtual DbSet<TreasureCantripCasterDist> TreasureCantripCasterDist { get; set; }
        public virtual DbSet<TreasureCantripLevelChance> TreasureCantripLevelChance { get; set; }
        public virtual DbSet<TreasureCantripLevelProgression> TreasureCantripLevelProgression { get; set; }
        public virtual DbSet<TreasureCantripMagicDist> TreasureCantripMagicDist { get; set; }
        public virtual DbSet<TreasureCantripMeleeDist> TreasureCantripMeleeDist { get; set; }
        public virtual DbSet<TreasureCantripMissileDist> TreasureCantripMissileDist { get; set; }
        public virtual DbSet<TreasureCantripSpellTier> TreasureCantripSpellTier { get; set; }
        public virtual DbSet<TreasureCaster> TreasureCaster { get; set; }
        public virtual DbSet<TreasureCasterOrbSpell> TreasureCasterOrbSpell { get; set; }
        public virtual DbSet<TreasureCasterSpell> TreasureCasterSpell { get; set; }
        public virtual DbSet<TreasureCasterWandStaffSpell> TreasureCasterWandStaffSpell { get; set; }
        public virtual DbSet<TreasureClothing1> TreasureClothing1 { get; set; }
        public virtual DbSet<TreasureClothing2> TreasureClothing2 { get; set; }
        public virtual DbSet<TreasureClothing3> TreasureClothing3 { get; set; }
        public virtual DbSet<TreasureClothingPalette> TreasureClothingPalette { get; set; }
        public virtual DbSet<TreasureConsumable> TreasureConsumable { get; set; }
        public virtual DbSet<TreasureDeath> TreasureDeath { get; set; }
        public virtual DbSet<TreasureGemClass> TreasureGemClass { get; set; }
        public virtual DbSet<TreasureGemDist> TreasureGemDist { get; set; }
        public virtual DbSet<TreasureGemMaterial> TreasureGemMaterial { get; set; }
        public virtual DbSet<TreasureGemValue> TreasureGemValue { get; set; }
        public virtual DbSet<TreasureHealKit> TreasureHealKit { get; set; }
        public virtual DbSet<TreasureHeritage> TreasureHeritage { get; set; }
        public virtual DbSet<TreasureItem> TreasureItem { get; set; }
        public virtual DbSet<TreasureItemBaneSpell> TreasureItemBaneSpell { get; set; }
        public virtual DbSet<TreasureItemChance> TreasureItemChance { get; set; }
        public virtual DbSet<TreasureJewelry> TreasureJewelry { get; set; }
        public virtual DbSet<TreasureLockpick> TreasureLockpick { get; set; }
        public virtual DbSet<TreasureMagic> TreasureMagic { get; set; }
        public virtual DbSet<TreasureManaStone> TreasureManaStone { get; set; }
        public virtual DbSet<TreasureMaterialBase> TreasureMaterialBase { get; set; }
        public virtual DbSet<TreasureMaterialCeramic> TreasureMaterialCeramic { get; set; }
        public virtual DbSet<TreasureMaterialCloth> TreasureMaterialCloth { get; set; }
        public virtual DbSet<TreasureMaterialColor> TreasureMaterialColor { get; set; }
        public virtual DbSet<TreasureMaterialColorDist> TreasureMaterialColorDist { get; set; }
        public virtual DbSet<TreasureMaterialDist> TreasureMaterialDist { get; set; }
        public virtual DbSet<TreasureMaterialGem> TreasureMaterialGem { get; set; }
        public virtual DbSet<TreasureMaterialGroups> TreasureMaterialGroups { get; set; }
        public virtual DbSet<TreasureMaterialLeather> TreasureMaterialLeather { get; set; }
        public virtual DbSet<TreasureMaterialMetal> TreasureMaterialMetal { get; set; }
        public virtual DbSet<TreasureMaterialMod> TreasureMaterialMod { get; set; }
        public virtual DbSet<TreasureMaterialStone> TreasureMaterialStone { get; set; }
        public virtual DbSet<TreasureMaterialWood> TreasureMaterialWood { get; set; }
        public virtual DbSet<TreasureMundane> TreasureMundane { get; set; }
        public virtual DbSet<TreasureMutateFilter> TreasureMutateFilter { get; set; }
        public virtual DbSet<TreasurePea> TreasurePea { get; set; }
        public virtual DbSet<TreasureQualityLevel> TreasureQualityLevel { get; set; }
        public virtual DbSet<TreasureQualityMod> TreasureQualityMod { get; set; }
        public virtual DbSet<TreasureScroll> TreasureScroll { get; set; }
        public virtual DbSet<TreasureSpellBase> TreasureSpellBase { get; set; }
        public virtual DbSet<TreasureSpellData> TreasureSpellData { get; set; }
        public virtual DbSet<TreasureSpellDesc> TreasureSpellDesc { get; set; }
        public virtual DbSet<TreasureSpellDist> TreasureSpellDist { get; set; }
        public virtual DbSet<TreasureSpellLevel> TreasureSpellLevel { get; set; }
        public virtual DbSet<TreasureSpellLevelChance> TreasureSpellLevelChance { get; set; }
        public virtual DbSet<TreasureSpellLevelProgression> TreasureSpellLevelProgression { get; set; }
        public virtual DbSet<TreasureTierAdjust> TreasureTierAdjust { get; set; }
        public virtual DbSet<TreasureWcid> TreasureWcid { get; set; }
        public virtual DbSet<TreasureWeapon> TreasureWeapon { get; set; }
        public virtual DbSet<TreasureWeaponAtlatl> TreasureWeaponAtlatl { get; set; }
        public virtual DbSet<TreasureWeaponAttackDefenseMod> TreasureWeaponAttackDefenseMod { get; set; }
        public virtual DbSet<TreasureWeaponAxe1> TreasureWeaponAxe1 { get; set; }
        public virtual DbSet<TreasureWeaponAxe2> TreasureWeaponAxe2 { get; set; }
        public virtual DbSet<TreasureWeaponAxe3> TreasureWeaponAxe3 { get; set; }
        public virtual DbSet<TreasureWeaponBow1> TreasureWeaponBow1 { get; set; }
        public virtual DbSet<TreasureWeaponBow2> TreasureWeaponBow2 { get; set; }
        public virtual DbSet<TreasureWeaponBow3> TreasureWeaponBow3 { get; set; }
        public virtual DbSet<TreasureWeaponCrossbow> TreasureWeaponCrossbow { get; set; }
        public virtual DbSet<TreasureWeaponDagger1> TreasureWeaponDagger1 { get; set; }
        public virtual DbSet<TreasureWeaponDagger2> TreasureWeaponDagger2 { get; set; }
        public virtual DbSet<TreasureWeaponDagger3> TreasureWeaponDagger3 { get; set; }
        public virtual DbSet<TreasureWeaponMace1> TreasureWeaponMace1 { get; set; }
        public virtual DbSet<TreasureWeaponMace2> TreasureWeaponMace2 { get; set; }
        public virtual DbSet<TreasureWeaponMace3> TreasureWeaponMace3 { get; set; }
        public virtual DbSet<TreasureWeaponMeleeSpell> TreasureWeaponMeleeSpell { get; set; }
        public virtual DbSet<TreasureWeaponMissileSpell> TreasureWeaponMissileSpell { get; set; }
        public virtual DbSet<TreasureWeaponSkillRemap> TreasureWeaponSkillRemap { get; set; }
        public virtual DbSet<TreasureWeaponSpear1> TreasureWeaponSpear1 { get; set; }
        public virtual DbSet<TreasureWeaponSpear2> TreasureWeaponSpear2 { get; set; }
        public virtual DbSet<TreasureWeaponSpear3> TreasureWeaponSpear3 { get; set; }
        public virtual DbSet<TreasureWeaponSpeedMod> TreasureWeaponSpeedMod { get; set; }
        public virtual DbSet<TreasureWeaponStaff1> TreasureWeaponStaff1 { get; set; }
        public virtual DbSet<TreasureWeaponStaff2> TreasureWeaponStaff2 { get; set; }
        public virtual DbSet<TreasureWeaponStaff3> TreasureWeaponStaff3 { get; set; }
        public virtual DbSet<TreasureWeaponSword1> TreasureWeaponSword1 { get; set; }
        public virtual DbSet<TreasureWeaponSword2> TreasureWeaponSword2 { get; set; }
        public virtual DbSet<TreasureWeaponSword3> TreasureWeaponSword3 { get; set; }
        public virtual DbSet<TreasureWeaponUnarmed1> TreasureWeaponUnarmed1 { get; set; }
        public virtual DbSet<TreasureWeaponUnarmed2> TreasureWeaponUnarmed2 { get; set; }
        public virtual DbSet<TreasureWeaponUnarmed3> TreasureWeaponUnarmed3 { get; set; }
        public virtual DbSet<TreasureWielded> TreasureWielded { get; set; }
        public virtual DbSet<TreasureWorkmanshipDist> TreasureWorkmanshipDist { get; set; }
        public virtual DbSet<Version> Version { get; set; }
        public virtual DbSet<Weenie> Weenie { get; set; }
        public virtual DbSet<WeeniePropertiesAnimPart> WeeniePropertiesAnimPart { get; set; }
        public virtual DbSet<WeeniePropertiesAttribute> WeeniePropertiesAttribute { get; set; }
        public virtual DbSet<WeeniePropertiesAttribute2nd> WeeniePropertiesAttribute2nd { get; set; }
        public virtual DbSet<WeeniePropertiesBodyPart> WeeniePropertiesBodyPart { get; set; }
        public virtual DbSet<WeeniePropertiesBook> WeeniePropertiesBook { get; set; }
        public virtual DbSet<WeeniePropertiesBookPageData> WeeniePropertiesBookPageData { get; set; }
        public virtual DbSet<WeeniePropertiesBool> WeeniePropertiesBool { get; set; }
        public virtual DbSet<WeeniePropertiesCreateList> WeeniePropertiesCreateList { get; set; }
        public virtual DbSet<WeeniePropertiesDID> WeeniePropertiesDID { get; set; }
        public virtual DbSet<WeeniePropertiesEmote> WeeniePropertiesEmote { get; set; }
        public virtual DbSet<WeeniePropertiesEmoteAction> WeeniePropertiesEmoteAction { get; set; }
        public virtual DbSet<WeeniePropertiesEventFilter> WeeniePropertiesEventFilter { get; set; }
        public virtual DbSet<WeeniePropertiesFloat> WeeniePropertiesFloat { get; set; }
        public virtual DbSet<WeeniePropertiesGenerator> WeeniePropertiesGenerator { get; set; }
        public virtual DbSet<WeeniePropertiesIID> WeeniePropertiesIID { get; set; }
        public virtual DbSet<WeeniePropertiesInt> WeeniePropertiesInt { get; set; }
        public virtual DbSet<WeeniePropertiesInt64> WeeniePropertiesInt64 { get; set; }
        public virtual DbSet<WeeniePropertiesPalette> WeeniePropertiesPalette { get; set; }
        public virtual DbSet<WeeniePropertiesPosition> WeeniePropertiesPosition { get; set; }
        public virtual DbSet<WeeniePropertiesSkill> WeeniePropertiesSkill { get; set; }
        public virtual DbSet<WeeniePropertiesSpellBook> WeeniePropertiesSpellBook { get; set; }
        public virtual DbSet<WeeniePropertiesString> WeeniePropertiesString { get; set; }
        public virtual DbSet<WeeniePropertiesTextureMap> WeeniePropertiesTextureMap { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var config = Common.ConfigManager.Config.MySql.World;

                optionsBuilder.UseMySql($"server={config.Host};port={config.Port};user={config.Username};password={config.Password};database={config.Database}");
            }

            optionsBuilder.EnableSensitiveDataLogging(true);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CookBook>(entity =>
            {
                entity.ToTable("cook_book");

                entity.HasIndex(e => e.SourceWCID)
                    .HasName("source_idx");

                entity.HasIndex(e => e.TargetWCID)
                    .HasName("target_idx");

                entity.HasIndex(e => new { e.RecipeId, e.SourceWCID, e.TargetWCID })
                    .HasName("recipe_source_target_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.RecipeId).HasColumnName("recipe_Id");

                entity.Property(e => e.SourceWCID).HasColumnName("source_W_C_I_D");

                entity.Property(e => e.TargetWCID).HasColumnName("target_W_C_I_D");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.CookBook)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("cookbook_recipe");
            });

            modelBuilder.Entity<Encounter>(entity =>
            {
                entity.ToTable("encounter");

                entity.HasIndex(e => e.Landblock)
                    .HasName("landblock_idx");

                entity.HasIndex(e => new { e.Landblock, e.CellX, e.CellY })
                    .HasName("landblock_cellx_celly_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CellX)
                    .HasColumnName("cell_X")
                    .HasColumnType("int(5)");

                entity.Property(e => e.CellY)
                    .HasColumnName("cell_Y")
                    .HasColumnType("int(5)");

                entity.Property(e => e.Landblock)
                    .HasColumnName("landblock")
                    .HasColumnType("int(5)");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.WeenieClassId).HasColumnName("weenie_Class_Id");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("event");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EndTime)
                    .HasColumnName("end_Time")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.StartTime)
                    .HasColumnName("start_Time")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.State)
                    .HasColumnName("state")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<HousePortal>(entity =>
            {
                entity.ToTable("house_portal");

                entity.HasIndex(e => new { e.HouseId, e.ObjCellId })
                    .HasName("house_Id_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnglesW).HasColumnName("angles_W");

                entity.Property(e => e.AnglesX).HasColumnName("angles_X");

                entity.Property(e => e.AnglesY).HasColumnName("angles_Y");

                entity.Property(e => e.AnglesZ).HasColumnName("angles_Z");

                entity.Property(e => e.HouseId).HasColumnName("house_Id");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ObjCellId).HasColumnName("obj_Cell_Id");

                entity.Property(e => e.OriginX).HasColumnName("origin_X");

                entity.Property(e => e.OriginY).HasColumnName("origin_Y");

                entity.Property(e => e.OriginZ).HasColumnName("origin_Z");
            });

            modelBuilder.Entity<LandblockInstance>(entity =>
            {
                entity.HasKey(e => e.Guid)
                    .HasName("PRIMARY");

                entity.ToTable("landblock_instance");

                entity.HasIndex(e => e.Landblock)
                    .HasName("instance_landblock_idx");

                entity.Property(e => e.Guid).HasColumnName("guid");

                entity.Property(e => e.AnglesW).HasColumnName("angles_W");

                entity.Property(e => e.AnglesX).HasColumnName("angles_X");

                entity.Property(e => e.AnglesY).HasColumnName("angles_Y");

                entity.Property(e => e.AnglesZ).HasColumnName("angles_Z");

                entity.Property(e => e.IsLinkChild)
                    .HasColumnName("is_Link_Child")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Landblock)
                    .HasColumnName("landblock")
                    .HasColumnType("int(5)");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ObjCellId).HasColumnName("obj_Cell_Id");

                entity.Property(e => e.OriginX).HasColumnName("origin_X");

                entity.Property(e => e.OriginY).HasColumnName("origin_Y");

                entity.Property(e => e.OriginZ).HasColumnName("origin_Z");

                entity.Property(e => e.WeenieClassId).HasColumnName("weenie_Class_Id");
            });

            modelBuilder.Entity<LandblockInstanceLink>(entity =>
            {
                entity.ToTable("landblock_instance_link");

                entity.HasIndex(e => e.ChildGuid)
                    .HasName("child_idx");

                entity.HasIndex(e => new { e.ParentGuid, e.ChildGuid })
                    .HasName("parent_child_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChildGuid).HasColumnName("child_GUID");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.ParentGuid).HasColumnName("parent_GUID");

                entity.HasOne(d => d.ParentGu)
                    .WithMany(p => p.LandblockInstanceLink)
                    .HasForeignKey(d => d.ParentGuid)
                    .HasConstraintName("instance_link");
            });

            modelBuilder.Entity<Mutation>(entity =>
            {
                entity.ToTable("mutation");

                entity.HasIndex(e => e.MutationId)
                    .HasName("mutation_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idx).HasColumnName("idx");

                entity.Property(e => e.MutationId).HasColumnName("mutation_Id");
            });

            modelBuilder.Entity<MutationChance>(entity =>
            {
                entity.ToTable("mutation_chance");

                entity.HasIndex(e => e.MutationId)
                    .HasName("mutation_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.MutationId).HasColumnName("mutation_Id");

                entity.HasOne(d => d.Mutation)
                    .WithMany(p => p.MutationChance)
                    .HasForeignKey(d => d.MutationId)
                    .HasConstraintName("mutation_chance_mutation_id");
            });

            modelBuilder.Entity<MutationEffect>(entity =>
            {
                entity.ToTable("mutation_effect");

                entity.HasIndex(e => e.MutationEffectListId)
                    .HasName("mutation_Effect_List_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.EffectType).HasColumnName("effect_Type");

                entity.Property(e => e.MutationEffectListId).HasColumnName("mutation_Effect_List_Id");

                entity.HasOne(d => d.MutationEffectList)
                    .WithMany(p => p.MutationEffect)
                    .HasForeignKey(d => d.MutationEffectListId)
                    .HasConstraintName("mutation_effect_mutation_effect_list_id");
            });

            modelBuilder.Entity<MutationEffectArgument>(entity =>
            {
                entity.ToTable("mutation_effect_argument");

                entity.HasIndex(e => e.MutationEffectId)
                    .HasName("mutation_effect_argument_mutation_effect_id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArgType).HasColumnName("arg_Type");

                entity.Property(e => e.DoubleVal).HasColumnName("double_Val");

                entity.Property(e => e.EffectType).HasColumnName("effect_Type");

                entity.Property(e => e.IntVal)
                    .HasColumnName("int_Val")
                    .HasColumnType("int(11)");

                entity.Property(e => e.MaxVal).HasColumnName("max_Val");

                entity.Property(e => e.MinVal).HasColumnName("min_Val");

                entity.Property(e => e.MutationEffectId).HasColumnName("mutation_Effect_Id");

                entity.Property(e => e.StatIdx)
                    .HasColumnName("stat_Idx")
                    .HasColumnType("int(11)");

                entity.Property(e => e.StatType)
                    .HasColumnName("stat_Type")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.MutationEffect)
                    .WithMany(p => p.MutationEffectArgument)
                    .HasForeignKey(d => d.MutationEffectId)
                    .HasConstraintName("mutation_effect_argument_mutation_effect_id");
            });

            modelBuilder.Entity<MutationEffectList>(entity =>
            {
                entity.ToTable("mutation_effect_list");

                entity.HasIndex(e => e.MutationOutcomeId)
                    .HasName("mutation_Outcome_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idx).HasColumnName("idx");

                entity.Property(e => e.MutationOutcomeId).HasColumnName("mutation_Outcome_Id");

                entity.Property(e => e.Probability).HasColumnName("probability");

                entity.HasOne(d => d.MutationOutcome)
                    .WithMany(p => p.MutationEffectList)
                    .HasForeignKey(d => d.MutationOutcomeId)
                    .HasConstraintName("mutation_effect_list_mutation_outcome_id");
            });

            modelBuilder.Entity<MutationOutcome>(entity =>
            {
                entity.ToTable("mutation_outcome");

                entity.HasIndex(e => e.MutationId)
                    .HasName("mutation_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MutationId).HasColumnName("mutation_Id");

                entity.HasOne(d => d.Mutation)
                    .WithMany(p => p.MutationOutcome)
                    .HasForeignKey(d => d.MutationId)
                    .HasConstraintName("mutation_outcome_mutation_id");
            });

            modelBuilder.Entity<PointsOfInterest>(entity =>
            {
                entity.ToTable("points_of_interest");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.WeenieClassId).HasColumnName("weenie_Class_Id");
            });

            modelBuilder.Entity<Quest>(entity =>
            {
                entity.ToTable("quest");

                entity.HasIndex(e => e.Name)
                    .HasName("name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.MaxSolves)
                    .HasColumnName("max_Solves")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.MinDelta).HasColumnName("min_Delta");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.ToTable("recipe");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataId).HasColumnName("data_Id");

                entity.Property(e => e.Difficulty).HasColumnName("difficulty");

                entity.Property(e => e.FailAmount).HasColumnName("fail_Amount");

                entity.Property(e => e.FailDestroySourceAmount).HasColumnName("fail_Destroy_Source_Amount");

                entity.Property(e => e.FailDestroySourceChance).HasColumnName("fail_Destroy_Source_Chance");

                entity.Property(e => e.FailDestroySourceMessage)
                    .HasColumnName("fail_Destroy_Source_Message")
                    .HasColumnType("text");

                entity.Property(e => e.FailDestroyTargetAmount).HasColumnName("fail_Destroy_Target_Amount");

                entity.Property(e => e.FailDestroyTargetChance).HasColumnName("fail_Destroy_Target_Chance");

                entity.Property(e => e.FailDestroyTargetMessage)
                    .HasColumnName("fail_Destroy_Target_Message")
                    .HasColumnType("text");

                entity.Property(e => e.FailMessage)
                    .HasColumnName("fail_Message")
                    .HasColumnType("text");

                entity.Property(e => e.FailWCID).HasColumnName("fail_W_C_I_D");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.SalvageType).HasColumnName("salvage_Type");

                entity.Property(e => e.Skill).HasColumnName("skill");

                entity.Property(e => e.SuccessAmount).HasColumnName("success_Amount");

                entity.Property(e => e.SuccessDestroySourceAmount).HasColumnName("success_Destroy_Source_Amount");

                entity.Property(e => e.SuccessDestroySourceChance).HasColumnName("success_Destroy_Source_Chance");

                entity.Property(e => e.SuccessDestroySourceMessage)
                    .HasColumnName("success_Destroy_Source_Message")
                    .HasColumnType("text");

                entity.Property(e => e.SuccessDestroyTargetAmount).HasColumnName("success_Destroy_Target_Amount");

                entity.Property(e => e.SuccessDestroyTargetChance).HasColumnName("success_Destroy_Target_Chance");

                entity.Property(e => e.SuccessDestroyTargetMessage)
                    .HasColumnName("success_Destroy_Target_Message")
                    .HasColumnType("text");

                entity.Property(e => e.SuccessMessage)
                    .HasColumnName("success_Message")
                    .HasColumnType("text");

                entity.Property(e => e.SuccessWCID).HasColumnName("success_W_C_I_D");

                entity.Property(e => e.Unknown1).HasColumnName("unknown_1");
            });

            modelBuilder.Entity<RecipeMod>(entity =>
            {
                entity.ToTable("recipe_mod");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("recipeId_Mod");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DataId)
                    .HasColumnName("data_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ExecutesOnSuccess)
                    .HasColumnName("executes_On_Success")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Health)
                    .HasColumnName("health")
                    .HasColumnType("int(10)");

                entity.Property(e => e.InstanceId)
                    .HasColumnName("instance_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Mana)
                    .HasColumnName("mana")
                    .HasColumnType("int(10)");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_Id");

                entity.Property(e => e.Stamina)
                    .HasColumnName("stamina")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Unknown7)
                    .HasColumnName("unknown_7")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Unknown9)
                    .HasColumnName("unknown_9")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeMod)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("recipeId_Mod");
            });

            modelBuilder.Entity<RecipeModsBool>(entity =>
            {
                entity.ToTable("recipe_mods_bool");

                entity.HasIndex(e => e.RecipeModId)
                    .HasName("recipeId_mod_bool");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.RecipeModId).HasColumnName("recipe_Mod_Id");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("bit(1)");

                entity.HasOne(d => d.RecipeMod)
                    .WithMany(p => p.RecipeModsBool)
                    .HasForeignKey(d => d.RecipeModId)
                    .HasConstraintName("recipeId_mod_bool");
            });

            modelBuilder.Entity<RecipeModsDID>(entity =>
            {
                entity.ToTable("recipe_mods_d_i_d");

                entity.HasIndex(e => e.RecipeModId)
                    .HasName("recipeId_mod_did");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.RecipeModId).HasColumnName("recipe_Mod_Id");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.RecipeMod)
                    .WithMany(p => p.RecipeModsDID)
                    .HasForeignKey(d => d.RecipeModId)
                    .HasConstraintName("recipeId_mod_did");
            });

            modelBuilder.Entity<RecipeModsFloat>(entity =>
            {
                entity.ToTable("recipe_mods_float");

                entity.HasIndex(e => e.RecipeModId)
                    .HasName("recipeId_mod_float");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.RecipeModId).HasColumnName("recipe_Mod_Id");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.RecipeMod)
                    .WithMany(p => p.RecipeModsFloat)
                    .HasForeignKey(d => d.RecipeModId)
                    .HasConstraintName("recipeId_mod_float");
            });

            modelBuilder.Entity<RecipeModsIID>(entity =>
            {
                entity.ToTable("recipe_mods_i_i_d");

                entity.HasIndex(e => e.RecipeModId)
                    .HasName("recipeId_mod_iid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.RecipeModId).HasColumnName("recipe_Mod_Id");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.RecipeMod)
                    .WithMany(p => p.RecipeModsIID)
                    .HasForeignKey(d => d.RecipeModId)
                    .HasConstraintName("recipeId_mod_iid");
            });

            modelBuilder.Entity<RecipeModsInt>(entity =>
            {
                entity.ToTable("recipe_mods_int");

                entity.HasIndex(e => e.RecipeModId)
                    .HasName("recipeId_mod_int");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.RecipeModId).HasColumnName("recipe_Mod_Id");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.RecipeMod)
                    .WithMany(p => p.RecipeModsInt)
                    .HasForeignKey(d => d.RecipeModId)
                    .HasConstraintName("recipeId_mod_int");
            });

            modelBuilder.Entity<RecipeModsString>(entity =>
            {
                entity.ToTable("recipe_mods_string");

                entity.HasIndex(e => e.RecipeModId)
                    .HasName("recipeId_mod_string");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.RecipeModId).HasColumnName("recipe_Mod_Id");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("text");

                entity.HasOne(d => d.RecipeMod)
                    .WithMany(p => p.RecipeModsString)
                    .HasForeignKey(d => d.RecipeModId)
                    .HasConstraintName("recipeId_mod_string");
            });

            modelBuilder.Entity<RecipeRequirementsBool>(entity =>
            {
                entity.ToTable("recipe_requirements_bool");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("recipeId_req_bool");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_Id");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("bit(1)");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRequirementsBool)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("recipeId_req_bool");
            });

            modelBuilder.Entity<RecipeRequirementsDID>(entity =>
            {
                entity.ToTable("recipe_requirements_d_i_d");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("recipeId_req_did");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_Id");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRequirementsDID)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("recipeId_req_did");
            });

            modelBuilder.Entity<RecipeRequirementsFloat>(entity =>
            {
                entity.ToTable("recipe_requirements_float");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("recipeId_req_float");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_Id");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRequirementsFloat)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("recipeId_req_float");
            });

            modelBuilder.Entity<RecipeRequirementsIID>(entity =>
            {
                entity.ToTable("recipe_requirements_i_i_d");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("recipeId_req_iid");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_Id");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRequirementsIID)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("recipeId_req_iid");
            });

            modelBuilder.Entity<RecipeRequirementsInt>(entity =>
            {
                entity.ToTable("recipe_requirements_int");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("recipeId_req_int");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_Id");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRequirementsInt)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("recipeId_req_int");
            });

            modelBuilder.Entity<RecipeRequirementsString>(entity =>
            {
                entity.ToTable("recipe_requirements_string");

                entity.HasIndex(e => e.RecipeId)
                    .HasName("recipeId_req_string");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Enum)
                    .HasColumnName("enum")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.RecipeId).HasColumnName("recipe_Id");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("text");

                entity.HasOne(d => d.Recipe)
                    .WithMany(p => p.RecipeRequirementsString)
                    .HasForeignKey(d => d.RecipeId)
                    .HasConstraintName("recipeId_req_string");
            });

            modelBuilder.Entity<Spell>(entity =>
            {
                entity.ToTable("spell");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Align)
                    .HasColumnName("align")
                    .HasColumnType("int(10)");

                entity.Property(e => e.BaseIntensity)
                    .HasColumnName("base_Intensity")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Boost)
                    .HasColumnName("boost")
                    .HasColumnType("int(10)");

                entity.Property(e => e.BoostVariance)
                    .HasColumnName("boost_Variance")
                    .HasColumnType("int(10)");

                entity.Property(e => e.CreateOffsetOriginX).HasColumnName("create_Offset_Origin_X");

                entity.Property(e => e.CreateOffsetOriginY).HasColumnName("create_Offset_Origin_Y");

                entity.Property(e => e.CreateOffsetOriginZ).HasColumnName("create_Offset_Origin_Z");

                entity.Property(e => e.CritFreq).HasColumnName("crit_Freq");

                entity.Property(e => e.CritMultiplier).HasColumnName("crit_Multiplier");

                entity.Property(e => e.DamageRatio).HasColumnName("damage_Ratio");

                entity.Property(e => e.DamageType)
                    .HasColumnName("damage_Type")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DefaultLaunchAngle).HasColumnName("default_Launch_Angle");

                entity.Property(e => e.Destination)
                    .HasColumnName("destination")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DimsOriginX).HasColumnName("dims_Origin_X");

                entity.Property(e => e.DimsOriginY).HasColumnName("dims_Origin_Y");

                entity.Property(e => e.DimsOriginZ).HasColumnName("dims_Origin_Z");

                entity.Property(e => e.DispelSchool)
                    .HasColumnName("dispel_School")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DotDuration).HasColumnName("dot_Duration");

                entity.Property(e => e.DrainPercentage).HasColumnName("drain_Percentage");

                entity.Property(e => e.EType).HasColumnName("e_Type");

                entity.Property(e => e.ElementalModifier).HasColumnName("elemental_Modifier");

                entity.Property(e => e.IgnoreMagicResist)
                    .HasColumnName("ignore_Magic_Resist")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ImbuedEffect).HasColumnName("imbued_Effect");

                entity.Property(e => e.Index)
                    .HasColumnName("index")
                    .HasColumnType("int(10)");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Link)
                    .HasColumnName("link")
                    .HasColumnType("int(10)");

                entity.Property(e => e.LossPercent).HasColumnName("loss_Percent");

                entity.Property(e => e.MaxBoostAllowed)
                    .HasColumnName("max_Boost_Allowed")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MaxPower)
                    .HasColumnName("max_Power")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MinPower)
                    .HasColumnName("min_Power")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("text");

                entity.Property(e => e.NonTracking)
                    .HasColumnName("non_Tracking")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.NumProjectiles)
                    .HasColumnName("num_Projectiles")
                    .HasColumnType("int(10)");

                entity.Property(e => e.NumProjectilesVariance)
                    .HasColumnName("num_Projectiles_Variance")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Number)
                    .HasColumnName("number")
                    .HasColumnType("int(10)");

                entity.Property(e => e.NumberVariance).HasColumnName("number_Variance");

                entity.Property(e => e.PaddingOriginX).HasColumnName("padding_Origin_X");

                entity.Property(e => e.PaddingOriginY).HasColumnName("padding_Origin_Y");

                entity.Property(e => e.PaddingOriginZ).HasColumnName("padding_Origin_Z");

                entity.Property(e => e.PeturbationOriginX).HasColumnName("peturbation_Origin_X");

                entity.Property(e => e.PeturbationOriginY).HasColumnName("peturbation_Origin_Y");

                entity.Property(e => e.PeturbationOriginZ).HasColumnName("peturbation_Origin_Z");

                entity.Property(e => e.PositionAnglesW).HasColumnName("position_Angles_W");

                entity.Property(e => e.PositionAnglesX).HasColumnName("position_Angles_X");

                entity.Property(e => e.PositionAnglesY).HasColumnName("position_Angles_Y");

                entity.Property(e => e.PositionAnglesZ).HasColumnName("position_Angles_Z");

                entity.Property(e => e.PositionObjCellId).HasColumnName("position_Obj_Cell_ID");

                entity.Property(e => e.PositionOriginX).HasColumnName("position_Origin_X");

                entity.Property(e => e.PositionOriginY).HasColumnName("position_Origin_Y");

                entity.Property(e => e.PositionOriginZ).HasColumnName("position_Origin_Z");

                entity.Property(e => e.PowerVariance).HasColumnName("power_Variance");

                entity.Property(e => e.Proportion).HasColumnName("proportion");

                entity.Property(e => e.SlayerCreatureType)
                    .HasColumnName("slayer_Creature_Type")
                    .HasColumnType("int(10)");

                entity.Property(e => e.SlayerDamageBonus).HasColumnName("slayer_Damage_Bonus");

                entity.Property(e => e.Source)
                    .HasColumnName("source")
                    .HasColumnType("int(10)");

                entity.Property(e => e.SourceLoss)
                    .HasColumnName("source_Loss")
                    .HasColumnType("int(10)");

                entity.Property(e => e.SpreadAngle).HasColumnName("spread_Angle");

                entity.Property(e => e.StatModKey).HasColumnName("stat_Mod_Key");

                entity.Property(e => e.StatModType).HasColumnName("stat_Mod_Type");

                entity.Property(e => e.StatModVal).HasColumnName("stat_Mod_Val");

                entity.Property(e => e.TransferBitfield).HasColumnName("transfer_Bitfield");

                entity.Property(e => e.TransferCap)
                    .HasColumnName("transfer_Cap")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Variance)
                    .HasColumnName("variance")
                    .HasColumnType("int(10)");

                entity.Property(e => e.VerticalAngle).HasColumnName("vertical_Angle");

                entity.Property(e => e.Wcid).HasColumnName("wcid");
            });

            modelBuilder.Entity<TreasureArmor>(entity =>
            {
                entity.ToTable("treasure_armor");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArmorSubtable)
                    .HasColumnName("armor_Subtable")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorChainmail>(entity =>
            {
                entity.ToTable("treasure_armor_chainmail");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorCovenant>(entity =>
            {
                entity.ToTable("treasure_armor_covenant");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorHeritageHigh1>(entity =>
            {
                entity.ToTable("treasure_armor_heritage_high1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorHeritageHigh2>(entity =>
            {
                entity.ToTable("treasure_armor_heritage_high2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorHeritageHigh3>(entity =>
            {
                entity.ToTable("treasure_armor_heritage_high3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorHeritageLow1>(entity =>
            {
                entity.ToTable("treasure_armor_heritage_low1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorHeritageLow2>(entity =>
            {
                entity.ToTable("treasure_armor_heritage_low2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorHeritageLow3>(entity =>
            {
                entity.ToTable("treasure_armor_heritage_low3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorLeather>(entity =>
            {
                entity.ToTable("treasure_armor_leather");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorLeatherPalette>(entity =>
            {
                entity.ToTable("treasure_armor_leather_palette");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorMetalPalette>(entity =>
            {
                entity.ToTable("treasure_armor_metal_palette");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorPalette>(entity =>
            {
                entity.ToTable("treasure_armor_palette");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorPlatemail1>(entity =>
            {
                entity.ToTable("treasure_armor_platemail1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorPlatemail2>(entity =>
            {
                entity.ToTable("treasure_armor_platemail2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorPlatemail3>(entity =>
            {
                entity.ToTable("treasure_armor_platemail3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorResistance>(entity =>
            {
                entity.ToTable("treasure_armor_resistance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Max).HasColumnName("max");

                entity.Property(e => e.Min).HasColumnName("min");

                entity.Property(e => e.QualityLevel)
                    .HasColumnName("quality_Level")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArmorStuddedLeather>(entity =>
            {
                entity.ToTable("treasure_armor_studded_leather");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureArt>(entity =>
            {
                entity.ToTable("treasure_art");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureBurdenMod>(entity =>
            {
                entity.ToTable("treasure_burden_mod");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Max).HasColumnName("max");

                entity.Property(e => e.Min).HasColumnName("min");

                entity.Property(e => e.QualityLevel)
                    .HasColumnName("quality_Level")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCantripArmorDist>(entity =>
            {
                entity.ToTable("treasure_cantrip_armor_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCantripCasterDist>(entity =>
            {
                entity.ToTable("treasure_cantrip_caster_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCantripLevelChance>(entity =>
            {
                entity.ToTable("treasure_cantrip_level_chance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCantripLevelProgression>(entity =>
            {
                entity.ToTable("treasure_cantrip_level_progression");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Epic)
                    .HasColumnName("epic")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lego)
                    .HasColumnName("lego")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Major)
                    .HasColumnName("major")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Minor)
                    .HasColumnName("minor")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCantripMagicDist>(entity =>
            {
                entity.ToTable("treasure_cantrip_magic_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCantripMeleeDist>(entity =>
            {
                entity.ToTable("treasure_cantrip_melee_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCantripMissileDist>(entity =>
            {
                entity.ToTable("treasure_cantrip_missile_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCantripSpellTier>(entity =>
            {
                entity.ToTable("treasure_cantrip_spell_tier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCaster>(entity =>
            {
                entity.ToTable("treasure_caster");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCasterOrbSpell>(entity =>
            {
                entity.ToTable("treasure_caster_orb_spell");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCasterSpell>(entity =>
            {
                entity.ToTable("treasure_caster_spell");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureCasterWandStaffSpell>(entity =>
            {
                entity.ToTable("treasure_caster_wand_staff_spell");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureClothing1>(entity =>
            {
                entity.ToTable("treasure_clothing1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureClothing2>(entity =>
            {
                entity.ToTable("treasure_clothing2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureClothing3>(entity =>
            {
                entity.ToTable("treasure_clothing3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureClothingPalette>(entity =>
            {
                entity.ToTable("treasure_clothing_palette");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureConsumable>(entity =>
            {
                entity.ToTable("treasure_consumable");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureDeath>(entity =>
            {
                entity.ToTable("treasure_death");

                entity.HasIndex(e => e.TreasureType)
                    .HasName("treasureType_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemChance)
                    .HasColumnName("item_Chance")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ItemMaxAmount)
                    .HasColumnName("item_Max_Amount")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ItemMinAmount)
                    .HasColumnName("item_Min_Amount")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ItemTreasureTypeSelectionChances)
                    .HasColumnName("item_Treasure_Type_Selection_Chances")
                    .HasColumnType("int(10)");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.LootQualityMod).HasColumnName("loot_Quality_Mod");

                entity.Property(e => e.MagicItemChance)
                    .HasColumnName("magic_Item_Chance")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MagicItemMaxAmount)
                    .HasColumnName("magic_Item_Max_Amount")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MagicItemMinAmount)
                    .HasColumnName("magic_Item_Min_Amount")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MagicItemTreasureTypeSelectionChances)
                    .HasColumnName("magic_Item_Treasure_Type_Selection_Chances")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MundaneItemChance)
                    .HasColumnName("mundane_Item_Chance")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MundaneItemMaxAmount)
                    .HasColumnName("mundane_Item_Max_Amount")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MundaneItemMinAmount)
                    .HasColumnName("mundane_Item_Min_Amount")
                    .HasColumnType("int(10)");

                entity.Property(e => e.MundaneItemTypeSelectionChances)
                    .HasColumnName("mundane_Item_Type_Selection_Chances")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(10)");

                entity.Property(e => e.TreasureType).HasColumnName("treasure_Type");

                entity.Property(e => e.UnknownChances)
                    .HasColumnName("unknown_Chances")
                    .HasColumnType("int(10)");
            });

            modelBuilder.Entity<TreasureGemClass>(entity =>
            {
                entity.ToTable("treasure_gem_class");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.GemClass)
                    .HasColumnName("gem_Class")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureGemDist>(entity =>
            {
                entity.ToTable("treasure_gem_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Count)
                    .HasColumnName("count")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Group)
                    .HasColumnName("group")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureGemMaterial>(entity =>
            {
                entity.ToTable("treasure_gem_material");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureGemValue>(entity =>
            {
                entity.ToTable("treasure_gem_value");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureHealKit>(entity =>
            {
                entity.ToTable("treasure_heal_kit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureHeritage>(entity =>
            {
                entity.ToTable("treasure_heritage");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Dist)
                    .HasColumnName("dist")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Heritage)
                    .HasColumnName("heritage")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureItem>(entity =>
            {
                entity.ToTable("treasure_item");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.RollType)
                    .HasColumnName("roll_Type")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TreasureItemName)
                    .IsRequired()
                    .HasColumnName("treasure_Item_Name")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.TreasureItemTableName)
                    .IsRequired()
                    .HasColumnName("treasure_Item_Table_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TreasureItemBaneSpell>(entity =>
            {
                entity.ToTable("treasure_item_bane_spell");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureItemChance>(entity =>
            {
                entity.ToTable("treasure_item_chance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.ItemTable)
                    .HasColumnName("item_Table")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TreasureItemTable)
                    .HasColumnName("treasure_Item_Table")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureJewelry>(entity =>
            {
                entity.ToTable("treasure_jewelry");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureLockpick>(entity =>
            {
                entity.ToTable("treasure_lockpick");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMagic>(entity =>
            {
                entity.ToTable("treasure_magic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.ItemTable)
                    .HasColumnName("item_Table")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TreasureItemTable)
                    .HasColumnName("treasure_Item_Table")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureManaStone>(entity =>
            {
                entity.ToTable("treasure_mana_stone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMaterialBase>(entity =>
            {
                entity.ToTable("treasure_material_base");

                entity.HasIndex(e => e.Tier)
                    .HasName("tier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MaterialCode).HasColumnName("material_Code");

                entity.Property(e => e.MaterialId).HasColumnName("material_Id");

                entity.Property(e => e.Probability).HasColumnName("probability");

                entity.Property(e => e.Tier).HasColumnName("tier");
            });

            modelBuilder.Entity<TreasureMaterialCeramic>(entity =>
            {
                entity.ToTable("treasure_material_ceramic");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMaterialCloth>(entity =>
            {
                entity.ToTable("treasure_material_cloth");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMaterialColor>(entity =>
            {
                entity.ToTable("treasure_material_color");

                entity.HasIndex(e => e.ColorCode)
                    .HasName("tsys_Mutation_Color");

                entity.HasIndex(e => e.MaterialId)
                    .HasName("material_Id");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ColorCode).HasColumnName("color_Code");

                entity.Property(e => e.MaterialId).HasColumnName("material_Id");

                entity.Property(e => e.PaletteTemplate).HasColumnName("palette_Template");

                entity.Property(e => e.Probability).HasColumnName("probability");
            });

            modelBuilder.Entity<TreasureMaterialColorDist>(entity =>
            {
                entity.ToTable("treasure_material_color_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Color)
                    .HasColumnName("color")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Group)
                    .HasColumnName("group")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMaterialDist>(entity =>
            {
                entity.ToTable("treasure_material_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Group)
                    .HasColumnName("group")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMaterialGem>(entity =>
            {
                entity.ToTable("treasure_material_gem");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMaterialGroups>(entity =>
            {
                entity.ToTable("treasure_material_groups");

                entity.HasIndex(e => e.Tier)
                    .HasName("tier");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MaterialGroup).HasColumnName("material_Group");

                entity.Property(e => e.MaterialId).HasColumnName("material_Id");

                entity.Property(e => e.Probability).HasColumnName("probability");

                entity.Property(e => e.Tier).HasColumnName("tier");
            });

            modelBuilder.Entity<TreasureMaterialLeather>(entity =>
            {
                entity.ToTable("treasure_material_leather");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMaterialMetal>(entity =>
            {
                entity.ToTable("treasure_material_metal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMaterialMod>(entity =>
            {
                entity.ToTable("treasure_material_mod");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Multiplier).HasColumnName("multiplier");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TreasureMaterialStone>(entity =>
            {
                entity.ToTable("treasure_material_stone");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMaterialWood>(entity =>
            {
                entity.ToTable("treasure_material_wood");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Material)
                    .HasColumnName("material")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMundane>(entity =>
            {
                entity.ToTable("treasure_mundane");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.ItemTable)
                    .HasColumnName("item_Table")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TreasureItemTable)
                    .HasColumnName("treasure_Item_Table")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureMutateFilter>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PRIMARY");

                entity.ToTable("treasure_mutate_filter");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QualityID)
                    .HasColumnName("quality_I_D")
                    .HasColumnType("int(11)");

                entity.Property(e => e.QualityType)
                    .HasColumnName("quality_Type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasurePea>(entity =>
            {
                entity.ToTable("treasure_pea");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureQualityLevel>(entity =>
            {
                entity.ToTable("treasure_quality_level");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.QualityLevel)
                    .HasColumnName("quality_Level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureQualityMod>(entity =>
            {
                entity.ToTable("treasure_quality_mod");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.QualityMod)
                    .HasColumnName("quality_Mod")
                    .HasColumnType("int(11)");

                entity.Property(e => e._1).HasColumnName("1");

                entity.Property(e => e._2).HasColumnName("2");

                entity.Property(e => e._3).HasColumnName("3");

                entity.Property(e => e._4).HasColumnName("4");

                entity.Property(e => e._5).HasColumnName("5");

                entity.Property(e => e._6).HasColumnName("6");

                entity.Property(e => e._7).HasColumnName("7");

                entity.Property(e => e._8).HasColumnName("8");
            });

            modelBuilder.Entity<TreasureScroll>(entity =>
            {
                entity.ToTable("treasure_scroll");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureSpellBase>(entity =>
            {
                entity.ToTable("treasure_spell_base");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Power)
                    .HasColumnName("power")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureSpellData>(entity =>
            {
                entity.ToTable("treasure_spell_data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Diff)
                    .HasColumnName("diff")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Duration)
                    .HasColumnName("duration")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Family)
                    .HasColumnName("family")
                    .HasColumnType("int(11)");

                entity.Property(e => e.FamilyOverride)
                    .HasColumnName("family_Override")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsFellow)
                    .HasColumnName("is_Fellow")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsInstant)
                    .HasColumnName("is_Instant")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsOff)
                    .HasColumnName("is_Off")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IsUntargeted)
                    .HasColumnName("is_Untargeted")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.SchoolID)
                    .HasColumnName("school_I_D")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpellID)
                    .HasColumnName("spell_I_D")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TurnTo)
                    .HasColumnName("turn_To")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Words)
                    .IsRequired()
                    .HasColumnName("words")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TreasureSpellDesc>(entity =>
            {
                entity.ToTable("treasure_spell_desc");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Descriptor)
                    .IsRequired()
                    .HasColumnName("descriptor")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Diff)
                    .HasColumnName("diff")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Mana)
                    .HasColumnName("mana")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.NoDescEntry)
                    .HasColumnName("no_Desc_Entry")
                    .HasColumnType("int(11)");

                entity.Property(e => e.SpellID)
                    .HasColumnName("spell_I_D")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TargetType)
                    .HasColumnName("target_Type")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureSpellDist>(entity =>
            {
                entity.ToTable("treasure_spell_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Group)
                    .HasColumnName("group")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureSpellLevel>(entity =>
            {
                entity.ToTable("treasure_spell_level");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureSpellLevelChance>(entity =>
            {
                entity.ToTable("treasure_spell_level_chance");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureSpellLevelProgression>(entity =>
            {
                entity.ToTable("treasure_spell_level_progression");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lvl1)
                    .HasColumnName("lvl1")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lvl2)
                    .HasColumnName("lvl2")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lvl3)
                    .HasColumnName("lvl3")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lvl4)
                    .HasColumnName("lvl4")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lvl5)
                    .HasColumnName("lvl5")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lvl6)
                    .HasColumnName("lvl6")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lvl7)
                    .HasColumnName("lvl7")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Lvl8)
                    .HasColumnName("lvl8")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureTierAdjust>(entity =>
            {
                entity.ToTable("treasure_tier_adjust");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AdjustTier)
                    .HasColumnName("adjust_Tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWcid>(entity =>
            {
                entity.HasKey(e => e.Wcid)
                    .HasName("PRIMARY");

                entity.ToTable("treasure_wcid");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.DidMut)
                    .HasColumnName("did_Mut")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TSysDID)
                    .HasColumnName("t_Sys_D_I_D")
                    .HasColumnType("int(11)");

                entity.Property(e => e.TSysInt)
                    .HasColumnName("t_Sys_Int")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WeenieName)
                    .IsRequired()
                    .HasColumnName("weenie_Name")
                    .HasColumnType("varchar(50)");
            });

            modelBuilder.Entity<TreasureWeapon>(entity =>
            {
                entity.ToTable("treasure_weapon");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.WeaponSubtable)
                    .HasColumnName("weapon_Subtable")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponAtlatl>(entity =>
            {
                entity.ToTable("treasure_weapon_atlatl");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponAttackDefenseMod>(entity =>
            {
                entity.ToTable("treasure_weapon_attack_defense_mod");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Max).HasColumnName("max");

                entity.Property(e => e.Min).HasColumnName("min");

                entity.Property(e => e.QualityLevel)
                    .HasColumnName("quality_Level")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponAxe1>(entity =>
            {
                entity.ToTable("treasure_weapon_axe1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponAxe2>(entity =>
            {
                entity.ToTable("treasure_weapon_axe2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponAxe3>(entity =>
            {
                entity.ToTable("treasure_weapon_axe3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponBow1>(entity =>
            {
                entity.ToTable("treasure_weapon_bow1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponBow2>(entity =>
            {
                entity.ToTable("treasure_weapon_bow2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponBow3>(entity =>
            {
                entity.ToTable("treasure_weapon_bow3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponCrossbow>(entity =>
            {
                entity.ToTable("treasure_weapon_crossbow");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponDagger1>(entity =>
            {
                entity.ToTable("treasure_weapon_dagger1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponDagger2>(entity =>
            {
                entity.ToTable("treasure_weapon_dagger2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponDagger3>(entity =>
            {
                entity.ToTable("treasure_weapon_dagger3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponMace1>(entity =>
            {
                entity.ToTable("treasure_weapon_mace1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponMace2>(entity =>
            {
                entity.ToTable("treasure_weapon_mace2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponMace3>(entity =>
            {
                entity.ToTable("treasure_weapon_mace3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponMeleeSpell>(entity =>
            {
                entity.ToTable("treasure_weapon_melee_spell");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponMissileSpell>(entity =>
            {
                entity.ToTable("treasure_weapon_missile_spell");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponSkillRemap>(entity =>
            {
                entity.ToTable("treasure_weapon_skill_remap");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Skill)
                    .HasColumnName("skill")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Subskill)
                    .HasColumnName("subskill")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponSpear1>(entity =>
            {
                entity.ToTable("treasure_weapon_spear1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponSpear2>(entity =>
            {
                entity.ToTable("treasure_weapon_spear2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponSpear3>(entity =>
            {
                entity.ToTable("treasure_weapon_spear3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponSpeedMod>(entity =>
            {
                entity.ToTable("treasure_weapon_speed_mod");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Max).HasColumnName("max");

                entity.Property(e => e.Min).HasColumnName("min");

                entity.Property(e => e.QualityLevel)
                    .HasColumnName("quality_Level")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponStaff1>(entity =>
            {
                entity.ToTable("treasure_weapon_staff1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponStaff2>(entity =>
            {
                entity.ToTable("treasure_weapon_staff2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponStaff3>(entity =>
            {
                entity.ToTable("treasure_weapon_staff3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponSword1>(entity =>
            {
                entity.ToTable("treasure_weapon_sword1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponSword2>(entity =>
            {
                entity.ToTable("treasure_weapon_sword2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponSword3>(entity =>
            {
                entity.ToTable("treasure_weapon_sword3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponUnarmed1>(entity =>
            {
                entity.ToTable("treasure_weapon_unarmed1");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponUnarmed2>(entity =>
            {
                entity.ToTable("treasure_weapon_unarmed2");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWeaponUnarmed3>(entity =>
            {
                entity.ToTable("treasure_weapon_unarmed3");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Wcid)
                    .HasColumnName("wcid")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<TreasureWielded>(entity =>
            {
                entity.ToTable("treasure_wielded");

                entity.HasIndex(e => e.TreasureType)
                    .HasName("treasureType_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ContinuesPreviousSet)
                    .HasColumnName("continues_Previous_Set")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.HasSubSet)
                    .HasColumnName("has_Sub_Set")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PaletteId).HasColumnName("palette_Id");

                entity.Property(e => e.Probability).HasColumnName("probability");

                entity.Property(e => e.SetStart)
                    .HasColumnName("set_Start")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Shade).HasColumnName("shade");

                entity.Property(e => e.StackSize)
                    .HasColumnName("stack_Size")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.StackSizeVariance).HasColumnName("stack_Size_Variance");

                entity.Property(e => e.TreasureType).HasColumnName("treasure_Type");

                entity.Property(e => e.Unknown1).HasColumnName("unknown_1");

                entity.Property(e => e.Unknown10).HasColumnName("unknown_10");

                entity.Property(e => e.Unknown11).HasColumnName("unknown_11");

                entity.Property(e => e.Unknown12).HasColumnName("unknown_12");

                entity.Property(e => e.Unknown3).HasColumnName("unknown_3");

                entity.Property(e => e.Unknown4).HasColumnName("unknown_4");

                entity.Property(e => e.Unknown5).HasColumnName("unknown_5");

                entity.Property(e => e.Unknown9).HasColumnName("unknown_9");

                entity.Property(e => e.WeenieClassId).HasColumnName("weenie_Class_Id");
            });

            modelBuilder.Entity<TreasureWorkmanshipDist>(entity =>
            {
                entity.ToTable("treasure_workmanship_dist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Chance).HasColumnName("chance");

                entity.Property(e => e.Tier)
                    .HasColumnName("tier")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Workmanship)
                    .HasColumnName("workmanship")
                    .HasColumnType("int(11)");
            });

            modelBuilder.Entity<Version>(entity =>
            {
                entity.ToTable("version");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.BaseVersion)
                    .HasColumnName("base_Version")
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.PatchVersion)
                    .HasColumnName("patch_Version")
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Weenie>(entity =>
            {
                entity.HasKey(e => e.ClassId)
                    .HasName("PRIMARY");

                entity.ToTable("weenie");

                entity.HasIndex(e => e.ClassName)
                    .HasName("className_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.ClassId).HasColumnName("class_Id");

                entity.Property(e => e.ClassName)
                    .IsRequired()
                    .HasColumnName("class_Name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.LastModified)
                    .HasColumnName("last_Modified")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("'current_timestamp()'")
                    .ValueGeneratedOnAddOrUpdate();

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasColumnType("int(5)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<WeeniePropertiesAnimPart>(entity =>
            {
                entity.ToTable("weenie_properties_anim_part");

                entity.HasIndex(e => new { e.ObjectId, e.Index })
                    .HasName("object_Id_index_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnimationId).HasColumnName("animation_Id");

                entity.Property(e => e.Index).HasColumnName("index");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesAnimPart)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_animpart");
            });

            modelBuilder.Entity<WeeniePropertiesAttribute>(entity =>
            {
                entity.ToTable("weenie_properties_attribute");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_attribute_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CPSpent).HasColumnName("c_P_Spent");

                entity.Property(e => e.InitLevel).HasColumnName("init_Level");

                entity.Property(e => e.LevelFromCP).HasColumnName("level_From_C_P");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesAttribute)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_attribute");
            });

            modelBuilder.Entity<WeeniePropertiesAttribute2nd>(entity =>
            {
                entity.ToTable("weenie_properties_attribute_2nd");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_attribute2nd_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CPSpent).HasColumnName("c_P_Spent");

                entity.Property(e => e.CurrentLevel).HasColumnName("current_Level");

                entity.Property(e => e.InitLevel).HasColumnName("init_Level");

                entity.Property(e => e.LevelFromCP).HasColumnName("level_From_C_P");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesAttribute2nd)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_attribute2nd");
            });

            modelBuilder.Entity<WeeniePropertiesBodyPart>(entity =>
            {
                entity.ToTable("weenie_properties_body_part");

                entity.HasIndex(e => new { e.ObjectId, e.Key })
                    .HasName("wcid_bodypart_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ArmorVsAcid)
                    .HasColumnName("armor_Vs_Acid")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ArmorVsBludgeon)
                    .HasColumnName("armor_Vs_Bludgeon")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ArmorVsCold)
                    .HasColumnName("armor_Vs_Cold")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ArmorVsElectric)
                    .HasColumnName("armor_Vs_Electric")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ArmorVsFire)
                    .HasColumnName("armor_Vs_Fire")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ArmorVsNether)
                    .HasColumnName("armor_Vs_Nether")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ArmorVsPierce)
                    .HasColumnName("armor_Vs_Pierce")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ArmorVsSlash)
                    .HasColumnName("armor_Vs_Slash")
                    .HasColumnType("int(10)");

                entity.Property(e => e.BH)
                    .HasColumnName("b_h")
                    .HasColumnType("int(10)");

                entity.Property(e => e.BaseArmor)
                    .HasColumnName("base_Armor")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DType)
                    .HasColumnName("d_Type")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DVal)
                    .HasColumnName("d_Val")
                    .HasColumnType("int(10)");

                entity.Property(e => e.DVar).HasColumnName("d_Var");

                entity.Property(e => e.HLB).HasColumnName("h_l_b");

                entity.Property(e => e.HLF).HasColumnName("h_l_f");

                entity.Property(e => e.HRB).HasColumnName("h_r_b");

                entity.Property(e => e.HRF).HasColumnName("h_r_f");

                entity.Property(e => e.Key).HasColumnName("key");

                entity.Property(e => e.LLB).HasColumnName("l_l_b");

                entity.Property(e => e.LLF).HasColumnName("l_l_f");

                entity.Property(e => e.LRB).HasColumnName("l_r_b");

                entity.Property(e => e.LRF).HasColumnName("l_r_f");

                entity.Property(e => e.MLB).HasColumnName("m_l_b");

                entity.Property(e => e.MLF).HasColumnName("m_l_f");

                entity.Property(e => e.MRB).HasColumnName("m_r_b");

                entity.Property(e => e.MRF).HasColumnName("m_r_f");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesBodyPart)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_bodypart");
            });

            modelBuilder.Entity<WeeniePropertiesBook>(entity =>
            {
                entity.ToTable("weenie_properties_book");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("wcid_bookdata_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MaxNumCharsPerPage)
                    .HasColumnName("max_Num_Chars_Per_Page")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'1000'");

                entity.Property(e => e.MaxNumPages)
                    .HasColumnName("max_Num_Pages")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.HasOne(d => d.Object)
                    .WithOne(p => p.WeeniePropertiesBook)
                    .HasForeignKey<WeeniePropertiesBook>(d => d.ObjectId)
                    .HasConstraintName("wcid_bookdata");
            });

            modelBuilder.Entity<WeeniePropertiesBookPageData>(entity =>
            {
                entity.ToTable("weenie_properties_book_page_data");

                entity.HasIndex(e => new { e.ObjectId, e.PageId })
                    .HasName("wcid_pageid_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorAccount)
                    .IsRequired()
                    .HasColumnName("author_Account")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("'prewritten'");

                entity.Property(e => e.AuthorId).HasColumnName("author_Id");

                entity.Property(e => e.AuthorName)
                    .IsRequired()
                    .HasColumnName("author_Name")
                    .HasColumnType("varchar(255)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.IgnoreAuthor)
                    .HasColumnName("ignore_Author")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.PageId).HasColumnName("page_Id");

                entity.Property(e => e.PageText)
                    .IsRequired()
                    .HasColumnName("page_Text")
                    .HasColumnType("text");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesBookPageData)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_pagedata");
            });

            modelBuilder.Entity<WeeniePropertiesBool>(entity =>
            {
                entity.ToTable("weenie_properties_bool");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_bool_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("bit(1)");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesBool)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_bool");
            });

            modelBuilder.Entity<WeeniePropertiesCreateList>(entity =>
            {
                entity.ToTable("weenie_properties_create_list");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("wcid_createlist");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DestinationType)
                    .HasColumnName("destination_Type")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Palette)
                    .HasColumnName("palette")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.Shade).HasColumnName("shade");

                entity.Property(e => e.StackSize)
                    .HasColumnName("stack_Size")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TryToBond)
                    .HasColumnName("try_To_Bond")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.WeenieClassId).HasColumnName("weenie_Class_Id");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesCreateList)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_createlist");
            });

            modelBuilder.Entity<WeeniePropertiesDID>(entity =>
            {
                entity.ToTable("weenie_properties_d_i_d");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_did_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesDID)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_did");
            });

            modelBuilder.Entity<WeeniePropertiesEmote>(entity =>
            {
                entity.ToTable("weenie_properties_emote");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("wcid_emote");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Category).HasColumnName("category");

                entity.Property(e => e.MaxHealth).HasColumnName("max_Health");

                entity.Property(e => e.MinHealth).HasColumnName("min_Health");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Probability)
                    .HasColumnName("probability")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Quest)
                    .HasColumnName("quest")
                    .HasColumnType("text");

                entity.Property(e => e.Style).HasColumnName("style");

                entity.Property(e => e.Substyle).HasColumnName("substyle");

                entity.Property(e => e.VendorType)
                    .HasColumnName("vendor_Type")
                    .HasColumnType("int(10)");

                entity.Property(e => e.WeenieClassId).HasColumnName("weenie_Class_Id");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesEmote)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_emote");
            });

            modelBuilder.Entity<WeeniePropertiesEmoteAction>(entity =>
            {
                entity.ToTable("weenie_properties_emote_action");

                entity.HasIndex(e => new { e.EmoteId, e.Order })
                    .HasName("emoteid_order_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Amount)
                    .HasColumnName("amount")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Amount64)
                    .HasColumnName("amount_64")
                    .HasColumnType("bigint(10)");

                entity.Property(e => e.AnglesW).HasColumnName("angles_W");

                entity.Property(e => e.AnglesX).HasColumnName("angles_X");

                entity.Property(e => e.AnglesY).HasColumnName("angles_Y");

                entity.Property(e => e.AnglesZ).HasColumnName("angles_Z");

                entity.Property(e => e.Delay)
                    .HasColumnName("delay")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.DestinationType)
                    .HasColumnName("destination_Type")
                    .HasColumnType("tinyint(5)");

                entity.Property(e => e.Display)
                    .HasColumnName("display")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.EmoteId).HasColumnName("emote_Id");

                entity.Property(e => e.Extent)
                    .HasColumnName("extent")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.HeroXP64)
                    .HasColumnName("hero_X_P_64")
                    .HasColumnType("bigint(10)");

                entity.Property(e => e.Max)
                    .HasColumnName("max")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Max64)
                    .HasColumnName("max_64")
                    .HasColumnType("bigint(10)");

                entity.Property(e => e.MaxDbl).HasColumnName("max_Dbl");

                entity.Property(e => e.Message)
                    .HasColumnName("message")
                    .HasColumnType("text");

                entity.Property(e => e.Min)
                    .HasColumnName("min")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Min64)
                    .HasColumnName("min_64")
                    .HasColumnType("bigint(10)");

                entity.Property(e => e.MinDbl).HasColumnName("min_Dbl");

                entity.Property(e => e.Motion)
                    .HasColumnName("motion")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ObjCellId).HasColumnName("obj_Cell_Id");

                entity.Property(e => e.Order).HasColumnName("order");

                entity.Property(e => e.OriginX).HasColumnName("origin_X");

                entity.Property(e => e.OriginY).HasColumnName("origin_Y");

                entity.Property(e => e.OriginZ).HasColumnName("origin_Z");

                entity.Property(e => e.PScript)
                    .HasColumnName("p_Script")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Palette)
                    .HasColumnName("palette")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Percent).HasColumnName("percent");

                entity.Property(e => e.Shade).HasColumnName("shade");

                entity.Property(e => e.Sound)
                    .HasColumnName("sound")
                    .HasColumnType("int(10)");

                entity.Property(e => e.SpellId)
                    .HasColumnName("spell_Id")
                    .HasColumnType("int(10)");

                entity.Property(e => e.StackSize)
                    .HasColumnName("stack_Size")
                    .HasColumnType("int(10)");

                entity.Property(e => e.Stat)
                    .HasColumnName("stat")
                    .HasColumnType("int(10)");

                entity.Property(e => e.TestString)
                    .HasColumnName("test_String")
                    .HasColumnType("text");

                entity.Property(e => e.TreasureClass)
                    .HasColumnName("treasure_Class")
                    .HasColumnType("int(10)");

                entity.Property(e => e.TreasureType)
                    .HasColumnName("treasure_Type")
                    .HasColumnType("int(10)");

                entity.Property(e => e.TryToBond)
                    .HasColumnName("try_To_Bond")
                    .HasColumnType("bit(1)");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.WealthRating)
                    .HasColumnName("wealth_Rating")
                    .HasColumnType("int(10)");

                entity.Property(e => e.WeenieClassId).HasColumnName("weenie_Class_Id");

                entity.HasOne(d => d.Emote)
                    .WithMany(p => p.WeeniePropertiesEmoteAction)
                    .HasForeignKey(d => d.EmoteId)
                    .HasConstraintName("emoteid_emoteaction");
            });

            modelBuilder.Entity<WeeniePropertiesEventFilter>(entity =>
            {
                entity.ToTable("weenie_properties_event_filter");

                entity.HasIndex(e => new { e.ObjectId, e.Event })
                    .HasName("wcid_eventfilter_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Event)
                    .HasColumnName("event")
                    .HasColumnType("int(10)");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesEventFilter)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_eventfilter");
            });

            modelBuilder.Entity<WeeniePropertiesFloat>(entity =>
            {
                entity.ToTable("weenie_properties_float");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_float_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesFloat)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_float");
            });

            modelBuilder.Entity<WeeniePropertiesGenerator>(entity =>
            {
                entity.ToTable("weenie_properties_generator");

                entity.HasIndex(e => e.ObjectId)
                    .HasName("wcid_generator");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnglesW).HasColumnName("angles_W");

                entity.Property(e => e.AnglesX).HasColumnName("angles_X");

                entity.Property(e => e.AnglesY).HasColumnName("angles_Y");

                entity.Property(e => e.AnglesZ).HasColumnName("angles_Z");

                entity.Property(e => e.Delay).HasColumnName("delay");

                entity.Property(e => e.InitCreate)
                    .HasColumnName("init_Create")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.MaxCreate)
                    .HasColumnName("max_Create")
                    .HasColumnType("int(10)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.ObjCellId).HasColumnName("obj_Cell_Id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.OriginX).HasColumnName("origin_X");

                entity.Property(e => e.OriginY).HasColumnName("origin_Y");

                entity.Property(e => e.OriginZ).HasColumnName("origin_Z");

                entity.Property(e => e.PaletteId).HasColumnName("palette_Id");

                entity.Property(e => e.Probability)
                    .HasColumnName("probability")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Shade).HasColumnName("shade");

                entity.Property(e => e.StackSize)
                    .HasColumnName("stack_Size")
                    .HasColumnType("int(10)");

                entity.Property(e => e.WeenieClassId).HasColumnName("weenie_Class_Id");

                entity.Property(e => e.WhenCreate)
                    .HasColumnName("when_Create")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.WhereCreate)
                    .HasColumnName("where_Create")
                    .HasDefaultValueSql("'4'");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesGenerator)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_generator");
            });

            modelBuilder.Entity<WeeniePropertiesIID>(entity =>
            {
                entity.ToTable("weenie_properties_i_i_d");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_iid_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Value).HasColumnName("value");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesIID)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_iid");
            });

            modelBuilder.Entity<WeeniePropertiesInt>(entity =>
            {
                entity.ToTable("weenie_properties_int");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_int_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesInt)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_int");
            });

            modelBuilder.Entity<WeeniePropertiesInt64>(entity =>
            {
                entity.ToTable("weenie_properties_int64");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_int64_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Value)
                    .HasColumnName("value")
                    .HasColumnType("bigint(10)");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesInt64)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_int64");
            });

            modelBuilder.Entity<WeeniePropertiesPalette>(entity =>
            {
                entity.ToTable("weenie_properties_palette");

                entity.HasIndex(e => new { e.ObjectId, e.SubPaletteId, e.Offset, e.Length })
                    .HasName("object_Id_subPaletteId_offset_length_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Offset).HasColumnName("offset");

                entity.Property(e => e.SubPaletteId).HasColumnName("sub_Palette_Id");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesPalette)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_palette");
            });

            modelBuilder.Entity<WeeniePropertiesPosition>(entity =>
            {
                entity.ToTable("weenie_properties_position");

                entity.HasIndex(e => new { e.ObjectId, e.PositionType })
                    .HasName("wcid_position_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AnglesW).HasColumnName("angles_W");

                entity.Property(e => e.AnglesX).HasColumnName("angles_X");

                entity.Property(e => e.AnglesY).HasColumnName("angles_Y");

                entity.Property(e => e.AnglesZ).HasColumnName("angles_Z");

                entity.Property(e => e.ObjCellId).HasColumnName("obj_Cell_Id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.OriginX).HasColumnName("origin_X");

                entity.Property(e => e.OriginY).HasColumnName("origin_Y");

                entity.Property(e => e.OriginZ).HasColumnName("origin_Z");

                entity.Property(e => e.PositionType).HasColumnName("position_Type");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesPosition)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_position");
            });

            modelBuilder.Entity<WeeniePropertiesSkill>(entity =>
            {
                entity.ToTable("weenie_properties_skill");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_skill_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.InitLevel).HasColumnName("init_Level");

                entity.Property(e => e.LastUsedTime).HasColumnName("last_Used_Time");

                entity.Property(e => e.LevelFromPP).HasColumnName("level_From_P_P");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.PP).HasColumnName("p_p");

                entity.Property(e => e.ResistanceAtLastCheck).HasColumnName("resistance_At_Last_Check");

                entity.Property(e => e.SAC).HasColumnName("s_a_c");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesSkill)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_skill");
            });

            modelBuilder.Entity<WeeniePropertiesSpellBook>(entity =>
            {
                entity.ToTable("weenie_properties_spell_book");

                entity.HasIndex(e => new { e.ObjectId, e.Spell })
                    .HasName("wcid_spellbook_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Probability)
                    .HasColumnName("probability")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Spell)
                    .HasColumnName("spell")
                    .HasColumnType("int(10)");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesSpellBook)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_spellbook");
            });

            modelBuilder.Entity<WeeniePropertiesString>(entity =>
            {
                entity.ToTable("weenie_properties_string");

                entity.HasIndex(e => new { e.ObjectId, e.Type })
                    .HasName("wcid_string_type_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.Type).HasColumnName("type");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasColumnName("value")
                    .HasColumnType("text");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesString)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_string");
            });

            modelBuilder.Entity<WeeniePropertiesTextureMap>(entity =>
            {
                entity.ToTable("weenie_properties_texture_map");

                entity.HasIndex(e => new { e.ObjectId, e.Index, e.OldId })
                    .HasName("object_Id_index_oldId_uidx")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Index).HasColumnName("index");

                entity.Property(e => e.NewId).HasColumnName("new_Id");

                entity.Property(e => e.ObjectId).HasColumnName("object_Id");

                entity.Property(e => e.OldId).HasColumnName("old_Id");

                entity.HasOne(d => d.Object)
                    .WithMany(p => p.WeeniePropertiesTextureMap)
                    .HasForeignKey(d => d.ObjectId)
                    .HasConstraintName("wcid_texturemap");
            });
        }
    }
}
