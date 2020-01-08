using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs
{
    class GraphNode<T> where T : IComparable<T>
    {
        public T value;
        public List<GraphNode<T>> nodes = new List<GraphNode<T>> ();


        public GraphNode()
        {
            nodes = new List<GraphNode<T>> ();
        }

        public GraphNode(T theValue)
        {
            value = theValue;
            nodes = new List<GraphNode<T>> ();
        }


        public String DepthFirstToString()
        {
            return DepthFirstToString (this);
        }

        private static String DepthFirstToString(GraphNode<T> currNode)
        {
            // Leaf
            if (currNode.nodes.Count <= 0)
                return currNode.value.ToString () + " ";

            String returnString = "";

            for (int i = 0; i < currNode.nodes.Count; i++)
            {
                if (currNode.nodes[i] == null)
                    continue;
                returnString += DepthFirstToString (currNode.nodes[i]);
            }

            return currNode.value.ToString () + " " + returnString;
        }


        public String BreadthFirstToString()
        {
            return BreadthFirstToString (this);
        }

        private static String BreadthFirstToString(GraphNode<T> startNode)
        {
            Queue<GraphNode<T>> queue = new Queue<GraphNode<T>> ();
            String returnString = "";

            queue.Enqueue (startNode);

            while (queue.Count > 0)
            {
                GraphNode<T> currNode = queue.Dequeue ();
                if (currNode == null)
                    continue;
                returnString += currNode.value.ToString () + " ";
                currNode.nodes.ForEach (n => queue.Enqueue (n));
            }

            return returnString;
        }

    }
}
