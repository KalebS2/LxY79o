using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Items
{
    internal class Leggings : Armor
    {
        public static Leggings wLegs = new Leggings("Weak Leggings", "It can't hurt anything but your bank account. Oh well it's cheap", 15, 10, 10, 10, false, 1);
        public static Leggings sLegs = new Leggings("Strong Leggings", "Now this is some good pants", 40, 30, 20, 20, false, 2);
        public Leggings(string name, string description, int shopPrice, int sellPrice, float currentDurability, float maxDurability, bool isEquipped, float defense) : base(name, description, shopPrice, sellPrice, currentDurability, maxDurability, isEquipped, defense)
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