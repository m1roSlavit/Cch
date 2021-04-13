using System;

namespace Classclass
{
    class Program
    {
        static void Main(string[] args)
        {
            var wet = new Weather(-10, 10);
            Console.WriteLine(wet.getRandomTemp());
            Console.WriteLine(wet.getWeatherType(wet.getRandomTemp()));
        }
    }
}
