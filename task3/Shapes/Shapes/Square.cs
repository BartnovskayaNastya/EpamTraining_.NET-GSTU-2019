using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public class Square : Figure
    {
        private int size;

        public Square(Material material, params Point[] points) : base(material, points)
        {
            size = points[0].X;
        }

        public override double GetP()
        {
            return 4 * size;
        }

        public override double GetS()
        {
            return size * size;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return obj is Square square &&
                   base.Equals(obj) &&
                   size == square.size;
        }

        public bool Equals(Square obj)
        {
            if (obj == null)
                return false;

            return obj.size == this.size;
        }

        public override int GetHashCode()
        {
            var hashCode = 1221766130;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + size.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Square: side  - " + size + "\n";
        }

    }
}
