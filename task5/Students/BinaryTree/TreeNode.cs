using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BinaryTree
{
    [Serializable]
    class TreeNode<T> where T : IComparable
    {
        [DataMember]
        public T Data { get; set; }

        [DataMember]
        public TreeNode<T> LeftBranch { get; set; }

        [DataMember]
        public TreeNode<T> RightBranch { get; set; }

        [DataMember]
        public TreeNode<T> Parent { get; set; }

        public TreeNode(T data)
        {
            Data = data;
        }

      

        public int CompareTo(T data)
        {
            return Data.CompareTo(data);
        }

        public override bool Equals(object obj)
        {
            return obj is TreeNode<T> node &&
                   EqualityComparer<T>.Default.Equals(Data, node.Data) &&
                   EqualityComparer<TreeNode<T>>.Default.Equals(LeftBranch, node.LeftBranch) &&
                   EqualityComparer<TreeNode<T>>.Default.Equals(RightBranch, node.RightBranch) &&
                   EqualityComparer<TreeNode<T>>.Default.Equals(Parent, node.Parent);
        }

        public override int GetHashCode()
        {
            var hashCode = -1051451865;
            hashCode = hashCode * -1521134295 + EqualityComparer<T>.Default.GetHashCode(Data);
            hashCode = hashCode * -1521134295 + EqualityComparer<TreeNode<T>>.Default.GetHashCode(LeftBranch);
            hashCode = hashCode * -1521134295 + EqualityComparer<TreeNode<T>>.Default.GetHashCode(RightBranch);
            hashCode = hashCode * -1521134295 + EqualityComparer<TreeNode<T>>.Default.GetHashCode(Parent);
            return hashCode;
        }
    }
}
