namespace MassEffect.GameObjects.Projectiles
{
    using Interfaces;

    public class Laser : Projectile
    {
        public Laser(int damage)
            : base(damage)
        {
        }

        public override void Hit(IStarship ship)
        {
            int remaining = this.Damage - ship.Shields;

            ship.Shields -= this.Damage;

            if (remaining > 0)
            {
                ship.Health -= remaining;
            }
        }
    }
}
