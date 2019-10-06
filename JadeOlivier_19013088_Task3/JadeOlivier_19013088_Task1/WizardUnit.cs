using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace JadeOlivier_19013088_Task1
{
    class WizardUnit : Unit
    {
        GameEngine ge = new GameEngine();

        public WizardUnit(int wizardX, int wizardY, string wizardName, string wizardTeam, char wizardSymb, bool wizardAttacking) : base(wizardX, wizardY, wizardName, 6, 6, 3, 1, wizardTeam, wizardSymb, wizardAttacking)
        {

        }

        public WizardUnit(int wizardX, int wizardY, string wizardName, int wizardHp, int wizardMaxHP, string wizardTeam, char wizardSymb, bool wizardAttacking) : base(wizardX, wizardY, wizardName, wizardHp, wizardMaxHP, 6, 3, 1, wizardTeam, wizardSymb, wizardAttacking)
        {

        }

        public override Unit ClosestUnit(Unit[] unitClosetCheck)
        {
            int workingOut, xDis, yDis;
            int closest = 1000;
            Unit returnVal = this;

            foreach (Unit temp in unitClosetCheck)
            {
                string typeCheck = temp.GetType().ToString();
                string[] splitArray = typeCheck.Split('.');
                typeCheck = splitArray[splitArray.Length - 1];

                if (typeCheck == "MeleeUnit")
                {
                    MeleeUnit m = (MeleeUnit)temp;
                    if (m.XPos != this.XPos && m.YPos != this.YPos)
                    {
                        if (m.Faction != this.Faction)
                        {
                            xDis = Math.Abs(this.XPos - m.XPos);
                            yDis = Math.Abs(this.YPos - m.YPos);
                            workingOut = Convert.ToInt32(Math.Sqrt((xDis * xDis) + (yDis * yDis)));

                            if (workingOut < closest)
                            {
                                closest = workingOut;
                                returnVal = m;
                            }
                        }
                    }
                }
                else
                {
                    RangedUnit r = (RangedUnit)temp;
                    if (r.XPos != this.XPos && r.YPos != this.YPos)
                    {
                        if (r.Faction != this.Faction)
                        {
                            xDis = Math.Abs(this.XPos - r.XPos);
                            yDis = Math.Abs(this.YPos - r.YPos);
                            workingOut = Convert.ToInt32(Math.Sqrt((xDis * xDis) + (yDis * yDis)));

                            if (workingOut < closest)
                            {
                                closest = workingOut;
                                returnVal = r;
                            }
                        }
                    }
                }
            }

            return returnVal;
        }

        public override void Combat(Unit attackingUnit)
        {
            string typeCheck = attackingUnit.GetType().ToString();
            string[] splitArray = typeCheck.Split('.');
            typeCheck = splitArray[splitArray.Length - 1];

            if (typeCheck == "MeleeUnit")
            {
                MeleeUnit mu = (MeleeUnit)attackingUnit;
                mu.Health -= this.Attk;
                this.isAttacking = false;
            }
            else
            {
                RangedUnit ru = (RangedUnit)attackingUnit;
                ru.Health -= this.Attk;
                this.IsAttacking = false;
            }
        }

        public override bool IsDead()
        {
            bool unitDead;
            if (this.Health <= 0)
            {
                unitDead = true;
                ge.MapTracker.mapVisuals[this.YPos, this.XPos] = '.';
                ge.MapTracker.NumWizards--;
            }
            else
            {
                unitDead = false;
            }

            return unitDead;
        }

        public override bool IsInRange(Unit unitInRange)
        {
            throw new NotImplementedException();
        }

        public override string Move(Unit unitToEngage)
        {
            throw new NotImplementedException();
        }

        public string RandomMove()
        {
            Random rgn = new Random();
            int move = rgn.Next(0, 4);
            string moveDirect = "";

            switch (move)
            {
                case 0:
                    {
                        moveDirect = "Right";
                        break;
                    }
                case 1:
                    {
                        moveDirect = "Left";
                        break;
                    }
                case 2:
                    {
                        moveDirect = "Up";
                        break;
                    }
                case 3:
                    {
                        moveDirect = "Down";
                        break;
                    }
            }

            return moveDirect;
        }

        public override void Save()
        {
            string savedString = "";
            savedString += "Wizard,";
            savedString += XPos + ",";
            savedString += YPos + ",";
            savedString += Name + ",";
            savedString += Health + ",";
            savedString += MaxHealth + ",";
            savedString += Speed + ",";
            savedString += Attk + ",";
            savedString += AttkRange + ",";
            savedString += Faction + ",";
            savedString += Symbol + ",";
            savedString += IsAttacking;

            FileStream fs = new FileStream("SavedUnits/unitTextFile", FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(fs);

            writer.WriteLine(savedString);

            writer.Close();
            fs.Close();
        }

        public override string ToString()
        {
            string returnVal = "";
            returnVal += "A new Wizard Unit enters the battlefield" + Environment.NewLine;
            returnVal += "Their x position is: " + this.XPos + Environment.NewLine;
            returnVal += "Their y position is: " + this.YPos + Environment.NewLine;
            returnVal += "Their name is: " + this.Name + Environment.NewLine;
            returnVal += "Their current hp is: " + this.Health + Environment.NewLine;
            returnVal += "Their max hp is: " + this.Health + Environment.NewLine;
            returnVal += "Their attack damage is: " + this.Attk + Environment.NewLine;
            returnVal += "Their range is: " + this.AttkRange + Environment.NewLine;
            returnVal += "Their speed is: " + this.Speed + Environment.NewLine;
            returnVal += "Their team is: " + this.Faction + Environment.NewLine;
            returnVal += "Their symbol is: " + this.Symbol + Environment.NewLine;
            returnVal += "----------------------------------------" + Environment.NewLine;
            returnVal += Environment.NewLine;

            return returnVal;
        }

        public int XPos { get => base.xPos; set => base.xPos = value; }
        public int YPos { get => base.yPos; set => base.yPos = value; }
        public int Health { get => base.health; set => base.health = value; }
        public int MaxHealth { get => base.maxHealth; }
        public int Speed { get => base.speed; }
        public int Attk { get => base.attk; }
        public int AttkRange { get => base.attkRange; }
        public string Faction { get => base.faction; }
        public char Symbol { get => base.symbol; }
        public bool IsAttacking { get => base.isAttacking; set => base.isAttacking = value; }
        public string Name { get => base.name; set => base.name = value; }
    }
}
