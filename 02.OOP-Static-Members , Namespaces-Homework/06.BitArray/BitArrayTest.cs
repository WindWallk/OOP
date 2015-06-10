using System;

namespace _06.BitArray
{
    class BitArrayTest
    {
        static void Main(string[] args)
        {
            BitArray bitArray = new BitArray(100000);
            bitArray[1] = 1;
            bitArray[99999] = 1;
            Console.WriteLine(bitArray);
        }
    }
}
