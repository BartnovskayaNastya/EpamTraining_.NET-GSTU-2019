using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Circle : Figure
    {
        private int r;

        public Circle(Material material, params Point[] points) : base(material, points)
        {
            r = points[1].X;
        }


        public override double GetP()
        {
            return 2 * Math.PI * r;
        }

        public override double GetS()
        {
            return Math.PI * Math.Pow(r, 2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            return obj is Circle circle &&
                   base.Equals(obj) &&
                   r == circle.r;
        }

        public bool Equals(Circle obj)
        {
            if (obj == null)
                return false;

            return obj.r == this.r;
        }
        public override int GetHashCode()
        {
            var hashCode = 1523293247;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + r.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Circle: radius - " + r + "\n";
        }

    }
}
