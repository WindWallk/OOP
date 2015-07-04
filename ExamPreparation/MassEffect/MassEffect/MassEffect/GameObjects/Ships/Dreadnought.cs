namespace MassEffect.GameObjects.Ships
{
    using System.ComponentModel;
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Dreadnought : Starship
    {
        private const int DreadnoughtDefaultHealth = 200;
        private const int DreadnoughtDefaultShields = 300;
        private const int DreadnoughtDefaultDamage = 150;
        private const double DreadnoughtDefaultFuel = 700;

        public Dreadnought(string name, StarSystem location)
            : base(
                  DreadnoughtDefaultHealth,
                  DreadnoughtDefaultShields,
                  DreadnoughtDefaultDamage,
                  DreadnoughtDefaultFuel, 
                  name,
                  location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            int damage = this.Shields/2 + this.Damage;

            var projectile = new Laser(damage);

            return projectile;
        }

        public override void RespondToAttack(IProjectile attack)
        {
            this.Shields += 50;

            base.RespondToAttack(attack);

            this.Shields -= 50;
        }
    }
}
