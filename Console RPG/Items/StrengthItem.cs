using System;
using System.Collections.Generic;
using System.Text;

namespace Console_RPG.Items
{
    internal class StrengthItem : Item
    {
        public int strengthIncrease;

        public static StrengthItem strengthPot1 = new StrengthItem("Strength Potion 1","A permanent (weak) defense potion for use on one player", 20, 15, 3);
        public static StrengthItem strengthPot2 = new StrengthItem("Strength Potion 2", "A permanent (STRONG) defense potion for use on one player", 50, 35, 10);

        public StrengthItem(string name, string description, int shopPrice, int sellPrice, int strengthIncrease) : base(name, description, shopPrice, sellPrice)
        {
            this.strengthIncrease = strengthIncrease;
        }

        public override void Use(Entity user, Entity target)
        {
            target.stats.attack += strengthIncrease;
            Console.WriteLine($"{target.name} had their attack power raised by {strengthIncrease}!");
        }
    }
}
