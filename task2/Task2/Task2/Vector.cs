using System;

namespace Task2Vector
{
    public class Vector
    {
        private int x;
        private int y;
        private int z;

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
        /// <returns></returns>
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        /// <summary>
        /// Method for subtruction vectors
        /// </summary>
        /// <param name="v1">First vector fot subtruction</param>
        /// <param name="v2">Second vector for subtruction</param>
        /// <returns></returns>
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector operator *(Vector v1, Vector v2)
        {
            return new Vector(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }


        public static Vector operator -(Vector v)
        {
            return new Vector(-v.x, -v.y, -v.z);
        }

        public static Vector operator ++(Vector v)
        {
            return new Vector(++v.x, ++v.y, ++v.z);
        }

        public static Vector operator --(Vector v)
        {
            return new Vector(--v.x, --v.y, --v.z);
        }

        //public static Vector operator *(Vector v1, Vector v2)
        //{
        //    return new Vector(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        //}
    }
}
