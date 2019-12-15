using Microsoft.VisualStudio.TestTools.UnitTesting;
using Box;
using BoxExceptions;
using Shapes;

namespace UnitTestShapes
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestPaintFigureOneTime()
        {
            Figure circle = new Circle(Material.Paper, 5);
            circle.Paint(Color.Green);

            Assert.IsTrue(circle.isPainted);
        }
    }
}
