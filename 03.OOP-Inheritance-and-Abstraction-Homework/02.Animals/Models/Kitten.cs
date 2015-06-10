namespace Animals.Models
{
    class Kitten : Cat
    {
        public Kitten(string name, int age)
            : base(name, age, "female")
        {
        }
    }
}
