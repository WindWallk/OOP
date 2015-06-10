using System;
using System.Collections.Generic;
using Shapes.Models;

namespace _01.Shapes
{
    class Test
    {
        static void Main(string[] args)
        {
            try
            {
                List<BasicShape> shapes = new List<BasicShape>()
                {
                    new Circle(2.6),
                    new Circle(12.3),
                    new Rectangle(4.4, 9.3),
                    new Rectangle(1.4, 2.7),
                    new Triangle(1.5, 2.0, 3.3),
                    new Triangle(6.8, 9.4, 3.5)
                };

                foreach (BasicShape shape in shapes)
                {
                    Console.WriteLine("Shape {0}\nPerimeter = {1}\nArea = {2}\n", shape.GetType().Name, shape.CalculateArea(), shape.CalculatePerimeter());
                }
            }
            catch (OverflowException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
