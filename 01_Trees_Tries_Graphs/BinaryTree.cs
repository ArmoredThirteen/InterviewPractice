using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs.BinaryTree
{
    class BinaryTree<T> where T : IComparable<T>
    {
        //TODO: should be private
        public Node<T> head = null;


        public void Insert(T newValue)
        {
            if (head == null)
            {
                head = new Node<T> (newValue);
                return;
            }
            
            Insert (ref head, newValue);
        }

        private void Insert(ref Node<T> currNode, T newValue)
        {
            // New leaf node
            if (currNode == null)
            {
                currNode = new Node<T> (newValue);
                return;
            }

            // Duplicate
            if (newValue == currNode)
            {
                return;
            }
            else if (newValue < currNode)
            {
                Insert (ref currNode.left, newValue);
            }
            else if (newValue > currNode)
            {
                Insert (ref currNode.right, newValue);
            }
        }


        private void RotateRight()
        {

        }

        private void RotateLeft()
        {

        }


        public override string ToString()
        {
            return head.ToString ();
        }
    }
}
