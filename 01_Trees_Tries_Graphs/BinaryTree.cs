using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs.BinaryTree
{
    class BinaryTree<T> where T : IComparable<T>
    {
        //TODO: should be private
        public Node<T> head = null;


        public void Insert(ref Node<T> newNode)
        {

        }


        public override string ToString()
        {
            return head.ToString ();
        }
    }
}
