using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Rectangle : Figure
    {
        int width;
        int height;

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
    }
}
