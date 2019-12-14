using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
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


    }
}
