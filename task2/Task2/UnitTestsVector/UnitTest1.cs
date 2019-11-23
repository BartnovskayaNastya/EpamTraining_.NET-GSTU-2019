using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task2Vector;

namespace UnitTestsVector
{
    [TestClass]
    public class UnitTest1
    {
        private bool CheckResult(Vector v1, Vector v2)
        {
            return v1 == v2 ? true : false;
        }

        [TestMethod]
        public void TestMethod()
        {
            Random random = new Random();

           // for()
            Vector v1 = new Vector(1500, 452, -896);
            Vector v2 = new Vector(102, -458, 78);

            Assert.AreEqual((v1 != v2), true);
            Assert.AreEqual((v1 == v2), false);

            //Assert.AreEqual(new Vector(1398, 910, -974), v1 - v2);
            //Assert.AreEqual(new Vector(153000, -207016, -69888), v1 * v2);
            //Assert.AreEqual(new Vector(-1500, -452, 896), -v1);
            //Assert.AreEqual(new Vector(1499, 451, -897), --v1);
            //Assert.AreEqual(new Vector(1501, 453, -895), ++v1);



        }
    }
}