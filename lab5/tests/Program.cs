using System;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            var rnd = new Random();
            int numberOfProblem = Convert.ToInt32(Console.ReadLine());
            int[,] allResult = new int[numberOfProblem, 4];
            for (int i = 0; i < numberOfProblem; i++)
            {
                int randomNumber1 = rnd.Next(0, 9);
                int randomNumber2 = rnd.Next(0, 9);
                Console.WriteLine($"{randomNumber1} + {randomNumber2} = ?");
                string userNumberString;

                while (true)
                {
                    userNumberString = Console.ReadLine();
                    if (int.TryParse(userNumberString, out _))
                        break;
                    Console.WriteLine("Ви ввели не ціле число");
                }
                int userNumber = Convert.ToInt32(userNumberString);
                int resultSum = randomNumber1 + randomNumber2;
                if (userNumber == resultSum)
                {
                    Console.WriteLine("Правильно");
                    allResult[i, 0] = 1;
                }
                else
                {
                    Console.WriteLine("Не правильно");
                    allResult[i, 0] = 0;
                }
                allResult[i, 1] = randomNumber1;
                allResult[i, 2] = randomNumber2;
                allResult[i, 3] = userNumber;

            }
            for (int i = 0; i < numberOfProblem; i++)
            {
                Console.Write("{0}. {1}; {2} + {3} = {4}. Ви ввели: {5} \n", i + 1, Convert.ToBoolean(allResult[i, 0]) ? "Правильно" : "Не правильно", allResult[i, 1], allResult[i, 2], allResult[i, 1] +
                allResult[i, 2], allResult[i, 3]);
            }

        }
    }
}
