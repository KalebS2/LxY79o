using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Items
{
    abstract class Item
    {
        public string name;
        public string description;
        public int shopPrice;
        public int sellPrice;

        public Item(string name, string description, int shopPrice, int sellPrice)
        {
            this.name = name;
            this.description = description;
            this.shopPrice = shopPrice;
            this.sellPrice = sellPrice;
        }
        public abstract void Use(Entity user, Entity target);
    }
}

