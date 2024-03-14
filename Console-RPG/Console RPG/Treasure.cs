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
            Console.WriteLine($"You got the {item.name}");
            Player.Inventory.Add(item);
        }
    }
}
