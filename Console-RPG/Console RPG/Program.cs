using System;
using System.Collections.Generic;
using Console_RPG.Items;

namespace Console_RPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Location.snoIsle.SetNearbyLocations(north : Location.damonsHouse, west : Location.mushroomKingdom);
            Location.damonsHouse.SetNearbyLocations(north : Location.damonsBasement, south : Location.snoIsle);
            Location.damonsBasement.SetNearbyLocations(north : Location.animeHQ, south : Location.damonsHouse);
            Location.animeHQ.SetNearbyLocations(north : Location.kalebsHouse, south : Location.damonsBasement);
            Location.kalebsHouse.SetNearbyLocations(north : Location.shopKH, south : Location.animeHQ, west : Location.iceLevel);
            Location.iceLevel.SetNearbyLocations(west : Location.desert, east : Location.kalebsHouse);
            Location.desert.SetNearbyLocations(north : Location.mountDoom, west : Location.northKorea, east : Location.iceLevel);
            Location.mountDoom.SetNearbyLocations(north : Location.shopMD, south : Location.desert);
            Location.northKorea.SetNearbyLocations(south : Location.shopNK, west : Location.godsHouse, east : Location.desert);
            Location.mushroomKingdom.SetNearbyLocations(west : Location.skeld, east : Location.snoIsle);
            Location.skeld.SetNearbyLocations(north : Location.secretTunnel, west : Location.netherFortress, east : Location.mushroomKingdom);
            Location.secretTunnel.SetNearbyLocations(north : Location.secretTreasure, south : Location.skeld);
            Location.secretTreasure.SetNearbyLocations(south : Location.secretTunnel);
            Location.netherFortress.SetNearbyLocations(east : Location.skeld, west : Location.waterLevel);
            Location.waterLevel.SetNearbyLocations(north : Location.saulGoodman, east : Location.netherFortress, west : Location.shopOWL);
            Location.saulGoodman.SetNearbyLocations(north : Location.hyrule, south : Location.waterLevel);
            Location.hyrule.SetNearbyLocations(north : Location.facebookHQ, south : Location.saulGoodman);
            Location.facebookHQ.SetNearbyLocations(north : Location.godsHouse, south : Location.hyrule, east : Location.shopNK);
            Location.shopKH.SetNearbyLocations(south : Location.kalebsHouse);
            Location.shopOWL.SetNearbyLocations(east : Location.waterLevel);
            Location.shopMD.SetNearbyLocations(south : Location.mountDoom);
            Location.shopNK.SetNearbyLocations(north : Location.northKorea, west : Location.facebookHQ);
            Location.godsHouse.SetNearbyLocations(south : Location.facebookHQ, east : Location.northKorea);

            Location.snoIsle.Resolve(new List<Player>() { Player.kaleb });


            // This would add a Health Potion 3 to my inventory
            Player.Inventory.Add(HealthItem.potion3);

            //Print the name of the first item in inventory
            Console.WriteLine(Player.Inventory[0].name);

            //remove the health potion 1 from inventory if it's in there
            Player.Inventory.Remove(HealthItem.potion1);

            //Remove the first item from inventory
            Player.Inventory.RemoveAt(0);

            //This would remove everything from the inventory
            Player.Inventory.Clear();
        }
    }
}
