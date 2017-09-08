using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_tree
{
    class BinaryTree<T> 
        where T : IComparable
    {
        public BinaryTreeNode<T> Head { get; set; } = null;
        public int Count { get; set; } = 0;


        public void AddToTree(T value)
        {

            if (Head == null)
            {
                Head = new BinaryTreeNode<T>(value);
            }
            else
            {
                Add(Head, value);
            }

            Count++;

        }

        private void Add(BinaryTreeNode<T> node, T value)
        {
            if(node.CompareTo(value) > 0)
            {

                if(node.Left == null)
                {
                    
                    node.Left = new BinaryTreeNode<T>(value);
                }
                else
                {
                    Add(node.Left, value);
                }
            }
            else
            {
                if(node.Right == null)
                {
                    
                    node.Right = new BinaryTreeNode<T>(value);
                }
                else
                {
                    Add(node.Right, value);
                }
            }
        }

        public bool Remove(T value)
        {
          BinaryTreeNode<T> parent;
          BinaryTreeNode<T> current =  FindValue(value, out parent);


            if (current == null)
            {
                return false;
            }

            // Если не существет правой ветки
            if(current.Right == null)
            {
                Console.WriteLine("check");
                // значение по левую ветку
                if (parent.Left == current)
                {
                    // Родитель ссылается на левый узел, от найденого узла
                    parent.Left = current.Left;
                }
                // значение по правую ветку
                else if (parent.Right == current)
                {
                    // Родитель ссылается на левый узел, от найденого узла
                    parent.Right = current.Left;
                }
                Count--;
                return true;

            }
            // Если правая и левая ветки существуют но у правого дочернего узла нет ветки слева
            if (current.Right != null && current.Right.Left == null)
            {
               
                if (parent.Left == current)
                {
                    // Родитель ссылается на правй узел, от найденого узла
                    parent.Left = current.Right;
                    current.Right.Left = current.Left;
                }
                else if (parent.Right == current)
                {
                    // Родитель ссылается на правй узел, от найденого узла
                    parent.Right = current.Right;
                    current.Right.Left = current.Left;
                }

                Count--;
                return true;

            }

            // Если правая  ветка существует и имеет дочерний узел
             if (current.Right.Left != null)
            {
                
                // Узнаем последний элемент
                BinaryTreeNode<T> last = LeftLastNode(current.Right);

                if (parent.Left == current)
                {
                    //Родитель ссылается на последний узел
                    parent.Left = last;
                }
                else if (parent.Right == current)
                {
                    //Родитель ссылается на последний узел
                    parent.Right = last;
                }


                last.Left = current.Left;
                last.Right = current.Right;

                Count--;
                return true;
            }

            return false;
        }

        private BinaryTreeNode<T> LeftLastNode(BinaryTreeNode<T> node)
        {

            if(node.Left == null)
            {
                return node;
            }

            return LeftLastNode(node.Left);
        }

        public void Clear()
        {
            Head = null;
            Count = 0;
        }
   
        public bool Contains(T value)
        {
            return FindValue(value, out BinaryTreeNode<T> parent) == null ? false : true;
        }

        private BinaryTreeNode<T> FindValue(T value, out BinaryTreeNode<T> parent)
        {
            parent = null;
            BinaryTreeNode<T> current = Head;

            while (current != null)
            {
               
                if (current.CompareTo(value) > 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else if(current.CompareTo(value) < 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else if(current.CompareTo(value) == 0)
                {

                    break;
                }

            }
            return current;
        }

        public void ShowInorder()
        {
            Inorder(Head);
        }

        public void ShowPostorder()
        {
            Postorder(Head);
        }
        public void ShowPreorder()
        {
            Preorder(Head);
        }

        public void Preorder(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Console.WriteLine(node.Value);
                Inorder(node.Left);
                Inorder(node.Right);
            }
        }

        public void Postorder(BinaryTreeNode<T> node)
        {
            if (node != null)
            {
                Inorder(node.Left);
                Inorder(node.Right);
                Console.WriteLine(node.Value);
            }
        }
        private void Inorder(BinaryTreeNode<T> node)
        {
            
            if (node != null)
            {
                Inorder(node.Left);
                Console.WriteLine(node.Value);
                Inorder(node.Right);
               
            }

        }

    }
}
