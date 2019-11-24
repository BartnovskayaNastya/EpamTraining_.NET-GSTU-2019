using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2Vector;

namespace UnitTestsTask2

{
    [TestClass]
    public class UnitTestVector
    {
        private Vector3 CheckVectorOnNumber(Vector3 v1, float a)
        {
            Vector3 result = v1 * a;

            if (result.X / a == v1.X && result.Y / a == v1.Y && result.Z / a == v1.Z)
            {
                return result;
            }
            else
            {
                return v1;
            }

        }


        [TestMethod]
        public void TestVector()
        {

            Vector3 v1;
            Vector3 v2;
            Vector3 result;
            float scalarResult;
            Random random = new Random();

            for(int i = 0; i < 50; i++)
            {
                v1 = new Vector3(random.Next(-1550, 1254), random.Next(-568, 2), random.Next(10, 154879));
                v2 = new Vector3(random.Next(-10, 5000), random.Next(-788, 20), random.Next(100, 152139));
                result = v1 + v2;
                Assert.IsTrue(v1 == result - v2);
                result = v1 - v2;
                Assert.IsTrue(v1 == result + v2);
                result = v1 * 5;
                Assert.IsTrue(result == CheckVectorOnNumber(v1, 5));
                result = ++result;
                Assert.IsTrue(result == result--);
            }

            v1 = new Vector3(12, 125, -45);
            v2 = new Vector3(-8, 78, 90);
            result = new Vector3(14760, -720, 1936);
            Assert.IsTrue((v1 * v2) == result);


            scalarResult = Vector3.ScalarMultiply(v1, v2);
            Assert.AreEqual(5604, scalarResult);

        }

    }
}