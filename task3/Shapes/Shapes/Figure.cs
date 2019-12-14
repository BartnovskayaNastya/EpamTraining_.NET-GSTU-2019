using System;

namespace Shapes
{
    public abstract class Figure : IMaterial
    {
        public Point[] points;
        public bool isPainted = false;
        Material Material { get; set; }
        Color Color { set { isPainted = true; } }

        public Figure(Material material, params Point[] points)
        {
            Material = material;
            this.points = points;
        }

        public void Paint(Color color)
        {
            if(Material == Material.Film)
            {
                throw new Exception("You can't paint this type of figure (Film figure)");
            }

            Color = color;
        }

        public abstract double GetP();
        public abstract double GetS();

    }
}
