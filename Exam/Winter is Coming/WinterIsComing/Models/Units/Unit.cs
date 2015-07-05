namespace WinterIsComing.Models.Units
{
    using System;
    using System.Text;
    using CombatHandlers;
    using Contracts;

    public abstract class Unit : IUnit
    {
        protected Unit(
            int attackPoints, 
            int defencePoints,
            int energyPoints, 
            int healthPoints,
            string name, 
            int range, 
            int x,
            int y)
        {
            this.AttackPoints = attackPoints;
            this.DefensePoints = defencePoints;
            this.EnergyPoints = energyPoints;
            this.HealthPoints = healthPoints;
            this.Name = name;
            this.Range = range;
            this.X = x;
            this.Y = y;
        }

        public int AttackPoints { get; set; }

        public ICombatHandler CombatHandler
        {
            get
            {
                return this.GetCombatHandler();
            }
        }

        public int DefensePoints { get; set; }

        public int EnergyPoints { get; set; }

        public int HealthPoints { get; set; }

        public string Name { get; private set; }

        public int Range { get; private set; }

        public int X { get; set; }

        public int Y { get; set; }

        public ICombatHandler GetCombatHandler()
        {
            string name = this.GetType().Name;

            switch (name)
            {
                case "Warrior":
                    return new WarriorCombatHandler(this);
                case "Mage":
                    return new MageCombatHandler(this);
                case "IceGiant":
                    return new IceGiantCombatHandler(this);
                default:
                    throw new NotImplementedException();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine(string.Format(
                ">{0} - {1} at ({2},{3})", 
                this.Name, 
                this.GetType().Name,
                this.X, 
                this.Y));

            if (this.HealthPoints > 0)
            {
                result.AppendLine(string.Format("-Health points = {0}", this.HealthPoints));
                result.AppendLine(string.Format("-Attack points = {0}", this.AttackPoints));
                result.AppendLine(string.Format("-Defense points = {0}", this.DefensePoints));
                result.AppendLine(string.Format("-Energy points = {0}", this.EnergyPoints));
                result.AppendLine(string.Format("-Range = {0}", this.Range));
            }
            else
            {
                result.AppendLine("(Dead)");
            }

            return result.ToString().Trim();
        }
    }
}
