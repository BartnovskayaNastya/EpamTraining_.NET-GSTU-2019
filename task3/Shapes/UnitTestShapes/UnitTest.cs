using Microsoft.VisualStudio.TestTools.UnitTesting;
using Box;
using BoxExceptions;
using Shapes;
using System;
using NUnit.Framework;

namespace UnitTestShapes
{

    [TestClass]
    public class UnitTest
    {

        Random random = new Random();
        FigureBox box = new FigureBox();
        Figure figure;

        /// <summary>
        /// Tast for adding figure
        /// </summary>
        [TestMethod]

        public void TestAddFigure()
        {
            Circle circle = new Circle(Material.Paper, 5);
            box.AddFigure(circle);

            NUnit.Framework.Assert.AreEqual(box.GetCount(), 1);
        }


        [TestMethod]

        public void TestChangeByNumber()
        {
            Triangle triangle = new Triangle(Material.Paper, 5);
            box.ChangeByNumber(0, triangle);

            NUnit.Framework.Assert.IsTrue(triangle.Equals(box.FindByNumber(1)));
        }

        [TestMethod]

        public void TestRemoveByIndex()
        {
            box.RemoveByIndex(1);
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(box.GetCount(), 0);
        }


        [TestMethod]

        public void TestFindFigure()
        {
            Square square1 = new Square(Material.Paper, 2);
            box.AddFigure(square1);
            Square square2 = new Square(Material.Film, 3);
            box.AddFigure(square2);
            Square square3 = new Square(Material.Paper, 4);
            box.AddFigure(square3);

            Square figure = new Square(Material.Film, 3);
            box.FindFigure(figure);

            NUnit.Framework.Assert.IsTrue(square2.Equals(box.FindFigure(figure)));
        }


        [TestMethod]

        public void TestGetPandSFigures()
        {
            NUnit.Framework.Assert.AreEqual(box.GetPFigures(), 36);
            NUnit.Framework.Assert.AreEqual(box.GetSFigures(), 29);
        }

        [TestMethod]

        public void TestRemoveAllCircles()
        {
            Circle circle = new Circle(Material.Paper, 5);
            box.AddFigure(circle);
            box.RemoveAllCircles();

            NUnit.Framework.Assert.AreEqual(box.FindFigure(circle), null);

        }

        [TestMethod()]
        [ExpectedException(typeof(ExistsFigureException))]
        public void TestExistsFigureException()
        {
            for(int i = 0; i < 2; i++)
            {
                figure = new Square(Material.Film, 3);
                box.AddFigure(figure);
            }
        }

        [TestMethod]

        public void TestCutFigure()
        {
            Rectangle rectangle = new Rectangle(Material.Paper, 2, 3);
            Square square = new Square(rectangle);

        }

    }
}
