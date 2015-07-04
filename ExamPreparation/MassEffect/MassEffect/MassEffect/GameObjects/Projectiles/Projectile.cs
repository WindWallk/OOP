namespace MassEffect.GameObjects.Projectiles
{
    using System;
    using Interfaces;

    public abstract class Projectile : IProjectile
    {
        private int damage;

        public Projectile(int damage)
        {
            this.Damage = damage;
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("damage", "The projectile damage cannot me negative!");
                }

                this.damage = value;
            }
        }

        public abstract void Hit(IStarship ship);
    }
}
