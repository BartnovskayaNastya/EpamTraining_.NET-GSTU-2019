using System;
using System.Collections.Generic;

namespace Shapes
{
    [Serializable]
    public abstract class Figure : IMaterial
    {
        /// <summary>
        /// array of parametrs for shape
        /// </summary>
        public int[] points;
        public bool isPainted = false;
        public Material Material { get; set; }
        public Color Color 
        {
            get { return Color;}
            set { Color = value;
                isPainted = true;} 
        }

        /// <summary>
        /// Constructior for figure
        /// </summary>
        /// <param name="material">Material of figure</param>
        /// <param name="points">Array of parametrs</param>
        public Figure(Material material = Material.Film, params int[] points)
        {
            Material = material;
            this.points = points;
        }

        /// <summary>
        /// Method for getting string type of figure 
        /// </summary>
        /// <param name="figure">Figure for getting type</param>
        /// <returns>String type of figure</returns>
        public static string GetFigureType(Figure figure)
        {
            return figure.GetType().ToString();
        }

        /// <summary>
        /// Method for getting string type of material 
        /// </summary>
        /// <param name="figure">Figure for getting material </param>
        /// <returns>String material of figure</returns>
        public static string GetFigureMaterial(Figure figure)
        {
            return figure.Material.ToString();
        }


        /// <summary>
        /// Method for painting paper figure
        /// </summary>
        /// <param name="color">Color for painting</param>
        public void Paint(Color color)
        {
            if(Material == Material.Film)
            {
                throw new Exception("You can't paint this type of figure (Film figure)");
            }
            if (isPainted == false)
            {
                Color = color;
            }
                
        }

        /// <summary>
        /// Abstract method for getting perimetr of shape
        /// </summary>
        /// <returns>Perimetr of shape</returns>
        public abstract double GetP();

        /// <summary>
        /// Abstract method for getting square of shape
        /// </summary>
        /// <returns>Square of shape</returns>
        public abstract double GetS();

        /// <summary>
        /// Overridden method for comparison two objects
        /// </summary>
        /// <param name="obj">Object for compare</param>
        /// <returns>True - if objects equal, false if not </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
                return obj is Figure figure &&
                   EqualityComparer<int[]>.Default.Equals(points, figure.points) &&
                   isPainted == figure.isPainted &&
                   Material == figure.Material;
        }

        /// <summary>
        /// Overridden method for comparison two figure
        /// </summary>
        /// <param name="obj">Figure for compare</param>
        /// <returns>True - if objects equal, false if not</returns>
        public bool Equals(Figure obj)
        {
            if (obj == null)
                return false;
            if (this.Material == obj.Material && obj.GetType() == this.GetType() && this.isPainted == obj.isPainted)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Overridden method for getting hashCode
        /// </summary>
        /// <returns>hashCode for object</returns>
        public override int GetHashCode()
        {
            var hashCode = 1155158392;
            hashCode = hashCode * -1521134295 + EqualityComparer<int[]>.Default.GetHashCode(points);
            hashCode = hashCode * -1521134295 + isPainted.GetHashCode();
            hashCode = hashCode * -1521134295 + Material.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Overridden method for getting string with information about object
        /// </summary>
        /// <returns>String with information about object</returns>
        public override string ToString()
        {
            return "Figure: color - " + Color + "material - " + Material + "\n";
        }
    }
}
