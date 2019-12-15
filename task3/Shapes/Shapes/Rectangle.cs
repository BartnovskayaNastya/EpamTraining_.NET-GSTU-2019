using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public class Rectangle : Figure
    {
        public int Width { get; private set; }
        private int height;

        /// <summary>
        /// Constructior for rectangle
        /// </summary>
        /// <param name="material">Material of rectangle</param>
        /// <param name="points">Array of parametrs</param>
        public Rectangle(Material material, params int[] points) : base(material, points)
        {
            height = points[0];
            Width = points[1];
        }

        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        public Rectangle(Figure figure)
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
            return 2 * (Width + height);
            
        }

        /// <summary>
        /// Method for getting square of shape
        /// </summary>
        /// <returns>Square of shape</returns>
        public override double GetS()
        {
            return Width * height;
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
            return obj is Rectangle rectangle &&
                   base.Equals(obj) &&
                   Width == rectangle.Width &&
                   height == rectangle.height;
        }

        /// <summary>
        /// Overridden method for comparison two rectangle
        /// </summary>
        /// <param name="obj">Rectangle for compare</param>
        /// <returns>True - if objects equal, false if not</returns>
        public bool Equals(Rectangle obj)
        {
            if (obj == null)
                return false;

            return obj.Width == this.Width && obj.height == this.height;
        }

        /// <summary>
        /// Overridden method for getting hashCode
        /// </summary>
        /// <returns>hashCode for object</returns>
        public override int GetHashCode()
        {
            var hashCode = 1694380351;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + Width.GetHashCode();
            hashCode = hashCode * -1521134295 + height.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Overridden method for getting string with information about object
        /// </summary>
        /// <returns>String with information about object</returns>
        public override string ToString()
        {
            return "Rectangle: side A - " + Width + " side B - " + height +  "\n";
        }
    }
}
