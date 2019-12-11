using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    class Trapezoid : Figure
    {
        Point upSide;
        Point downSide;

        public Trapezoid(params Point[] points) : base(points)
        {
            upSide = points[0];
            downSide = points[1];
        }


    }
}
