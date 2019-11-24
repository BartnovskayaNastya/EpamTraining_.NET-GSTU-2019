using System;
using System.Collections.Generic;

namespace TaskPolynom
{
    public class Polynom
    {
        int degrees;
        public int Degrees
        {
            get { return degrees; }
            set
            {
                if(degrees > 0)
                {
                    degrees = value;
                }
            }
        }

        public int[] Coefficients { get;}
        public int FreeMember { get; }

        /// <summary>
        /// Constructor for polunom
        /// </summary>
        /// <param name="degrees"> Maximal degrees of polynom</param>
        /// <param name="freeMember">Free member of polynom</param>
        /// <param name="coefficients">Coefficients of polynom</param>
        public Polynom(int degrees, int freeMember, int []coefficients)
        {
            this.degrees = degrees;
            this.FreeMember = freeMember;
            this.Coefficients = coefficients;

        }

        public Polynom(int[] coefficients)
        {
            this.Coefficients = coefficients;

        }
        /// <summary>
        /// Method for addition polynoms
        /// </summary>
        /// <param name="p1">First polynom for addition</param>
        /// <param name="p2">Second polynom for addition</param>
        /// <returns>New polynom - result of addition first and second polunoms</returns>
        public static Polynom operator + (Polynom p1, Polynom p2)
        {
            int degrees;
            int freeMember;
            Polynom p3;
            bool flag;
            int difference = Math.Abs(p1.Degrees - p2.Degrees);
           
            if (p1.Degrees >= p2.Degrees)
            {
                degrees = p1.Degrees;
                flag = true;
            }
            else
            {
                degrees = p2.Degrees;
                flag = false;
            }

            int[] coefficients = new int[degrees];

            for (int i = 0; i < degrees; i++)
            {
                if (flag && i <= difference)
                {
                    while (i < difference)
                    {

                        coefficients[i] = p1.Coefficients[i];
                        i++;
                    }

                }
                else
                {
                    while (i < difference)
                    {

                        coefficients[i] = p2.Coefficients[i];
                        i++;
                    }
                }

                if (flag)
                {
                    coefficients[i] = p1.Coefficients[i] + p2.Coefficients[i - difference];
                }
                else
                {
                    coefficients[i] = p1.Coefficients[i - difference] + p2.Coefficients[i];
                }
            }
            
                freeMember = p1.FreeMember + p2.FreeMember;
            
            p3 = new Polynom(degrees, freeMember, coefficients);
            return p3;
        }


        /// <summary>
        /// Method for subtruction polynoms
        /// </summary>
        /// <param name="p1">First polynom fot subtruction</param>
        /// <param name="p2">Second polynom for subtruction</param>
        /// <returns>New polynom - result of subtruction first and second polynoms</returns>
        public static Polynom operator -(Polynom p1, Polynom p2)
        {
            int degrees;
            int freeMember;
            Polynom p3;
            bool flag;
            int difference = Math.Abs(p1.Degrees - p2.Degrees);


            if (p1.Degrees >= p2.Degrees)
            {
                degrees = p1.Degrees;

                for (int i = 0; i < p2.Degrees; i++)
                {
                    if (p1.Coefficients[i] == p2.Coefficients[i])
                    {
                        degrees--;
                    }
                }

                flag = true;
            }
            else
            {
                degrees = p2.Degrees;

                for (int i = 0; i < p1.Degrees; i++)
                {
                    if (p1.Coefficients[i] == p2.Coefficients[i])
                    {
                        degrees--;
                    }
                }
                flag = false;
            }

            int[] coefficients = new int[degrees];

            for (int i = 0; i < degrees; i++)
            {
                if (flag && i <= difference)
                {
                    while (i < difference)
                    {

                        coefficients[i] = p1.Coefficients[i];
                        i++;
                    }

                }
                else
                {
                    while (i < difference)
                    {

                        coefficients[i] = -p2.Coefficients[i];
                        i++;
                    }
                }
                if (flag)
                {
                    coefficients[i] = p1.Coefficients[i] - p2.Coefficients[i - difference];
                }
                else
                {
                    coefficients[i] = p1.Coefficients[i - difference] - p2.Coefficients[i];
                }

            }

            freeMember = p1.FreeMember - p2.FreeMember;

            p3 = new Polynom(degrees, freeMember, coefficients);
            return p3;
        }


    }
}
