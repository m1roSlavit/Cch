using System;

namespace _3
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("n:");
            int n = Convert.ToInt32(Console.ReadLine());

            int[] vect1 = new int[n];
            int[] vect2 = new int[n];

            Console.WriteLine("vect1:");
            for (int i = 0; i < n; i++)
            {
                vect1[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("vect2:");
            for (int i = 0; i < n; i++)
            {
                vect2[i] = Convert.ToInt32(Console.ReadLine());
            }

            int sum = 0;

            for (int i = 0; i < n; i++)
            {
                sum += vect1[i] * vect2[i];
            }

            if (sum == 0)
            {
                Console.WriteLine("Перпендикулярні");
            } else
            {
                Console.WriteLine("Не перпендикулярні");
            }
        }
    }
}
