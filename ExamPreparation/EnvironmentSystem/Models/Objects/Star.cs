using System;
using System.Collections.Generic;
using EnvironmentSystem.Models.DataStructures;

namespace EnvironmentSystem.Models.Objects
{
    public class Star : EnvironmentObject
    {
        private const char DefaultCharImageCharacter = 'O';
        private const int StareImgUpdateFrequency = 10;
        private  readonly static Random randomizer = new Random();
        private static char[] StarImageProfiles = new char[] {'O', '@', '0'};
        private int updateCount = 0;

        public Star(int x, int y) 
            : base(x, y, 1, 1)
        {
            this.ImageProfile = new char[,] {{DefaultCharImageCharacter}};
        }

        public Star(Rectangle bounds) : base(bounds)
        {
        }

        public override void Update()
        {
            if (updateCount == StareImgUpdateFrequency)
            {
                int index = randomizer.Next(0, StarImageProfiles.Length);
                this.ImageProfile = new char[,] { { StarImageProfiles[index] } };
                this.updateCount = 0;
            }

            this.updateCount++;
        }

        public override void RespondToCollision(CollisionInfo collisionInfo)
        {
            var hitObjects = collisionInfo.HitObject.CollisionGroup;

            if (hitObjects == CollisionGroup.Explosion)
            {
                this.Exists = false;
            }
        }

        public override IEnumerable<EnvironmentObject> ProduceObjects()
        {
            return new List<EnvironmentObject>();
        }
    }
}
