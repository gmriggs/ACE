using System;
using ACE.Server.WorldObjects;

namespace ACE.Server.Diagnostics
{
    public class Callbacks
    {
        public static Server Server { get => Server.Instance; }

        static Callbacks()
        {
            Init();
        }

        public static void Init()
        {
            WorldObject.NotifyUpdate = new Action<WorldObject>(UpdateWorldObject);
        }

        public static void UpdateWorldObject(WorldObject wo)
        {
            if (!UpdateSendable(wo)) return;

            //Console.WriteLine("WorldObject updated: " + wo.Guid.Full.ToString("X8"));
            Server.SendUpdate(wo);
        }

        public static bool Sendable(WorldObject wo)
        {
            var creature = wo as Creature;

            var isPlayer = wo is Player;
            var isMonster = (creature != null && creature.IsMonster());
            var isAttackable = (creature != null && creature.IsAttackable());
            var isMissile = wo.Missile != null && wo.Missile.Value;

            return (isPlayer || isAttackable || isMissile);
        }

        public static bool UpdateSendable(WorldObject wo)
        {
            var creature = wo as Creature;

            var isPlayer = wo is Player;
            var isAttackable = (creature != null && creature.IsAttackable());
            var isMissile = wo.Missile != null && wo.Missile.Value;

            return (isPlayer || isAttackable || isMissile || wo.ForceSend);
        }
    }
}
