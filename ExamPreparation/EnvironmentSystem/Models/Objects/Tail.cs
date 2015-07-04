using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Tail : EnvironmentObject
    {
        private int lifetime;

        public Tail(int x, int y, int lifetime = 1)
            : base(x, y, 1, 1)
        {
            this.lifetime = lifetime;
            this.ImageProfile = new char[,] { { '*' } };
        }

        public Tail(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
            this.lifetime --;
            if (lifetime <= 0)
            {
                this.Exists = false;
            }
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {

        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
