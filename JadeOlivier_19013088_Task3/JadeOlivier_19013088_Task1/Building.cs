using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JadeOlivier_19013088_Task1
{
    abstract class Building
    {
        protected int x;
        protected int y;
        protected int health;
        protected int maxHealth;
        protected string team;
        protected char symbol;

        public Building(int xPos, int yPos, int hp, string faction, char symb)
        {
            this.x = xPos;
            this.y = yPos;
            this.health = hp;
            this.team = faction;
            this.symbol = symb;
            this.maxHealth = hp;
        }

        public Building(int xPos, int yPos, int hp, int maxHP, string faction, char symb)
        {
            this.x = xPos;
            this.y = yPos;
            this.health = hp;
            this.team = faction;
            this.symbol = symb;
            this.maxHealth = maxHP;
        }

        protected abstract bool IsDead();
        public override abstract string ToString();
        public abstract void Save();
    }
}
