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
                    return data.ToString () + "/" + weight + "/" + count;
                return data.ToString () + "/" + weight;
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

            RecursiveBalancedInsert (null, headNode, newNode);
        }

        private int RecursiveBalancedInsert(TreeNode<NodeData> parentNode, TreeNode<NodeData> currNode, TreeNode<NodeData> newNode)
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

            // New value is smaller than current node
            if (compareCurr < 0)
            {
                // Move to smaller node
                if (left != null)
                {
                    int weightChange = RecursiveBalancedInsert (currNode, left, newNode);
                    currNode.value.weight -= weightChange;
                    if (currNode.value.weight <= -2)
                    {
                        Rebalance (parentNode, currNode);
                        return 0;
                    }
                    return weightChange;
                }
                // Insert leaf node
                else
                {
                    Console.WriteLine ("Inserting to left of node: " + currNode.value.data);
                    currNode.children[0] = newNode;
                    currNode.value.weight -= 1;
                    if (right == null)
                        return 1;
                }
            }
            // New value is bigger than current node
            else if (compareCurr > 0)
            {
                // Move to bigger node
                if (right != null)
                {
                    int weightChange = RecursiveBalancedInsert (currNode, right, newNode);
                    currNode.value.weight += weightChange;
                    if (currNode.value.weight >= 2)
                    {
                        Rebalance (parentNode, currNode);
                        return 0;
                    }
                    return weightChange;
                }
                // Insert leaf node
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

        private void Rebalance(TreeNode<NodeData> parentNode, TreeNode<NodeData> currNode)
        {
            Console.WriteLine ("Rebalancing: " + currNode.value.data + ", weight is: " + currNode.value.weight);

            if (currNode.value.weight == -2 && currNode.children[0].value.weight == -1)
            {
                RotateRight (parentNode, currNode);
            }
            else if (currNode.value.weight == 2 && currNode.children[1].value.weight == 1)
            {
                RotateLeft (parentNode, currNode);
            }
            else if (currNode.value.weight == -2 && Left(currNode).value.weight == 1)
            {
                TreeNode<NodeData> currLeft = Left (currNode);

                //Right (currLeft).value.weight = -1;
                RotateLeft (currNode, currLeft);
                Left (currNode).value.weight -= 1;

                // Grab new Left since RotateLeft() breaks currLeft...
                TreeNode<NodeData> currLeftLeft = Left (Left (currNode));
                RotateRight (parentNode, currNode);
                currLeftLeft.value.weight -= 1;
            }
            else if (currNode.value.weight == 2 && currNode.children[1].value.weight == -1)
            {
                TreeNode<NodeData> currRight = Right (currNode);
                //Left (currRight).value.weight = 1;
                RotateRight (currNode, currRight);
                Right (currNode).value.weight += 1;

                // Grab new Right since RotateRight() breaks currRight...
                //Right (currNode).value.weight = 1;
                RotateLeft (parentNode, currNode);
            }
        }

        private void RotateLeft(TreeNode<NodeData> parentNode, TreeNode<NodeData> currNode)
        {
            TreeNode<NodeData> currRight = Right (currNode);

            // Set right node to be new root/sub-root
            if (parentNode == null)
                headNode = currRight;
            else
            {
                TreeNode<NodeData> parenRight = Right (parentNode);

                if (parenRight != null && parenRight.value.weight >= 2)
                    parentNode.children[1] = currRight;
                else
                    parentNode.children[0] = currRight;
            }

            currNode.children[1] = Left (currRight);
            currRight.children[0] = currNode;

            currNode.value.weight = 0;
            currRight.value.weight = 0;
        }

        private void RotateRight(TreeNode<NodeData> parentNode, TreeNode<NodeData> currNode)
        {
            TreeNode<NodeData> currLeft = Left (currNode);

            // Set left node to be new root/sub-root
            if (parentNode == null)
                headNode = currLeft;
            else
            {
                TreeNode<NodeData> parenLeft = Left (parentNode);

                if (parenLeft != null && parenLeft.value.weight <= -2)
                    parentNode.children[0] = currLeft;
                else
                    parentNode.children[1] = currLeft;
            }
            
            currNode.children[0] = Right(currLeft);
            currLeft.children[1] = currNode;

            currNode.value.weight = 0;
            currLeft.value.weight = 0;
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
