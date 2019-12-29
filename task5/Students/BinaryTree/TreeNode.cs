using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace BinaryTree
{
    [Serializable]
    public class TreeNode<T> where T : IComparable
    {
        /// <summary>
        /// Data
        /// </summary>
        [DataMember]
        public T Data { get; set; }

        /// <summary>
        /// Left branch for tree node
        /// </summary>
        [DataMember]
        public TreeNode<T> LeftBranch { get; set; }

        /// <summary>
        ///  Right branch for tree node
        /// </summary>
        [DataMember]
        public TreeNode<T> RightBranch { get; set; }

        /// <summary>
        /// Parent for tree node
        /// </summary>
        [DataMember]
        public TreeNode<T> Parent { get; set; }

        /// <summary>
        /// Constructor for Tree node
        /// </summary>
        /// <param name="data">Data of tree node</param>
        public TreeNode(T data)
        {
            Data = data;
        }


        /// <summary>
        /// Method for comparing data
        /// </summary>
        /// <param name="data">Data for comparing</param>
        /// <returns>Result of comparing</returns>
        public int CompareTo(T data)
        {
            return Data.CompareTo(data);
        }

        /// <summary>
        /// Override method for object comparisons
        /// </summary>
        /// <param name="obj">object for comparisons</param>
        /// <returns>true if they are equals, false if they are not</returns>
        public override bool Equals(object obj)
        {
            return obj is TreeNode<T> node &&
                   EqualityComparer<T>.Default.Equals(Data, node.Data) &&
                   EqualityComparer<TreeNode<T>>.Default.Equals(LeftBranch, node.LeftBranch) &&
                   EqualityComparer<TreeNode<T>>.Default.Equals(RightBranch, node.RightBranch) &&
                   EqualityComparer<TreeNode<T>>.Default.Equals(Parent, node.Parent);
        }

        /// <summary>
        /// Override method for getting hashCode
        /// </summary>
        /// <returns>Hash code</returns>
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
