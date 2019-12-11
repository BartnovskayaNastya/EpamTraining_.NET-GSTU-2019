using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Triangle : Figure
    {
        private int a;
        private int b;
        private int c;

        public Triangle(params Point[] points): base(points) 
        {
            a = points[0].X;
            b = points[0].Y;
            c = points[1].X;
        }
        public override double GetP()
        {
            return a + b + c;
        }

        public override double GetS()
        {
            
            if (a == b) return (c * (Math.Sqrt(Math.Pow(a, 2) - ((Math.Pow(c, 2)) / 4)))) / 2;
            if (a == c) return (b * (Math.Sqrt(Math.Pow(a, 2) - ((Math.Pow(b, 2)) / 4)))) / 2;
            if (b == c) return (a * (Math.Sqrt(Math.Pow(b, 2) - ((Math.Pow(a, 2)) / 4)))) / 2;
            if (a == b && a == c && c == b) return (Math.Sqrt(3) / 4) * Math.Pow(a, 2);
            else
            {
                return Math.Sqrt(GetP() / 2 * ((GetP() / 2) - a) * ((GetP() / 2) - b) * ((GetP() / 2) - c));
            }
        }
        
    }
}
