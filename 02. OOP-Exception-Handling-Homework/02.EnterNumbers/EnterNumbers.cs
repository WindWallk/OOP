using System;
using System.Linq;

namespace _02.EnterNumbers
{
    class EnterNumbers
    {
        static void Main(string[] args)
        {
            int[] a = new int[10];

            for (int i = 0; i < a.Length; i++)
            {
                int start = Math.Max(1, a.Max());
                int end = 91 - i;
                a[i] = ReadNumbers(start, end);
            }

            Console.WriteLine("Numbers:");

            for (int i = 0; i < a.Length; i++)
            {
                Console.WriteLine("Numer {0}: {1}", i + 1, a[i]);
            }
        }

        static int ReadNumbers(int start, int end)
        {
            try
            {
                Console.WriteLine("Enter a number in the range:[{0}...{1}]", start + 1, end - 1);
                int number = int.Parse(Console.ReadLine());
                if (number <= start || number >= end)
                {
                    throw new ArgumentOutOfRangeException("The number is not in range!");
                }

                return number;
            }
            catch (ArgumentOutOfRangeException)
            {
                Console.WriteLine("The number should be in the range:[{0}...{1}]! Try again!", start + 1, end - 1);
                return ReadNumbers(start, end);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message + "Try again!");
                return ReadNumbers(start, end);
            }
            catch(FormatException)
            {
                Console.WriteLine("You have to enter integer number! Try again!");
                return ReadNumbers(start, end);
            }
        }
    }
}
