using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JadeOlivier_19013088_Task1
{
    class GameEngine
    {
        int numRounds= 0;
        private static int hEIGHT = 30;
        private static int wIDTH = 25;
        Map mapTracker = new Map(WIDTH,HEIGHT,15,6);

        public GameEngine()
        {
            
        }

        public Map MapTracker { get => mapTracker; set => mapTracker = value; }
        //Constants created for map height and width
        public static int HEIGHT { get => hEIGHT;}
        public static int WIDTH { get => wIDTH;}

        //Units and buildings each move on their own turn if number of rounds that have happened allow the unit/building to move.
        //Units will then either move to their closest enemy unit, attack that enemy unit or simply runaway based on its current state
        //Resource buildings  tick up resources for the team and Factory buildings spawn units if the number of rounds falls withing thier production speed and their are enough resources to do so
        public void GameRun()
        {
            ++numRounds;
            bool unitDied;
            string direction;

            foreach (Unit temp in MapTracker.unitArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit obj = (MeleeUnit)temp;
                    unitDied = obj.IsDead();
                    if (unitDied == false)
                    {
                        if (numRounds % obj.Speed == 0)
                        {
                            if (obj.Health > (0.25 * obj.MaxHealth))
                            {
                                switch (obj.Faction)
                                {
                                    case "Night Riders":
                                        {
                                            if (MapTracker.DwBuildings > 0)
                                            {
                                                Building closestBuilding = obj.ClosestUnit(MapTracker.buildingArray);
                                                if (obj.IsAttacking == false && obj.IsInRange(closestBuilding) == false)
                                                {
                                                    direction = obj.Move(closestBuilding);
                                                    switch (direction)
                                                    {
                                                        case "Right":
                                                            {
                                                                if (obj.XPos != HEIGHT)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, HEIGHT - 1] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Left":
                                                            {
                                                                if (obj.XPos != -1)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = HEIGHT - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Up":
                                                            {
                                                                if (obj.YPos != WIDTH)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[WIDTH - 1, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Down":
                                                            {
                                                                if (obj.YPos != -1)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = WIDTH - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                    }

                                                }
                                                else if (obj.IsInRange(closestBuilding) == true)
                                                {
                                                    obj.IsAttacking = true;
                                                    obj.Combat(closestBuilding);
                                                }
                                            }
                                            else
                                            {
                                                Unit closest = obj.ClosestUnit(MapTracker.unitArray);
                                                if (obj.IsAttacking == false && obj.IsInRange(closest) == false)
                                                {
                                                    direction = obj.Move(closest);
                                                    switch (direction)
                                                    {
                                                        case "Right":
                                                            {
                                                                if (obj.XPos != HEIGHT)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, HEIGHT - 1] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Left":
                                                            {
                                                                if (obj.XPos != -1)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = HEIGHT - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Up":
                                                            {
                                                                if (obj.YPos != WIDTH)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[WIDTH - 1, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Down":
                                                            {
                                                                if (obj.YPos != 0)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = WIDTH - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                    }

                                                }
                                                else if (obj.IsInRange(closest) == true)
                                                {
                                                    obj.IsAttacking = true;
                                                    obj.Combat(closest);
                                                }
                                            }
                                            break;
                                        }

                                    case "Day Walkers":
                                        {
                                            if (MapTracker.NrBuildings > 0)
                                            {
                                                Building closestBuilding = obj.ClosestUnit(MapTracker.buildingArray);
                                                if (obj.IsAttacking == false && obj.IsInRange(closestBuilding) == false)
                                                {
                                                    direction = obj.Move(closestBuilding);
                                                    switch (direction)
                                                    {
                                                        case "Right":
                                                            {
                                                                if (obj.XPos != HEIGHT)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, HEIGHT - 1] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Left":
                                                            {
                                                                if (obj.XPos != -1)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = HEIGHT - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Up":
                                                            {
                                                                if (obj.YPos != WIDTH)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[WIDTH - 1, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Down":
                                                            {
                                                                if (obj.YPos != 0)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = WIDTH - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                    }

                                                }
                                                else if (obj.IsInRange(closestBuilding) == true)
                                                {
                                                    obj.IsAttacking = true;
                                                    obj.Combat(closestBuilding);
                                                }
                                            }
                                            else
                                            {
                                                Unit closest = obj.ClosestUnit(MapTracker.unitArray);
                                                if (obj.IsAttacking == false && obj.IsInRange(closest) == false)
                                                {
                                                    direction = obj.Move(closest);
                                                    switch (direction)
                                                    {
                                                        case "Right":
                                                            {
                                                                if (obj.XPos != HEIGHT)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, HEIGHT - 1] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Left":
                                                            {
                                                                if (obj.XPos != -1)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = HEIGHT - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Up":
                                                            {
                                                                if (obj.YPos != WIDTH)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[WIDTH - 1, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Down":
                                                            {
                                                                if (obj.YPos != 0)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = WIDTH - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                    }

                                                }
                                                else if (obj.IsInRange(closest) == true)
                                                {
                                                    obj.IsAttacking = true;
                                                    obj.Combat(closest);
                                                }
                                            }
                                            break;
                                        }
                                }                               
                               
                            }
                            else
                            {
                                direction = obj.RandomMove();
                                switch (direction)
                                {
                                    case "Right":
                                        {
                                            obj.XPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                            break;
                                        }
                                    case "Left":
                                        {
                                            obj.XPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                            break;
                                        }
                                    case "Up":
                                        {
                                            obj.YPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                            break;
                                        }
                                    case "Down":
                                        {
                                            obj.YPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                            break;
                                        }
                                }
                            }
                        }
                    }                   
                }
                else if (typeCheck == "RangedUnit")
                {
                    RangedUnit obj = (RangedUnit)temp;
                    unitDied = obj.IsDead();
                    if (unitDied == false)
                    {
                        if (numRounds % obj.Speed == 0)
                        {
                            if (obj.Health > (0.25 * obj.MaxHealth))
                            {
                                switch (obj.Faction)
                                {
                                    case "Night Riders":
                                        {
                                            if (MapTracker.DwBuildings > 0)
                                            {
                                                Building closestBuilding = obj.ClosestUnit(MapTracker.buildingArray);
                                                if (obj.IsAttacking == false && obj.IsInRange(closestBuilding) == false)
                                                {
                                                    direction = obj.Move(closestBuilding);
                                                    switch (direction)
                                                    {
                                                        case "Right":
                                                            {
                                                                if (obj.XPos != HEIGHT)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, HEIGHT - 1] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Left":
                                                            {
                                                                if (obj.XPos != -1)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = HEIGHT - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Up":
                                                            {
                                                                if (obj.YPos != WIDTH)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[WIDTH - 1, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Down":
                                                            {
                                                                if (obj.YPos != 0)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = WIDTH - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                    }

                                                }
                                                else if (obj.IsInRange(closestBuilding) == true)
                                                {
                                                    obj.IsAttacking = true;
                                                    obj.Combat(closestBuilding);
                                                }
                                            }
                                            else
                                            {
                                                Unit closest = obj.ClosestUnit(MapTracker.unitArray);
                                                if (obj.IsAttacking == false && obj.IsInRange(closest) == false)
                                                {
                                                    direction = obj.Move(closest);
                                                    switch (direction)
                                                    {
                                                        case "Right":
                                                            {
                                                                if (obj.XPos != HEIGHT)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, HEIGHT - 1] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Left":
                                                            {
                                                                if (obj.XPos != -1)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = HEIGHT - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Up":
                                                            {
                                                                if (obj.YPos != WIDTH)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[WIDTH - 1, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Down":
                                                            {
                                                                if (obj.YPos != 0)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = WIDTH - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                    }

                                                }
                                                else if (obj.IsInRange(closest) == true)
                                                {
                                                    obj.IsAttacking = true;
                                                    obj.Combat(closest);
                                                }
                                            }
                                            break;
                                        }

                                    case "Day Walkers":
                                        {
                                            if (MapTracker.NrBuildings > 0)
                                            {
                                                Building closestBuilding = obj.ClosestUnit(MapTracker.buildingArray);
                                                if (obj.IsAttacking == false && obj.IsInRange(closestBuilding) == false)
                                                {
                                                    direction = obj.Move(closestBuilding);
                                                    switch (direction)
                                                    {
                                                        case "Right":
                                                            {
                                                                if (obj.XPos != HEIGHT)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, HEIGHT - 1] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Left":
                                                            {
                                                                if (obj.XPos != -1)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = HEIGHT - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Up":
                                                            {
                                                                if (obj.YPos != WIDTH)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[WIDTH - 1, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Down":
                                                            {
                                                                if (obj.YPos != 0)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = WIDTH - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                    }

                                                }
                                                else if (obj.IsInRange(closestBuilding) == true)
                                                {
                                                    obj.IsAttacking = true;
                                                    obj.Combat(closestBuilding);
                                                }
                                            }
                                            else
                                            {
                                                Unit closest = obj.ClosestUnit(MapTracker.unitArray);
                                                if (obj.IsAttacking == false && obj.IsInRange(closest) == false)
                                                {
                                                    direction = obj.Move(closest);
                                                    switch (direction)
                                                    {
                                                        case "Right":
                                                            {
                                                                if (obj.XPos != HEIGHT)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, HEIGHT - 1] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Left":
                                                            {
                                                                if (obj.XPos != -1)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.XPos = HEIGHT - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Up":
                                                            {
                                                                if (obj.YPos != WIDTH)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = 0;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[WIDTH - 1, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                        case "Down":
                                                            {
                                                                if (obj.YPos != 0)
                                                                {
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                                }
                                                                else
                                                                {
                                                                    obj.YPos = WIDTH - 1;
                                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                                }
                                                                break;
                                                            }
                                                    }

                                                }
                                                else if (obj.IsInRange(closest) == true)
                                                {
                                                    obj.IsAttacking = true;
                                                    obj.Combat(closest);
                                                }
                                            }
                                            break;
                                        }
                                }
                            }
                            else
                            {
                                direction = obj.RandomMove();
                                switch (direction)
                                {
                                    case "Right":
                                        {
                                            obj.XPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                            break;
                                        }
                                    case "Left":
                                        {
                                            obj.XPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                            break;
                                        }
                                    case "Up":
                                        {
                                            obj.YPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                            break;
                                        }
                                    case "Down":
                                        {
                                            obj.YPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                            break;
                                        }
                                }
                            }
                        }
                    }                   
                }
                else if (typeCheck == "WizardUnit")
                {
                    WizardUnit obj = (WizardUnit)temp;
                    unitDied = obj.IsDead();
                    if (unitDied == false)
                    {
                        if(numRounds% obj.Speed == 0)
                        {
                            if(obj.Health > (0.5 * obj.MaxHealth))
                            {                               
                                Unit closest = obj.ClosestUnit(MapTracker.unitArray);
                                if (obj.IsAttacking == false && obj.IsInRange(closest) == false)
                                {
                                    direction = obj.Move(closest);
                                    switch (direction)
                                    {
                                        case "Right":
                                            {
                                                if (obj.XPos != HEIGHT)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                                }
                                                else
                                                {
                                                    obj.XPos = 0;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, HEIGHT - 1] = '.';
                                                }
                                                break;
                                            }
                                        case "Left":
                                            {
                                                if (obj.XPos != -1)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                                }
                                                else
                                                {
                                                    obj.XPos = HEIGHT - 1;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos, 0] = '.';
                                                }
                                                break;
                                            }
                                        case "Up":
                                            {
                                                if (obj.YPos != WIDTH)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                                }
                                                else
                                                {
                                                    obj.YPos = 0;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[WIDTH - 1, obj.XPos] = '.';
                                                }
                                                break;
                                            }
                                        case "Down":
                                            {
                                                if (obj.YPos != 0)
                                                {
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                                }
                                                else
                                                {
                                                    obj.YPos = WIDTH - 1;
                                                    MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                                    mapTracker.mapVisuals[0, obj.XPos] = '.';
                                                }
                                                break;
                                            }
                                    }

                                }
                                else 
                                {
                                    for (int i = 0; i < MapTracker.unitArray.Length; i++)
                                    {
                                        if (obj.IsInRange(MapTracker.unitArray[i]) == true)
                                        {
                                            obj.Combat(MapTracker.unitArray[i]);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                direction = obj.RandomMove();
                                switch (direction)
                                {
                                    case "Right":
                                        {
                                            obj.XPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos - 1] = '.';
                                            break;
                                        }
                                    case "Left":
                                        {
                                            obj.XPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos + 1] = '.';
                                            break;
                                        }
                                    case "Up":
                                        {
                                            obj.YPos++;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos - 1, obj.XPos] = '.';
                                            break;
                                        }
                                    case "Down":
                                        {
                                            obj.YPos--;
                                            MapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                            mapTracker.mapVisuals[obj.YPos + 1, obj.XPos] = '.';
                                            break;
                                        }
                                }
                            }
                        }
                    }                    
                }
            }


            //Dealing with the buildings duties
            foreach (Building temp in mapTracker.buildingArray)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if(typeCheck == "ResourceBuilding")
                {
                    ResourceBuilding resource = (ResourceBuilding)temp;
                    resource.GeneratedResources();
                }
                else
                {
                    FactoryBuilding factory = (FactoryBuilding)temp;
                    if(numRounds % factory.ProdutionSpeed == 0)
                    {
                        switch (factory.Team)
                        {
                            case "Night Riders":
                                {
                                    if (MapTracker.NrResources > factory.ResourceToUnit)
                                    {
                                        Array.Resize(ref mapTracker.unitArray, mapTracker.unitArray.Length + 1);
                                        Unit generatedUnit = factory.generateUnit();
                                        mapTracker.unitArray[mapTracker.unitArray.Length - 1] = generatedUnit;

                                        typeCheck = generatedUnit.GetType().ToString();
                                        splitArray = typeCheck.Split('.');
                                        typeCheck = splitArray[splitArray.Length - 1];

                                        if (typeCheck == "MeleeUnit")
                                        {
                                            MeleeUnit obj = (MeleeUnit)generatedUnit;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                        }
                                        else
                                        {
                                            RangedUnit obj = (RangedUnit)generatedUnit;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                        }

                                        MapTracker.NrResources -= factory.ResourceToUnit;
                                    }
                                    break;
                                }

                            case "Day Walkers":
                                {
                                    if (MapTracker.DwResources > factory.ResourceToUnit)
                                    {
                                        Array.Resize(ref mapTracker.unitArray, mapTracker.unitArray.Length + 1);
                                        Unit generatedUnit = factory.generateUnit();
                                        mapTracker.unitArray[mapTracker.unitArray.Length - 1] = generatedUnit;

                                        typeCheck = generatedUnit.GetType().ToString();
                                        splitArray = typeCheck.Split('.');
                                        typeCheck = splitArray[splitArray.Length - 1];

                                        if (typeCheck == "MeleeUnit")
                                        {
                                            MeleeUnit obj = (MeleeUnit)generatedUnit;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                        }
                                        else
                                        {
                                            RangedUnit obj = (RangedUnit)generatedUnit;
                                            mapTracker.mapVisuals[obj.YPos, obj.XPos] = obj.Symbol;
                                        }

                                        MapTracker.DwResources -= factory.ResourceToUnit;
                                    }
                                    break;
                                }
                        }
                    }
                }
            }
        }

    }
}
