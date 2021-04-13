using System;
using System.Collections.Generic;
using System.Text;

namespace lab15
{
    class TGeomProgression : IProgression
    {
        public double B { get; set; }

        public double Q { get; set; }

        public TGeomProgression(double b, double q)
        {
            B = b;
            Q = q;
        }

        public double getElement(int n)
        {
            return B * Math.Pow(Q, n - 1);
        }

        public double getSum(int n)
        {
            return (getElement(n) * (Math.Pow(Q, n) - 1)) / (Q - 1);
        }
    }
}
