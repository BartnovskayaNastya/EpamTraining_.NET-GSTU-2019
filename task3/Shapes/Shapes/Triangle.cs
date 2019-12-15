using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public class Triangle : Figure
    {
        private int a;
        private int b;
        private int c;

        public Triangle(Material material, params Point[] points) : base(material, points) 
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

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return obj is Triangle triangle &&
                   base.Equals(obj) &&
                   a == triangle.a &&
                   b == triangle.b &&
                   c == triangle.c;
        }

        public bool Equals(Triangle obj)
        {
            if (obj == null)
                return false;

            return obj.a == this.a && obj.b == this.b && obj.c == this.c;
        }

        public override int GetHashCode()
        {
            var hashCode = 1861068769;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + a.GetHashCode();
            hashCode = hashCode * -1521134295 + b.GetHashCode();
            hashCode = hashCode * -1521134295 + c.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Triangle: side A - " + a + " side B - " + b + " side C - " + c + "\n"; 
        }

    }
}
