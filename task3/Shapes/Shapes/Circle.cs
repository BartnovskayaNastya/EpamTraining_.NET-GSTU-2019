
using System;

namespace Figures
{
    [Serializable]
    public abstract class Circle : IFigure
    {
        /// <summary>
        /// Radius of circle
        /// </summary>
        public int R { get; }

        /// <summary>
        /// Constructior for circle
        /// </summary>
        /// <param name="points">Array of parametrs</param>
        public Circle(params int[] points)
        {
            R = points[0];
        }

        /// <summary>
        /// Constructor for cuting new figure
        /// </summary>
        /// <param name="figure">Result of cutting figure </param>
        /// /// <param name="r">Radius of cutting figure </param>
        /// 
        public Circle(IFigure figure, int r)
        {
            if (figure.GetS() > GetS())
            {
                throw new Exception("You can't cut this shape");
            }
            else
            {
                R = r;
            }
        }
        /// <summary>
        /// Method for getting perimetr of shape
        /// </summary>
        /// <returns>Perimetr of shape</returns>
        public double GetP()
        {
            return 2 * Math.PI * R;
        }

        /// <summary>
        /// Method for getting square of shape
        /// </summary>
        /// <returns>Square of shape</returns>
        public double GetS()
        {
            return Math.PI * Math.Pow(R, 2);
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
        }*/

    }
}
