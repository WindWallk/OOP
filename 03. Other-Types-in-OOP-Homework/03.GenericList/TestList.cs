using System;

namespace _03.GenericList
{
    class TestList
    {
        static void Main(string[] args)
        {
            var list = new GenericList<int> { 1, 4, 2, 7, 12, 452, 21 };

            Console.WriteLine(list.Count);
            list.Add(43);
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Min());
            Console.WriteLine(list.Max());
            Console.WriteLine(list.Contains(11));
            Console.WriteLine(list.FindIndex(3));
            list.Insert(0, 5);
            Console.WriteLine(list);
            list.Remove(0);
            Console.WriteLine(list);
            list[0] = 23;
            Console.WriteLine(list);
            list.Clear();
            Console.WriteLine();
        }
    }
}
