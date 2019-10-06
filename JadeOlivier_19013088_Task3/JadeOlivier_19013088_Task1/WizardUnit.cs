using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JadeOlivier_19013088_Task1
{
    class WizardUnit : Unit
    {
        public WizardUnit(int wizardX, int wizardY, string wizardName, string wizardTeam, char wizardSymb, bool wizardAttacking) : base(wizardX, wizardY, wizardName, 6, 6, 3, 1, wizardTeam, wizardSymb, wizardAttacking)
        {

        }

        public WizardUnit(int wizardX, int wizardY, string wizardName, int wizardHp, int wizardMaxHP, string wizardTeam, char wizardSymb, bool wizardAttacking) : base(wizardX, wizardY, wizardName, wizardHp, wizardMaxHP, 6, 3, 1, wizardTeam, wizardSymb, wizardAttacking)
        {

        }

        public override Unit ClosestUnit(Unit[] unitClosetCheck)
        {
            throw new NotImplementedException();
        }

        public override void Combat(Unit attackingUnit)
        {
            throw new NotImplementedException();
        }

        public override bool IsDead()
        {
            throw new NotImplementedException();
        }

        public override bool IsInRange(Unit unitInRange)
        {
            throw new NotImplementedException();
        }

        public override string Move(Unit unitToEngage)
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
