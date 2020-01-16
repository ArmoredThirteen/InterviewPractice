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


        // Returns true if subtree height increased
        private bool Insert(ref Node<T> currNode, T newValue)
        {
            // Insert left
            if (newValue < currNode)
            {
                if (currNode.left == null)
                {
                    currNode.left = new Node<T> (newValue);
                    currNode.weight -= 1;
                    if (currNode.right == null)
                    {
                        return true;
                    }
                }
                else
                {
                    bool isHigher = Insert (ref currNode.left, newValue);
                    currNode.weight -= isHigher ? 1 : 0;

                    if (currNode.weight == -2)
                    {
                        Balance (ref currNode);
                        //return false;
                    }

                    return isHigher;
                }
            }
            // Insert right
            else if (newValue > currNode)
            {
                if (currNode.right == null)
                {
                    currNode.right = new Node<T> (newValue);
                    currNode.weight += 1;
                    if (currNode.left == null)
                    {
                        return true;
                    }
                }
                else
                {
                    bool isHigher = Insert (ref currNode.right, newValue);
                    currNode.weight += isHigher ? 1 : 0;

                    if (currNode.weight == 2)
                    {
                        Balance (ref currNode);
                        //return false;
                    }

                    return isHigher;
                }
            }

            return false;
        }


        private void Balance(ref Node<T> root)
        {
            if (root.weight == -2 && root.left.weight == -1)
            {
                RotateRight (ref root);
            }
            else if (root.weight == 2 && root.right.weight == 1)
            {
                RotateLeft (ref root);
            }
            else if (root.weight == -2 && root.left != null && root.left.weight == 1)
            {
                root.left.right.weight = -1;
                RotateLeft (ref root.left);
                root.left.weight = -1;
                RotateRight (ref root);
            }
            else if (root.weight == 2 && root.right != null && root.right.weight == -1)
            {
                root.right.left.weight = 1;
                RotateRight (ref root.right);
                root.right.weight = 1;
                RotateLeft (ref root);
            }
        }

        private void RotateLeft(ref Node<T> root)
        {
            Node<T> pivot = root.right;
            root.right = root.right.left;
            pivot.left = root;
            root = pivot;

            root.weight = 0;
            root.left.weight = 0;
        }

        private void RotateRight(ref Node<T> root)
        {
            Node<T> pivot = root.left;
            root.left = root.left.right;
            pivot.right = root;
            root = pivot;

            root.weight = 0;
            root.right.weight = 0;
        }


        public override string ToString()
        {
            return head.ToString ();
        }

    }
}
