using System;

namespace Task2Vector
{
    public class Vector3
    {

        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        /// <summary>
        /// Constructor for integer vector type
        /// </summary>
        /// <param name="x">Integer coordinate x of vector</param>
        /// <param name="y">Integer coordinate y of vector</param>
        /// <param name="z">Integer coordinate z of vector</param>
        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }


        /// <summary>
        /// Method for addition vectors
        /// </summary>
        /// <param name="v1">First vector for addition</param>
        /// <param name="v2">Second vector for addition</param>
        /// <returns>New vector - result of addition first and second vectors</returns>
        public static Vector3 operator + (Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X + v2.X, v1.Y+ v2.Y, v1.Z + v2.Z);
        }

        /// <summary>
        /// Method for subtruction vectors
        /// </summary>
        /// <param name="v1">First vector fot subtruction</param>
        /// <param name="v2">Second vector for subtruction</param>
        /// <returns>New vector - result vector of subtruction first and second vectors</returns>
        public static Vector3 operator - (Vector3 v1, Vector3 v2)
        {
            return new Vector3(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }


        /// <summary>
        /// Method for vector product of vectors
        /// </summary>
        /// <param name="v1">First vector for product</param>
        /// <param name="v2">Second vector for product</param>
        /// <returns>New vector - result of vector product first and second vectors</returns>
        public static Vector3 operator * (Vector3 v1, Vector3 v2)//!
        {
            float x = v1.Y * v2.Z - v1.Z * v2.Y;
            float y = v1.Z * v2.X - v1.X * v2.Z;
            float z = v1.X * v2.Y - v1.Y * v2.X;
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Method for scalar product vectors
        /// </summary>
        /// <param name="v1">First vector for scalar product</param>
        /// <param name="v2">Second vector for scalar product</param>
        /// <returns>Number - result of scalar product first and second vectors</returns>
        public static float ScalarMultiply(Vector3 v1, Vector3 v2) 
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        /// <summary>
        /// Method for multiply vector on integer number
        /// </summary>
        /// <param name="v">Vector for multiply on number</param>
        /// <param name="a">Number for multiply on vector</param>
        /// <returns>New vector - result of multiply vector on integer number</returns>
        public static Vector3 operator *(Vector3 v, int a)
        {
            return new Vector3(v.X * a, v.Y * a, v.Z * a);
        }

        /// <summary>
        /// Method for multiply vector on float number
        /// </summary>
        /// <param name="v">Vector for multiply on number</param>
        /// <param name="a">Number for multiply on vector</param>
        /// <returns>New vector - result of multiply vector on float number</returns>
        public static Vector3 operator *(Vector3 v, float a)
        {
            return new Vector3(v.X * a, v.Y * a, v.Z * a);
        }

        /// <summary>
        /// Method that change sign of coordinates of vector
        /// </summary>
        /// <param name="v">Vector for changing sign of his coordinates</param>
        /// <returns>New vector - result of changing sign of each coordinates of vector </returns>
        public static Vector3 operator -(Vector3 v)
        {
            return new Vector3(-v.X, -v.Y, -v.Z);
        }

        /// <summary>
        /// Method for adding 1 for each coordinates of vector
        /// </summary>
        /// <param name="v">Vector for adding 1 for each coordinates of vector</param>
        /// <returns>New vector - result of adding 1 for each coordinates of vector</returns>
        public static Vector3 operator ++(Vector3 v)
        {
            return new Vector3(++v.X, ++v.Y, ++v.Z);
        }

        /// <summary>
        /// Method for subtruction 1 for each coordinates of vector
        /// </summary>
        /// <param name="v">Vector for subtruction 1 for each coordinates of vector</param>
        /// <returns>New vector - result of subtruction 1 for each coordinates of vector</returns>
        public static Vector3 operator --(Vector3 v)
        {
            return new Vector3(--v.X, --v.Y, --v.Z);
        }

        /// <summary>
        /// Method for cheaking inequality for two of vector
        /// </summary>
        /// <param name="v1">First vector for cheaking inequality with second vector</param>
        /// <param name="v2">Second vector for cheaking inequality with first vector</param>
        /// <returns>True - if vectors are inequa. False - if vectors are not inequal</returns>
        public static bool operator !=(Vector3 v1, Vector3 v2)
        {
            if (v1.X != v2.X && v1.Y != v2.Y && v1.Z != v2.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method for cheaking equality for two of vector
        /// </summary>
        /// <param name="v1">First vector for cheaking equality with second vector</param>
        /// <param name="v2">Second vector for cheaking equality with first vector</param>
        /// <returns>True - if vectors are equal. False - if vectors are not equal</returns>
        public static bool operator == (Vector3 v1, Vector3 v2)
        {
            if(v1.X == v2.X && v1.Y == v2.Y && v1.Z == v2.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method for compare coordinates for two of vector
        /// </summary>
        /// <param name="v1">First vector for compare</param>
        /// <param name="v2">Second vector for compare</param>
        /// <returns>True if the value of the left operand is greater than the right</returns>
        public static bool operator > (Vector3 v1, Vector3 v2)
        {
            if (v1.X > v2.X && v1.Y > v2.Y && v1.Z > v2.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method for compare coordinates for two of vector
        /// </summary>
        /// <param name="v1">First vector for compare</param>
        /// <param name="v2">Second vector for compare</param>
        /// <returns>True if the value of the left is less than the value of the operand on the right</returns>
        public static bool operator < (Vector3 v1, Vector3 v2)
        {
            if (v1.X < v2.X && v1.Y < v2.Y && v1.Z < v2.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method for compare coordinates for two of vector
        /// </summary>
        /// <param name="v1">First vector for compare</param>
        /// <param name="v2">Second vector for compare</param>
        /// <returns>True if the value of the left is less or equal than the value of the operand on the right</returns>
        public static bool operator <= (Vector3 v1, Vector3 v2)
        {
            if (v1.X <= v2.X && v1.Y <= v2.Y && v1.Z <= v2.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Method for compare coordinates for two of vector
        /// </summary>
        /// <param name="v1">First vector for compare</param>
        /// <param name="v2">Second vector for compare</param>
        /// <returns>True if the value of the left is less or equal than the value of the operand on the right</returns>
        public static bool operator >= (Vector3 v1, Vector3 v2)
        {
            if (v1.X >= v2.X && v1.Y >= v2.Y && v1.Z >= v2.Z)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
