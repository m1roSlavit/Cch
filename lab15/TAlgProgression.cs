using System;
using System.Collections.Generic;
using System.Text;

namespace lab15
{
    class TAlgProgression : IProgression
    {
        public double A { get; set; }

        public double D { get; set; }

        public TAlgProgression(double a, double d)
        {
            A = a;
            D = d;
        }

        public double getElement(int n)
        {
            return A + D*(n - 1);
        }

        public double getSum(int n)
        {
            return (A + getElement(n))*n/2;
        }
    }
}
