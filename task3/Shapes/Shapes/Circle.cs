using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    public abstract class Circle : Figure
    {
        private Point center;
        private int r;

        public Circle(Material material, params Point[] points) : base(material, points)
        {
            center = points[0];
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

    }
}
