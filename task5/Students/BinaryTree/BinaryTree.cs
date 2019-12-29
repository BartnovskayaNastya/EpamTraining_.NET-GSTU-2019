using System;
using System.Collections.Generic;

namespace BinaryTree
{
    [Serializable]

    public class BinaryTree<T> where T : IComparable
    {
        private TreeNode<T> treeNode;

        /// <summary>
        /// Constructor for class Binary Tree
        /// </summary>
        public BinaryTree()
        {

        }

        /// <summary>
        /// Method for adding data tree node 
        /// </summary>
        /// <param name="data">Data of tree node </param>
        public void AddNode(T data)
        {
            if (treeNode == null)
            {
                treeNode = new TreeNode<T>(data);
            }
            else
            {
                AddNodeBranch(treeNode, data);
            }
            
        }

        /// <summary>
        /// Method for adding left or right branch of tree node
        /// </summary>
        /// <param name="treeNode">Tree node</param>
        /// <param name="data">Data of tree node</param>
        private void AddNodeBranch(TreeNode<T> treeNode, T data)
        {

            if (data.CompareTo(treeNode.Data) < 0)
            {
                if (treeNode.LeftBranch == null)
                {
                    treeNode.LeftBranch = new TreeNode<T>(data);
                }
                else
                {
                    AddNodeBranch(treeNode.LeftBranch, data);
                }
            }
            else
            {
                if (treeNode.RightBranch == null)
                {
                    treeNode.RightBranch = new TreeNode<T>(data);
                }
                else
                {
                    AddNodeBranch(treeNode.RightBranch, data);
                }
            }
        }

       /// <summary>
       /// Method for getting all information (Parent and type of node)
       /// </summary>
       /// <param name="data">data of node</param>
       /// <param name="parent">out parametr of parent of tree node</param>
       /// <returns>Tree node</returns>
        public TreeNode<T> GetNodeInfo(T data, out TreeNode<T> parent)
        {
            TreeNode<T> node = treeNode;
            parent = null;

            while (node != null)
            {
                int result = node.CompareTo(data);

                if (result > 0)
                {
                    parent = node;
                    node = node.LeftBranch;
                }
                else if (result < 0)
                {
                    parent = node;
                    node = node.RightBranch;
                }
                else
                {
                    break;
                }
            }

            return node;
        }

        /// <summary>
        /// Method for dalete tree node
        /// </summary>
        /// <param name="data">Data of tree node</param>
        /// <returns>true </returns>
        public void RemoveNode(T data)
        {
            TreeNode<T> node;
            TreeNode<T> parent;

            node = GetNodeInfo(data, out parent);

            if (node == null)
            {
                throw new Exception("Data is not correct");
            }


            if (node.RightBranch == null)
            {
                if (parent == null)
                {
                    treeNode = node.LeftBranch;
                }
                else
                {
                    int result = parent.CompareTo(node.Data);
                    if (result > 0)
                    {
                        parent.LeftBranch = node.LeftBranch;
                    }
                    else if (result < 0)
                    {
                        parent.RightBranch = node.LeftBranch; 
                    }
                } 
            } 
            else if (node.RightBranch.LeftBranch == null) 
            { 
                node.RightBranch.LeftBranch = node.LeftBranch;

                if (parent == null) 
                { 
                    treeNode = node.RightBranch;
                } 
                else
                { 
                    int result = parent.CompareTo(node.Data);
                    if (result > 0)
                    {
                            parent.LeftBranch = node.RightBranch;
                    }
                    else if (result < 0)
                    { 
                        parent.RightBranch = node.RightBranch;
                    } 
                } 
            } 
            else 
            {
                TreeNode<T> leftNode = node.RightBranch.LeftBranch;
                TreeNode<T> leftmostParent = node.RightBranch;
                while (leftNode.LeftBranch != null) 
                { 
                    leftmostParent = leftNode; leftNode = leftNode.LeftBranch;
                } 
                
                leftmostParent.LeftBranch = leftNode.RightBranch;
                leftNode.LeftBranch = node.LeftBranch;
                leftNode.RightBranch = node.RightBranch;
                if (parent == null) 
                {
                    treeNode = leftNode;
                } 
                else 
                { 
                    int result = parent.CompareTo(node.Data);
                    if (result > 0)
                    {
                        parent.RightBranch = leftNode;
                    }
                     else if (result < 0)
                     {
                        parent.RightBranch = leftNode;
                     }
                }
            }
        }


    }
}
