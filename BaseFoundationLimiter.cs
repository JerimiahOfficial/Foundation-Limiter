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
https://github.com/JerimiahOfficial/Foundation-Limiter
*/

using System.Collections.Generic;
using System.Linq;

namespace Oxide.Plugins {
    [Info("BaseFoundationLimiter", "Jerimiah", "0.0.3")]
    [Description("Limits the amount of foundations a base can have.")]

    class BaseFoundationLimiter : CovalencePlugin {
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
