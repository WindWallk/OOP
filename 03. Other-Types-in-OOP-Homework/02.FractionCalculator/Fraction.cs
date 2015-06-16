using System;
using System.Numerics;

namespace _02.FractionCalculator
{
    public struct Fraction
    {
        private long denominator;

        public Fraction(long numerator, long denominator)
            : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public long Numerator { get; set; }

        public long Denominator
        {
            get
            {
                return this.denominator;
            }

            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("The denumerator cannot be 0!");
                }
                this.denominator = value;
            }
        }

        public static Fraction operator +(Fraction a, Fraction b)
        {
            BigInteger numerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
            BigInteger denominator = a.Denominator * b.Denominator;

            if (numerator > long.MaxValue || numerator < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("numerator", "Numerator value exceeds the valid range [-9223372036854775808 … 9223372036854775807]!");
            }

            if (denominator > long.MaxValue || denominator < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("denominator", "Numerator value exceeds the valid range [-9223372036854775808 … 9223372036854775807]!");
            }

            return new Fraction((long)numerator, (long)denominator);
        }
        public static Fraction operator -(Fraction a, Fraction b)
        {
            BigInteger numerator = a.Numerator * b.Denominator - b.Numerator * a.Denominator;
            BigInteger denominator = a.Denominator * b.Denominator;

            if (numerator > long.MaxValue || numerator < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("numerator", "Numerator value exceeds the valid range [-9223372036854775808 … 9223372036854775807]!");
            }

            if (denominator > long.MaxValue || denominator < long.MinValue)
            {
                throw new ArgumentOutOfRangeException("denominator", "Numerator value exceeds the valid range [-9223372036854775808 … 9223372036854775807]!");
            }

            return new Fraction((long)numerator, (long)denominator);
        }

        public override string ToString()
        {
            return string.Format("{0}", (decimal)this.Numerator / this.Denominator);
        }
    }
}
