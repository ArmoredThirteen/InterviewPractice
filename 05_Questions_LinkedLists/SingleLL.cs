using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05_Questions_LinkedLists
{
    public class SingleLL
    {
        public class Node
        {
            public Node next;
            public int val;

            public Node(int theVal)
            {
                val = theVal;
            }
        }


        public Node root;


        public SingleLL(params int[] theVals)
        {
            for (int i = 0; i < theVals.Length; i++)
                AddLast (theVals[i]);
        }


        public bool IsEmpty()
        {
            return root == null;
        }

        public static bool IsNullOrEmpty(SingleLL theList)
        {
            return theList == null || theList.IsEmpty ();
        }

        public int GetLength()
        {
            int length = 0;

            Node currNode = root;
            while (currNode != null)
            {
                length++;
                currNode = currNode.next;
            }

            return length;
        }

        
        public void AddFirst(int theVal)
        {
            AddFirst (new Node (theVal));
        }

        public void AddFirst(SingleLL theList)
        {
            if (theList == null)
                return;

            theList.AddLast (this);
            root = theList.root;
        }

        public void AddFirst(Node newNode)
        {
            if (newNode == null)
                return;

            newNode.next = root;
            root = newNode;
        }


        public void AddLast(int theVal)
        {
            AddLast (new Node (theVal));
        }

        public void AddLast(SingleLL theList)
        {
            if (IsNullOrEmpty (theList))
                return;

            AddLast (theList.root);
        }

        public void AddLast(Node newNode)
        {
            if (newNode == null)
                return;

            if (IsEmpty ())
            {
                root = newNode;
                return;
            }

            Node currNode = root;
            while (currNode.next != null)
                currNode = currNode.next;

            currNode.next = newNode;
        }


        public override bool Equals(object obj)
        {
            SingleLL that = (SingleLL)obj;

            if (IsEmpty () && that.IsEmpty ())
                return true;
            if (IsEmpty () || that.IsEmpty ())
                return false;

            Node currThis = root;
            Node currThat = that.root;

            while (currThis != null || currThat != null)
            {
                if (currThis == null)
                    return false;
                if (currThat == null)
                    return false;

                if (currThis.val != currThat.val)
                    return false;

                currThis = currThis.next;
                currThat = currThat.next;
            }

            return true;
        }

        public override string ToString()
        {
            if (IsEmpty ())
                return "empty";

            StringBuilder builder = new StringBuilder ();

            for (Node currThis = root; currThis != null; currThis = currThis.next)
            {
                builder.Append (currThis.val);
                if (currThis.next != null)
                    builder.Append (", ");
            }

            return builder.ToString ();
        }

    }
}
