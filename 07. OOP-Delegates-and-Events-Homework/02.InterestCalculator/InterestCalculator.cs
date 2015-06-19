using System;

namespace _02.InterestCalculator
{
    public class InterestCalculator
    {
        private decimal sum;
        private decimal interest;
        private int years;
        
        public InterestCalculator(decimal sum, decimal interest,
                     int years, Func<decimal, decimal, int, decimal> interestCalculator)
        {
            this.Sum = sum;
            this.Interest = interest;
            this.Years = years;
            this.TotalSum = interestCalculator(sum, interest, years);
        }

        public decimal Sum
        {
            get
            {
                return this.sum;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("sum", "Sum cannot be negative!");
                }

                this.sum = value;
            }
        }

        public decimal Interest
        {
            get
            {
                return this.interest;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("interest","Interest cannot be negative!");
                }

                this.interest = value;
            }
        }

        public int Years
        {
            get
            {
                return this.years;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("years", "Years cannot be negative!");
                }

                this.years = value;
            }
        }

        public decimal TotalSum { get; set; }

        public override string ToString()
        {
            return string.Format("Money = {0}\nInterest = {1}\nYears = {2}\nTotalSum = {3:F4}\n",
                this.Sum, this.Interest, this.Years, this.TotalSum);
        }
    }
}
