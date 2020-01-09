using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs
{
    class Trie
    {
        // Value-less head node to kick searches off from
        public TreeNode<char> headNode = new TreeNode<char> ();


        public void AddString(string theWord)
        {
            char[] charWord = theWord.ToCharArray ();
            TreeNode<char> currNode = headNode;

            for (int i = 0; i < charWord.Length; i++)
            {
                // Get any existing matching connection
                TreeNode<char> conNode = currNode.nodes.Find (n => n.value.Equals (charWord[i]));

                // Add new connection if needed
                if (conNode == null)
                {
                    conNode = new TreeNode<char> (charWord[i]);
                    currNode.nodes.Add (conNode);
                }

                currNode = conNode;
            }
        }


        public bool HasString(string theWord)
        {
            char[] charWord = theWord.ToCharArray ();
            TreeNode<char> currNode = headNode;

            for (int i = 0; i < charWord.Length; i++)
            {
                // Get any existing matching connection
                TreeNode<char> conNode = currNode.nodes.Find (n => n.value.Equals (charWord[i]));

                // Letter does not exist
                if (conNode == null)
                    return false;

                currNode = conNode;
            }

            // Nothing caused string search to fail, so must be true
            return true;
        }


        public override string ToString()
        {
            return headNode.DepthFirstToString ();
            //return headNode.BreadthFirstToString ();
        }

    }
}
