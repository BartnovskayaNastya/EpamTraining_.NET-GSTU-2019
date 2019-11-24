using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaskPolynom;

namespace UnitTestPolynom
{
    [TestClass]
    public class UnitTestPolynom
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] nums1 = new int[4] { 1, 2, 3, 5 };
            int[] nums2 = new int[2] { 3, 5 };
            Polynom p1 = new Polynom(4, 10, nums1);
            Polynom p2 = new Polynom(2, 18, nums2);

            Polynom result;

            result = p1 + p2;

            Assert.IsTrue(result.FreeMember == 28);

        }
    }
}
