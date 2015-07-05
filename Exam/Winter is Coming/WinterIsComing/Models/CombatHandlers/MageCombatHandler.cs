namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Spells;
    using Units;

    public class MageCombatHandler : CombatHandler
    {

        public MageCombatHandler(IUnit unit) 
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            var pickTargets = candidateTargets
                .OrderByDescending(c => c.HealthPoints)
                .ThenBy(c => c.Name)
                .Take(3);

            return pickTargets;
        }

        public override ISpell GenerateAttack()
        {
            var mage = this.Unit as Mage;
            ISpell attack;
            int attackPoints = this.Unit.AttackPoints;

            if (mage.SpellPicker == 1)
            {
                attack = new FireBreath(attackPoints);
                this.IsThereEnoughEnergy(attack);

                mage.SpellPicker = 2;
            }
            else
            {
                attack = new Blizzard(attackPoints * 2);
                this.IsThereEnoughEnergy(attack);

                mage.SpellPicker = 1;
            }

            this.RemoveEnergyOnCast(attack);

            return attack;
        }
    }
}
