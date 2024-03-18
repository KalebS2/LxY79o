using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Items
{
    class Map : Item
    {
        public static Map map = new Map("Map", "See the entire map with all secrets", 50, 40);

        public Map(string name, string description, int shopPrice, int sellPrice) : base(name, description, shopPrice, sellPrice)
        {
        }

        public override void Use(Entity user, Entity target)
        {
            Console.WriteLine("                        |                        |                        |          Shop          |                        |                        ");
            Console.WriteLine("                        |                        |                        |                        |                        |                        ");
            Console.WriteLine("                        |                        |                        |       Mount Doom       |                        |          Shop          ");
            Console.WriteLine("                        |                        |                        |                        |                        |                        ");
            Console.WriteLine("                        |      God's House       |      North Korea       |     Sahara Desert      |  Obligatory Ice Level  |     Kaleb's House      ");
            Console.WriteLine("                        |                        |                        |                        |                        |                        ");
            Console.WriteLine("                        |      Facebook HQ       |          Shop          |                        |                        |        Anime HQ        ");
            Console.WriteLine("                        |                        |                        |                        |                        |                        ");
            Console.WriteLine("                        |        Hyrule          |                        |    Secret Treasure     |                        |    Damon's Basement    ");
            Console.WriteLine("                        |                        |                        |                        |                        |                        ");
            Console.WriteLine("                        |  Saul Goodman's Office |                        |     Secret Tunnel      |                        |     Damon's House      ");
            Console.WriteLine("                        |                        |                        |                        |                        |                        ");
            Console.WriteLine("          Shop          | Obligatory Water Level |    Nether Fortress     |       The Skeld        |    Mushroom Kingdom    |        Sno Isle        ");
            Console.WriteLine("");
            Player.Inventory.Add(map);
        }
    }
}
