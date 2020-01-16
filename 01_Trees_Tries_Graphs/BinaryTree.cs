using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs.BinaryTree
{
    class BinaryTree<T> where T : IComparable<T>
    {
        private Node<T> head = null;


        public void Insert(T newValue)
        {
            if (head == null)
            {
                head = new Node<T> (newValue);
                return;
            }
            
            Insert (ref head, newValue);
        }


        private void Insert(ref Node<T> node, T newValue)
        {
            // New leaf
            if (node == null)
            {
                node = new Node<T> (newValue);
                return;
            }

            // Attempt go left, go right, return if duplicate
            if (newValue < node)
                Insert (ref node.left, newValue);
            else if (newValue > node)
                Insert (ref node.right, newValue);
            else
                return;

            node.ResetHeight ();
            Balance (ref node, newValue);
        }


        private void Balance(ref Node<T> node, T newValue)
        {
            int factor = node.BalanceFactor ();
            
            // Height difference not imbalanced enough
            if (Math.Abs(factor) <= 1)
                return;

            // Left left
            if (factor < -1 && newValue < node.left)
                RotateRight (ref node);
            // Right right
            else if (factor > 1 && newValue > node.right)
                RotateLeft (ref node);
            // Left right
            else if (factor < -1 && newValue > node.left)
            {
                RotateLeft (ref node.left);
                RotateRight (ref node);
            }
            // Right left
            else if (factor > 1 && newValue < node.right)
            {
                RotateRight (ref node.right);
                RotateLeft (ref node);
            }
        }

        private void RotateLeft(ref Node<T> root)
        {
            Node<T> pivot = root.right;
            root.right = root.right.left;
            pivot.left = root;
            root = pivot;

            root.left.ResetHeight ();
            root.ResetHeight ();
        }

        private void RotateRight(ref Node<T> root)
        {
            Node<T> pivot = root.left;
            root.left = root.left.right;
            pivot.right = root;
            root = pivot;

            root.right.ResetHeight ();
            root.ResetHeight ();
        }
        

        public override string ToString()
        {
            return head.ToString ();
        }

    }
}
