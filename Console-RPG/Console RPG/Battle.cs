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
                        Console.WriteLine("It is " + player.name + "s turn");
                        player.DoTurn(players, enemies);
                    }
                }
                //Loop through all the enemies
                foreach (var enemy in enemies)
                {
                    if (enemy.currentHP > 0)
                    {
                        Console.WriteLine("It is " + enemy.name + "s turn");
                        enemy.DoTurn(players, this.enemies);
                    }
                }
                // If the players lose we bully them here
                if (players.TrueForAll(player => player.currentHP <= 0))
                {
                    Console.WriteLine("Skill issue. You suck at this game. Go cry in a corner now because you're just so bad at video games.");
                    break;
                }
                // If the players win we praise them here
                if (enemies.TrueForAll(enemy => enemy.currentHP <= 0))
                {
                    Console.WriteLine("Congratualations! The enemies are now sent to the gulag to work off thier defeat.");
                    break;
                }
            }
        }
    }
}
