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
            Node newNode = new Node (theVal);
            newNode.next = root;
            root = newNode;
        }

        public void AddLast(int theVal)
        {
            Node newNode = new Node (theVal);

            if (root == null)
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

            if (this.root == null && that.root == null)
                return true;
            if (this.root == null || that.root == null)
                return false;

            Node currThis = root;
            Node currThat = that.root;

            while (currThis != null)
            {
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
            if (root == null)
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
