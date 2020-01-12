using Figures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shapes
{
    [Serializable]
    public abstract class Square : IFigure
    {
        public int Size { get; private set; }

        /// <summary>
        /// Constructior for square
        /// </summary>
        /// <param name="points">Array of parametrs</param>
        public Square(params int[] points)
        {
            Size = points[0];
        }

        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        public Square(IFigure figure, int size) 
        {

            if (figure.GetS() > GetS())
            {
                throw new Exception("You can't cut this shape");
            }
            else
            {
                Size = size;
            }


        }
        
        /// <summary>
        /// Method for getting perimetr of shape
        /// </summary>
        /// <returns>Perimetr of shape</returns>
        public double GetP()
        {
            return 4 * Size;
        }

        /// <summary>
        /// Method for getting square of shape
        /// </summary>
        /// <returns>Square of shape</returns>
        public double GetS()
        {
            return Size * Size;
        }


       /* /// <summary>
        /// Overridden method for comparison two objects
        /// </summary>
        /// <param name="obj">Object for compare</param>
        /// <returns>True - if objects equal, false if not </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != this.GetType())
                return false;
            return obj is Square square &&
                   base.Equals(obj) &&
                   size == square.size;
        }

        /// <summary>
        /// Overridden method for comparison two squares
        /// </summary>
        /// <param name="obj">Square for compare</param>
        /// <returns>True - if objects equal, false if not</returns>
        public bool Equals(Square obj)
        {
            if (obj == null)
                return false;

            return obj.size == this.size;
        }

        /// <summary>
        /// Overridden method for getting hashCode
        /// </summary>
        /// <returns>hashCode for object</returns>
        public override int GetHashCode()
        {
            var hashCode = 1221766130;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + size.GetHashCode();
            return hashCode;
        }

        /// <summary>
        /// Overridden method for getting string with information about object
        /// </summary>
        /// <returns>String with information about object</returns>
        public override string ToString()
        {
            return "Square: side  - " + size + "\n";
        }*/

    }
}
