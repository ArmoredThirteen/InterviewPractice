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
            public int weight;

            public NodeData(T theValue)
            {
                data = theValue;
                count = 1;
                weight = 0;
            }

            public int CompareTo(NodeData other)
            {
                return this.data.CompareTo (other.data);
            }

            public override string ToString()
            {
                if (count > 1)
                    return "v" + data.ToString () + " w" + weight + " c" + count;
                return "v" + data.ToString () + " w" + weight;
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

            RecursiveBalancedInsert (headNode, newNode);
        }

        private int RecursiveBalancedInsert(TreeNode<NodeData> currNode, TreeNode<NodeData> newNode)
        {
            int compareCurr = newNode.value.data.CompareTo (currNode.value.data);

            // Duplicate entry, increment count only
            if (compareCurr == 0)
            {
                currNode.value.count++;
                Console.WriteLine ("Duplicate value, new count is: " + currNode.value.count);
                return 0;
            }

            TreeNode<NodeData> left = Left (currNode);
            TreeNode<NodeData> right = Right (currNode);

            // Move or insert to left
            if (compareCurr < 0)
            {
                if (left != null)
                {
                    int weightChange = RecursiveBalancedInsert (left, newNode);
                    currNode.value.weight -= weightChange;
                    return weightChange;
                }
                else
                {
                    Console.WriteLine ("Inserting to left of node: " + currNode.value.data);
                    currNode.children[0] = newNode;
                    currNode.value.weight -= 1;
                    if (right == null)
                        return 1;
                }
            }
            // Move or insert right
            else if (compareCurr > 0)
            {
                if (right != null)
                {
                    int weightChange = RecursiveBalancedInsert (right, newNode);
                    currNode.value.weight += weightChange;
                    return weightChange;
                }
                else
                {
                    Console.WriteLine ("Inserting to right of node: " + currNode.value.data);
                    currNode.children[1] = newNode;
                    currNode.value.weight += 1;
                    if (left == null)
                        return 1;
                }
            }

            return 0;
        }


        public void UnbalancedInsert(T newValue)
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
            
            while (true)
            {
                int compareCurr = newValue.CompareTo (currNode.value.data);

                // Move left
                TreeNode<NodeData> left = Left (currNode);
                if (left != null && compareCurr < 0)
                {
                    //Console.WriteLine ("Move left to value: " + left.value.data);
                    currNode = left;
                    continue;
                }
                
                // Move right
                TreeNode<NodeData> right = Right (currNode);
                if (right != null && compareCurr > 0)
                {
                    //Console.WriteLine ("Move right to value: " + right.value.data);
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
                        currNode.children[0] = newNode;
                }
                // Insert to right of curr node
                else
                {
                    Console.WriteLine ("Inserting to right of node: " + currNode.value.data);
                    if (right == null)
                        currNode.children[1] = newNode;
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
            return theNode.children[0];
        }

        public TreeNode<NodeData> Right(TreeNode<NodeData> theNode)
        {
            return theNode.children[1];
        }


        public TreeNode<NodeData> NewNode(T theValue)
        {
            TreeNode<NodeData> newNode = new TreeNode<NodeData> (new NodeData (theValue));
            newNode.children.Add (null);
            newNode.children.Add (null);
            return newNode;
        }

    }
}
