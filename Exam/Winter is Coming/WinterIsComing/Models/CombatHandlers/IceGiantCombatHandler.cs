namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Spells;

    public class IceGiantCombatHandler : CombatHandler
    {
        public IceGiantCombatHandler(IUnit unit) 
            : base(unit)
        {
        }

        public override IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets)
        {
            if (this.Unit.HealthPoints <= 150)
            {
                return candidateTargets.Take(1);
            }

            return candidateTargets;
        }

        public override ISpell GenerateAttack()
        {
            var attack = new Stomp(this.Unit.AttackPoints);

            this.IsThereEnoughEnergy(attack);

            this.RemoveEnergyOnCast(attack);
            this.Unit.AttackPoints += 5;

            return attack;
        }
    }
}
