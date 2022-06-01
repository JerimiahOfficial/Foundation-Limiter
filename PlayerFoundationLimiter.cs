/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣶⣄⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣷⣴⣿⡄⠀⠀⠀⠀⠀⢀⡀
⠀⠀⠀⠀⠀⠀⠀⠀⠰⣶⣾⣿⣿⣿⣿⣿⡇⠀⢠⣷⣤⣶⣿⡇
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⣿⣀⣿⣿⣿⣿⣿⣧⣀
⠀⠀⠀⠀⠀⠀⠀⣷⣦⣀⠘⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠃
⠀⠀⠀⠀⢲⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁
⠀⠀⠀⠀⠀⠙⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡟⠁
⠀⠀⠀⠀⠀⠚⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠿⠿⠂
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠙⢻⣿⣿⡿⠛⠉⡇
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ ⠘⠋⠁⠀⠀ ⣧

Created by Jerimiah
https://github.com/JerimiahOfficial/
*/

using System.Linq;

namespace Oxide.Plugins {
    [Info("FoundationLimiter", "Jerimiah", "0.0.2")]
    [Description("A plugin to limit players to a set amout of foundations.")]

    class FoundationLimiter : CovalencePlugin {
        public static FoundationLimiter Plugin;

        // Run when server is Initialized.
        private void OnServerInitialized() {
            Plugin = this;
            Puts("Initialized");
        }

        // When the server is loaded.
        private void Unload() {
            Plugin = null;
        }

        // Hook for CanBuild so we can check if a player 
        // is building and make sure they're under the 
        // build limit.
        private object CanBuild(Planner planner, Construction entity, Construction.Target target) {
            return CheckBuild(planner.GetOwnerPlayer(), entity);
        }

        // stop building before it happens
        private object CheckBuild(BasePlayer player, Construction entity) {
            if (entity.fullName.Contains("foundation") && PlayerOverLimit(player)) {
                player.ChatMessage("You've reached the maxium foundations.");
                return false;
            }
            return null;
        }

        // Check if given player is over the foundation limit.
        private bool PlayerOverLimit(BasePlayer player) {
            return BaseNetworkable.serverEntities.OfType<BuildingBlock>().Count(x => x.name.Contains("foundation") && x.OwnerID == player.userID) > 100;
        }
    }
}
