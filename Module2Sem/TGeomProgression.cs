using System;
using System.Collections.Generic;
using System.Text;

namespace Module2Sem
{
    class TGeomProgression
    {

        public double B { get; set; }

        public double Q { get; set; }

        public TGeomProgression(double b, double q)
        {
            B = b;
            Q = q;
        }

        public TGeomProgression():this(1, 1) { }

        public TGeomProgression(TGeomProgression prog):this(prog.B, prog.Q) { }

        public void inputData() {
            Console.WriteLine("input b1 value: ");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("input q value: ");
            double q = Convert.ToDouble(Console.ReadLine());
            B = b;
            Q = q;
        }

        public void consoleData() {
            Console.WriteLine($"b1: {B}; q: {Q}");
        }

        public double getElement(int n) {
            return B * Math.Pow(Q, n - 1);
        }

        public double getSum(int n) {
            return (getElement(n) * (Math.Pow(Q, n) - 1)) / (Q - 1);
        }

        public static TGeomProgression operator + (TGeomProgression a, TGeomProgression b) {
            return new TGeomProgression(a.B + b.B, a.Q + b.Q);
        }

        public static TGeomProgression operator - (TGeomProgression a, TGeomProgression b)
        {
            return new TGeomProgression(a.B - b.B, a.Q - b.Q);
        }


    }
}
