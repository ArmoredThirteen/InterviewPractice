using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs
{
    class TreeNode<T> where T : IComparable<T>
    {
        public T value;
        public List<TreeNode<T>> nodes = new List<TreeNode<T>> ();


        public TreeNode()
        {
            nodes = new List<TreeNode<T>> ();
        }

        public TreeNode(T theValue)
        {
            value = theValue;
            nodes = new List<TreeNode<T>> ();
        }


        public String DepthFirstToString()
        {
            return DepthFirstToString (this);
        }

        private static String DepthFirstToString(TreeNode<T> theNode)
        {
            // Leaf
            if (theNode.nodes.Count <= 0)
                return theNode.value.ToString () + " ";

            String returnString = "";

            for (int i = 0; i < theNode.nodes.Count; i++)
            {
                if (theNode.nodes[i] == null)
                    continue;
                returnString += DepthFirstToString (theNode.nodes[i]);
            }

            return theNode.value.ToString () + " " + returnString;
        }


        public String BreadthFirstToString()
        {
            return BreadthFirstToString (this);
        }

        private static String BreadthFirstToString(TreeNode<T> theNode)
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>> ();
            String returnString = "";

            queue.Enqueue (theNode);

            while (queue.Count > 0)
            {
                TreeNode<T> currNode = queue.Dequeue ();
                if (currNode == null)
                    continue;
                returnString += currNode.value.ToString () + " ";
                currNode.nodes.ForEach (n => queue.Enqueue (n));
            }

            return returnString;
        }

        public String TreeGraphToString()
        {
            StringBuilder buffer = new StringBuilder (50);
            TreeGraphToString (this, buffer, "", "");
            return buffer.ToString ();
        }

        // Modified version of answer by VasiliNovikov:
        // https://stackoverflow.com/questions/4965335/how-to-print-binary-tree-diagram
        private static void TreeGraphToString(TreeNode<T> theNode, StringBuilder buffer, String prefix, String childrenPrefix)
        {
            buffer.Append (prefix);
            if (theNode == null)
            {
                buffer.Append ("*\r\n");
                return;
            }

            buffer.Append (theNode.value.ToString ());
            buffer.Append ("\r\n");

            for (int i = 0; i < theNode.nodes.Count; i++)
            {
                TreeNode<T> nextNode = theNode.nodes[i];

                if (i != theNode.nodes.Count - 1)
                    TreeGraphToString (nextNode, buffer, childrenPrefix + "├── ", childrenPrefix + "│   ");
                else
                    TreeGraphToString (nextNode, buffer, childrenPrefix + "└── ", childrenPrefix + "    ");
            }
        }

    }
}
