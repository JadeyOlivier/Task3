using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JadeOlivier_19013088_Task1
{
    abstract class Unit
    {
        protected int xPos;
        protected int yPos;
        protected string name;
        protected int health;
        protected int maxHealth;
        protected int speed;
        protected int attk;
        protected int attkRange;
        protected string faction;
        protected char symbol;
        protected bool isAttacking;

        //Constructor intialiser for Unit class
        protected Unit(int x, int y, string unitName, int hp, int howFast, int attack, int range, string team, char symb, bool attkConfirmed)
        {
            this.xPos = x;
            this.yPos = y;
            this.name = unitName;
            this.health = hp;
            this.speed = howFast;
            this.attk = attack;
            this.attkRange = range;
            this.faction = team;
            this.symbol = symb;
            this.isAttacking = attkConfirmed;
            this.maxHealth = hp;
        }

        protected Unit(int x, int y, string unitName, int hp, int maxHp, int howFast, int attack, int range, string team, char symb, bool attkConfirmed)
        {
            this.xPos = x;
            this.yPos = y;
            this.name = unitName;
            this.health = hp;
            this.speed = howFast;
            this.attk = attack;
            this.attkRange = range;
            this.faction = team;
            this.symbol = symb;
            this.isAttacking = attkConfirmed;
            this.maxHealth = maxHp;
        }

        //Abstract methods to be used by subclasses
        //Movement takes in the enemy unit the current unit needs to move to and finds the shortest way of getting to that unit without moviong diagonally
        public abstract string Move(Unit unitToEngage);

        //Method to deal with combatting the enemy unit once it is in range. Lowers enemy hp using current units attack value 
        public abstract void Combat(Unit attackingUnit);

        //Tests if closest enemy unit is within range of the current unit 
        public abstract bool IsInRange(Unit unitInRange);

        //Distance formula used to determine closest unit. If distance of the opponent unit currently being tested is less than the
        //distance of the previously tested opponent unit, the current unit then becomes the closest unit. Once all units in the 
        //array have been tested, the closest enemy unit is passed back to GameEngine
        public abstract Unit ClosestUnit(Unit[] unitClosetCheck);

        //Tests if current units health is <= 0 and removes it from the map
        public abstract bool IsDead();

        public abstract void Save();

        //For displaying stats of the unit
        public override abstract string ToString();   
        
        
    }

}
