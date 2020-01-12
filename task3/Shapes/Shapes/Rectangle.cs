using Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public abstract class Rectangle : IFigure
    {
        public int Width { get; private set; }
        public int Height { get; private set; }

    /// <summary>
    /// Constructior for rectangle
    /// </summary>
    /// <param name="points">Array of parametrs</param>
    public Rectangle(params int[] points)
        {
            Height = points[0];
            Width = points[1];
        }

       /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        public Rectangle(IFigure figure, int a, int b)
        {
            if (figure.GetS() > GetS())
            {
                throw new Exception("You can't cut this shape");
            }
            else
            {
                Width = b;
                Height = a;
            }
        }
        
        /// <summary>
        /// Method for getting perimetr of shape
        /// </summary>
        /// <returns>Perimetr of shape</returns>
        public double GetP()
        {
            return 2 * (Width + Height);
            
        }

        /// <summary>
        /// Method for getting square of shape
        /// </summary>
        /// <returns>Square of shape</returns>
        public double GetS()
        {
            return Width * Height;
        }

        /*/// <summary>
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
        }*/
    }
}
