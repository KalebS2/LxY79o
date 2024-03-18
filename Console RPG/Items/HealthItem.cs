using System;

namespace Console_RPG.Items
{
    class HealthItem : Item
    {
        public static HealthItem potion1 = new HealthItem("Health Potion Tier 1", "It'll heal you, but not much.", 20, 10, 20);
        public static HealthItem potion2 = new HealthItem("Health Potion Tier 2", "This will heal your wounds in a dire situation.", 50, 20, 40);
        public static HealthItem potion3 = new HealthItem("Health Potion Tier 3", "The enemies are going to report you for cheating.", 100, 40, 65);
       


        public int healthIncrease;
        public HealthItem(string name, string description, int shopPrice, int sellPrice, int healthIncrease) : base(name, description, shopPrice, sellPrice)
        {
            this.healthIncrease = healthIncrease;
        }

        public override void Use(Entity user, Entity target)
        {
            target.currentHP += healthIncrease;
            if (target.currentHP > 100)
            {
                target.currentHP = 100;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{target.name} has healed to max HP!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine(target.name + " healed! They are now at " + target.currentHP + " HP.");
            }
        }
    }
}

