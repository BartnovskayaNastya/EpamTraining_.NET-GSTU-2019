using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public class Circle : Figure
    {
        public int R { get; }

        public Circle(Material material, params int[] points) : base(material, points)
        {
            R = points[0];
        }

        public Circle(Figure figure)
        {
            if (figure.GetS() > GetS())
            {
                throw new Exception("You can't cut this shape");
            }
        }

        public override double GetP()
        {
            return 2 * Math.PI * R;
        }

        public override double GetS()
        {
            return Math.PI * Math.Pow(R, 2);
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;

            return obj is Circle circle &&
                   base.Equals(obj) &&
                   R == circle.R;
        }

        public bool Equals(Circle obj)
        {
            if (obj == null)
                return false;

            return obj.R == this.R;
        }
        public override int GetHashCode()
        {
            var hashCode = 1523293247;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + R.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Circle: radius - " + R + "\n";
        }

    }
}
