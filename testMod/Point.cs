using System;
using System.Collections.Generic;
using System.Text;

namespace testMod
{
    class Point
    {
        private int x;
        private int y;

        public int X
        {
            get{
                return x;
            }
            set
            {
                if (value > 100)
                {
                    x = 100;
                } else
                {
                    x = value;
                }
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                if (value > 100)
                {
                    y = 100;
                }else
                {
                    y = value;
                }
            }
        }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point(Point p)
        {
            X = p.X;
            Y = p.Y;
        }


        public Point(int coord):this(coord, coord)
        {
        }

        public static Point operator + (Point a, Point b) {
            return new Point(a.X + b.X, a.Y + b.Y);
        }
        public static Point operator +(Point a, int b)
        {
            return new Point(a.X + b, a.Y + b);
        }

        public void Move(int x, int y)
        {
            X += x;
            Y += y;
        }

        public override string ToString()
        {
            return $" Coords {X} : {Y}";
        }
    }
}
