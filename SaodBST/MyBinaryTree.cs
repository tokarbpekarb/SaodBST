using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaodBST
{
    class MyBinaryTree<T> where T : IComparable<T>
    {
        private TreeNode<T> _root;

        internal TreeNode<T> Root { get => _root; private set => _root = value; }

        public void Add(T item)
        {
            TreeNode<T> node  = new TreeNode<T>(item);
            if (Root == null)
                Root = node;
            else
                _Add(node, Root);
        }

        private void _Add(TreeNode<T> node, TreeNode<T> subroot)
        {
            if (node.value.CompareTo(subroot.value) < 0)
            {
                if (subroot.left == null)
                    subroot.left = node;
                else
                    _Add(node, subroot.left);
            }
            else
            {
                if (subroot.right == null)
                    subroot.right = node;
                else
                    _Add(node, subroot.right);
            }
        }
        public void Clear()
        {
            Root = null;
        }

        public int Size()
        {
            return _Size(Root);
        }

        public int LeafCount()
        {
            return _LeafCount(Root);
        }

        public int InternalCount()
        {
            return _InternalCount(Root);
        }

        private int _Size(TreeNode<T> subroot)
        {
            if (subroot == null)
                return 0;
            return 1 + _Size(subroot.left) + _Size(subroot.right);
        }

        private int _LeafCount(TreeNode<T> subroot) {
            if(subroot == null)
            {
                return 0;
            }
            if(subroot.left == null && subroot.right == null)
            {
                return 1;
            }
            return _LeafCount(subroot.left) + _LeafCount(subroot.right);
        }

        public int _InternalCount(TreeNode<T> subroot)
        {
            if (subroot == null)
            {
                return 0;
            }
            if (subroot.left != null || subroot.right != null)
            {
                return 1 + _InternalCount(subroot.left)+ _InternalCount(subroot.right);
            }
            return 0;
        }

        public bool Contains(T item)
        {
            TreeNode<T> current = Root;
            while(current != null)
            {
                if (current.value.CompareTo(item) == 0)
                    return true;
                if (current.value.CompareTo(item) > 0)
                    current = current.left;
                else
                    current = current.right;
            }
            return false;
        }

        public int GetDeep()
        {
            return _GetDeep(Root);
        }

        private int _GetDeep(TreeNode<T> subroot)
        {
            if (subroot == null) return 0;
            return 1 + Math.Max(_GetDeep(subroot.left), _GetDeep(subroot.right));
        }

        public T MaxValueItr()
        {
            TreeNode<T> current = Root;
            while(current.right != null)
            {
                current = current.right;
            }
            return current.value;
        }

        public T MinValueItr()
        {
            TreeNode<T> current = Root;
            while (current.left != null)
            {
                current = current.left;
            }
            return current.value;
        }

        public T MaxValueRec()
        {
            return _MaxValueRec(Root).value;
        }

        public T MinValueRec()
        {
            return _MinValueRec(Root).value;
        }
        private TreeNode<T> _MaxValueRec(TreeNode<T> subroot)
        {
            if (subroot.right == null)
                return subroot;
            return _MaxValueRec(subroot.right);
        }

        private TreeNode<T> _MinValueRec(TreeNode<T> subroot)
        {
            if (subroot.left == null)
                return subroot;
            return _MinValueRec(subroot.left);
        }

        //повороты, балансировка

        //малое правое вращение
        private TreeNode<T> _RightRotate(TreeNode<T> subroot)
        {
            TreeNode<T> b = subroot.left;
            subroot.left = b.right;
            b.right = subroot;
            return b;
        }

        //малое левое вращение
        private TreeNode<T> _LeftRotate(TreeNode<T> subroot)
        {
            TreeNode<T> b = subroot.right;
            subroot.right = b.left;
            b.left = subroot;
            return b;
        }

        //балансировка узла

        public TreeNode<T> Balance(TreeNode<T> subroot)
        {
            if(_GetDeep(subroot.right) - _GetDeep(subroot.left) == 2)
            {
                //большое левое вращение
                if(_GetDeep(subroot.right.left) > _GetDeep(subroot.right.right))
                    subroot.right = _RightRotate(subroot.right);
                return _LeftRotate(subroot);
            }
            if (_GetDeep(subroot.right) - _GetDeep(subroot.left) == -2)
            {
                if (_GetDeep(subroot.left.right) > _GetDeep(subroot.left.left))
                    subroot.left = _LeftRotate(subroot.left);
                return _RightRotate(subroot);
            }
            return subroot;
        }
    }
}
