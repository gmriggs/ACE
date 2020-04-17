using System.Linq;

using log4net;

using ACE.Entity.Enum;
using ACE.Server.WorldObjects;

namespace ACE.Server.Factories.Treasure.Mutate
{
    public class MutationEffect
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //public EffectArgument Quality;
        //public MutationEffectType Type;
        //public EffectArgument Arg1;
        //public EffectArgument Arg2;

        public static Database.Models.World.MutationEffectArgument GetQuality(Database.Models.World.MutationEffect effect)
        {
            return effect.MutationEffectArgument.FirstOrDefault(i => i.ArgType == 0);
        }

        public static Database.Models.World.MutationEffectArgument GetArg1(Database.Models.World.MutationEffect effect)
        {
            return effect.MutationEffectArgument.FirstOrDefault(i => i.ArgType == 1);
        }

        public static Database.Models.World.MutationEffectArgument GetArg2(Database.Models.World.MutationEffect effect)
        {
            return effect.MutationEffectArgument.FirstOrDefault(i => i.ArgType == 2);
        }

        public static bool TryMutate(Database.Models.World.MutationEffect effect, WorldObject item)
        {
            // type:enum - invalid, double, int32, quality (2 int32s: type and quality), float range (min, max), variable index (int32)
            // a=b,a+=b,a-=b,a*=b,a/=b,a=a<b?b:a+c,a=a>b?b:a-c,a+=b*c,a+=b/c,a-=b*c,a-=b/c,a=b+c,a=b-c,a=b*c,a=b/c

            // do not make changes to the members since this object will be reused

            var result = new EffectArgument(GetQuality(effect));
            var arg1 = new EffectArgument(GetArg1(effect));
            var arg2 = new EffectArgument(GetArg2(effect));

            result.ResolveValue(item);
            arg1.ResolveValue(item);
            arg2.ResolveValue(item);

            var type = (MutationEffectType)effect.EffectType;

            if (!Validate(item, result, arg1, arg2, type))
                return false;

            switch (type)
            {
                case MutationEffectType.Assign:

                    result = arg1;
                    break;

                case MutationEffectType.Add:

                    result = result + arg1;
                    break;

                case MutationEffectType.Subtract:

                    result = result - arg1;
                    break;

                case MutationEffectType.Multiply:

                    result = result * arg1;
                    break;

                case MutationEffectType.Divide:

                    result = result / arg1;
                    break;

                case MutationEffectType.AtLeastAdd:

                    result = (result < arg1) ? arg1 : result + arg2;
                    break;

                case MutationEffectType.AtMostSubtract:

                    result = (result > arg1) ? arg1 : result - arg2;
                    break;

                case MutationEffectType.AddMultiply:

                    result = result + (arg1 * arg2);
                    break;

                case MutationEffectType.AddDivide:

                    result = result + (arg1 / arg2);
                    break;

                case MutationEffectType.SubtractMultiply:

                    result = result - (arg1 * arg2);
                    break;

                case MutationEffectType.SubtractDivide:

                    result = result - (arg1 / arg2);
                    break;

                case MutationEffectType.AssignAdd:

                    result = arg1 + arg2;
                    break;

                case MutationEffectType.AssignSubtract:

                    result = arg1 - arg2;
                    break;

                case MutationEffectType.AssignMultiply:

                    result = arg1 * arg2;
                    break;

                case MutationEffectType.AssignDivide:

                    result = arg1 * arg2;
                    break;
            }

            result.StoreValue(item);

            return true;
        }

        public static bool Validate(WorldObject item, EffectArgument result, EffectArgument arg1, EffectArgument arg2, MutationEffectType type)
        {
            if (!result.IsValid)
            {
                log.Error($"{item.Name} ({item.Guid}).TryMutate({type}) - result invalid");
                return false;
            }

            if (!arg1.IsValid)
            {
                log.Error($"{item.Name} ({item.Guid}).TryMutate({type}) - argument 1 invalid");
                return false;
            }

            switch (type)
            {
                case MutationEffectType.AtLeastAdd:
                case MutationEffectType.AtMostSubtract:
                case MutationEffectType.AddMultiply:
                case MutationEffectType.AddDivide:
                case MutationEffectType.SubtractMultiply:
                case MutationEffectType.SubtractDivide:
                case MutationEffectType.AssignAdd:
                case MutationEffectType.AssignSubtract:
                case MutationEffectType.AssignMultiply:
                case MutationEffectType.AssignDivide:

                    if (!arg2.IsValid)
                    {
                        log.Error($"{item.Name} ({item.Guid}).TryMutate({type}) - argument 2 invalid");
                        return false;
                    }
                    break;
            }

            return true;
        }
    }
}
