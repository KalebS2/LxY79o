using System.Collections.Generic;
using System.Text;

namespace Console_RPG
{
    abstract class Entity
    {
        public string name;
        public float currentHP, maxHP;
        public Stats stats;

        public Entity(string name, float hp, Stats stats)
        {
            this.name = name;
            this.currentHP = hp;
            this.maxHP = hp;
            this.stats = stats;
        }
        public abstract void DoTurn(List<Player> players, List<Enemy> enemies);
        public abstract Entity ChooseTarget(List<Entity> choices);
        public abstract void Attack(Entity target);
    }
}
