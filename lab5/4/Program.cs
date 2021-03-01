using System;

namespace _4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            int x0 = 0,
                x1 = 7,
                resultValue = 0;
            for (int i = 2; i <= n; i++)
            {
                resultValue = x1*(1+x0);
                x0 = x1;
                x1 = resultValue;
            }
            Console.WriteLine(resultValue);
        }
    }
}
