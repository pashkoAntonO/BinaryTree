using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    class Program
    {
        static void Main(string[] args)
        {

            BinaryTree<int> tree = new BinaryTree<int>();

            tree.AddToTree(5);
            tree.AddToTree(4);
            tree.AddToTree(6);
            tree.AddToTree(3);
            tree.AddToTree(1);
            tree.AddToTree(2);

            Console.WriteLine(tree.Contains(5));


            tree.Remove(3);

            tree.ShowInorder();

           Console.WriteLine("Количество узлов - {0}", tree.Count);

            Console.ReadKey();

        }
    }
}
