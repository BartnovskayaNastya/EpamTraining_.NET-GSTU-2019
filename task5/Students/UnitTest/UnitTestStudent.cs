using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;
using Students;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTestStudent
    {
        Student student;
        /// <summary>
        /// Method for testing invalid parametr for name
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "You need to input some name")]

        
        public void TestStudentNameExeptionn()
        {
            student = new Student("", "OOP", Convert.ToDateTime("10 / 02 / 1999 3:04:59 AM"), 10);

        }


        /// <summary>
        /// Method for testing invalid parametr for mark
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception),
            "You need to input mark between 1 and 10")]

        public void TestStudentMarkExeptionn()
        {
           student = new Student("Name", "OOP", Convert.ToDateTime("10 / 02 / 1999 3:04:59 AM"), 1000);

        }


        /// <summary>
        /// Method for testing equal
        /// </summary>
        [TestMethod()]
        public void NotEqualsTest()
        {
           student = new Student("1op", "OOP", Convert.ToDateTime("10 / 02 / 1999 3:04:59 AM"), 10);
            Student student2 = new Student("1op", "OOP", Convert.ToDateTime("10 / 02 / 1999 3:04:59 AM"), 5);

            Assert.IsTrue(!student.Equals(student2));
        }

        /// <summary>
        /// Method for testing equal
        /// </summary>
        [TestMethod()]
        public void EqualsTest()
        {
            student = new Student("1op", "OOP", Convert.ToDateTime("10 / 02 / 1999 3:04:59 AM"), 10);
            Student student2 = new Student("1op", "OOP", Convert.ToDateTime("10 / 02 / 1999 3:04:59 AM"), 10);

            Assert.IsTrue(student.Equals(student2));
        }
    }
}
