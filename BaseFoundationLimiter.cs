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
    [Info("BaseFoundationLimiter", "Jerimiah", "0.0.1")]
    [Description("A plugin to limits bases to a set amout of foundations.")]

    class FoundationLimiter : CovalencePlugin {
        private bool? CanBuild(Planner planner, Construction prefab, Construction.Target target) {
            var buildingID = (target.entity as DecayEntity)?.buildingID;

            if (buildingID == null) return null;

            var building = BuildingManager.server.GetBuilding((uint)buildingID);
            var foundations = building.buildingBlocks.Where(x => x.PrefabName.Contains("foundation"));

            if (foundations.Count() > 225) {
                planner.GetOwnerPlayer().ChatMessage("You reached the maximum foundations.");
                return false;
            }
            return null;
        }
    }
}
