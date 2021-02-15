using System;

namespace _3
{
    class Program
    {
        static double getSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Pow(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2), 0.5);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("x1:");
            double x1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("y1:");
            double y1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x2:");
            double x2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("y2:");
            double y2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("x3:");
            double x3 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("y3:");
            double y3 = Convert.ToDouble(Console.ReadLine());

            double result = getSideLength(x1, y1, x2, y2) + getSideLength(x2, y2, x3, y3) + getSideLength(x3, y3, x1, y1);
            Console.WriteLine("result: {0}", result);
        }
    }
}
