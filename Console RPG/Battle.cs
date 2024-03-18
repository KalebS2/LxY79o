using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Console_RPG
{
    class Battle : Feature
    {
        public List<Enemy> enemies;

        public Battle(List<Enemy> enemies) : base(false)
        {
            this.enemies = enemies;
        }

        public override void Resolve(List<Player> players)
        {
            Console.WriteLine("You have just entered a battle!");
            // Loop the turn system
            while (true)
            {
                // Loop through all the players
                foreach (var player in players)
                {
                    if (player.currentHP > 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("It is " + player.name + "s turn");
                        player.DoTurn(players, enemies);
                    }
                }
                //Loop through all the enemies
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("It is " + enemy.name + "s turn");
                        enemy.DoTurn(players, this.enemies);
                    }
                }
                // If the players lose we bully them here
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.Beep(200, 500);
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.WriteLine("Skill issue. You suck at this game. Go cry in a corner now because you're just so bad at video games.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
                // If the players win we praise them here
                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.Beep(600, 500);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Congratualations! The enemies are now sent to the gulag to work off thier defeat.");
                    if(Enemy.god.currentHP <= 0)
                    {
                        Console.WriteLine("YOU WIN!!! God has been defeated. I don't see how this could create any problems.");
                        Console.WriteLine("Type anything to exit the game.");
                        string end = Console.ReadLine().ToLower();
                        if(end == "anything")
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Oh really. You just HAD to type the word anything. I see how it is. Now typing anything will close the game for real");
                            string ender = Console.ReadLine();
                            if(ender == "anything")
                            {
                                Environment.Exit(0);
                            }
                            else
                            {
                                Environment.Exit(0);
                            }
                        }
                        else
                        {
                            Environment.Exit(0);
                        }
                    }
                    foreach (var enemy in enemies)
                    {
                        Player.CoinCount += enemy.coinsDroppedOnDefeat;
                        enemy.currentHP = enemy.maxHP;
                    }
                    Console.WriteLine($"You have {Player.CoinCount} coins!");
                    
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                }
            }
        }
    }
}
