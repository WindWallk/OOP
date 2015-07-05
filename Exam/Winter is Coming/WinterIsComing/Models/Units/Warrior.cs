namespace WinterIsComing.Models.Units
{
    using CombatHandlers;
    using Contracts;

    public class Warrior : Unit
    {
        private const int WarriorDefaultAttackPoints = 120;
        private const int WarriorDefaultDefensePoints = 70;
        private const int WarriorDefaultEnergyPoints = 60;
        private const int WarriorDefautHealthPoints = 180;
        private const int WarriorDefaultRange = 1;

        public Warrior(string name, int x, int y)
            : base(
                  WarriorDefaultAttackPoints,
                  WarriorDefaultDefensePoints, 
                  WarriorDefaultEnergyPoints, 
                  WarriorDefautHealthPoints, 
                  name,
                  WarriorDefaultRange,
                  x, 
                  y)
        {
        }
    }
}
