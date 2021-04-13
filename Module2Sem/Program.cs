using System;

namespace Module2Sem
{
    class Program
    {
        static void Main(string[] args)
        {

            TGeomProgressionM obj3 = new TGeomProgressionM(1, 2);
            obj3.consoleData();

            Console.WriteLine(obj3.isInGeomProgression(4));

            TGeomProgression obj1 = new TGeomProgression(1, 2);

            obj1.consoleData();
            obj1.inputData();
            obj1.consoleData();


            Console.WriteLine(obj1.getElement(10));

            Console.WriteLine(obj1.getSum(5));

            TGeomProgression obj2 = new TGeomProgression(1, 2);

            TGeomProgression obj5 = obj1 + obj2;
            TGeomProgression obj6 = obj1 - obj2;
            obj5.consoleData();
            obj6.consoleData();


            double[] arr = new double[] { 1, 2, 4, 8, 16, 32, 64, 128 };
             Console.WriteLine(TGeomProgressionM.isGeomProgression(arr));
        }
    }
}
