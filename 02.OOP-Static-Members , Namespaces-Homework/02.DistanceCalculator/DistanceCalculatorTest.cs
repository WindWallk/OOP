using System;
using _01.Point3D;

namespace _02.DistanceCalculator
{
    class DistanceCalculatorTest
    {
        static void Main(string[] args)
        {
            Point3D point1 = new Point3D(0, 5, 1);
            Point3D point2 = new Point3D(-3, 20, 0);

            Console.WriteLine(DistanceCalculator.CalculateDistance(point1, point2));
        }
    }
}
