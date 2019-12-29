using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinaryTree;
using Students;
using System;


namespace UnitTest
{
    class UnitTestBinaryTree
    {
        [TestClass]
        public class UnitTestStudent
        {
            TreeNode<string> stringData;
            TreeNode<int> intData;
            TreeNode<bool> boolData;
            TreeNode<double> doubleData;
            /// <summary>
            /// Method for testing string data
            /// </summary>
            [TestMethod]
            public void TestStringdata()
            {
                stringData = new TreeNode<string>("hello word");

                Assert.AreEqual(stringData.Data, "hello word");

            }

            /// <summary>
            /// Method for testing int data
            /// </summary>
            [TestMethod]
            public void TestIntdata()
            {
                intData = new TreeNode<int>(10);

                Assert.AreEqual(intData.Data, 10);

            }

            /// <summary>
            /// Method for testing float data
            /// </summary>
            [TestMethod]
            public void TestFloatdata()
            {
                doubleData = new TreeNode<double>(10.06);

                Assert.AreEqual(doubleData.Data, 10.06);

            }

            /// <summary>
            /// Method for testing bool data
            /// </summary>
            [TestMethod]
            public void TestBooldata()
            {
                boolData = new TreeNode<bool>(false);

                Assert.AreEqual(boolData.Data, false);

            }

            /// <summary>
            /// Method for testing adding tree node in binay tree
            /// </summary>
            [TestMethod()]
            public void AddThreeNodeInBinaryTree()
            {
                BinaryTree<Student> binaryTree = new BinaryTree<Student>();

                Student foxStudent = new Student("Fox", "NeuralNetworks", Convert.ToDateTime("10 / 02 / 1999 3:04:59 AM"), 5);
                binaryTree.AddNode(foxStudent);

                Student bobStudent = new Student("Bob", "OOP", Convert.ToDateTime("10 / 02 / 1999 3:04:59 AM"), 10);
                binaryTree.AddNode(bobStudent);

                Student alexStudent = new Student("Alex", "Biology", Convert.ToDateTime("10 / 02 / 1999 3:04:59 AM"), 4);
                binaryTree.AddNode(alexStudent);

                TreeNode<Student> parent;
                var info = binaryTree.GetNodeInfo(bobStudent, out parent);

                Assert.AreEqual(parent, foxStudent); 
            }
        }
    }
}
