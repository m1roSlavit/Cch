using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n: ");
            double x = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("E: ");
            double e = Convert.ToDouble(Console.ReadLine());
            double sum = 0;
            int sign = 1;

            int i = 1;
            double tempVal = Math.Sin(x);

            while (Math.Abs(tempVal) > e)
            {
                Console.WriteLine(sum + " " + tempVal);
                sum += tempVal;
                tempVal = sign * Math.Sin(i * x) / i;
                i++;
                sign *= -1;
            }

            Console.WriteLine(2 * sum);
        }
    }
}
