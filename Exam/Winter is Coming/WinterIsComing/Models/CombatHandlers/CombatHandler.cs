namespace WinterIsComing.Models.CombatHandlers
{
    using System.Collections.Generic;
    using Contracts;
    using Core;
    using Core.Exceptions;

    public abstract class CombatHandler : ICombatHandler
    {
        protected CombatHandler(IUnit unit)
        {
            this.Unit = unit;
        }
        public IUnit Unit { get; set; }
        public abstract IEnumerable<IUnit> PickNextTargets(IEnumerable<IUnit> candidateTargets);

        public abstract ISpell GenerateAttack();

        protected void IsThereEnoughEnergy(ISpell attack)
        {
            if (this.Unit.EnergyPoints < attack.EnergyCost)
            {
                throw new NotEnoughEnergyException(string.Format(
                    GlobalMessages.NotEnoughEnergy,
                    this.Unit.Name,
                    attack.GetType().Name));
            }
        }

        protected void RemoveEnergyOnCast(ISpell attack)
        {
            this.Unit.EnergyPoints -= attack.EnergyCost;
        }
    }
}
