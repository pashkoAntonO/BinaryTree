using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    class BinaryTreeNode<T> : IComparable<T>
        where T : IComparable
    {

        public BinaryTreeNode<T> Left { get; set; }
        public BinaryTreeNode<T> Right { get; set; }
        public T Value { get; set; }

        public BinaryTreeNode(T value)
        {
            Value = value;
        }

        public int CompareTo(T value)
        {
            return Value.CompareTo(value);
        }

    }
}
