using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _01_Trees_Tries_Graphs.BinaryTree
{
    public class Node<T> where T : IComparable<T>
    {
        public T value;
        public int height = 0;

        public Node<T> left  = null;
        public Node<T> right = null;


        public Node(T theValue)
        {
            value = theValue;
        }


        public override String ToString()
        {
            StringBuilder buffer = new StringBuilder (50);
            BuildString (this, buffer, "", "");
            return buffer.ToString ();
        }

        // Modified version of answer by VasiliNovikov:
        // https://stackoverflow.com/questions/4965335/how-to-print-binary-tree-diagram
        private static void BuildString(Node<T> currNode, StringBuilder buffer, String prefix, String childrenPrefix)
        {
            buffer.Append (prefix);
            if (currNode == null)
            {
                buffer.Append ("*\r\n");
                return;
            }

            buffer.Append (currNode.value.ToString ());
            buffer.Append ("\r\n");

            // Right then left subtrees (so placement when tilting head to left matches most tree examples)
            BuildString (currNode.right, buffer, childrenPrefix + "├── ", childrenPrefix + "│   ");
            BuildString (currNode.left, buffer, childrenPrefix + "└── ", childrenPrefix + "    ");
        }



        #region Operator Overloads
        // Operator <
        public static bool operator <(Node<T> n1, Node<T> n2) { return n1.value.CompareTo (n2.value) < 0; }
        public static bool operator <(Node<T> n1, T v2) { return n1.value.CompareTo (v2) < 0; }
        public static bool operator <(T v1, Node<T> n2) { return v1.CompareTo (n2.value) < 0; }

        // Operator >
        public static bool operator >(Node<T> n1, Node<T> n2) { return n1.value.CompareTo (n2.value) > 0; }
        public static bool operator >(Node<T> n1, T v2) { return n1.value.CompareTo (v2) > 0; }
        public static bool operator >(T v1, Node<T> n2) { return v1.CompareTo (n2.value) > 0; }
        
        // Operator <=
        public static bool operator <=(Node<T> n1, Node<T> n2) { return n1.value.CompareTo (n2.value) <= 0; }
        public static bool operator <=(Node<T> n1, T v2) { return n1.value.CompareTo (v2) <= 0; }
        public static bool operator <=(T v1, Node<T> n2) { return v1.CompareTo (n2.value) <= 0; }
        
        // Operator >=
        public static bool operator >=(Node<T> n1, Node<T> n2) { return n1.value.CompareTo (n2.value) >= 0; }
        public static bool operator >=(Node<T> n1, T v2) { return n1.value.CompareTo (v2) >= 0; }
        public static bool operator >=(T v1, Node<T> n2) { return v1.CompareTo (n2.value) >= 0; }
        
        // Operator ==
        public static bool operator ==(Node<T> n1, Node<T> n2)
        {
            if (n1 is null && n2 is null)
                return true;
            if (n1 is null ^ n2 is null)
                return false;

            return n1.value.CompareTo (n2.value) == 0;
        }

        public static bool operator ==(Node<T> n1, T v2)
        {
            if (n1 is null)
                return false;

            return n1.value.CompareTo (v2) == 0;
        }

        public static bool operator ==(T v1, Node<T> n2)
        {
            if (n2 is null)
                return true;

            return v1.CompareTo (n2.value) == 0;
        }
        
        // Operator !=
        public static bool operator !=(Node<T> n1, Node<T> n2)
        {
            if (n1 is null && n2 is null)
                return false;
            if (n1 is null ^ n2 is null)
                return true;

            return n1.value.CompareTo (n2.value) != 0;
        }

        public static bool operator !=(Node<T> n1, T v2)
        {
            if (n1 is null)
                return true;

            return n1.value.CompareTo (v2) != 0;
        }

        public static bool operator !=(T v1, Node<T> n2)
        {
            if (n2 is null)
                return false;

            return v1.CompareTo (n2.value) != 0;
        }
        #endregion

    }
}
