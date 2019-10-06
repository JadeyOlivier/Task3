using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JadeOlivier_19013088_Task1
{
    class Map
    {
        
        Random rgn = new Random();

        int unitAmount;
        int buildingAmount;
        int wizardAmount;
        public Unit[] unitArray;
        public char[,] mapVisuals;
        public Building[] buildingArray;


        public int width;
        public int height;

        private int numNightRiders;
        private int numDayWalkers;
        int numWizards;
        int dwBuildings, nrBuildings;

        public int UnitAmount { get => unitAmount; set => unitAmount = value; }
        public int BuildingAmount { get => buildingAmount; set => buildingAmount = value; }
        public int NumNightRiders { get => numNightRiders; set => numNightRiders = value; }
        public int NumDayWalkers { get => numDayWalkers; set => numDayWalkers = value; }
        public int DwBuildings { get => dwBuildings; set => dwBuildings = value; }
        public int NrBuildings { get => nrBuildings; set => nrBuildings = value; }
        public int NumWizards { get => numWizards; set => numWizards = value; }

        public Map(int mapHeight, int mapWidth, int numUnits, int numBuildings)
        {
            //const int HEIGHT = mapHeight;
            this.width = mapWidth;
            this.height = mapHeight;
            mapVisuals = new char[width, height];

            this.UnitAmount = numUnits;
            unitArray = new Unit[numUnits];

            this.BuildingAmount = numBuildings;
            buildingArray = new Building[numBuildings];
        }


        public void populateMap()
        {
            string teamName, unitName = "", resource, unitType = "";
            char symbol;
            int xPos, yPos, teamNum, nameNum, buildingNum, avaliableResources, perRound, unitToProduce;

            for (int m = 0; m <= unitArray.Length - 1; m++)
            {
                int type = rgn.Next(0, 3);
                switch (type)
                {
                    case 0:
                        {
                            xPos = rgn.Next(0, height);
                            yPos = rgn.Next(0, width);
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
                                ++NumNightRiders;
                            }
                            else
                            {
                                teamName = "Day Walkers";
                                symbol = 'm';
                                ++NumDayWalkers;
                            }
                            unitArray[m] = new MeleeUnit(xPos,yPos,unitName,teamName,symbol,false);
                            break;
                        }

                    case 1:
                        {
                            xPos = rgn.Next(0, height);
                            yPos = rgn.Next(0, width);
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
                                ++NumNightRiders;
                            }
                            else
                            {
                                teamName = "Day Walkers";
                                symbol = 'r';
                                ++NumDayWalkers;
                            }
                            unitArray[m] = new RangedUnit(xPos,yPos, unitName, teamName,symbol,false);
                            break;
                        }

                    case 3:
                        {
                            xPos = rgn.Next(0, height);
                            yPos = rgn.Next(0, width);
                            teamName = "Wizards";
                            symbol = 'W';
                            unitArray[m] = new WizardUnit(xPos, yPos, unitName, teamName, symbol, false);
                            break;
                        }
                }
            }

            foreach (Unit temp in unitArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)temp;
                    mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                }
                else
                {
                    RangedUnit obj = (RangedUnit)temp;
                    mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                }
            }

            for (int k = 0; k < BuildingAmount; k++)
            {
                buildingNum = rgn.Next(0, 2);
                switch (buildingNum)
                {
                    //ResourceBuilding
                    case 0:
                        {
                            xPos = rgn.Next(0, height);
                            yPos = rgn.Next(0, width);
                            while (mapVisuals[yPos,xPos] == 'r' && mapVisuals[yPos, xPos] == 'R' && mapVisuals[yPos, xPos] == 'm' && mapVisuals[yPos, xPos] == 'M')
                            {
                                xPos = rgn.Next(0, height);
                                yPos = rgn.Next(0, width);
                            }

                            teamNum = rgn.Next(0, 2);
                            if (teamNum == 0)
                            {
                                teamName = "Night Riders";
                                symbol = 'O';
                                resource = "Wood";
                                avaliableResources = rgn.Next(50, 201);
                                perRound = rgn.Next(1, 5);
                                NrBuildings++;
                            }
                            else
                            {
                                teamName = "Day Walkers";
                                symbol = 'o';
                                resource = "Steel";
                                avaliableResources = rgn.Next(50, 201);
                                perRound = rgn.Next(1, 5);
                                DwBuildings++;
                            }

                            mapVisuals[yPos, xPos] = symbol;
                            buildingArray[k] = new ResourceBuilding(xPos, yPos, teamName, symbol, resource, perRound, avaliableResources);
                            break;
                        }

                    //FactoryBuilding
                    case 1:
                        {
                            xPos = rgn.Next(0, height);
                            yPos = rgn.Next(0, width);
                            while (mapVisuals[yPos, xPos] == 'r' && mapVisuals[yPos, xPos] == 'R' && mapVisuals[yPos, xPos] == 'm' && mapVisuals[yPos, xPos] == 'M')
                            {
                                xPos = rgn.Next(0, height);
                                yPos = rgn.Next(0, width);
                            }
                            teamNum = rgn.Next(0, 2);
                            if (teamNum == 0)
                            {
                                teamName = "Night Riders";
                                symbol = 'U';
                                NrBuildings++;
                            }
                            else
                            {
                                teamName = "Day Walkers";
                                symbol = 'U';
                                DwBuildings++;
                            }

                            unitToProduce = rgn.Next(0, 2);
                            switch (unitToProduce)
                            {
                                case 0:
                                    {
                                        unitType = "MeleeUnit";
                                        break;
                                    }
                                case 1:
                                    {
                                        unitType = "RangedUnit";
                                        break;
                                    }
                            }
                            mapVisuals[yPos, xPos] = symbol;

                            buildingArray[k] = new FactoryBuilding(xPos, yPos, teamName, symbol, unitType, 5, 4);
                            break;
                        }
                }
            }

            for (int b = 0; b <= height - 1; b++)
            {
                for (int p = 0; p <= width - 1; p++)
                {
                    if (mapVisuals[b, p] != 'R' && mapVisuals[b, p] != 'r' && mapVisuals[b, p] != 'M' && mapVisuals[b, p] != 'm' && mapVisuals[b, p] != 'W' && mapVisuals[b, p] != 'w' && mapVisuals[b, p] != 'U' && mapVisuals[b, p] != 'u')
                    {
                        mapVisuals[b, p] = '.';
                    }

                }
            }
        }


        public string drawMap()
        {
            string mapShow = "";

            for (int i = 0; i <= height - 1; i++)
            {
                for (int j = 0; j <= width - 1; j++)
                {
                    mapShow += Convert.ToString(mapVisuals[j, i]);
                }
                mapShow += Environment.NewLine;
            }

            return mapShow;
        }   

        public void Read()
        {
            int index, x, y, health, maxHealth, generatedAmount, resourcePool, amountGeneratedPerRound, productionSpeed;
            string name, team, resourceType, unitType;
            char symbol;
            bool attackConfirmed;

            for (int b = 0; b <= height - 1; b++)
            {
                for (int p = 0; p <= width - 1; p++)
                {
                    mapVisuals[b, p] = ' ';
                }
            }

            FileStream fsU = new FileStream("SavedUnits/unitTextFile", FileMode.Open, FileAccess.Read);
            StreamReader readerUnits = new StreamReader(fsU);

            string lineUnit = readerUnits.ReadLine();
            index = 0;
            while (lineUnit != null)
            {
                string[] splitArray = lineUnit.Split(',');
                if (splitArray[0] == "Melee")
                {
                    x = Convert.ToInt32(splitArray[1]);
                    y = Convert.ToInt32(splitArray[2]);
                    name = splitArray[3];
                    health = Convert.ToInt32(splitArray[4]);
                    maxHealth = Convert.ToInt32(splitArray[5]);
                    team = splitArray[9];
                    symbol = Convert.ToChar(splitArray[10]);
                    attackConfirmed = Convert.ToBoolean(splitArray[11]);

                    unitArray[index] = new MeleeUnit(x, y, name, health, maxHealth, team, symbol, attackConfirmed);
                    mapVisuals[y, x] = symbol;
                }
                else
                {
                    x = Convert.ToInt32(splitArray[1]);
                    y = Convert.ToInt32(splitArray[2]);
                    name = splitArray[3];
                    health = Convert.ToInt32(splitArray[4]);
                    maxHealth = Convert.ToInt32(splitArray[5]);
                    team = splitArray[9];
                    symbol = Convert.ToChar(splitArray[10]);
                    attackConfirmed = Convert.ToBoolean(splitArray[11]);

                    unitArray[index] = new RangedUnit(x, y, name, health, maxHealth, team, symbol, attackConfirmed);
                    mapVisuals[y, x] = symbol;
                }

                index++;
                lineUnit = readerUnits.ReadLine();
            }

            FileStream fsB = new FileStream("SavedBuildings/buildingTextFile", FileMode.Open, FileAccess.Read);

            StreamReader readerBuildings = new StreamReader(fsB);

            string lineBuilding = readerBuildings.ReadLine();
            index = 0;
            while (lineBuilding != null)
            {
                string[] splitArray = lineBuilding.Split(',');
                if (splitArray[0] == "Resource")
                {
                    x = Convert.ToInt32(splitArray[1]);
                    y = Convert.ToInt32(splitArray[2]);
                    health = Convert.ToInt32(splitArray[3]);
                    maxHealth = Convert.ToInt32(splitArray[4]);
                    team = splitArray[5];
                    symbol = Convert.ToChar(splitArray[6]);
                    resourceType = splitArray[7];
                    generatedAmount = Convert.ToInt32(splitArray[8]);
                    resourcePool = Convert.ToInt32(splitArray[9]);
                    amountGeneratedPerRound = Convert.ToInt32(splitArray[10]);

                    buildingArray[index] = new ResourceBuilding(x, y, health, maxHealth, team, symbol, resourceType, generatedAmount, resourcePool, amountGeneratedPerRound);
                    mapVisuals[y, x] = symbol;
                }
                else
                {
                    x = Convert.ToInt32(splitArray[1]);
                    y = Convert.ToInt32(splitArray[2]);
                    health = Convert.ToInt32(splitArray[3]);
                    maxHealth = Convert.ToInt32(splitArray[4]);
                    team = splitArray[5];
                    symbol = Convert.ToChar(splitArray[6]);
                    unitType = splitArray[7];
                    productionSpeed = Convert.ToInt32(splitArray[8]);

                    buildingArray[index] = new FactoryBuilding(x,y,health,maxHealth,team,symbol,unitType,productionSpeed);
                    mapVisuals[y, x] = symbol;
                }

                index++;
                lineBuilding = readerBuildings.ReadLine();
            }

            for (int b = 0; b <= height - 1; b++)
            {
                for (int p = 0; p <= width - 1; p++)
                {
                    if (mapVisuals[b, p] != 'R' && mapVisuals[b, p] != 'r' && mapVisuals[b, p] != 'M' && mapVisuals[b, p] != 'm' && mapVisuals[b, p] != 'W' && mapVisuals[b, p] != 'w' && mapVisuals[b, p] != 'U' && mapVisuals[b, p] != 'u')
                    {
                        mapVisuals[b, p] = '.';
                    }

                }
            }

            fsU.Close();
            fsB.Close();

        }
    }
}
