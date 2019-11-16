using System;

namespace Task2Vector
{
    public class Vector
    {
        private int x;
        private int y;
        private int z;

        /// <summary>
        /// Constructor for vector type
        /// </summary>
        /// <param name="x">Coordinate x of vector</param>
        /// <param name="y">Coordinate y of vector</param>
        /// <param name="z">Coordinate z of vector</param>
        public Vector(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Method for addition vectors
        /// </summary>
        /// <param name="v1">First vector for addition</param>
        /// <param name="v2">Second vector for addition</param>
        /// <returns>New vector - result of addition first and second vectors</returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        /// Method for subtruction vectors
        /// </summary>
        /// <param name="v1">First vector fot subtruction</param>
        /// <param name="v2">Second vector for subtruction</param>
        /// <returns>New vector - result vector of subtruction first and second vectors</returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        /// <summary>
        /// Method for multiply vectors
        /// </summary>
        /// <param name="v1">First vector for multiply</param>
        /// <param name="v2">Second vector for multiply</param>
        /// <returns>New vector - result of multiply first and second vectors</returns>
        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        /// <summary>
        /// Method that change sign of coordinates of vector
        /// </summary>
        /// <param name="v">Vector for changing sign of his coordinates</param>
        /// <returns>New vector - result of changing sign of each coordinates of vector </returns>
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.x, -v.y, -v.z);
        }

        /// <summary>
        /// Method for adding 1 for each coordinates of vector
        /// </summary>
        /// <param name="v">Vector for adding 1 for each coordinates of vector</param>
        /// <returns>New vector - result of adding 1 for each coordinates of vector</returns>
        public static Vector operator ++(Vector v)
        {
            return new Vector(++v.x, ++v.y, ++v.z);
        }

        /// <summary>
        /// Method for subtruction 1 for each coordinates of vector
        /// </summary>
        /// <param name="v">Vector for subtruction 1 for each coordinates of vector</param>
        /// <returns>New vector - result of subtruction 1 for each coordinates of vector</returns>
        public static Vector operator --(Vector v)
        {
            return new Vector(--v.x, --v.y, --v.z);
        }
    }
}
