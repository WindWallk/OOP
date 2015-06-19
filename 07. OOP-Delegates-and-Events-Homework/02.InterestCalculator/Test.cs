using System;

namespace _02.InterestCalculator
{
    class Test
    {
        private const int InterestCompounded = 12;

        static void Main(string[] args)
        {
            Func<decimal, decimal, int, decimal> simple = GetSimpleInterest;
            Func<decimal, decimal, int, decimal> compound = GetCompoundInterest;

            var icalc1 = new InterestCalculator(500m, 5.6m, 10, compound);
            var icalc2 = new InterestCalculator(2500m, 7.2m, 15, simple);

            Console.WriteLine(icalc1);
            Console.WriteLine(icalc2);
        }

        private static decimal GetCompoundInterest(decimal sum, decimal interest, int years)
        {
            return sum * (decimal)Math.Pow((double)(1 + (interest / 100 / InterestCompounded)), years * InterestCompounded);
        }

        private static decimal GetSimpleInterest(decimal sum, decimal interest, int years)
        {
            return sum *(1 + (interest / 100 * years));
        }
    }
}
