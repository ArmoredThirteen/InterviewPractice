using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs.BinaryTree
{
    class BinaryTree<T> where T : IComparable<T>
    {
        public Node<T> head = null;
        

        #region Insertion

        public void Insert(T theVal)
        {
            if (head == null)
            {
                head = new Node<T> (theVal);
                return;
            }
            
            Insert (ref head, theVal);
        }

        private void Insert(ref Node<T> node, T theVal)
        {
            // New leaf
            if (node == null)
            {
                node = new Node<T> (theVal);
                return;
            }

            // Attempt go left, go right, return if duplicate
            if (theVal < node)
                Insert (ref node.left, theVal);
            else if (theVal > node)
                Insert (ref node.right, theVal);
            else
                return;

            node.ResetHeight ();
            Balance (ref node);
        }

        #endregion

        #region Deletion

        private void Delete(ref Node<T> node, T theVal)
        {
            // Value not found
            if (node == null)
                return;

            // Attempt go left, go right, or is on node to delete
            if (theVal < node)
                Delete (ref node.left, theVal);
            else if (theVal > node)
                Delete (ref node.right, theVal);
            else
            {
                int factor = node.BalanceFactor ();
                if (factor < 0)
                {

                }
                else
                {

                }
            }

            node.ResetHeight ();
            Balance (ref node);
        }

        public Node<T> DeleteMin(ref Node<T> node)
        {
            Node<T> minNode;

            if (node.left == null)
            {
                minNode = node;
                node = node.right;
            }
            else
                minNode = DeleteMin (ref node.left);

            if (node != null)
            {
                Console.WriteLine ("Height and balance: " + node.value);
                node.ResetHeight ();
            }

            return minNode;
        }

        /*private Node<T> DeleteMax(ref Node<T> node)
        {

        }*/

        #endregion

        #region Balancing

        private void Balance(ref Node<T> node)
        {
            int factor = node.BalanceFactor ();
            
            // Height difference not imbalanced enough
            if (Math.Abs(factor) <= 1)
                return;

            // Left left
            //if (factor < -1 && theVal < node.left)
            if (factor < -1 && node.left.BalanceFactor() < 0)
                RotateRight (ref node);
            // Right right
            //else if (factor > 1 && theVal > node.right)
            else if (factor > 1 && node.right.BalanceFactor() > 0)
                RotateLeft (ref node);
            // Left right
            //else if (factor < -1 && theVal > node.left)
            else if (factor < -1 && node.left.BalanceFactor () > 0)
            {
                RotateLeft (ref node.left);
                RotateRight (ref node);
            }
            // Right left
            //else if (factor > 1 && theVal < node.right)
            else if (factor > 1 && node.right.BalanceFactor() < 0)
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

        #endregion

        public override string ToString()
        {
            return head.ToString ();
        }

    }
}
