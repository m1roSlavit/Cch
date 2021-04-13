using System;

namespace testMod
{
    class Program
    {
        static void Main(string[] args)
        {
            Point3D p1 = new Point3D(2, 3, 4);
            Console.WriteLine(p1);
            p1.Move(10, 10, 10);
            Console.WriteLine(p1);

        }
    }
}
