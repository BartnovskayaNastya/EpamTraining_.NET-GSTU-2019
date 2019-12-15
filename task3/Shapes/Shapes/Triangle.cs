using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public class Triangle : Figure
    {
        private int a;
        private int b;
        private int c;

        /// <summary>
        /// Constructior for triangle
        /// </summary>
        /// <param name="material">Material of triangle</param>
        /// <param name="points">Array of parametrs</param>
        public Triangle(Material material, params int[] points) : base(material, points) 
        {
            a = points[0];
            b = points[1];
            c = points[2];
        }


        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        public Triangle(Figure figure)
        {
            if (figure.GetS() > GetS())
            {
                throw new Exception("You can't cut this shape");
            }
        }

        /// <summary>
        /// Method for getting perimetr of shape
        /// </summary>
        /// <returns>Perimetr of shape</returns>
        public override double GetP()
        {
            return a + b + c;
        }

        /// <summary>
        /// Method for getting square of shape
        /// </summary>
        /// <returns>Square of shape</returns>
        public override double GetS()
        {
            
            if (a == b) return (c * (Math.Sqrt(Math.Pow(a, 2) - ((Math.Pow(c, 2)) / 4)))) / 2;
            if (a == c) return (b * (Math.Sqrt(Math.Pow(a, 2) - ((Math.Pow(b, 2)) / 4)))) / 2;
            if (b == c) return (a * (Math.Sqrt(Math.Pow(b, 2) - ((Math.Pow(a, 2)) / 4)))) / 2;
            if (a == b && a == c && c == b) return (Math.Sqrt(3) / 4) * Math.Pow(a, 2);
            else
            {
                return Math.Sqrt(GetP() / 2 * ((GetP() / 2) - a) * ((GetP() / 2) - b) * ((GetP() / 2) - c));
            }
        }


        /// <summary>
        /// Overridden method for comparison two objects
        /// </summary>
        /// <param name="obj">Object for compare</param>
        /// <returns>True - if objects equal, false if not </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return obj is Triangle triangle &&
                   base.Equals(obj) &&
                   a == triangle.a &&
                   b == triangle.b &&
                   c == triangle.c;
        }

        /// <summary>
        /// Overridden method for comparison two Triangles
        /// </summary>
        /// <param name="obj">Triangl for compare</param>
        /// <returns>True - if objects equal, false if not</returns>
        public bool Equals(Triangle obj)
        {
            if (obj == null)
                return false;

            return obj.a == this.a && obj.b == this.b && obj.c == this.c;
        }

        /// <summary>
        /// Overridden method for getting hashCode
        /// </summary>
        /// <returns>hashCode for object</returns>
        public override int GetHashCode()
        {
            var hashCode = 1861068769;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + a.GetHashCode();
            hashCode = hashCode * -1521134295 + b.GetHashCode();
            hashCode = hashCode * -1521134295 + c.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Overridden method for getting string with information about object
        /// </summary>
        /// <returns>String with information about object</returns>
        public override string ToString()
        {
            return "Triangle: side A - " + a + " side B - " + b + " side C - " + c + "\n"; 
        }

    }
}
