using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Items
{
    internal class DamageItem : Item
    {
        public static DamageItem instaKill = new DamageItem("Drop of Annihilation", "Oh... Well I would save this one for a very powerful enemy", 0, 0, 9999);

        public int damage;
        public DamageItem(string name, string description, int shopPrice, int sellPrice, int damage) : base(name, description, shopPrice, sellPrice)
        {
            this.damage = damage;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHP -= damage;
            Console.WriteLine($"{target.name} just took {damage} damage. Ouch!");
        }
    }
}
