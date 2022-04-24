using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaodBST
{
    class Program
    {
        static void Main(string[] args)
        {
            MyBinaryTree<int> tree = new MyBinaryTree<int>();
            tree.Add(5);
            tree.Add(3);
            tree.Add(6);
            tree.Add(2);
            tree.Add(4);
            tree.Add(1);
            //Console.WriteLine(tree.LeafCount().ToString());
            //Console.WriteLine(tree.InternalCount().ToString());
            //Console.WriteLine(tree.Contains(2));
            //Console.WriteLine(tree.MaxValueRec().ToString());
            //Console.WriteLine(tree.MinValueItr().ToString());
            //Console.WriteLine(tree.Size().ToString());
            //Console.WriteLine(tree.GetDeep());
            Console.WriteLine(tree.Print());
            tree.Root = tree.Balance(tree.Root);
            Console.WriteLine();
            Console.WriteLine(tree.Print());
            Console.ReadLine();
        }
    }
}
