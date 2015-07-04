using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Snow : EnvironmentObject
    {
        public Snow(int x, int y) 
            : base(x, y, 1, 1)
        {
            this.CollisionGroup = CollisionGroup.Snow;
            this.ImageProfile = new char[,] { { '.' } };
        }

        public Snow(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
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
