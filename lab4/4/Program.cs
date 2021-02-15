using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(-4 > 0);
            Console.WriteLine("x:");
            double x = Convert.ToInt32(Console.ReadLine());
            double tempValue = 2 * Math.Pow(x, 2) - x - 3;
            if (tempValue == 0)
                Console.WriteLine(1);
            else if (tempValue > 0)
                Console.WriteLine(2);
            else
                Console.WriteLine(0);
        }
    }
}
