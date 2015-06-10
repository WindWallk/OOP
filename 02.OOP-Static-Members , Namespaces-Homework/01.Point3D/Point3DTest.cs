using System;

namespace _01.Point3D
{
    class Point3DTest
    {
        static void Main(string[] args)
        {
            Point3D point = new Point3D(0, -3, -7.5);

            Console.WriteLine(point);
            Console.WriteLine(Point3D.StartingPoint);
        }
    }
}
