using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Items
{
    internal class Chestplate : Armor
    {
        public static Chestplate wChest = new Chestplate("Weak Chestplate", "It may be cheap but it'll get the job done... maybe", 15, 10, 10, 10, false, 1);
        public static Chestplate sChest = new Chestplate("Strong Chestplate", "This chestplate is tougher, but more expensive. ", 40, 30, 20, 20, false, 2);
        public Chestplate(string name, string description, int shopPrice, int sellPrice, float currentDurability, float maxDurability, bool isEquipped, float defense) : base(name, description, shopPrice, sellPrice, currentDurability, maxDurability, isEquipped, defense)
        {
        }
        public override void Use(Entity user, Entity target)
        {
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                target.stats.defense += this.defense;
                Console.WriteLine($"You equipped the {this.name}.");
            }
            else
            {
                target.stats.defense -= this.defense;
            }
        }
    }
}
