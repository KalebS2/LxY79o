using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Console_RPG.Items
{
    internal class DefenseItem : Item
    {
        public int defenseIncrease;

        public static DefenseItem defensePot1 = new DefenseItem("Defense Potion 1", "A permanent (weak) defense potion for use on one player", 20, 15, 3);
        public static DefenseItem defensePot2 = new DefenseItem("Defense Potion 2", "A permanent (STRONG) defense potion for use on one player", 50, 35, 10);

        public DefenseItem(string name, string description, int shopPrice, int sellPrice, int defenseIncrease) : base(name, description, shopPrice, sellPrice)
        {
            this.defenseIncrease = defenseIncrease;
        }

        public override void Use(Entity user, Entity target)
        {
            target.stats.defense += defenseIncrease;
            Console.WriteLine($"{target.name} had their defense raised by {defenseIncrease}!");
        }
    }
}