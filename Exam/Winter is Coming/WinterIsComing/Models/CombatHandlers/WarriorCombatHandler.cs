namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Spells;

    public class WarriorCombatHandler : CombatHandler
    {
        public WarriorCombatHandler(IUnit unit)
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            IEnumerable<IUnit> pickTarget = candidateTargets
                .OrderBy(c => c.HealthPoints)
                .ThenBy(c => c.Name)
                .Take(1);

            return pickTarget;
        }

        public override ISpell GenerateAttack()
        {
            int attackPoints = this.Unit.AttackPoints;

            if (this.Unit.HealthPoints <= 80)
            {
                attackPoints += this.Unit.HealthPoints * 2;
            }

            var attack = new Cleave(attackPoints);

            if (this.Unit.HealthPoints > 50)
            {
                this.IsThereEnoughEnergy(attack);

                this.RemoveEnergyOnCast(attack);
            }

            return attack;
        }
    }
}
