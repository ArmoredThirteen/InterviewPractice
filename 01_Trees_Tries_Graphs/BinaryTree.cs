using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs
{
    class BinaryTree<T>
    {
        public GraphNode<T> headNode = new GraphNode<T> ();


        public void AddValue(T newValue)
        {

        }


        public bool HasValue(T nodeValue)
        {
            return FindNode (nodeValue) != null;
        }

        public GraphNode<T> FindNode(T nodeValue)
        {

        }

    }
}
