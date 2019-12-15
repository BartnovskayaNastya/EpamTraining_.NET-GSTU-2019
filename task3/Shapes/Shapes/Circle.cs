using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public class Circle : Figure
    {
        /// <summary>
        /// Radius of circle
        /// </summary>
        public int R { get; }

        /// <summary>
        /// Constructior for circle
        /// </summary>
        /// <param name="material">Material of circle</param>
        /// <param name="points">Array of parametrs</param>
        public Circle(Material material, params int[] points) : base(material, points)
        {
            R = points[0];
        }

        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        public Circle(Figure figure)
        {
            if ((figure.GetS() > GetS()) || (figure is Square && figure.points[0] > R) 
                || (figure is Rectangle && ((figure.points[0] > R)|| (figure.points[1] > R))))
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
            return 2 * Math.PI * R;
        }

        /// <summary>
        /// Method for getting square of shape
        /// </summary>
        /// <returns>Square of shape</returns>
        public override double GetS()
        {
            return Math.PI * Math.Pow(R, 2);
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

            return obj is Circle circle &&
                   base.Equals(obj) &&
                   R == circle.R;
        }

        /// <summary>
        /// Overridden method for comparison two circle
        /// </summary>
        /// <param name="obj">Circle for compare</param>
        /// <returns>True - if objects equal, false if not</returns>
        public bool Equals(Circle obj)
        {
            if (obj == null)
                return false;

            return obj.R == this.R;
        }

        /// <summary>
        /// Overridden method for getting hashCode
        /// </summary>
        /// <returns>hashCode for object</returns>
        public override int GetHashCode()
        {
            var hashCode = 1523293247;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + R.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Overridden method for getting string with information about object
        /// </summary>
        /// <returns>String with information about object</returns>
        public override string ToString()
        {
            return "Circle: radius - " + R + "\n";
        }

    }
}
