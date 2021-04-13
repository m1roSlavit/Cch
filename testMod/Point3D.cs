using System;
using System.Collections.Generic;
using System.Text;

namespace testMod
{
    class Point3D:Point
    {
        private int z;
        public int Z
        {
            get
            {
                return z;
            }
            set
            {
                if (value > 100)
                {
                    z = 100;
                }
                else
                {
                    z = value;
                }
            }
        } 
        public Point3D (int x, int y, int z):base(x, y)
        {
            Z = z;
        }

        public override string ToString()
        {
            return $"Coords {X} : {Y} : {Z}";
        }

        public void Move(int x, int y, int z)
        {
            X += x;
            Y += y;
            Z += z;
        }
    }
}
