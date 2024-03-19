using System;
using System.Collections.Generic;
using System.Text;


namespace Console_RPG.Items
{
    abstract class Equipment : Item
    {
        public float currentDurability;
        public float maxDurability;
        public bool isEquipped;

        protected Equipment(string name, string description, int shopPrice, int sellPrice, float currentDurability, float maxDurability, bool isEquipped) : base(name, description, shopPrice, sellPrice)
         {
            this.currentDurability = currentDurability;
            this.maxDurability = maxDurability;
            this.isEquipped = isEquipped;
        }
    }
    abstract class Armor : Equipment
    {
        public float defense;
        public Armor(string name, string description, int shopPrice, int sellPrice, float currentDurability, float maxDurability, bool isEquipped, float defense) : base(name, description, shopPrice, sellPrice, currentDurability, maxDurability, isEquipped)
        {
            this.defense = defense;
        }
        public override void Use(Entity user, Entity target)
        {

        }
    }

    class Weapon : Equipment
    {
        public float damageIncrease;
    public Weapon(string name, string description, int shopPrice, int sellPrice, float currentDurability, float maxDurability, bool isEquipped, float damageIncrease) : base(name, description, shopPrice, sellPrice, currentDurability, maxDurability, isEquipped)
        {
            this.damageIncrease = damageIncrease;
        }
        public override void Use(Entity user, Entity target)
        {
        }
    }
}
