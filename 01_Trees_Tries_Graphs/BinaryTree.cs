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
                if (count > 1)
                    return data.ToString () + ":" + count;
                return data.ToString ();
            }
        }


        public TreeNode<NodeData> headNode = null;


        public void Insert(T newValue)
        {
            Console.WriteLine ("Attempting to add value: " + newValue);
            TreeNode<NodeData> newNode = NewNode (newValue);

            // First value in empty list
            if (headNode == null)
            {
                Console.WriteLine ("List empty, inserting value " + newValue + " as head node");
                headNode = newNode;
                return;
            }

            TreeNode<NodeData> currNode = headNode;
            //int compareCurr = newValue.CompareTo (currNode.value.data);
            
            while (true)
            {
                int compareCurr = newValue.CompareTo (currNode.value.data);

                // Move left
                TreeNode<NodeData> left = Left (currNode);
                if (left != null && compareCurr < 0)
                {
                    Console.WriteLine ("Move left to value: " + left.value.data);
                    currNode = left;
                    continue;
                }
                
                // Move right
                TreeNode<NodeData> right = Right (currNode);
                if (right != null && compareCurr > 0)
                {
                    Console.WriteLine ("Move right to value: " + right.value.data);
                    currNode = right;
                    continue;
                }

                // Found existing duplicate entry, increment count
                if (compareCurr == 0)
                {
                    currNode.value.count++;
                    Console.WriteLine ("Duplicate value, new count is: " + currNode.value.count);
                }
                // Insert to left of curr node
                else if (compareCurr < 0)
                {
                    Console.WriteLine ("Inserting to left of node: " + currNode.value.data);
                    if (left == null)
                        currNode.nodes[0] = newNode;
                }
                // Insert to right of curr node
                else
                {
                    Console.WriteLine ("Inserting to right of node: " + currNode.value.data);
                    if (right == null)
                        currNode.nodes[1] = newNode;
                }

                break;
            }
        }


        /*public bool HasValue(T nodeValue)
        {
            return FindNode (nodeValue) != null;
        }

        public GraphNode<T> FindNode(T nodeValue)
        {

        }*/


        public TreeNode<NodeData> Left(TreeNode<NodeData> theNode)
        {
            return theNode.nodes[0];
        }

        public TreeNode<NodeData> Right(TreeNode<NodeData> theNode)
        {
            return theNode.nodes[1];
        }


        public TreeNode<NodeData> NewNode(T theValue)
        {
            TreeNode<NodeData> newNode = new TreeNode<NodeData> (new NodeData (theValue));
            newNode.nodes.Add (null);
            newNode.nodes.Add (null);
            return newNode;
        }

    }
}
