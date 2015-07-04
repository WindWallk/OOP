namespace MassEffect.GameObjects.Ships
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Enhancements;
    using Interfaces;
    using Locations;

    public abstract class Starship : IStarship
    {
        private readonly IList<Enhancement> enhancements;

        public Starship(
            int health,
            int shields,
            int damage, 
            double fuel,
            string name,
            StarSystem location)
        {
            this.Name = name;
            this.Health = health;
            this.Shields = shields;
            this.Damage = damage;
            this.Fuel = fuel;
            this.Location = location;
            this.enhancements = new List<Enhancement>();
        }

        public IEnumerable<Enhancement> Enhancements
        {
            get
            {
                return this.enhancements;
            }
        }       

        public string Name { get; set; }

        public int Health { get; set; }

        public int Shields { get; set; }

        public int Damage { get; set; }

        public double Fuel { get; set; }

        public StarSystem Location { get; set; }

        public abstract IProjectile ProduceAttack();

        public virtual void RespondToAttack(IProjectile attack)
        {
            attack.Hit(this);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(string.Format("--{0} - {1}", this.Name, this.GetType().Name));

            if (this.Health <= 0)
            {
                sb.AppendLine("(Destroyed)");
            }
            else
            {
                sb.AppendLine(string.Format("-Location: {0}", this.Location.Name));
                sb.AppendLine(string.Format("-Health: {0}", this.Health));
                sb.AppendLine(string.Format("-Shields: {0}", this.Shields));
                sb.AppendLine(string.Format("-Damage: {0}", this.Damage));
                sb.AppendLine(string.Format("-Fuel: {0:F1}", Math.Round(this.Fuel)));

                string enhancementsOutput = "N/A";

                if (this.Enhancements.Any())
                {
                    enhancementsOutput = string.Join(
                        ", ", this.Enhancements.Select(e => e.Name));
                }

                sb.AppendLine(string.Format("-Enhancements: {0}", enhancementsOutput));
            }

            return sb.ToString().Trim();
        }

        public void AddEnhancement(Enhancement enhancement)
        {
            this.enhancements.Add(enhancement);
            this.ApplyEnhancementEffect(enhancement);
        }

        private void ApplyEnhancementEffect(Enhancement enhancement)
        {
            this.Damage += enhancement.DamageBonus;
            this.Shields += enhancement.ShieldBonus;
            this.Fuel += enhancement.FuelBonus;
        }
    }
}
