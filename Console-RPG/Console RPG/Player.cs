using System;
using System.Collections.Generic;
using System.Linq;
using Console_RPG.Items;

namespace Console_RPG
{
    class Player : Entity
        {
        public static List<Item> Inventory = new List<Item>() { HealthItem.potion1, HealthItem.potion2};
        public static int CoinCount = 0;

           public static Player kaleb = new Player("Kaleb", 100, new Stats(attack : 10, defense : 3));
        public static Player hostage = new Player("Hostage", 150, new Stats(attack: 7, defense: 4));

        public Armor headgear, chestpiece, legwear;
        public Weapon weapon;
        public Player(string name, float hp, Stats stats) : base(name, hp, stats) { }


        //Choose the target to attack
        public override Entity ChooseTarget(List<Entity> choices)
        {     
            Console.WriteLine("Select an enemy to attack");
            for (int i = 0; i < choices.Count; i++)
            {
                if (choices[i].currentHP > 0)
                {
                    Console.WriteLine($"{i + 1} {choices[i].name}");
                }
            }
            int index;
            try
            {
                index = Convert.ToInt32(Console.ReadLine());
                return choices[index - 1];
            }
            catch (Exception)
            {
                Console.WriteLine("Please return a valid input");
                ChooseTarget(choices);
                return null;
            }
        }



        // Choose a player to use an item on
        public Entity ChooseTargetPI(List<Entity> choices)
        {
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine("Select a player to use your item on");
                Console.WriteLine($"{i + 1} {choices[i].name}");
            }
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }


        // Choose an enemy to use an item on
        public Entity ChooseTargetEI(List<Entity> choices)
        {
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine("Select an enemy to use your item on");
                Console.WriteLine($"{i + 1} {choices[i].name}");
            }
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }



        public Item ChooseItem(List<Item> choices)
        {
            Console.WriteLine("Select an item to use");
            for (int i = 0; i < choices.Count; i++)
            {
                Console.WriteLine($"{i + 1} {choices[i].name}");
            }
            int index = Convert.ToInt32(Console.ReadLine());
            return choices[index - 1];
        }
        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name + "!");
            target.currentHP -= this.stats.attack;

            if(target.currentHP < 0)
            {
                Console.WriteLine($"{target.name} has been killed!");
            }
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Console.WriteLine($"Your current HP is {Player.kaleb.currentHP}");
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("ATTACK | ITEM | CRY");
            string choice = Console.ReadLine().ToLower();

            // If attack is selected
            if (choice == "attack")
            {
                //Allow the user to choose a target and attack that target
                Entity target = ChooseTarget(enemies.Cast<Entity>().ToList());
                Attack(target);
            }
            else if (choice == "item")
            {
                if (Inventory.Count == 0)
                {
                    Console.WriteLine("You don't have any items to use. Loser.");
                }
                else
                {
                    Item item = ChooseItem(Inventory);
                    //Determine which type of item is being used to determine whether to list through enemies or players
                    if (item is DamageItem)
                    {
                        Entity target = ChooseTargetEI(enemies.Cast<Entity>().ToList());
                        item.Use(this, target);
                    }
                    else
                    {
                        Entity target = ChooseTargetPI(players.Cast<Entity>().ToList());
                        item.Use(this, target);
                    }
                    Inventory.Remove(item);
                }
            }
            else if(choice == "cry")
            {
                Console.WriteLine("Di... did you really just... start crying? Seriously?!");
                for (int i = 0; i < enemies.Count; i++)
                {
                    if (enemies[i].dCry == true)
                    {
                        enemies[i].currentHP = 0;
                        Console.WriteLine("Wow! That actually worked.");
                    }
                }
            }
        }
        public void UseItem(Item item, Entity target)
        {
            item.Use(this, target);
        }
    }
}
