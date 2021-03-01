using System;

namespace _1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("arrLength:");
            int arrLength = Convert.ToInt32(Console.ReadLine());

            double[] nums = new double[arrLength];

            for (int i = 0; i < arrLength; i++)
            {
                nums[i] = Convert.ToDouble(Console.ReadLine());
            }
            int counter = 0;

            for (int i = 0; i < arrLength-2; i++)
            {
                if (nums[i] - nums[i+1] == nums[i+1] - nums[i + 2])
                {
                    counter++;
                }
            }
            Console.WriteLine(counter);
        }
    }
}
