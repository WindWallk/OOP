using System.Collections.Generic;

namespace EnvironmentSystem.Models.Objects
{
    public class FallingStar : MovingObject
    {
        private char FallingStarImageCharacter = 'O';
        public FallingStar(int x, int y, Point direction) 
            : base(x, y, 1, 1, direction)
        {
            this.ImageProfile = new char[,] { { FallingStarImageCharacter } };
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObject = collisionInfo.HitObject.CollisionGroup;
            if (hitObject == CollisionGroup.Ground || hitObject == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }



        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            List<EnvironmentObject> produceObjects = new List<EnvironmentObject>();

            produceObjects.Add(new Tail(this.Bounds.TopLeft.X - this.Direction.X, this.Bounds.TopLeft.Y - this.Direction.Y));
            produceObjects.Add(new Tail(this.Bounds.TopLeft.X - 2 * this.Direction.X, this.Bounds.TopLeft.Y - 2 * this.Direction.Y));
            produceObjects.Add(new Tail(this.Bounds.TopLeft.X - 3 * this.Direction.X, this.Bounds.TopLeft.Y - 3 * this.Direction.Y));

            return produceObjects;
        }
    }
}
