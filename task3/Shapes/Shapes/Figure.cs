using System;

namespace Shapes
{
    public abstract class Figure
    {
        public Point[] points;

        public Figure(params Point[] points)
        {
            this.points = points;
        }

        public abstract double GetP();
        public abstract double GetS();

    }
}
