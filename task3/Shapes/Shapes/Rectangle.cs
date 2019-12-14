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

        public bool Equals(Rectangle obj)
        {
            if (obj == null)
                return false;

            return obj.width == this.width && obj.height == this.height;
        }

        public override int GetHashCode()
        {
            var hashCode = 1694380351;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + width.GetHashCode();
            hashCode = hashCode * -1521134295 + height.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Rectangle: side A - " + width + " side B - " + height +  "\n";
        }
    }
}
