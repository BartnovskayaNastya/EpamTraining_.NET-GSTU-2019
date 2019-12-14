using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public class Rectangle : Figure
    {
        private int width;
        private int height;

        public Rectangle(Material material, params Point[] points) : base(material, points)
        {
            height = points[0].X;
            width = points[0].Y;
        }

        public override double GetP()
        {
            return 2 * (width + height);
            
        }

        public override double GetS()
        {
            return width * height;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return obj is Rectangle rectangle &&
                   base.Equals(obj) &&
                   width == rectangle.width &&
                   height == rectangle.height;
        }

        public override int GetHashCode()
        {
            var hashCode = 1694380351;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + width.GetHashCode();
            hashCode = hashCode * -1521134295 + height.GetHashCode();
            return hashCode;
        }
    }
}
