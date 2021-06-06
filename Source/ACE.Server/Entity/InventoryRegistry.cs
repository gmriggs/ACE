using System;
using System.Collections.Concurrent;

using log4net;

using ACE.Server.Managers;
using ACE.Server.WorldObjects;

namespace ACE.Server.Entity
{
    public static class InventoryRegistry
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static readonly ConcurrentDictionary<uint, uint> items = new ConcurrentDictionary<uint, uint>();

        public static bool TryAdd(WorldObject item, Player player, bool handleContainers = false)
        {
            //Console.WriteLine($"InventoryRegistry.TryAdd({item.Name} ({item.Guid}), {player.Name})");

            var success = items.TryAdd(item.Guid.Full, player.Guid.Full);

            if (!success)
            {
                IPlayer owner = null;

                if (items.TryGetValue(item.Guid.Full, out var ownerGuid))
                    owner = GetPlayer(ownerGuid);

                log.Error($"[INVENTORY] TryAdd({item.Name} ({item.Guid}), {player.Name}) failed -- already owned by {owner?.Name}");
                log.Error(Environment.StackTrace);

                // we could return here, but continue onwards for full container logging
            }

            // handleContainers == false at login, and container management is handled outside of this function during login
            // during login, we have full per-item atomicity

            // handleContainers == true during gameplay, where we only have per-container atomicity
            if (handleContainers && item is Container container)
            {
                foreach (var kvp in container.Inventory)
                    success &= TryAdd(kvp.Value, player, false);    // side packs cannnot contain sub-containers?
            }

            return success;
        }

        /// <summary>
        /// If container, also iterates into all container items
        /// </summary>
        public static bool TryRemove(WorldObject item, Player player)
        {
            //Console.WriteLine($"InventoryRegistry.TryRemove({item.Name} ({item.Guid}), {player.Name})");

            var success = items.TryRemove(item.Guid.Full, out var ownerGuid);

            if (!success)
            {
                log.Error($"[INVENTORY] TryRemove({item.Name} ({item.Guid}), {player.Name}) failed");
                log.Error(Environment.StackTrace);

                // we could return here, but continue onwards for full container logging
            }

            // this function is only used during gameplay and logout,
            // and we only have per-container atomicity here
            if (item is Container container)
            {
                foreach (var kvp in container.Inventory)
                    success &= TryRemove(kvp.Value, player);    // side packs cannnot contain sub-containers?
            }
            return success;
        }

        private static IPlayer GetPlayer(uint playerGuid)
        {
            var onlinePlayer = PlayerManager.GetOnlinePlayer(playerGuid);

            if (onlinePlayer != null)
                return onlinePlayer;

            return PlayerManager.GetOfflinePlayer(playerGuid);
        }
    }
}
