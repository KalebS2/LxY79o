using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_RPG
{
    class Enemy : Entity
        {
            public static Enemy weakling = new Enemy("Weakling", 30, new Stats(attack : 5, defense : 1), 20, false);
        public static Enemy mario = new Enemy("Mario", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy luigi = new Enemy("Luigi", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy imposter = new Enemy("IMPOSTER", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy blaze = new Enemy("Blaze", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy wSkeleton = new Enemy("Wither Skeleton", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy nLawyer = new Enemy("Nintendo's Lawyer", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy loser1 = new Enemy("Loser", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy loser2 = new Enemy("Loser", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy loser3 = new Enemy("Loser", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy loser4 = new Enemy("Loser", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy oIceEnemy = new Enemy("Obligitory Ice Enemy", 30, new Stats(attack: 5, defense: 1), 20, false);
        public static Enemy oOIceEnemy = new Enemy("Other Obligitory Ice Enemy", 30, new Stats(attack: 5, defense: 1), 20, false);

            public static Enemy strongling = new Enemy("Strongling", 60, new Stats(attack: 7, defense: 3), 50, false);
        public static Enemy nGuard = new Enemy("Nintnendo's lawyer's bodyguard", 60, new Stats(attack: 7, defense: 3), 50, false);
        public static Enemy bbqSauce = new Enemy("Barbeque Sauce", 60, new Stats(attack: 7, defense: 3), 50, false);
        public static Enemy kaleb = new Enemy("Kaleb", 60, new Stats(attack: 7, defense: 3), 50, false);
        public static Enemy kJU = new Enemy("Kim Jong Un", 60, new Stats(attack: 7, defense: 3), 50, false);


            public static Enemy richling = new Enemy("Richling", 20, new Stats(attack: 4, defense: -50), 50, false);
        public static Enemy sGoodman = new Enemy("Saul Goodman", 20, new Stats(attack: 4, defense: -50), 50, false);
        public static Enemy bribe = new Enemy("Bribe", 20, new Stats(attack: 4, defense: -50), 50, false);


            public static Enemy fireBall = new Enemy("Fireball", 1, new Stats(attack: 10, defense: 99), 15, true);


            public static Enemy god = new Enemy("God", 250, new Stats(attack : 15, defense : 3), 500, false);

            int coinsDroppedOnDefeat;
            public bool dCry;
            public Enemy(string name, float hp, Stats stats, int coinsDroppedOnDefeat, bool dCry) : base(name, hp, stats) 
            {
                this.coinsDroppedOnDefeat = coinsDroppedOnDefeat;
                this.dCry = dCry;
            }
        public override Entity ChooseTarget(List<Entity> choices)
        {
            Random random = new Random();
            return choices[random.Next(0, choices.Count)];
        }
        public override void Attack(Entity target)
        {
            Console.WriteLine(this.name + " attacked " + target.name + "!");
            float damage;
            damage = this.stats.attack - target.stats.defense;
            target.currentHP -= damage;
            Console.WriteLine($"It did {damage} damage!");
        }

        public override void DoTurn(List<Player> players, List<Enemy> enemies)
        {
            Entity target = ChooseTarget(players.Cast<Entity>().ToList());
            Attack(target);
        }
    }
}
