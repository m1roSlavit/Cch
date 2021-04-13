using System;
using System.Collections.Generic;
using System.Text;

namespace Module2Sem
{
    class TGeomProgressionM:TGeomProgression
    {

        public TGeomProgressionM(double b, double q):base(b, q) { }
        public TGeomProgressionM() : base(1, 1) { }
        public TGeomProgressionM(TGeomProgressionM obj) : base(obj.B, obj.Q) { }




        static public bool isGeomProgression(double[] arr)
        {
            int arrLen = arr.Length;
            double diff = arr[arrLen-1]/arr[arrLen - 2];

            for (int i = arrLen - 2; i > 0; i--) {
                double diff1 = arr[i] / arr[i - 1];
                if (diff1 != diff)
                {
                    return false;
                }
            }
            return true;
        }

        public bool isInGeomProgression(double num)
        {
            double res = (Math.Log(num/B) / Math.Log(Q)) + 1;
            if (Convert.ToInt32(res) == res)
            {
                return true;
            }
            return false;
        }
    }
}
