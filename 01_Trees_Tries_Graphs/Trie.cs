using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs
{
    class Trie
    {
        // Value-less head node to kick searches off from
        public GraphNode<char> headNode = new GraphNode<char> ();


        public void AddString(string theWord)
        {
            char[] charWord = theWord.ToCharArray ();
            GraphNode<char> currNode = headNode;

            for (int i = 0; i < charWord.Length; i++)
            {
                // Get any existing matching connection
                GraphNode<char> conNode = currNode.nodes.Find (n => n.value.Equals (charWord[i]));

                // Add new connection if needed
                if (conNode == null)
                {
                    conNode = new GraphNode<char> (charWord[i]);
                    currNode.nodes.Add (conNode);
                }

                currNode = conNode;
            }
        }


        public bool HasString(string theWord)
        {
            char[] charWord = theWord.ToCharArray ();
            GraphNode<char> currNode = headNode;

            for (int i = 0; i < charWord.Length; i++)
            {
                // Get any existing matching connection
                GraphNode<char> conNode = currNode.nodes.Find (n => n.value.Equals (charWord[i]));

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
