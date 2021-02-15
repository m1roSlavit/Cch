using System;

namespace _2
{
    class Program
    {
        static int countNullInNumber(double number)
        {
            double tempNumber = number;
            int counter = 0;
            while (true)
            {
                if (tempNumber % 10 == 0) counter++;
                tempNumber = Convert.ToInt32(tempNumber / 10);
                if (tempNumber == 0) break;
            }
            return counter;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("a:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("b:");
            double b = Convert.ToDouble(Console.ReadLine());
            
            if (countNullInNumber(a) > countNullInNumber(b))
            {
                Console.WriteLine(a);
            }
            else
            {
                Console.WriteLine(b);
            }
        }
    }
}
