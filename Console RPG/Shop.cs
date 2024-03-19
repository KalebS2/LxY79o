using Console_RPG.Items;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;

namespace Console_RPG
{
    class Shop : Feature
    {
        public string shopKeeperName;
        public List<Item> items;
        public int annoy;

        public Shop(string shopKeeperName, List<Item> items) : base(false)
        {
            this.shopKeeperName = shopKeeperName;
            this.items = items;
        }
        public override void Resolve(List<Player> players)
        {
            Console.WriteLine($"Welcome to {shopKeeperName}'s emporiom!");
            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine($"What would you like to do? You have {Player.CoinCount} coins");
                Console.WriteLine("BUY | SELL | TALK | LEAVE");
                string userChoice = Console.ReadLine().ToLower();
                if (userChoice == "buy")
                {
                    Console.WriteLine("Select an item to buy");
                    Item item = ChooseItemB(this.items);
                    if (!(item is null))
                    {
                        if (item.shopPrice > Player.CoinCount)
                        {
                            Console.WriteLine("You can't afford this item.");
                        }
                        else
                        {
                            if (annoy > 2)
                            {
                                Player.CoinCount -= (item.shopPrice + 5);
                            }
                            else
                            {
                                Player.CoinCount -= item.shopPrice;
                            }
                            Player.Inventory.Add(item);
                            Console.WriteLine($"You got {item.name}");
                            Console.Beep(200, 300);
                        }
                    }
                }
                else if (userChoice == "sell")
                {

                    Console.WriteLine("Select an item to sell");
                    Item item = ChooseItemS(Player.Inventory);
                    if (!(item is null))
                    {
                        if (item is Leggings | item is Chestplate | item is Sword | item is Spear)
                        {
                            Player.CoinCount += item.shopPrice - (0); //Replace the 0 with however I check for max durability - current durability. C# is difficult sometimes
                        }
                        else
                        {
                            Player.CoinCount += item.sellPrice;
                        }

                        Player.Inventory.Remove(item);
                        Console.WriteLine($"You sold your {item.name}");
                        Console.Beep(500, 300);
                    }

                }
                else if (userChoice == "talk")
                {
                    if (annoy > 2)
                    {
                        Console.WriteLine("Fine then. Enjoy your raised prices you annoying slimeball");
                    }
                    else if (annoy == 2)
                    {
                        Console.WriteLine("If you keep wasting my time, you'll have to pay more for my goods!");
                    }
                    else if (annoy == 1)
                    {
                        Console.WriteLine("I told you already! I don't care to talk to you. Now buy something or get out!");
                    }
                    else
                    {
                        Console.WriteLine("I don't care what you have to say. Quit loitering and buy somethin!");
                    }
                    annoy += 1;
                }
                else if (userChoice == "leave")
                {
                    break;
                }
            }
            if (annoy > 2)
            {
                Console.WriteLine("Good riddance");
            }
            else
            {
                Console.WriteLine("Come back soon.");
            }

        }
        public Item ChooseItemB(List<Item> choices)
        {
            int money = Player.CoinCount;
            for (int i = 0; i < choices.Count; i++)
            {
                if (annoy > 2)
                {
                    if (choices[i].shopPrice > money)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].shopPrice + 5})");
                        Console.WriteLine(choices[i].description);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].shopPrice + 5})");
                        Console.WriteLine(choices[i].description);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                else
                {
                    if (choices[i].shopPrice > money)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].shopPrice})");
                        Console.WriteLine(choices[i].description);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].shopPrice})");
                        Console.WriteLine(choices[i].description);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                  
                }
            }

            Console.WriteLine("Back");
            string userChoice = Console.ReadLine().ToLower();
            if (userChoice == "back")
            {
                return null;
            }
            else if (int.TryParse(userChoice, out int choice))
            {
                int index = Convert.ToInt32(choice);
                return choices[index - 1];
            }
            else
            {
                Console.WriteLine("Please select a valid input");
                return null;
            }
        }
        public Item ChooseItemS(List<Item> choices)
        {
            int money = Player.CoinCount;
            for (int i = 0; i < choices.Count; i++)
            {
                if (annoy > 2)
                {
                    if (choices[i].sellPrice > money)
                    {
                        Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].sellPrice - 5})");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].sellPrice - 5})");
                    }
                }
                else
                {
                    if (choices[i].shopPrice > money)
                    {
                        Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].sellPrice})");
                    }
                    else
                    {
                        Console.WriteLine($"{i + 1}: {choices[i].name} ({choices[i].sellPrice})");
                    }

                }
            }

            Console.WriteLine("Back");
            string userChoice = Console.ReadLine().ToLower();
            if (userChoice == "back")
            {
                return null;
            }
            else if (int.TryParse(userChoice, out int choice))
            {
                int index = Convert.ToInt32(choice);
                return choices[index - 1];
            }
            else
            {
                Console.WriteLine("Please select a valid input");
                return null;
            }
        }
    }
}