using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            double result = 0;
            Console.WriteLine("n:");
            double n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("x:");
            double x = Convert.ToDouble(Console.ReadLine());
            for (int i = 1; i < n; i++)
            {
                result += Math.Pow(Math.Cos(x), n);
            }
            Console.WriteLine(result);
        }
    }
}
