using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("a:");
            double a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("b:");
            double b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("P: {0}, S: {1};", 2*a+2*b, a*b);
        }
    }
}
