using System;

namespace _2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("n:");
            int n = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("b:");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("c:");
            int c = Convert.ToInt32(Console.ReadLine());

            int[] nums = new int[n];
            nums[0] = -4;
            nums[1] = 3;
            int sum = 0;
            int counter = 0;

            for (int i = 2; i < n; i++)
            {
                nums[i] = Convert.ToInt32(Math.Pow(nums[i - 1], 2) + 2 * nums[i - 2] - i);
            }

            for (int i = 0; i < n; i++)
            {
                if (b < nums[i] && nums[i] < c)
                {
                    sum += nums[i];
                    counter++;
                }
             }

            Console.WriteLine(sum / (double)counter);
        }
    }
}
