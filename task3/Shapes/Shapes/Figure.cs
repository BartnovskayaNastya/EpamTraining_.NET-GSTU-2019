using System;
using System.Collections.Generic;

namespace Shapes
{
    [Serializable]
    public abstract class Figure : IMaterial
    {
        private Point[] points;
        public bool isPainted = false;
        public Material Material { get; set; }
        public Color Color 
        {
            get { return Color;}
            set { Color = value;
                isPainted = true;} 
        }

        public Figure(Material material, params Point[] points)
        {
            Material = material;
            this.points = points;
        }

        public static string GetFigureType(Figure figure)
        {
            return figure.GetType().ToString();
        }

        public static string GetFigureMaterial(Figure figure)
        {
            return figure.Material.ToString();
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

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
                return obj is Figure figure &&
                   EqualityComparer<Point[]>.Default.Equals(points, figure.points) &&
                   isPainted == figure.isPainted &&
                   Material == figure.Material;
        }

        public bool Equals(Figure obj)
        {
            if (obj == null)
                return false;

            return obj.isPainted == this.isPainted && obj.Material == this.Material && obj.points == this.points;
        }

        public override int GetHashCode()
        {
            var hashCode = 1155158392;
            hashCode = hashCode * -1521134295 + EqualityComparer<Point[]>.Default.GetHashCode(points);
            hashCode = hashCode * -1521134295 + isPainted.GetHashCode();
            hashCode = hashCode * -1521134295 + Material.GetHashCode();
            return hashCode;
        }

        public override string ToString()
        {
            return "Figure: color - " + Color + "material - " + Material + "\n";
        }
    }
}
