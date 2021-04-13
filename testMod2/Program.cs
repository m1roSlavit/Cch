using System;

namespace testMod2
{
    class Program
    {
        static void SayHi (IEssential obj)
        {
            var date = DateTime.Now;
            string str = obj.sayHi();
            Console.WriteLine($"|{date}| -===- {str}");
        }

        static void Main(string[] args)
        {
            IEssential[] a = new IEssential[5];

            a[0] = new Person("Ivan");
            a[1] = new Person("Sasha");
            a[2] = new Bot("Bot1");
            a[3] = new Person("Muro");
            a[4] = new Bot("Bot2");

            for (int i = 0; i < a.Length; i++)
            {
                SayHi(a[i]);
            }

        }
    }
}
