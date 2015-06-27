using System;

namespace _03.StringDisperser
{
    public class Test
    {
        private static void Main(string[] args)
        {
            StringDisperser stringDisperser = new StringDisperser("gosho", "pesho", "tanio");

            foreach (var ch in stringDisperser)
            {
                Console.Write(ch + " ");

            }

            Console.WriteLine();
        }
    }
}
