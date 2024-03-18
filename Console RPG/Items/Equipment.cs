using System;
using System.Collections.Generic;
using System.Text;


namespace Console_RPG.Items
{
    abstract class Equipment : Item
    {
        public float durability;
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice, float durability, bool isEquipped) : base(name, description, shopPrice, sellPrice)
         {
            this.durability = durability;
            this.isEquipped = isEquipped;
        }
    }
    class Armor : Equipment
    {
        public float defense;

        public Armor(string name, string description, int shopPrice, int sellPrice, float durability, bool isEquipped, float defense) : base(name, description, shopPrice, sellPrice, durability, isEquipped)
        {
            this.defense = defense;
        }
        public override void Use(Entity user, Entity target)
        {
            this.isEquipped = !this.isEquipped;

            if(this.isEquipped) 
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

    class Weapon : Equipment
    {
        public float damageIncrease;
    public Weapon(string name, string description, int shopPrice, int sellPrice, float durability, bool isEquipped, float damageIncrease) : base(name, description, shopPrice, sellPrice, durability, isEquipped)
        {
            this.damageIncrease = damageIncrease;
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
