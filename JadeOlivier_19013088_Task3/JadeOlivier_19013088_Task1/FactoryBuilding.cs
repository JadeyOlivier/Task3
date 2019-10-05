using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JadeOlivier_19013088_Task1
{
    class FactoryBuilding : Building
    {
        private string unitType;
        private int produtionSpeed;
        private int spawnPoint;

        GameEngine ge = new GameEngine();

        public int X { get => base.x; set => base.x = value; }
        public int Y { get => base.y; set => base.y = value; }
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth;}
        public string Team { get => base.team;}
        public char Symbol { get => base.symbol;}

        public int ProdutionSpeed { get => produtionSpeed;}

        public FactoryBuilding(int x, int y, string team, char symb, string unitToProduce, int speed) : base(x, y, 5, team, symb)
        {
            this.produtionSpeed = speed;
            this.unitType = unitToProduce;
            if (x != 19)
            {
                this.spawnPoint = x + 1;
            }
            else
            {
                this.spawnPoint = x - 1;
            }
        }

        public FactoryBuilding(int x, int y, int hp, int maxHP, string team, char symb, string unitToProduce, int speed) : base(x, y, hp, maxHP, team, symb)
        {
            this.produtionSpeed = speed;
            this.unitType = unitToProduce;
            if (x != 19)
            {
                this.spawnPoint = x + 1;
            }
            else
            {
                this.spawnPoint = x - 1;
            }

        }

        public Unit generateUnit()
        {        
            string teamName, unitName = "";
            char symbol;
            int yPos, teamNum, nameNum;
            Unit returnUnit = null;
            Random rgn = new Random();

            switch (unitType)
            {
                case "MeleeUnit":
                    {
                        yPos = this.Y;
                        nameNum = rgn.Next(0, 4);
                        switch (nameNum)
                        {
                            case 0:
                                {
                                    unitName = "Knight";
                                    break;
                                }
                            case 1:
                                {
                                    unitName = "Foot Soldier";
                                    break;
                                }
                            case 2:
                                {
                                    unitName = "Scout";
                                    break;
                                }
                            case 3:
                                {
                                    unitName = "Horseman";
                                    break;
                                }
                        }

                        teamNum = rgn.Next(0, 2);
                        if (teamNum == 0)
                        {
                            teamName = "Night Riders";
                            symbol = 'M';
                            
                            ++ge.MapTracker.NumNightRiders;
                        }
                        else
                        {
                            teamName = "Day Walkers";
                            symbol = 'm';
                            ++ge.MapTracker.NumDayWalkers;
                        }
                        returnUnit = new MeleeUnit(spawnPoint, yPos, unitName, teamName, symbol, false);
                        break;
                    }

                case "RangedUnit":
                    {
                        yPos = this.Y;
                        nameNum = rgn.Next(0, 4);
                        switch (nameNum)
                        {
                            case 0:
                                {
                                    unitName = "Archer";
                                    break;
                                }
                            case 1:
                                {
                                    unitName = "Catapult";
                                    break;
                                }
                            case 2:
                                {
                                    unitName = "Tank";
                                    break;
                                }
                            case 3:
                                {
                                    unitName = "Slinger";
                                    break;
                                }
                        }

                        teamNum = rgn.Next(0, 2);
                        if (teamNum == 0)
                        {
                            teamName = "Night Riders";
                            symbol = 'R';
                            ++ge.MapTracker.NumNightRiders;
                        }
                        else
                        {
                            teamName = "Day Walkers";
                            symbol = 'r';
                            ++ge.MapTracker.NumDayWalkers;
                        }
                        returnUnit = new RangedUnit(spawnPoint, yPos, unitName, teamName, symbol, false);
                        break;
                    }
            }

            return returnUnit;
        }

        protected override bool IsDead()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            string returnVal = "";

            returnVal += "A new Factory Building has spawned!" + Environment.NewLine;
            returnVal += "Its x position is: " + this.X + Environment.NewLine;
            returnVal += "Its y position is: " + this.Y + Environment.NewLine;
            returnVal += "Its health is: " + this.Health + Environment.NewLine;
            returnVal += "Its team is: " + this.Team + Environment.NewLine;
            returnVal += "Its symbol is: " + this.Symbol + Environment.NewLine;
            returnVal += "----------------------------------------" + Environment.NewLine;
            returnVal += Environment.NewLine;

            return returnVal;
        }

        public override void Save()
        {
            string savedString = "";
            savedString += "Factory,";
            savedString += X + ",";
            savedString += Y + ",";
            savedString += Health + ",";
            savedString += MaxHealth + ",";
            savedString += Team + ",";
            savedString += Symbol + ",";
            savedString += unitType + ",";
            savedString += ProdutionSpeed + ",";

            FileStream fs = new FileStream("SavedBuildings/buildingTextFile", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(savedString);

            writer.Close();
            fs.Close();
        }
    }
}
