/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣶⣄⠀⠀⢀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣷⣴⣿⡄⠀⠀⠀⠀⠀⠀⢀⡀
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

using System.Collections.Generic;
using System.Linq;

namespace Oxide.Plugins {
    [Info("BaseFoundationLimiter", "Jerimiah", "0.0.3")]
    [Description("A plugin to limit players to a set amount of foundations.")]

    class FoundationLimiter : CovalencePlugin {
        private bool? CanBuild(Planner planner, Construction prefab, Construction.Target target) {
            uint? buildingID = (target.entity as DecayEntity)?.buildingID;

            if (buildingID == null) return null;

            BuildingManager.Building building = BuildingManager.server.GetBuilding((uint)buildingID);
            IEnumerable<BuildingBlock> foundations = building.buildingBlocks.Where(x => x.PrefabName.Contains("foundation"));

            if (foundations.Count() > 225) {
                planner.GetOwnerPlayer().ChatMessage("You reached the maximum foundations.");
                return false;
            }
            return null;
        }
    }
}
