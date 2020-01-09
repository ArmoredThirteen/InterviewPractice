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


        public TreeNode<NodeData> headNode = new TreeNode<NodeData> ();


        public BinaryTree()
        {
            headNode = new TreeNode<NodeData> ();
        }


        public void Insert(T newValue)
        {
            Console.WriteLine ("Attempting to add value: " + newValue);
            TreeNode<NodeData> newNode = NewNode (newValue);

            // First value in empty list
            if (headNode == null)
            {
                headNode = newNode;
                return;
            }

            TreeNode<NodeData> currNode = headNode;
            while (true)
            {
                // If left is greater, move that direction
                TreeNode<NodeData> left = Left (currNode);
                if (left != null && left.value.data.CompareTo (newValue) > 0)
                {
                    Console.WriteLine ("Move left to value: " + left.value.data);
                    currNode = left;
                    continue;
                }
                else if (left != null && left.value.data.CompareTo (newValue) == 0)
                {
                    left.value.count++;
                    Console.WriteLine ("Move left to duplicate, new count is: " + left.value.count);
                    return;
                }
                
                // If right is less than, move that direction
                TreeNode<NodeData> right = Right (currNode);
                if (right != null && right.value.data.CompareTo (newValue) > 0)
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
