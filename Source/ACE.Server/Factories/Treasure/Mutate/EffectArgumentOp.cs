using ACE.Entity.Enum;

namespace ACE.Server.Factories.Treasure.Mutate
{
    public partial class EffectArgument
    {
        public static EffectArgument operator +(EffectArgument a, EffectArgument b)
        {
            switch (a.Type)
            {
                case EffectArgumentType.Double:

                    switch (b.Type)
                    {
                        case EffectArgumentType.Double:
                            return new EffectArgument(a.DoubleVal + b.DoubleVal);
                        case EffectArgumentType.Int:
                            return new EffectArgument(a.DoubleVal + b.IntVal);
                    }
                    break;

                case EffectArgumentType.Int:

                    switch (b.Type)
                    {
                        case EffectArgumentType.Double:
                            return new EffectArgument(a.IntVal + (int)b.DoubleVal);
                        case EffectArgumentType.Int:
                            return new EffectArgument(a.IntVal + b.IntVal);
                    }
                    break;
            }

            log.Error($"EffectArgument.Add() - invalid type {a.Type}, {b.Type}");

            return null;
        }

        public static EffectArgument operator -(EffectArgument a, EffectArgument b)
        {
            switch (a.Type)
            {
                case EffectArgumentType.Double:

                    switch (b.Type)
                    {
                        case EffectArgumentType.Double:
                            return new EffectArgument(a.DoubleVal - b.DoubleVal);
                        case EffectArgumentType.Int:
                            return new EffectArgument(a.DoubleVal - b.IntVal);
                    }
                    break;

                case EffectArgumentType.Int:

                    switch (b.Type)
                    {
                        case EffectArgumentType.Double:
                            return new EffectArgument(a.IntVal - (int)b.DoubleVal);
                        case EffectArgumentType.Int:
                            return new EffectArgument(a.IntVal - b.IntVal);
                    }
                    break;
            }

            log.Error($"EffectArgument.Subtract() - invalid type {a.Type}, {b.Type}");

            return null;
        }

        public static EffectArgument operator *(EffectArgument a, EffectArgument b)
        {
            switch (a.Type)
            {
                case EffectArgumentType.Double:

                    switch (b.Type)
                    {
                        case EffectArgumentType.Double:
                            return new EffectArgument(a.DoubleVal * b.DoubleVal);
                        case EffectArgumentType.Int:
                            return new EffectArgument(a.DoubleVal * b.IntVal);
                    }
                    break;

                case EffectArgumentType.Int:

                    switch (b.Type)
                    {
                        case EffectArgumentType.Double:
                            return new EffectArgument(a.IntVal * (int)b.DoubleVal);
                        case EffectArgumentType.Int:
                            return new EffectArgument(a.IntVal * b.IntVal);
                    }
                    break;
            }

            log.Error($"EffectArgument.Multiply() - invalid type {a.Type}, {b.Type}");

            return null;
        }

        public static EffectArgument operator /(EffectArgument a, EffectArgument b)
        {
            switch (a.Type)
            {
                case EffectArgumentType.Double:

                    switch (b.Type)
                    {
                        case EffectArgumentType.Double:
                            return new EffectArgument(a.DoubleVal / b.DoubleVal);
                        case EffectArgumentType.Int:
                            return new EffectArgument(a.DoubleVal / b.IntVal);
                    }
                    break;

                case EffectArgumentType.Int:

                    switch (b.Type)
                    {
                        case EffectArgumentType.Double:
                            return new EffectArgument(a.IntVal / (int)b.DoubleVal);
                        case EffectArgumentType.Int:
                            return new EffectArgument(a.IntVal / b.IntVal);
                    }
                    break;
            }

            log.Error($"EffectArgument.Divide() - invalid type {a.Type}, {b.Type}");

            return null;
        }

        public static bool operator <(EffectArgument a, EffectArgument b)
        {
            if (a.Type != b.Type)
            {
                log.Error($"EffectArgument.LessThan() - type mismatch {a.Type} {b.Type}");
                return false;
            }

            switch (a.Type)
            {
                case EffectArgumentType.Double:
                    return a.DoubleVal < b.DoubleVal;

                case EffectArgumentType.Int:
                    return a.IntVal < b.IntVal;
            }
            return false;
        }

        public static bool operator >(EffectArgument a, EffectArgument b)
        {
            if (a.Type != b.Type)
            {
                log.Error($"EffectArgument.GreaterThan() - type mismatch {a.Type} {b.Type}");
                return false;
            }

            switch (a.Type)
            {
                case EffectArgumentType.Double:
                    return a.DoubleVal > b.DoubleVal;

                case EffectArgumentType.Int:
                    return a.IntVal > b.IntVal;
            }
            return false;
        }
    }
}