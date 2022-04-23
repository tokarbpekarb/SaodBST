using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaodBST
{
    class TreeNode<T> where T : IComparable<T>
    {
        public T value;
        public TreeNode<T> left, right;

        public TreeNode(T item)
        {
            value = item;
        }
    }
}
