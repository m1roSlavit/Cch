using System;

namespace _2
{
    class Program
    {
        static double max(double num1, double num2)
        {
            if (num1 > num2) return num1;
            return num2;
        }
        static double min(double num1, double num2)
        {
            if (num1 < num2) return num1;
            return num2;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("a:");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("b:");
            double b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("c:");
            double c = Convert.ToInt32(Console.ReadLine());
            double result = min(a, b) + Math.Pow(min(b, c), 2);
            Console.WriteLine("result {0}", result);
        }
    }
}
