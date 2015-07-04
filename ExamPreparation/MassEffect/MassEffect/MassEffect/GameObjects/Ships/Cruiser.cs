namespace MassEffect.GameObjects.Ships
{
    using Interfaces;
    using Locations;
    using Projectiles;

    public class Cruiser : Starship
    {
        private const int CruiserDefaultHealth = 100;
        private const int CruiserDefaultShields = 100;
        private const int CruiserDefaultDamage = 50;
        private const double CruiserDefaultFuel = 300;

        public Cruiser(string name, StarSystem location)
            : base(
                  CruiserDefaultHealth,
                  CruiserDefaultShields, 
                  CruiserDefaultDamage, 
                  CruiserDefaultFuel, 
                  name, 
                  location)
        {
        }

        public override IProjectile ProduceAttack()
        {
            var projectile = new PenetrationShell(this.Damage);

            return projectile;
        }
    }
}
