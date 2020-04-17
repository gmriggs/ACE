using System;
using log4net;

using ACE.Common;
using ACE.Entity.Enum;
using ACE.Entity.Enum.Properties;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Mutate
{
    public partial class EffectArgument
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public EffectArgumentType Type;

        // union
        public byte[] RawData;

        // EffectArgumentType.Double
        public double DoubleVal;

        // EffectArgumentType.Int
        public int IntVal;

        // EffectArgumentType.Quality
        public StatType StatType;
        public int StatIdx;

        // EffectArgumentType.Random
        public float Min;
        public float Max;

        public EffectArgument(double val)
        {
            Type = EffectArgumentType.Double;
            DoubleVal = val;
        }

        public EffectArgument(int val)
        {
            Type = EffectArgumentType.Int;
            IntVal = val;
        }

        public EffectArgument(StatType statType, int propIdx)
        {
            Type = EffectArgumentType.Quality;
            StatType = statType;
            StatIdx = propIdx;
        }

        public EffectArgument(float min, float max)
        {
            Type = EffectArgumentType.Random;
            Min = min;
            Max = max;
        }

        public EffectArgument(Database.Models.World.MutationEffectArgument other)
        {
            if (other == null)
                return;

            Type = (EffectArgumentType)other.EffectType;
            //RawData = other.RawData;
            DoubleVal = other.DoubleVal ?? 0.0;
            IntVal = other.IntVal ?? 0;
            StatType = (StatType)(other.StatType ?? 0);
            StatIdx = other.StatIdx ?? 0;
            Min = other.MinVal ?? 0.0f;
            Max = other.MaxVal ?? 0.0f;
        }

        public object GetValue()
        {
            switch (Type)
            {
                case EffectArgumentType.Double:
                    return DoubleVal;
                case EffectArgumentType.Int:
                    return IntVal;
            }
            return null;
        }

        // output conversions
        public double ToDouble()
        {
            switch (Type)
            {
                case EffectArgumentType.Int:
                    return IntVal;
                case EffectArgumentType.Double:
                    return DoubleVal;
            }
            log.Error($"EffectArgument.ToDouble() - invalid type {Type}");
            return 0.0;
        }

        public int ToInt()
        {
            switch (Type)
            {
                case EffectArgumentType.Int:
                    return IntVal;
                case EffectArgumentType.Double:
                    return (int)DoubleVal;
            }
            log.Error($"EffectArgument.ToDouble() - invalid type {Type}");
            return 0;
        }

        // gdle custom

        public bool IsValid = false;

        public bool ResolveValue(WorldObject item)
        {
            // type:enum - invalid, double, int32, quality (2 int32s: type and quality), float range (min, max), variable index (int32)
            switch (Type)
            {
                case EffectArgumentType.Double:
                case EffectArgumentType.Int:
                    // these are ok as-is
                    IsValid = true;
                    break;

                case EffectArgumentType.Quality:

                    switch (StatType)
                    {
                        case StatType.Int:

                            IntVal = item.GetProperty((PropertyInt)StatIdx) ?? 0;
                            Type = EffectArgumentType.Int;
                            IsValid = true;
                            break;

                        case StatType.Bool:

                            IntVal = Convert.ToInt32(item.GetProperty((PropertyBool)StatIdx) ?? false);
                            Type = EffectArgumentType.Int;
                            IsValid = true;
                            break;

                        case StatType.Float:

                            DoubleVal = item.GetProperty((PropertyFloat)StatIdx) ?? 0.0;
                            Type = EffectArgumentType.Double;
                            break;

                        case StatType.DID:

                            IntVal = (int)(item.GetProperty((PropertyDataId)StatIdx) ?? 0);
                            Type = EffectArgumentType.Int;
                            break;
                    }

                    break;

                case EffectArgumentType.Random:

                    DoubleVal = ThreadSafeRandom.Next(Min, Max);
                    Type = EffectArgumentType.Double;
                    IsValid = true;
                    break;

                case EffectArgumentType.Variable:

                    /*if (IntVal < 0 || IntVal >= GTVariables.Count)
                        break;

                    this = GTVariables[IntVal];
                    IsValid = true;*/
                    log.Error($"TODO: EffectArgumentTYpe.Variable");
                    break;
            }

            return IsValid;
        }

        public bool StoreValue(WorldObject item)
        {
            // here the resolved value (result) is applied to the qualities specified by our value

            if (!IsValid)
                return false;

            switch (Type)
            {
                case EffectArgumentType.Quality:

                    switch (StatType)
                    {
                        case StatType.Int:
                            item.SetProperty((PropertyInt)StatIdx, ToInt());
                            break;

                        case StatType.Bool:
                            item.SetProperty((PropertyBool)StatIdx, Convert.ToBoolean(ToInt()));
                            break;

                        case StatType.Float:
                            item.SetProperty((PropertyFloat)StatIdx, ToDouble());
                            break;

                        case StatType.DID:
                            item.SetProperty((PropertyDataId)StatIdx, (uint)ToInt());
                            break;
                    }
                    break;

                case EffectArgumentType.Variable:

                    // TODO
                    /*if (IntVal < 0 || IntVal > GTVariables.Count)
                        break;

                    GTVariables[IntVal] = result;*/
                    break;
            }
            return true;
        }
    }
}
