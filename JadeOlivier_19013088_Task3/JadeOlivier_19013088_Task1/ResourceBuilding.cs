using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JadeOlivier_19013088_Task1
{
    class ResourceBuilding : Building
    {
        GameEngine ge = new GameEngine();
        private string rescourceType;
        private int generatedAmount;
        private int amountPerRound;
        private int resourcePool;

        public int X { get => base.x; set => base.x = value; }
        public int Y { get => base.y; set => base.y = value; }
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth;}
        public string Team { get => base.team;}
        public char Symbol { get => base.symbol;}

        public ResourceBuilding(int x, int y, string team, char symb, string typeResource, int eachRound, int avaliableAmount) : base(x, y, 5, team, symb)
        {
            this.rescourceType = typeResource;
            this.amountPerRound = eachRound;
            this.resourcePool = avaliableAmount;
        }

        public ResourceBuilding(int x, int y, int hp, int maxhp, string team, char symb, string typeResource, int currrentGenerated, int avaliableAmount, int eachRound) : base(x, y, hp, maxhp, team, symb)
        {
            this.rescourceType = typeResource;
            this.amountPerRound = eachRound;
            this.resourcePool = avaliableAmount;
            this.health = hp;
        }

        public void GeneratedResources()
        {
            if (IsDead() == false && resourcePool > 0)
            {
                generatedAmount += amountPerRound;
                resourcePool -= amountPerRound;
            }
        }

        protected override bool IsDead()
        {
            bool died;
            if(this.Health <= 0)
            {
                died = true;
            }
            else
            {
                died = false;
            }

            return died;
        }
        public override string ToString()
        {
            string returnVal = "";

            returnVal += "A new Resource Building has spawned!" + Environment.NewLine;
            returnVal += "Its x position is: " + this.X + Environment.NewLine;
            returnVal += "Its y position is: " + this.Y + Environment.NewLine;
            returnVal += "Its health is: " + this.Health + Environment.NewLine;
            returnVal += "Its team is: " + this.Team + Environment.NewLine;
            returnVal += "Its symbol is: " + this.Symbol + Environment.NewLine;
            returnVal += "The resource it generates is: " + this.rescourceType + Environment.NewLine;
            returnVal += "Amount of resources generated each round is: " + this.amountPerRound + Environment.NewLine;
            returnVal += "Generated resources/Avaliable resources: " + this.generatedAmount + "/" + this.resourcePool + Environment.NewLine;
            returnVal += "----------------------------------------" + Environment.NewLine;
            returnVal += Environment.NewLine;

            return returnVal;
        }

        public override void Save()
        {
            string savedString = "";
            savedString += "Resource,";
            savedString += X + ",";
            savedString += Y + ",";
            savedString += Health + ",";
            savedString += MaxHealth + ",";
            savedString += Team + ",";
            savedString += Symbol + ",";
            savedString += rescourceType + ",";
            savedString += generatedAmount + ",";
            savedString += resourcePool + ",";
            savedString += amountPerRound + ",";

            FileStream fs = new FileStream("SavedBuildings/buildingTextFile", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(savedString);

            writer.Close();
            fs.Close();
        }
    }
}
