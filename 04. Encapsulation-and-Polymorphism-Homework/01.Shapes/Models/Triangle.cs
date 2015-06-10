using System;

namespace Shapes.Models
{
    class Triangle : BasicShape
    {
        private double thirdSide;

        public Triangle(double firstSide, double secondSide, double thirdSide) 
            : base(firstSide, secondSide)
        {
            this.ThirdSide = thirdSide;
        }

        public double ThirdSide
        {
            get
            {
                return this.thirdSide;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("thirdSide", "The side cannot be a negative number!");
                }

                this.thirdSide = value;
            }
        }

        public override double CalculateArea()
        {
            double p = (this.Width + this.Height + this.ThirdSide) / 2;
            double area = Math.Sqrt(p * (p - this.Height) * (p - this.Width) * (p - this.ThirdSide));

            if (double.IsNaN(area))
            {
                throw new ArgumentException("Not a Triangle if one side is bigger than the other two combined");
            }

            return area;
        }

        public override double CalculatePerimeter()
        {
            double perimeter = this.Width + this.Height + this.ThirdSide;

            return perimeter;
        }
    }
}
