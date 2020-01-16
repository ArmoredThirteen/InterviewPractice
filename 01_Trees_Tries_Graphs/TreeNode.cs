using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs
{
    class TreeNode<T> where T : IComparable<T>
    {
        public T value;
        public List<TreeNode<T>> children = new List<TreeNode<T>> ();


        public TreeNode()
        {
            children = new List<TreeNode<T>> ();
        }

        public TreeNode(T theValue)
        {
            value = theValue;
            children = new List<TreeNode<T>> ();
        }


        public String DepthFirstToString()
        {
            return DepthFirstToString (this);
        }

        private static String DepthFirstToString(TreeNode<T> theNode)
        {
            // Leaf
            if (theNode.children.Count <= 0)
                return theNode.value.ToString () + " ";

            String returnString = "";

            for (int i = 0; i < theNode.children.Count; i++)
            {
                if (theNode.children[i] == null)
                    continue;
                returnString += DepthFirstToString (theNode.children[i]);
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
                currNode.children.ForEach (n => queue.Enqueue (n));
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

            for (int i = 0; i < theNode.children.Count; i++)
            {
                // Mirror so that it orients more closely to how binary trees in examples are shown, when tilting head to left
                TreeNode<T> nextNode = theNode.children[(theNode.children.Count - 1) - i];

                if (i != theNode.children.Count - 1)
                    TreeGraphToString (nextNode, buffer, childrenPrefix + "├── ", childrenPrefix + "│   ");
                else
                    TreeGraphToString (nextNode, buffer, childrenPrefix + "└── ", childrenPrefix + "    ");
            }
        }

    }
}
