using System;

namespace arrF
{
    class Program
    {
        static int getCountOfOddNumers(int[] nums)
        {
            int counter = 0;
            foreach (int elem in nums)
            {
                if(elem % 2 != 0) counter++;
            }
            return counter;
        }
        static int [] inputArr()
        {
            Console.WriteLine("Введ1ть довжину масиву");
            int length = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[length];
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("Введ1ть елемент номеру: " + i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            return arr;
        }
        static void Main(string[] args)
        {
            int[] arr1 = inputArr();
            int[] arr2 = inputArr();
            int lengthArr1 = getCountOfOddNumers(arr1);
            int lengthArr2 = getCountOfOddNumers(arr2);
            if (lengthArr1 > lengthArr2)
            {
                Console.WriteLine("у першому б1льше непарних");
            } else if(lengthArr1 == lengthArr2)
            {
                Console.WriteLine("одинаково");
            } else
            {
                Console.WriteLine("у другому б1льше непарних");
            }
        }
    }
}
