using System;
using System.IO;

namespace _1
{
    class Program
    {
        static void sortFile(string source)
        {
            StreamReader SR = new StreamReader(source);
            int numbersCount = Convert.ToInt32(SR.ReadLine());
            Console.WriteLine(numbersCount);
            int[] nums = new int[numbersCount];
            string[] stringNums = new string[numbersCount];
            stringNums = SR.ReadLine().Split(' ');
            SR.Close();
            for (int i = 0; i < numbersCount; i++)
            {
                nums[i] = Convert.ToInt32(stringNums[i]);
            }
            Array.Sort(nums);
            string numsRes = string.Join(' ', nums);
            Console.WriteLine(numsRes);
            StreamWriter SW = new StreamWriter(source);
            SW.WriteLine(numbersCount);
            SW.WriteLine(numsRes);
            SW.Close();

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            sortFile("../file.txt");
        }
    }
}
