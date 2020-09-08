using System;
using System.IO;
using System.Globalization;
using System.Linq;

using ACE.Database;
using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;
using ACE.Server.Factories.Treasure.Mutate;
using ACE.Server.Factories;
using ACE.Server.Factories.Treasure;
using ACE.Server.Network;
using System.Collections.Generic;

namespace ACE.Server.Command.Handlers
{
    public static class DeveloperLootCommands
    {
        [CommandHandler("testlootgen", AccessLevel.Admin, CommandHandlerFlag.ConsoleInvoke, 1, "Generates Loot for testing LootFactories.  Do testlootgen -info for examples.", "<number of items> <loot tier> <melee, missile, caster, armor, pet, aetheria (optional)>")]
        public static void TestLootGenerator(Session session, params string[] parameters)
        {
            // This generates loot items and displays the drop rates of LootFactory
            string logFile = "";
            string displayTable = "";
            bool logstats = false;
            // Switch for different options
            switch (parameters[0])
            {
                case "-info":
                    Console.WriteLine($"Usage: \n" +
                                    $"<number of items> <loot tier> <(optional)display table - melee, missile, caster, jewelry, armor, cloak, pet, aetheria> \n" +
                                    $" Example: The following command will generate 1000 items in Tier 7 that shows the melee table\n" +
                                    $"testlootgen 1000 7 melee \n" +
                                    $" Example: The following command will generate 1000 items in Tier 6 that just shows a summary \n" +
                                    $"testlootgen 1000 6 \n");
                    return;
                default:
                    break;
            }

            if (int.TryParse(parameters[0], out int numberItemsGenerate))
            {
                ////Console.WriteLine("Number of items to generate " + numberItemsGenerate);
            }
            else
            {
                Console.WriteLine("Number of items is not an integer");
                return;
            }

            if (int.TryParse(parameters[1], out int itemsTier))
            {
                ////Console.WriteLine("tier is " + itemsTier);
            }
            else
            {
                Console.WriteLine("Tier is not an integer");
                return;
            }
            if (parameters.Length > 2)
                displayTable = parameters[2].ToLower();
            switch (displayTable)
            {
                case "melee":
                case "missile":
                case "caster":
                case "jewelry":
                case "armor":
                case "pet":
                case "aetheria":
                case "all":
                case "cloak":
                case "":
                    break;
                case "-log":
                    logstats = true;
                    break;
                default:
                    Console.WriteLine("Invalid Table Option.  Available Tables to show are melee, missile, caster, jewelry, armor, cloak, pet, aetheria or all.");
                    return;
            }
            if (parameters.Length > 3)
                logFile = parameters[3].ToLower();
            switch (logFile)
            {
                case "":
                    break;
                case "-log":
                    logstats = true;
                    // Console.WriteLine("Logging is not currently working, Displaying results to screen.");
                    break;
                default:
                    Console.WriteLine("Invalid Option.  To log a file, use option -log");
                    return;
            }
            if (itemsTier > 0 && itemsTier < 9)
                Console.WriteLine(LootGenerationFactory_Test.TestLootGen(numberItemsGenerate, itemsTier, logstats, displayTable));
            else
            {
                Console.WriteLine($"Tier must be 1-8.  You entered tier {itemsTier}, which does not exist!");
                return;
            }
        }

        [CommandHandler("testlootgencorpse", AccessLevel.Admin, CommandHandlerFlag.ConsoleInvoke, 1, "Generates Corpses for testing LootFactories", "<DID> <number corpses> <display table - melee, missile, caster, armor, pet, aetheria>")]
        public static void TestLootGeneratorCorpse(Session session, params string[] parameters)
        {
            // This generates loot items and displays the drop rates of LootFactory
            int monsterDID = 0;
            int numberItemsGenerate = 0;
            string logFile = "";
            string displayTable = "";

            bool logstats = false;

            // Switch for different options
            switch (parameters[0])
            {
                case "-info":
                    Console.WriteLine($"Usage: \n" +
                                    $"<DID> <number corpses> <(optional)display table - melee, missile, caster, jewelry, armor, pet, aetheria> \n" +
                                    $" Example: The following command will generate 50 corpses generated from DeathTreasure DID 998 that shows the caster table\n" +
                                    $"testlootgencorpse 998 50 caster \n" +
                                    $" Example: The following command will generate 75 corpses generated from DeathTreasure DID 452 that just shows a summary \n" +
                                    $"testlootgencorpse 452 75 \n");
                    return;
                default:
                    break;
            }
            if (!int.TryParse(parameters[0], out monsterDID))
            {
                Console.WriteLine($" LootFactory Simulator \n ---------------------\n DID specified is not an integer \n");
                return;
            }
            if (parameters.Length > 1)
            {
                if (!int.TryParse(parameters[1], out numberItemsGenerate))
                {
                    Console.WriteLine($" LootFactory Simulator \n ---------------------\n Invalid Parameter - Must be a number \n");
                    return;
                }
            }
            else
            {
                Console.WriteLine($" LootFactory Simulator \n ---------------------\n Need to specify number of coprses\n");
                return;
            }
            if (parameters.Length > 2)
                displayTable = parameters[2].ToLower();
            switch (displayTable)
            {
                case "melee":
                case "missile":
                case "caster":
                case "jewelry":
                case "armor":
                case "pet":
                case "aetheria":
                case "all":
                case "cloak":
                case "":
                    break;
                case "-log":
                    logstats = true;
                    break;
                default:
                    Console.WriteLine("Invalid Table Option.  Available Tables to show are melee, missile, caster, jewelry, armor, pet, aetheria or all.");
                    return;
            }
            if (parameters.Length > 3)
                logFile = parameters[3].ToLower();
            switch (logFile)
            {
                case "":
                    break;
                case "-log":
                    logstats = true;
                    // Console.WriteLine("Logging is not currently working, Displaying results to screen.");
                    break;
                default:
                    Console.WriteLine("Invalid Option.  To log a file, use option -log");
                    return;
            }
            Console.WriteLine(LootGenerationFactory_Test.TestLootGenMonster(Convert.ToUInt32(monsterDID), numberItemsGenerate, logstats, displayTable));
        }

        [CommandHandler("testlootgen2", AccessLevel.Admin, CommandHandlerFlag.ConsoleInvoke, "Preliminary tests for moro's loot system")]
        public static void TestLootGen2(Session session, params string[] parameters)
        {
            uint yumiWcid = 363;
            uint hauberkPlatemail = 72;

            uint itemWcid = hauberkPlatemail;

            var item = WorldObjectFactory.CreateNewWorldObject(itemWcid);

            if (item == null)
            {
                Console.WriteLine($"Couldn't find wcid {itemWcid}", ChatMessageType.Broadcast);
                return;
            }

            var tSysMutationDataInt = item.GetProperty(PropertyInt.TsysMutationData);
            var tSysMutationDataDid = item.GetProperty(PropertyDataId.TsysMutationFilter);
            var mutateFilter = item.GetProperty(PropertyDataId.MutateFilter);

            // other fields
            var creationMutationFilter = item.GetProperty(PropertyDataId.CreationMutationFilter);
            var augmentationMutationFilter = item.GetProperty(PropertyDataId.AugmentationMutationFilter);

            Console.WriteLine($"PropertyInt.TsysMutationData: {tSysMutationDataInt:X8}");
            Console.WriteLine($"PropertyDataId.TsysMutationFilter: {tSysMutationDataDid:X8}");
            Console.WriteLine($"PropertyDataId.MutateFilter: {mutateFilter:X8}");
            Console.WriteLine($"PropertyDataId.CreationMutationFilter: {creationMutationFilter:X8}");
            Console.WriteLine($"PropertyDataId.MutateFilter: {augmentationMutationFilter:X8}");

            bool hasMagic = false;
            int tier = 6;
            double qualityMod = 0.0;    // default value?

            var success = TreasureSystem.MutateItem(item, hasMagic, tier, qualityMod, TreasureItemClass.BowWeapon);

            Console.WriteLine($"TryMutateItem: {success}");
        }

        [CommandHandler("show-mutation-filters", AccessLevel.Admin, CommandHandlerFlag.ConsoleInvoke, "Shows all of the PropertyInt.MutateFilters on the system")]
        public static void HandleShowMutationFilters(Session session, params string[] parameters)
        {
            var allMutationFilters = TreasureTables.GetAllMutationFilters();

            foreach (var kvp in allMutationFilters.OrderBy(i => i.Key))
            {
                Console.WriteLine($"{kvp.Key:X8}:");
                kvp.Value.Output();
                Console.WriteLine();
            }
        }

        [CommandHandler("show-mutations", AccessLevel.Admin, CommandHandlerFlag.ConsoleInvoke, 1, "Shows all of the possible mutations for a 0x38 PropertyDID.TsysMutationFilter", "a 0x38 record id")]
        public static void HandleShowMutations(Session session, params string[] parameters)
        {
            if (!uint.TryParse(parameters[0], NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var tSysMutationFilter))
            {
                Console.WriteLine($"Couldn't parse {parameters[0]}");
                return;
            }

            if (tSysMutationFilter < 0x38000000)
                tSysMutationFilter = 0x38000000 | tSysMutationFilter;

            var mutations = DatabaseManager.World.GetCachedMutationFilter(tSysMutationFilter);

            if (mutations == null)
            {
                Console.WriteLine($"Couldn't find mutation filter {tSysMutationFilter:X8}");
                return;
            }

            var lines = BuildMutationScript(tSysMutationFilter, mutations);

            foreach (var line in lines)
                Console.WriteLine(line);
        }

        [CommandHandler("output-mutations", AccessLevel.Admin, CommandHandlerFlag.ConsoleInvoke, "Outputs mutation scripts for every mutation filter on the system", "a 0x38 record id")]
        public static void HandleOutputMutations(Session session, params string[] parameters)
        {
            uint firstMutationId = 1;
            uint lastMutationId = 74;

            for (uint mutationId = firstMutationId; mutationId <= lastMutationId; mutationId++)
            {
                var tSysMutationFilter = 0x38000000 | mutationId;

                var mutations = DatabaseManager.World.GetCachedMutationFilter(tSysMutationFilter);

                if (mutations == null)
                {
                    Console.WriteLine($"Couldn't find mutation filter {tSysMutationFilter:X8}");
                    return;
                }

                var lines = BuildMutationScript(tSysMutationFilter, mutations);

                var sep = Path.DirectorySeparatorChar;
                var scriptFolder = Directory.GetCurrentDirectory() + sep + "MutationScript" + sep;

                if (!Directory.Exists(scriptFolder))
                    Directory.CreateDirectory(scriptFolder);

                var filename = scriptFolder + tSysMutationFilter.ToString("X8") + ".txt";

                File.WriteAllLines(filename, lines);

                Console.WriteLine($"Wrote {filename}");
            }
        }

        public static List<string> BuildMutationScript(uint tSysMutationFilter, List<Database.Models.World.Mutation> mutations)
        {
            var lines = new List<string>();

            foreach (var mutation in mutations)
            {
                lines.Add($"0x{tSysMutationFilter:X8} Mutation #{mutation.Idx + 1}:");
                lines.Add("");
                lines.Add($"Tier chances: {string.Join(", ", mutation.MutationChance.Select(i => i.Chance))}");
                lines.Add("");

                foreach (var outcome in mutation.MutationOutcome)
                {
                    for (var effectListIdx = 0; effectListIdx < outcome.MutationEffectList.Count; effectListIdx++)
                    {
                        var effectList = outcome.MutationEffectList.ElementAt(effectListIdx);

                        lines.Add($"    - Chance {effectList.Probability}:");

                        for (var effectIdx = 0; effectIdx < effectList.MutationEffect.Count; effectIdx++)
                        {
                            var effect = effectList.MutationEffect.ElementAt(effectIdx);

                            //lines.Add($"        - EffectType: {(MutationEffectType)effect.EffectType}");

                            var curLine = "";

                            PropertyInt propInt = 0;

                            for (var argIdx = 0; argIdx < effect.MutationEffectArgument.Count; argIdx++)
                            {
                                var _arg = effect.MutationEffectArgument.ElementAt(argIdx);

                                if (argIdx == 0)
                                {
                                    curLine += "        ";
                                }

                                if (argIdx == 1)
                                {
                                    switch ((MutationEffectType)effect.EffectType)
                                    {
                                        case MutationEffectType.Assign:
                                        case MutationEffectType.AssignAdd:
                                        case MutationEffectType.AssignSubtract:
                                        case MutationEffectType.AssignMultiply:
                                        case MutationEffectType.AssignDivide:
                                            curLine += " = ";
                                            break;

                                        case MutationEffectType.Add:
                                        case MutationEffectType.AddMultiply:
                                        case MutationEffectType.AddDivide:
                                            curLine += " += ";
                                            break;

                                        case MutationEffectType.Subtract:
                                        case MutationEffectType.SubtractMultiply:
                                        case MutationEffectType.SubtractDivide:
                                            curLine += " -= ";
                                            break;

                                        case MutationEffectType.Multiply:
                                            curLine += " *= ";
                                            break;

                                        case MutationEffectType.Divide:
                                            curLine += " /= ";
                                            break;

                                        case MutationEffectType.AtLeastAdd:
                                            curLine += " >= ";
                                            break;

                                        case MutationEffectType.AtMostSubtract:
                                            curLine += " <= ";
                                            break;
                                    }
                                }

                                if (argIdx == 2)
                                {
                                    switch ((MutationEffectType)effect.EffectType)
                                    {
                                        case MutationEffectType.AssignAdd:
                                            curLine += " + ";
                                            break;

                                        case MutationEffectType.AssignSubtract:
                                            curLine += " - ";
                                            break;

                                        case MutationEffectType.AssignMultiply:
                                        case MutationEffectType.AddMultiply:
                                        case MutationEffectType.SubtractMultiply:
                                            curLine += " * ";
                                            break;

                                        case MutationEffectType.AssignDivide:
                                        case MutationEffectType.AddDivide:
                                        case MutationEffectType.SubtractDivide:
                                            curLine += " / ";
                                            break;

                                        case MutationEffectType.AtLeastAdd:
                                            curLine += ", add ";
                                            break;

                                        case MutationEffectType.AtMostSubtract:
                                            curLine += ", sub ";
                                            break;
                                    }
                                }
                                    
                                var arg = new EffectArgument(_arg);

                                switch (arg.Type)
                                {
                                    case EffectArgumentType.Int:
                                        if (argIdx == 1 && propInt == PropertyInt.WieldRequirements)
                                            curLine += ($"{(WieldRequirement)arg.IntVal}");
                                        else
                                            curLine += ($"{arg.IntVal}");
                                        break;

                                    case EffectArgumentType.Double:
                                        curLine += ($"{arg.DoubleVal}");
                                        break;

                                    case EffectArgumentType.Quality:

                                        switch (arg.StatType)
                                        {
                                            case StatType.Int:
                                                curLine += $"{(PropertyInt)arg.StatIdx}";
                                                if (argIdx == 0)
                                                    propInt = (PropertyInt)arg.StatIdx;
                                                break;

                                            case StatType.Bool:
                                                curLine += $"{(PropertyBool)arg.StatIdx}";
                                                break;

                                            case StatType.Float:
                                                curLine += $"{(PropertyFloat)arg.StatIdx}";
                                                break;

                                            case StatType.DID:
                                                curLine += $"{(PropertyDataId)arg.StatIdx}";
                                                break;

                                            default:
                                                curLine += $"Unknown StatType: {arg.StatType}, StatIdx: {arg.StatIdx}";
                                                break;
                                        }
                                        break;

                                    case EffectArgumentType.Random:
                                        curLine += $"Random({arg.Min}, {arg.Max})";
                                        break;

                                    case EffectArgumentType.Variable:
                                        curLine += $"Variable[{arg.IntVal}]";
                                        break;

                                    default:
                                        curLine += $"Unknown EffectArgumentType: {arg.Type}";
                                        break;

                                }
                            }
                            lines.Add(curLine);
                        }
                        lines.Add("");
                    }
                }
            }
            return lines;
        }
    }
}
