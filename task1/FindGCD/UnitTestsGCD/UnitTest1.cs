using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1GCD;

namespace UnitTestsGCD
{
    [TestClass]
    public class UnitTestGCD
    {
        readonly Random random = new Random();

        bool p = false;
        int a;
        int b;
        int c;
        int d;
        int result;


        private bool Check(int x, params int[] numbers)
        {
            int k = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] % x == 0)
                {
                    k++;
                }
            }

            if (k == numbers.Length)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [TestMethod]
        public void TestGCD()
        {
            for (int i = 0; i < 5; i++)
            {
                a = random.Next(-12, 85);
                b = random.Next(-5, 15);
                c = random.Next(-8, 80);
                d = random.Next(-27, 520);

                result = FindGCD.GetGCD(a, b, c, d);

                if (Check(result, a, b, c, d))
                {
                    p = true;
                }

                Assert.IsTrue(p);

            }
        }


        [TestMethod]
        public void TestBinaryGCD()
        {
            double time;

            for (int i = 0; i < 50; i++)
            {
                a = random.Next(-100, 85);
                b = random.Next(-25, 150);

                result = FindGCD.GetBinaryGCD(a, b, out time);

                if (Check(result, a, b))
                {
                    p = true;
                }

                Assert.IsTrue(p);

            }
        }


    }
}