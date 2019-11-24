using System;

namespace TaskPolynom
{
    public class Polynom
    {
        public int Degrees
        {
            get { return Degrees; }
            set
            {
                if(Degrees > 0)
                {
                    Degrees = value;
                }
            }
        }

        public int[] Coefficients { get;}
        public int FreeMember { get; }

        public Polynom(int degrees, int freeMember, int []coefficients)
        {
            this.Degrees = degrees;
            this.FreeMember = freeMember;
            this.Coefficients = coefficients;

        }


        public static Polynom operator + (Polynom p1, Polynom p2)
        {
            int degrees;
            int freeMember;
            Polynom p3;
            bool flag;
            int difference = Math.Abs(p1.Degrees - p2.Degrees);

            if (p1.Degrees > p2.Degrees)
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
                if (flag && i < difference)
                {
                    while(i < difference)
                    {

                        coefficients[i] = p1.Coefficients[i];
                        i++;
                    }

                }
                else
                {
                    while (i < difference && i < difference)
                    {

                        coefficients[i] = p2.Coefficients[i];
                        i++;
                    }
                }

                coefficients[i] = p1.Coefficients[i] + p2.Coefficients[i];
            }

            freeMember = p1.FreeMember + p2.FreeMember;

            p3 = new Polynom(degrees, freeMember, coefficients);
            return p3;
        }

        public static Polynom operator -(Polynom p1, Polynom p2)
        {
            int degrees;
            int freeMember;
            Polynom p3;
            bool flag;
            int difference = Math.Abs(p1.Degrees - p2.Degrees);

            if (p1.Degrees > p2.Degrees)
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
                if (flag && i < difference)
                {
                    while (i < difference)
                    {

                        coefficients[i] = p1.Coefficients[i];
                        i++;
                    }

                }
                else
                {
                    while (i < difference && i < difference)
                    {

                        coefficients[i] = p2.Coefficients[i];
                        i++;
                    }
                }

                coefficients[i] = p1.Coefficients[i] - p2.Coefficients[i];
            }

            freeMember = p1.FreeMember - p2.FreeMember;

            p3 = new Polynom(degrees, freeMember, coefficients);
            return p3;
        }



    }
}
