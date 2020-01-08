using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs
{
    class BinaryTree<T> where T : IComparable<T>
    {
        public GraphNode<T> headNode = new GraphNode<T> ();


        public BinaryTree()
        {
            headNode = new GraphNode<T> ();
        }


        public void AddValue(T newValue)
        {
            Console.WriteLine ("Attempting to add value: " + newValue);
            GraphNode<T> newNode = NewNode (newValue);

            // First value in empty list
            if (headNode == null)
            {
                headNode = newNode;
                return;
            }

            GraphNode<T> currNode = headNode;
            while (true)
            {
                // If left is greater, move that direction
                GraphNode<T> left = Left (currNode);
                if (left != null && left.value.CompareTo(newValue) > 0)
                {
                    Console.WriteLine ("Move left");
                    currNode = left;
                    continue;
                }

                // If right is less than, move that direction
                GraphNode<T> right = Right (currNode);
                if (right != null && right.value.CompareTo (newValue) < 0)
                {
                    Console.WriteLine ("Move right");
                    currNode = right;
                    continue;
                }

                break;
            }

            Console.WriteLine ("CurrVal: " + currNode.value);
        }


        /*public bool HasValue(T nodeValue)
        {
            return FindNode (nodeValue) != null;
        }

        public GraphNode<T> FindNode(T nodeValue)
        {

        }*/


        public GraphNode<T> Left(GraphNode<T> theNode)
        {
            return theNode.nodes[0];
        }

        public GraphNode<T> Right(GraphNode<T> theNode)
        {
            return theNode.nodes[1];
        }


        public GraphNode<T> NewNode(T theValue)
        {
            GraphNode<T> newNode = new GraphNode<T> (theValue);
            newNode.nodes.Add (null);
            newNode.nodes.Add (null);
            return newNode;
        }

    }
}
