using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Items
{
    internal class Spear : Weapon
    {
        public static Spear yardStick = new Spear("Yard Stick", "Getting stabbed with a yard stick sounds unpleasent", 20, 15, 10, 10, false, 1);
        public static Spear spear = new Spear("Spear", "Now this will really hurt", 40, 30, 20, 20, false, 3);
        public Spear(string name, string description, int shopPrice, int sellPrice, float currentDurability, float maxDurability, bool isEquipped, float damageIncrease) : base(name, description, shopPrice, sellPrice, currentDurability, maxDurability, isEquipped, damageIncrease)
        {
        }
        public override void Use(Entity user, Entity target)
        {
            this.isEquipped = !this.isEquipped;

            if (this.isEquipped)
            {
                target.stats.attack += this.damageIncrease;
                Console.WriteLine($"You equipped the {this.name}.");
            }
            else
            {
                target.stats.attack -= this.damageIncrease;
            }
        }
    }
}