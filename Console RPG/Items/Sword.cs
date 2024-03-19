using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Items
{
    internal class Sword : Weapon
    {
        public static Sword twig = new Sword("Twig", "It's a twig the shopkeeper is selling. It does less damage then your fists so there is no advantage to buying this", 10, 8, 5, 5, false, -1);
        public static Sword sword = new Sword("Sword", "It's dangerous to go alone. Take this!", 30, 25, 15, 15, false, 3);
        public Sword(string name, string description, int shopPrice, int sellPrice, float currentDurability, float maxDurability, bool isEquipped, float damageIncrease) : base(name, description, shopPrice, sellPrice, currentDurability, maxDurability, isEquipped, damageIncrease)
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