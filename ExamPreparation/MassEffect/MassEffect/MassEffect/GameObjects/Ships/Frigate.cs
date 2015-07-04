namespace MassEffect.GameObjects.Ships
{
    using System.Text;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Frigate : Starship
    {
        private const int FrigateDefaultHealth = 60;
        private const int FrigateDefaultShields = 50;
        private const int FrigateDefaultDamage = 30;
        private const double FrigateDefaultFuel = 220;

        private int projectilesFired;

        public Frigate(string name, StarSystem location)
            : base(
                FrigateDefaultHealth,
                FrigateDefaultShields,
                FrigateDefaultDamage,
                FrigateDefaultFuel,
                name,
                location)
        {
            this.projectilesFired = 0;
        }

        public override IProjectile ProduceAttack()
        {
            this.projectilesFired++;

            var projectile = new ShieldReaver(this.Damage);

            return projectile;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(base.ToString());
            if (this.Health >= 0)
            {
                sb.AppendLine(string.Format("\n-Projectiles fired: {0}", this.projectilesFired));
            }

            return sb.ToString().Trim();
        }
    }
}
