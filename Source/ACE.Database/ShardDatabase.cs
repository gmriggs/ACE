using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

using log4net;

using ACE.Database.Entity;
using ACE.Database.Models.Shard;
using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;

namespace ACE.Database
{
    public class ShardDatabase
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public bool Exists(bool retryUntilFound)
        {
            var config = Common.ConfigManager.Config.MySql.World;

            for (; ; )
            {
                using (var context = new ShardDbContext())
                {
                    if (((RelationalDatabaseCreator)context.Database.GetService<IDatabaseCreator>()).Exists())
                    {
                        log.Debug($"Successfully connected to {config.Database} database on {config.Host}:{config.Port}.");
                        return true;
                    }
                }

                log.Error($"Attempting to reconnect to {config.Database} database on {config.Host}:{config.Port} in 5 seconds...");

                if (retryUntilFound)
                    Thread.Sleep(5000);
                else
                    return false;
            }
        }


        /// <summary>
        /// Will return uint.MaxValue if no records were found within the range provided.
        /// </summary>
        public uint GetMaxGuidFoundInRange(uint min, uint max)
        {
            using (var context = new ShardDbContext())
            {
                var results = context.Biota
                    .AsNoTracking()
                    .Where(r => r.Id >= min && r.Id <= max)
                    .ToList();

                if (!results.Any())
                    return uint.MaxValue;

                var maxId = min;

                foreach (var result in results)
                {
                    if (result.Id > maxId)
                        maxId = result.Id;
                }

                return maxId;
            }
        }


        public List<Character> GetCharacters(uint accountId, bool includeDeleted)
        {
            using (var context = new ShardDbContext())
            {
                var results = context.Character
                    .Include(r => r.CharacterPropertiesContract)
                    .Include(r => r.CharacterPropertiesFillCompBook)
                    .Include(r => r.CharacterPropertiesFriendList)
                    .Include(r => r.CharacterPropertiesQuestRegistry)
                    .Include(r => r.CharacterPropertiesShortcutBar)
                    .Include(r => r.CharacterPropertiesSpellBar)
                    .Include(r => r.CharacterPropertiesTitleBook)
                    .AsNoTracking()
                    .Where(r => r.AccountId == accountId && (includeDeleted || !r.IsDeleted))
                    .ToList();

                return results;
            }
        }

        public List<Character> GetAllCharacters()
        {
            using (var context = new ShardDbContext())
            {
                var results = context.Character
                    .AsNoTracking()
                    .ToList();

                return results;
            }
        }

        public List<Character> GetAllegianceCharacters(uint monarchID)
        {
            using (var context = new ShardDbContext())
            {
                /*var results = context.Character
                    .AsNoTracking()
                    .Where(r => r.Biota.BiotaProperties)
                    .ToList();

                return results;*/
            }
            return null;
        }

        public bool IsCharacterNameAvailable(string name)
        {
            using (var context = new ShardDbContext())
            {
                var result = context.Character
                    .AsNoTracking()
                    .Where(r => !r.IsDeleted)
                    .Where(r => !(r.DeleteTime > 0))
                    .FirstOrDefault(r => r.Name == name);

                return result == null;
            }
        }

        public bool IsCharacterPlussed(uint biotaId)
        {
            using (var context = new ShardDbContext())
            {
                var result = context.Biota
                    .AsNoTracking()
                    .Include(r => r.BiotaPropertiesBool)
                    .FirstOrDefault(r => r.Id == biotaId);

                if (result == null)
                    return false;

                if (result.GetProperty(PropertyBool.IsAdmin, new ReaderWriterLockSlim()) ?? false)
                    return true;
                if (result.GetProperty(PropertyBool.IsArch, new ReaderWriterLockSlim()) ?? false)
                    return true;
                if (result.GetProperty(PropertyBool.IsPsr, new ReaderWriterLockSlim()) ?? false)
                    return true;
                if (result.GetProperty(PropertyBool.IsSentinel, new ReaderWriterLockSlim()) ?? false)
                    return true;

                if (result.WeenieType == (int)WeenieType.Admin || result.WeenieType == (int)WeenieType.Sentinel)
                    return true;

                return false;
            }
        }

        public bool AddCharacterInParallel(Biota biota, IEnumerable<Biota> possessions, Character character)
        {
            if (!SaveBiota(biota, new ReaderWriterLockSlim()))
                return false; // Biota save failed which mean Character fails.

            if (!SaveBiotasInParallel(possessions))
                return false;

            using (var context = new ShardDbContext())
            {
                context.Character.Add(character);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    // Character name might be in use or some other fault
                    log.Error($"AddCharacter failed with exception: {ex}");
                    return false;
                }
            }
        }

        public bool DeleteOrRestoreCharacter(ulong unixTime, uint guid)
        {
            using (var context = new ShardDbContext())
            {
                var result = context.Character
                    .FirstOrDefault(r => r.Id == guid);

                if (result != null)
                {
                    result.DeleteTime = unixTime;
                    result.IsDeleted = false;
                }
                else
                    return false;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error($"DeleteOrRestoreCharacter failed with exception: {ex}");
                    return false;
                }
            }
        }

        public bool MarkCharacterDeleted(uint guid)
        {
            using (var context = new ShardDbContext())
            {
                var result = context.Character
                    .FirstOrDefault(r => r.Id == guid);

                if (result != null)
                    result.IsDeleted = true;
                else
                    return false;

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    log.Error($"MarkCharacterDeleted failed with exception: {ex}");
                    return false;
                }
            }
        }

        public bool SaveCharacter(Character character)
        {
            using (var context = new ShardDbContext())
            {
                context.Character.Update(character);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    // Character name might be in use or some other fault
                    log.Error($"SaveCharacter failed with exception: {ex}");
                    return false;
                }
            }
        }


        [Flags]
        enum PopulatedCollectionFlags
        {
            BiotaPropertiesAnimPart             = 0x1,
            BiotaPropertiesAttribute            = 0x2,
            BiotaPropertiesAttribute2nd         = 0x4,
            BiotaPropertiesBodyPart             = 0x8,
            BiotaPropertiesBook                 = 0x10,
            BiotaPropertiesBookPageData         = 0x20,
            BiotaPropertiesBool                 = 0x40,
            BiotaPropertiesCreateList           = 0x80,
            BiotaPropertiesDID                  = 0x100,
            BiotaPropertiesEmote                = 0x200,
            BiotaPropertiesEnchantmentRegistry  = 0x400,
            BiotaPropertiesEventFilter          = 0x800,
            BiotaPropertiesFloat                = 0x1000,
            BiotaPropertiesGenerator            = 0x2000,
            BiotaPropertiesIID                  = 0x4000,
            BiotaPropertiesInt                  = 0x8000,
            BiotaPropertiesInt64                = 0x10000,
            BiotaPropertiesPalette              = 0x20000,
            BiotaPropertiesPosition             = 0x40000,
            BiotaPropertiesSkill                = 0x80000,
            BiotaPropertiesSpellBook            = 0x100000,
            BiotaPropertiesString               = 0x200000,
            BiotaPropertiesTextureMap           = 0x400000
        }

        private static void SetBiotaPopulatedCollections(Biota biota)
        {
            PopulatedCollectionFlags populatedCollectionFlags = 0;

            if (biota.BiotaPropertiesAnimPart != null && biota.BiotaPropertiesAnimPart.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesAnimPart;
            if (biota.BiotaPropertiesAttribute != null && biota.BiotaPropertiesAttribute.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesAttribute;
            if (biota.BiotaPropertiesAttribute2nd != null && biota.BiotaPropertiesAttribute2nd.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesAttribute2nd;
            if (biota.BiotaPropertiesBodyPart != null && biota.BiotaPropertiesBodyPart.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesBodyPart;
            if (biota.BiotaPropertiesBook != null) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesBook;
            if (biota.BiotaPropertiesBookPageData != null && biota.BiotaPropertiesBookPageData.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesBookPageData;
            if (biota.BiotaPropertiesBool != null && biota.BiotaPropertiesBool.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesBool;
            if (biota.BiotaPropertiesCreateList != null && biota.BiotaPropertiesCreateList.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesCreateList;
            if (biota.BiotaPropertiesDID != null && biota.BiotaPropertiesDID.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesDID;
            if (biota.BiotaPropertiesEmote != null && biota.BiotaPropertiesEmote.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesEmote;
            if (biota.BiotaPropertiesEnchantmentRegistry != null && biota.BiotaPropertiesEnchantmentRegistry.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesEnchantmentRegistry;
            if (biota.BiotaPropertiesEventFilter != null && biota.BiotaPropertiesEventFilter.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesEventFilter;
            if (biota.BiotaPropertiesFloat != null && biota.BiotaPropertiesFloat.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesFloat;
            if (biota.BiotaPropertiesGenerator != null && biota.BiotaPropertiesGenerator.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesGenerator;
            if (biota.BiotaPropertiesIID != null && biota.BiotaPropertiesIID.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesIID;
            if (biota.BiotaPropertiesInt != null && biota.BiotaPropertiesInt.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesInt;
            if (biota.BiotaPropertiesInt64 != null && biota.BiotaPropertiesInt64.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesInt64;
            if (biota.BiotaPropertiesPalette != null && biota.BiotaPropertiesPalette.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesPalette;
            if (biota.BiotaPropertiesPosition != null && biota.BiotaPropertiesPosition.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesPosition;
            if (biota.BiotaPropertiesSkill != null && biota.BiotaPropertiesSkill.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesSkill;
            if (biota.BiotaPropertiesSpellBook != null && biota.BiotaPropertiesSpellBook.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesSpellBook;
            if (biota.BiotaPropertiesString != null && biota.BiotaPropertiesString.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesString;
            if (biota.BiotaPropertiesTextureMap != null && biota.BiotaPropertiesTextureMap.Count > 0) populatedCollectionFlags |= PopulatedCollectionFlags.BiotaPropertiesTextureMap;

            biota.PopulatedCollectionFlags = (uint)populatedCollectionFlags;
        }

        private static Biota GetBiota(ShardDbContext context, uint id)
        {
            var biota = context.Biota
            .FirstOrDefault(r => r.Id == id);

            if (biota == null)
                return null;

            PopulatedCollectionFlags populatedCollectionFlags = (PopulatedCollectionFlags)biota.PopulatedCollectionFlags;

            // todo: There are gains to be had here if we can conditionally perform mulitple .Include (.Where) statements in a single query.
            // todo: Until I figure out how to do that, this is still pretty good. Mag-nus 2018-08-10
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesAnimPart)) biota.BiotaPropertiesAnimPart = context.BiotaPropertiesAnimPart.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesAttribute)) biota.BiotaPropertiesAttribute = context.BiotaPropertiesAttribute.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesAttribute2nd)) biota.BiotaPropertiesAttribute2nd = context.BiotaPropertiesAttribute2nd.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesBodyPart)) biota.BiotaPropertiesBodyPart = context.BiotaPropertiesBodyPart.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesBook)) biota.BiotaPropertiesBook = context.BiotaPropertiesBook.FirstOrDefault(r => r.ObjectId == biota.Id);
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesBookPageData)) biota.BiotaPropertiesBookPageData = context.BiotaPropertiesBookPageData.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesBool)) biota.BiotaPropertiesBool = context.BiotaPropertiesBool.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesCreateList)) biota.BiotaPropertiesCreateList = context.BiotaPropertiesCreateList.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesDID)) biota.BiotaPropertiesDID = context.BiotaPropertiesDID.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesEmote)) biota.BiotaPropertiesEmote = context.BiotaPropertiesEmote.Include(r => r.BiotaPropertiesEmoteAction).Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesEnchantmentRegistry)) biota.BiotaPropertiesEnchantmentRegistry = context.BiotaPropertiesEnchantmentRegistry.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesEventFilter)) biota.BiotaPropertiesEventFilter = context.BiotaPropertiesEventFilter.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesFloat)) biota.BiotaPropertiesFloat = context.BiotaPropertiesFloat.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesGenerator)) biota.BiotaPropertiesGenerator = context.BiotaPropertiesGenerator.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesIID)) biota.BiotaPropertiesIID = context.BiotaPropertiesIID.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesInt)) biota.BiotaPropertiesInt = context.BiotaPropertiesInt.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesInt64)) biota.BiotaPropertiesInt64 = context.BiotaPropertiesInt64.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesPalette)) biota.BiotaPropertiesPalette = context.BiotaPropertiesPalette.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesPosition)) biota.BiotaPropertiesPosition = context.BiotaPropertiesPosition.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesSkill)) biota.BiotaPropertiesSkill = context.BiotaPropertiesSkill.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesSpellBook)) biota.BiotaPropertiesSpellBook = context.BiotaPropertiesSpellBook.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesString)) biota.BiotaPropertiesString = context.BiotaPropertiesString.Where(r => r.ObjectId == biota.Id).ToList();
            if (populatedCollectionFlags.HasFlag(PopulatedCollectionFlags.BiotaPropertiesTextureMap)) biota.BiotaPropertiesTextureMap = context.BiotaPropertiesTextureMap.Where(r => r.ObjectId == biota.Id).ToList();

            return biota;
        }

        public Biota GetBiota(uint id)
        {
            using (var context = new ShardDbContext())
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                return GetBiota(context, id);
            }
        }

        public bool SaveBiota(Biota biota, ReaderWriterLockSlim rwLock)
        {
            using (var context = new ShardDbContext())
            {
                rwLock.EnterWriteLock();
                try
                {
                    SetBiotaPopulatedCollections(biota);

                    // This pattern is described here: https://docs.microsoft.com/en-us/ef/core/saving/disconnected-entities
                    // You'll notice though that we're not using the recommended: context.Entry(existingEntry).CurrentValues.SetValues(newEntry);
                    // It is EXTREMLY slow. 4x or more slower. I suspect because it uses reflection to find the properties that the object contains
                    // Manually setting the properties like we do below is the best case scenario for performance. However, it also has risks.
                    // If we add columns to the schema and forget to add those changes here, changes to the biota may not propegate to the database.
                    // Mag-nus 2018-08-18

                    var existingBiota = GetBiota(context, biota.Id);

                    if (existingBiota == null)
                    {
                        context.Biota.Add(biota);
                    }
                    else
                    {
                        context.Entry(existingBiota).CurrentValues.SetValues(biota);

                        foreach (var value in biota.BiotaPropertiesAnimPart)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesAnimPart.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesAnimPart.Add(value);
                            else
                            {
                                existingValue.Index = value.Index;
                                existingValue.AnimationId = value.AnimationId;
                                existingValue.Order = value.Order;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesAnimPart)
                        {
                            if (!biota.BiotaPropertiesAnimPart.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesAnimPart.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesAttribute)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesAttribute.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesAttribute.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.InitLevel = value.InitLevel;
                                existingValue.LevelFromCP = value.LevelFromCP;
                                existingValue.CPSpent = value.CPSpent;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesAttribute)
                        {
                            if (!biota.BiotaPropertiesAttribute.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesAttribute.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesAttribute2nd)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesAttribute2nd.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesAttribute2nd.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.InitLevel = value.InitLevel;
                                existingValue.LevelFromCP = value.LevelFromCP;
                                existingValue.CPSpent = value.CPSpent;
                                existingValue.CurrentLevel = value.CurrentLevel;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesAttribute2nd)
                        {
                            if (!biota.BiotaPropertiesAttribute2nd.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesAttribute2nd.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesBodyPart)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesBodyPart.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesBodyPart.Add(value);
                            else
                            {
                                existingValue.Key = value.Key;
                                existingValue.DType = value.DType;
                                existingValue.DVal = value.DVal;
                                existingValue.DVar = value.DVar;
                                existingValue.BaseArmor = value.BaseArmor;
                                existingValue.ArmorVsSlash = value.ArmorVsSlash;
                                existingValue.ArmorVsPierce = value.ArmorVsPierce;
                                existingValue.ArmorVsBludgeon = value.ArmorVsBludgeon;
                                existingValue.ArmorVsCold = value.ArmorVsCold;
                                existingValue.ArmorVsFire = value.ArmorVsFire;
                                existingValue.ArmorVsAcid = value.ArmorVsAcid;
                                existingValue.ArmorVsElectric = value.ArmorVsElectric;
                                existingValue.ArmorVsNether = value.ArmorVsNether;
                                existingValue.BH = value.BH;
                                existingValue.HLF = value.HLF;
                                existingValue.MLF = value.MLF;
                                existingValue.LLF = value.LLF;
                                existingValue.HRF = value.HRF;
                                existingValue.MRF = value.MRF;
                                existingValue.LRF = value.LRF;
                                existingValue.HLB = value.HLB;
                                existingValue.MLB = value.MLB;
                                existingValue.LLB = value.LLB;
                                existingValue.HRB = value.HRB;
                                existingValue.MRB = value.MRB;
                                existingValue.LRB = value.LRB;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesBodyPart)
                        {
                            if (!biota.BiotaPropertiesBodyPart.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesBodyPart.Remove(value);
                        }

                        if (biota.BiotaPropertiesBook != null)
                        {
                            if (existingBiota.BiotaPropertiesBook == null)
                                existingBiota.BiotaPropertiesBook = new BiotaPropertiesBook();

                            existingBiota.BiotaPropertiesBook.MaxNumPages = biota.BiotaPropertiesBook.MaxNumPages;
                            existingBiota.BiotaPropertiesBook.MaxNumCharsPerPage =
                                biota.BiotaPropertiesBook.MaxNumCharsPerPage;
                        }
                        else
                        {
                            if (existingBiota.BiotaPropertiesBook != null)
                                ; // todo remove the old one
                        }

                        foreach (var value in biota.BiotaPropertiesBookPageData)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesBookPageData.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesBookPageData.Add(value);
                            else
                            {
                                existingValue.PageId = value.PageId;
                                existingValue.AuthorId = value.AuthorId;
                                existingValue.AuthorName = value.AuthorName;
                                existingValue.AuthorAccount = value.AuthorAccount;
                                existingValue.IgnoreAuthor = value.IgnoreAuthor;
                                existingValue.PageText = value.PageText;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesBookPageData)
                        {
                            if (!biota.BiotaPropertiesBookPageData.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesBookPageData.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesBool)
                        {
                            var existingValue = existingBiota.BiotaPropertiesBool.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesBool.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.Value = value.Value;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesBool)
                        {
                            if (!biota.BiotaPropertiesBool.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesBool.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesCreateList)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesCreateList.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesCreateList.Add(value);
                            else
                            {
                                existingValue.DestinationType = value.DestinationType;
                                existingValue.WeenieClassId = value.WeenieClassId;
                                existingValue.StackSize = value.StackSize;
                                existingValue.Palette = value.Palette;
                                existingValue.Shade = value.Shade;
                                existingValue.TryToBond = value.TryToBond;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesCreateList)
                        {
                            if (!biota.BiotaPropertiesCreateList.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesCreateList.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesDID)
                        {
                            var existingValue = existingBiota.BiotaPropertiesDID.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesDID.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.Value = value.Value;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesDID)
                        {
                            if (!biota.BiotaPropertiesDID.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesDID.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesEmote)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesEmote.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesEmote.Add(value);
                            else
                            {
                                existingValue.Category = value.Category;
                                existingValue.Probability = value.Probability;
                                existingValue.WeenieClassId = value.WeenieClassId;
                                existingValue.Style = value.Style;
                                existingValue.Substyle = value.Substyle;
                                existingValue.Quest = value.Quest;
                                existingValue.VendorType = value.VendorType;
                                existingValue.MinHealth = value.MinHealth;
                                existingValue.MaxHealth = value.MaxHealth;
                            }

                            // todo BiotaPropertiesEmoteAction
                        }

                        foreach (var value in existingBiota.BiotaPropertiesEmote)
                        {
                            if (!biota.BiotaPropertiesEmote.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesEmote.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesEnchantmentRegistry)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesEnchantmentRegistry.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesEnchantmentRegistry.Add(value);
                            else
                            {
                                existingValue.EnchantmentCategory = value.EnchantmentCategory;
                                existingValue.SpellId = value.SpellId;
                                existingValue.LayerId = value.LayerId;
                                existingValue.HasSpellSetId = value.HasSpellSetId;
                                existingValue.SpellCategory = value.SpellCategory;
                                existingValue.PowerLevel = value.PowerLevel;
                                existingValue.StartTime = value.StartTime;
                                existingValue.Duration = value.Duration;
                                existingValue.CasterObjectId = value.CasterObjectId;
                                existingValue.DegradeModifier = value.DegradeModifier;
                                existingValue.DegradeLimit = value.DegradeLimit;
                                existingValue.LastTimeDegraded = value.LastTimeDegraded;
                                existingValue.StatModType = value.StatModType;
                                existingValue.StatModKey = value.StatModKey;
                                existingValue.StatModValue = value.StatModValue;
                                existingValue.SpellSetId = value.SpellSetId;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesEnchantmentRegistry)
                        {
                            if (!biota.BiotaPropertiesEnchantmentRegistry.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesEnchantmentRegistry.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesEventFilter)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesEventFilter.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesEventFilter.Add(value);
                            else
                            {
                                existingValue.Event = value.Event;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesEventFilter)
                        {
                            if (!biota.BiotaPropertiesEventFilter.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesEventFilter.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesFloat)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesFloat.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesFloat.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.Value = value.Value;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesFloat)
                        {
                            if (!biota.BiotaPropertiesFloat.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesFloat.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesGenerator)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesGenerator.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesGenerator.Add(value);
                            else
                            {
                                existingValue.Probability = value.Probability;
                                existingValue.WeenieClassId = value.WeenieClassId;
                                existingValue.Delay = value.Delay;
                                existingValue.InitCreate = value.InitCreate;
                                existingValue.MaxCreate = value.MaxCreate;
                                existingValue.WhenCreate = value.WhenCreate;
                                existingValue.WhereCreate = value.WhereCreate;
                                existingValue.StackSize = value.StackSize;
                                existingValue.PaletteId = value.PaletteId;
                                existingValue.Shade = value.Shade;
                                existingValue.ObjCellId = value.ObjCellId;
                                existingValue.OriginX = value.OriginX;
                                existingValue.OriginY = value.OriginY;
                                existingValue.OriginZ = value.OriginZ;
                                existingValue.AnglesW = value.AnglesW;
                                existingValue.AnglesX = value.AnglesX;
                                existingValue.AnglesY = value.AnglesY;
                                existingValue.AnglesZ = value.AnglesZ;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesGenerator)
                        {
                            if (!biota.BiotaPropertiesGenerator.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesGenerator.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesIID)
                        {
                            var existingValue = existingBiota.BiotaPropertiesIID.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesIID.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.Value = value.Value;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesIID)
                        {
                            if (!biota.BiotaPropertiesIID.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesIID.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesInt)
                        {
                            var existingValue = existingBiota.BiotaPropertiesInt.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesInt.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.Value = value.Value;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesInt)
                        {
                            if (!biota.BiotaPropertiesInt.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesInt.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesInt64)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesInt64.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesInt64.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.Value = value.Value;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesInt64)
                        {
                            if (!biota.BiotaPropertiesInt64.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesInt64.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesPalette)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesPalette.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesPalette.Add(value);
                            else
                            {
                                existingValue.SubPaletteId = value.SubPaletteId;
                                existingValue.Offset = value.Offset;
                                existingValue.Length = value.Length;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesPalette)
                        {
                            if (!biota.BiotaPropertiesPalette.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesPalette.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesPosition)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesPosition.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesPosition.Add(value);
                            else
                            {
                                existingValue.PositionType = value.PositionType;
                                existingValue.ObjCellId = value.ObjCellId;
                                existingValue.OriginX = value.OriginX;
                                existingValue.OriginY = value.OriginY;
                                existingValue.OriginZ = value.OriginZ;
                                existingValue.AnglesW = value.AnglesW;
                                existingValue.AnglesX = value.AnglesX;
                                existingValue.AnglesY = value.AnglesY;
                                existingValue.AnglesZ = value.AnglesZ;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesPosition)
                        {
                            if (!biota.BiotaPropertiesPosition.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesPosition.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesSkill)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesSkill.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesSkill.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.LevelFromPP = value.LevelFromPP;
                                existingValue.SAC = value.SAC;
                                existingValue.PP = value.PP;
                                existingValue.InitLevel = value.InitLevel;
                                existingValue.ResistanceAtLastCheck = value.ResistanceAtLastCheck;
                                existingValue.LastUsedTime = value.LastUsedTime;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesSkill)
                        {
                            if (!biota.BiotaPropertiesSkill.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesSkill.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesSpellBook)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesSpellBook.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesSpellBook.Add(value);
                            else
                            {
                                existingValue.Spell = value.Spell;
                                existingValue.Probability = value.Probability;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesSpellBook)
                        {
                            if (!biota.BiotaPropertiesSpellBook.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesSpellBook.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesString)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesString.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesString.Add(value);
                            else
                            {
                                existingValue.Type = value.Type;
                                existingValue.Value = value.Value;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesString)
                        {
                            if (!biota.BiotaPropertiesString.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesString.Remove(value);
                        }

                        foreach (var value in biota.BiotaPropertiesTextureMap)
                        {
                            var existingValue =
                                existingBiota.BiotaPropertiesTextureMap.FirstOrDefault(r => r.Id == value.Id);

                            if (existingValue == null)
                                existingBiota.BiotaPropertiesTextureMap.Add(value);
                            else
                            {
                                existingValue.Index = value.Index;
                                existingValue.OldId = value.OldId;
                                existingValue.NewId = value.NewId;
                                existingValue.Order = value.Order;
                            }
                        }

                        foreach (var value in existingBiota.BiotaPropertiesTextureMap)
                        {
                            if (!biota.BiotaPropertiesTextureMap.Any(p => p.Id == value.Id))
                                context.BiotaPropertiesTextureMap.Remove(value);
                        }
                    }

                    try
                    {
                        context.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Character name might be in use or some other fault
                        log.Error($"SaveBiota failed with exception: {ex}");
                        return false;
                    }
                }
                finally
                {
                    rwLock.ExitWriteLock();
                }
            }
        }

        public bool SaveBiotasInParallel(IEnumerable<Biota> biotas)
        {
            var result = true;

            Parallel.ForEach(biotas, biota =>
            {
                if (!SaveBiota(biota, new ReaderWriterLockSlim()))
                    result = false;
            });

            return result;
        }

        public bool RemoveBiota(Biota biota, ReaderWriterLockSlim rwLock)
        {
            using (var context = new ShardDbContext())
            {
                rwLock.EnterWriteLock();
                try
                {
                    context.Biota.Remove(biota);

                    try
                    {
                        context.SaveChanges();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        // Character name might be in use or some other fault
                        log.Error($"RemoveBiota failed with exception: {ex}");
                        return false;
                    }
                }
                finally
                {
                    rwLock.ExitWriteLock();
                }
            }
        }

        public bool RemoveBiotasInParallel(IEnumerable<Biota> biotas)
        {
            var result = true;

            Parallel.ForEach(biotas, biota =>
            {
                if (!RemoveBiota(biota, new ReaderWriterLockSlim()))
                    result = false;
            });

            return result;
        }


        public bool RemoveEntity(object entity)
        {
            using (var context = new ShardDbContext())
            {
                context.Remove(entity);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    // Character name might be in use or some other fault
                    log.Error($"RemoveEntity failed with exception: {ex}");
                    return false;
                }
            }
        }

        public bool RemoveEntity(CharacterPropertiesShortcutBar entity)
        {
            using (var context = new ShardDbContext())
            {
                context.CharacterPropertiesShortcutBar.Remove(entity);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    // Character name might be in use or some other fault
                    log.Error($"RemoveEntity failed with exception: {ex}");
                    return false;
                }
            }
        }

        public bool RemoveEntity(CharacterPropertiesSpellBar entity)
        {
            using (var context = new ShardDbContext())
            {
                context.CharacterPropertiesSpellBar.Remove(entity);

                try
                {
                    context.SaveChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    // Character name might be in use or some other fault
                    log.Error($"RemoveEntity failed with exception: {ex}");
                    return false;
                }
            }
        }


        public PlayerBiotas GetPlayerBiotasInParallel(uint id)
        {
            var biota = GetBiota(id);

            var inventory = GetInventoryInParallel(id, true);

            var wieldedItems = GetWieldedItemsInParallel(id);

            return new PlayerBiotas(biota, inventory, wieldedItems);
        }

        public List<Biota> GetInventoryInParallel(uint parentId, bool includedNestedItems)
        {
            var inventory = new ConcurrentBag<Biota>();

            using (var context = new ShardDbContext())
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var results = context.BiotaPropertiesIID
                    .Where(r => r.Type == (ushort)PropertyInstanceId.Container && r.Value == parentId)
                    .ToList();

                Parallel.ForEach(results, result =>
                {
                    var biota = GetBiota(result.ObjectId);

                    if (biota != null)
                    {
                        inventory.Add(biota);

                        if (includedNestedItems && biota.WeenieType == (int) WeenieType.Container)
                        {
                            var subItems = GetInventoryInParallel(biota.Id, false);

                            foreach (var subItem in subItems)
                                inventory.Add(subItem);
                        }
                    }
                });
            }

            return inventory.ToList();
        }

        public List<Biota> GetWieldedItemsInParallel(uint parentId)
        {
            var wieldedItems = new ConcurrentBag<Biota>();

            using (var context = new ShardDbContext())
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var results = context.BiotaPropertiesIID
                    .Where(r => r.Type == (ushort)PropertyInstanceId.Wielder && r.Value == parentId)
                    .ToList();

                Parallel.ForEach(results, result =>
                {
                    var biota = GetBiota(result.ObjectId);

                    if (biota != null)
                        wieldedItems.Add(biota);
                });
            }

            return wieldedItems.ToList();
        }


        public List<Biota> GetObjectsByLandblockInParallel(ushort landblockId)
        {
            var decayables = new ConcurrentBag<Biota>();

            using (var context = new ShardDbContext())
            {
                context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

                var results = context.BiotaPropertiesPosition
                    .Where(p => p.ObjCellId >> 16 == landblockId)
                    .ToList();

                Parallel.ForEach(results, result =>
                {
                    var biota = GetBiota(result.ObjectId);

                    if (biota != null && biota.WeenieType == (int)WeenieType.Corpse)
                        decayables.Add(biota);
                });
            }

            return decayables.ToList();
        }
    }
}
