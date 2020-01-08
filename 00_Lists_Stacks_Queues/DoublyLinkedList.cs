using System;

namespace LinkedLists
{
    abstract class DoublyLinkedList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;


        protected bool HasHead()
        {
            return head != null;
        }

        protected bool HasTail()
        {
            return tail != null;
        }


        protected T GetHeadValue()
        {
            if (head == null)
                throw new InvalidOperationException ("Could not get head value, list is empty");
            return head.value;
        }
        
        protected T GetTailValue()
        {
            if (head == null)
                throw new InvalidOperationException ("Could not get tail value, list is empty");
            return head.value;
        }


        protected void AddHead(T toAdd)
        {
            ListNode<T> newNode = new ListNode<T> (toAdd);
            if (AddedIfFirst (newNode))
                return;

            head.prev = newNode;
            newNode.next = head;
            head = newNode;
        }

        protected void AddTail(T toAdd)
        {
            ListNode<T> newNode = new ListNode<T> (toAdd);
            if (AddedIfFirst (newNode))
                return;

            tail.next = newNode;
            newNode.prev = tail;
            tail = newNode;
        }

        /*protected void AddAt(int index, T toAdd)
        {

        }*/

        
        private bool AddedIfFirst(ListNode<T> newNode)
        {
            if (head != null)
                return false;

            head = newNode;
            tail = newNode;

            return true;
        }

        private bool RemovedIfLast()
        {
            if (head.next != null)
                return false;

            head = null;
            tail = null;

            return true;
        }


        protected T RemoveHead()
        {
            if (head == null)
                throw new InvalidOperationException ("Could not remove head, list is empty");

            T returnVal = head.value;
            if (RemovedIfLast ())
                return returnVal;

            head = head.next;
            head.prev = null;

            // Last element
            if (head == null)
                tail = null;

            return returnVal;
        }

        protected T RemoveTail()
        {
            if (tail == null)
                throw new InvalidOperationException ("Could not remove head, list is empty");

            T returnVal = tail.value;
            if (RemovedIfLast ())
                return returnVal;

            tail = tail.prev;
            tail.next = null;

            // Last element
            if (tail == null)
                head = null;

            return returnVal;
        }

        /*protected T RemoveAt(int index)
        {
            ListNode<T> toRemove = GetNodeAt (index);
            ListNode<T> prev = toRemove.prev;

            if (toRemove.next != null)
                toRemove.prev.next = toRemove.next;
            if (toRemove.prev != null)
                toRemove.next.prev = prev;

            return toRemove.value;
        }*/


        /*public T this[int index]
        {
            get
            {
                return GetNodeAt (index).value;
            }

            set
            {
                GetNodeAt (index).value = value;
            }
        }*/


        private ListNode<T> GetNodeAt(int index)
        {
            if (head == null)
                throw new IndexOutOfRangeException ("List is empty");
            if (index < 0)
                throw new IndexOutOfRangeException ("Index less than zero");

            ListNode<T> curr = head;
            for (int i = 0; i < index; i++)
            {
                if (curr.next == null)
                    throw new IndexOutOfRangeException ("Index exceeds list length");
                curr = curr.next;
            }
            return curr;
        }


        public override String ToString()
        {
            String toReturn = "[";

            ListNode<T> curr = head;
            while (curr != null)
            {
                String seper = curr.next == null ? "" : ", ";
                toReturn += curr.value.ToString() + seper;
                curr = curr.next;
            }

            return toReturn + "]";
        }

    }
}
