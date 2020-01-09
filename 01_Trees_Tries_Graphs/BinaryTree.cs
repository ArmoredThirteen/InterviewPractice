using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs
{
    class BinaryTree<T> where T : IComparable<T>
    {
        public class NodeData : IComparable<NodeData>
        {
            public T data;
            public int count;

            public NodeData(T theValue)
            {
                data = theValue;
                count = 1;
            }

            public int CompareTo(NodeData other)
            {
                return this.data.CompareTo (other.data);
            }

            public override string ToString()
            {
                return data.ToString ();
            }
        }


        public GraphNode<NodeData> headNode = new GraphNode<NodeData> ();


        public BinaryTree()
        {
            headNode = new GraphNode<NodeData> ();
        }


        public void Insert(T newValue)
        {
            Console.WriteLine ("Attempting to add value: " + newValue);
            GraphNode<NodeData> newNode = NewNode (newValue);

            // First value in empty list
            if (headNode == null)
            {
                headNode = newNode;
                return;
            }

            GraphNode<NodeData> currNode = headNode;
            while (true)
            {
                // If left is greater, move that direction
                GraphNode<NodeData> left = Left (currNode);
                if (left != null && left.value.data.CompareTo (newValue) > 0)
                {
                    Console.WriteLine ("Move left to value: " + left.value.data);
                    currNode = left;
                    continue;
                }
                else if (left != null && left.value.data.CompareTo (newValue) == 0)
                {
                    left.value.count++;
                    Console.WriteLine ("Move left");
                    Console.WriteLine ("Move left to duplicate, new count is: " + left.value.count);
                    return;
                }
                
                // If right is less than, move that direction
                GraphNode<NodeData> right = Right (currNode);
                if (right != null && right.value.data.CompareTo (newValue) < 0)
                {
                    Console.WriteLine ("Move right to value: " + right.value.data);
                    currNode = right;
                    continue;
                }
                else if (right != null && right.value.data.CompareTo (newValue) == 0)
                {
                    right.value.count++;
                    Console.WriteLine ("Move right to duplicate, new count is: " + right.value.count);
                    return;
                }

                //TODO: Actually inserting
                //TODO: Refactor required to make rebalancing a lot easier
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


        public GraphNode<NodeData> Left(GraphNode<NodeData> theNode)
        {
            return theNode.nodes[0];
        }

        public GraphNode<NodeData> Right(GraphNode<NodeData> theNode)
        {
            return theNode.nodes[1];
        }


        public GraphNode<NodeData> NewNode(T theValue)
        {
            GraphNode<NodeData> newNode = new GraphNode<NodeData> (new NodeData (theValue));
            newNode.nodes.Add (null);
            newNode.nodes.Add (null);
            return newNode;
        }

    }
}
