﻿using System;
using System.Diagnostics;

namespace Task1GCD
{
    public class FindGCD
    {

        static Stopwatch watch = new Stopwatch();

        /// <summary>
        /// Method for getting Greatest Common Divisor(GCD) for two numbers
        /// </summary>
        /// <param name="a">First number for GCD</param>
        /// <param name="b">Second number for GCD</param>
        /// <returns>The Greatest Common Divisor for 2 numbers </returns>
        public static int GetGCD(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return a;
        }

        /// <summary>
        /// Method for getting Greatest Common Divisor (GCD) for 3 numbers
        /// </summary>
        /// <param name="a">First number for GCD</param>
        /// <param name="b">Second number for GCD</param>
        /// <param name="c">Third number for GCD</param>
        /// <returns>The Greatest Common Divisor for 3 numbers</returns>
        public static int GetGCD(int a, int b, int c)
        {
            c = Math.Abs(c);

            return GetGCD(GetGCD(a, b), c);
        }


        /// <summary>
        /// Method for getting Greatest Common Divisor (GCD) for 4 numbers
        /// </summary>
        /// <param name="a">First number for GCD</param>
        /// <param name="b">Second number for GCD</param>
        /// <param name="c">Third number for GCD</param>
        /// <param name="d">Fourth number for GCD</param>
        /// <returns>The Greatest Common Divisor for 4 numbers</returns>
        public static int GetGCD(int a, int b, int c, int d)
        {
            return GetGCD(GetGCD(a, b), GetGCD(c, d));
        }

        /// <summary>
        /// Binary method for getting Greatest Common Divisor for 2 numbers
        /// with runtime
        /// </summary>
        /// <param name="a">First number for GCD</param>
        /// <param name="b">Second number for GCD</param>
        /// <param name="time">Runtime for Binary method of getting GCD</param>
        /// <returns>The Greatest Common Divisor for 2 numbers by binary method</returns>
        public static int GetBinaryGCD(int a, int b, out double time)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            watch.Start();
            int k = 1;
            while ((a != 0) && (b != 0))
            {
                while ((a % 2 == 0) && (b % 2 == 0))
                {
                    a /= 2;
                    b /= 2;
                    k *= 2;
                }

                while (a % 2 == 0)
                {
                    a /= 2;
                }

                while (b % 2 == 0)
                {
                    b /= 2;
                }

                if (a >= b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }
            watch.Stop();
            time = watch.Elapsed.TotalMilliseconds;
            return b * k;
        }

        /// <summary>
        /// Method for getting Greatest Common Divisor(GCD) for 2 numbers
        /// with runtime
        /// </summary>
        /// <param name="a">First number for GCD</param>
        /// <param name="b">Second number for GCD</param>
        /// <param name="time">Rintime for method GetGCD</param>
        /// <returns>The Greatest Common Divisor for 2 numbers </returns>
        public static int GetGCD(int a, int b, out double time)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            watch.Start();
            while (a != b)
            {
                if (a > b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            watch.Stop();

            time = watch.Elapsed.TotalMilliseconds;
            return a;
        }


        /// <summary>
        /// Method that prepares data (names and runtime for methods) for using
        /// </summary>
        /// <param name="data">Array of runtimes for each methods</param>
        /// <param name="amount">Amount of methods</param>
        /// <returns>Array of method's names</returns>
        public static string[] GetData(out double[] data, int amount)
        {
            double time;
            string[] methodsName = new string[amount];
            data = new double[amount];

            methodsName[0] = "GetGCD";
            methodsName[1] = "GetBinaryGCD";

            GetGCD(5, 25, out time);
            data[0] = time;

            GetBinaryGCD(5, 25, out time);
            data[1] = time;

            return methodsName;
        }



    }
}
