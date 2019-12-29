using System;
using System.Collections.Generic;

namespace BinaryTree
{
    [Serializable]
    public class BinaryTree<T> : IComparable where T : IComparable
    {
        private int counter;
        private TreeNode<T> treeNode;
        private TreeNode<T> parent;

        public BinaryTree()
        {

        }

        public void AddNode(T data)
        {
            if (treeNode == null)
            {
                treeNode = new TreeNode<T>(data);
            }
            else
            {
                FindNode(treeNode, data);
            }
            
        }

        private void FindNode(TreeNode<T> treeNode, T data)
        {

            if (data.CompareTo(treeNode.Data) < 0)
            {
                if (treeNode.LeftBranch == null)
                {
                    treeNode.LeftBranch = new TreeNode<T>(data);
                }
                else
                {
                    FindNode(treeNode.LeftBranch, data);
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
                    FindNode(treeNode.RightBranch, data);
                }
            }
        }

       
        private TreeNode<T> GetNodeInfo(T data, out TreeNode<T> parent)
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


        public bool RemoveNode(T data)
        {
            TreeNode<T> node;
            TreeNode<T> parent;

            node = GetNodeInfo(data, out parent);

            if (node == null)
            {
                return false;
            }

            counter--;

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
            return true;
        }

        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

    }
}
