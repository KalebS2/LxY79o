using System;
using System.Collections.Generic;
using Console_RPG.Items;
using System.Text;

namespace Console_RPG
{
    class Treasure : Feature
    {
        public Item item;

        public Treasure(Item item) : base(false)
        {
            this.item = item;
        }
        public override void Resolve(List<Player> players)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"You got the {item.name}");
            Console.ForegroundColor = ConsoleColor.White;
            Player.Inventory.Remove(item);
            Player.Inventory.Add(item);
        }
    }
}
