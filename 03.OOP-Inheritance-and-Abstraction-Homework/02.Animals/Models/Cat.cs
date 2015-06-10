using System;

namespace Animals.Models
{
    abstract class Cat : Animal
    {
        public Cat(string name, int age, string gender) 
            : base(name, age, gender)
        {
        }

        public override void ProduceSound()
        {
            Console.WriteLine("meow");
        }
    }
}
