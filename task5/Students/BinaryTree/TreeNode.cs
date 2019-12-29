using System;
using System.Collections.Generic;
using System.Text;

namespace BinaryTree
{
    class TreeNode<T> where T : IComparable
    {
        public T Data { get; private set; }
        public TreeNode<T> LeftBranch { get; set; }
        public TreeNode<T> RightBranch { get; set; }

        public TreeNode(T data)
        {
            Data = data;
        }

        public int CompareTo(T data)
        {
            return Data.CompareTo(data);
        }
    }
}
