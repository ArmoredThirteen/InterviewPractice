using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedLists
{
    class Stack<T> : DoublyLinkedList<T>
    {
        public void Push(T toAdd)
        {
            this.AddHead (toAdd);
        }

        public bool CanPop()
        {
            return this.HasHead ();
        }

        public T Pop()
        {
            return this.RemoveHead ();
        }

        public T Peek()
        {
            return this.GetHeadValue();
        }

    }
}
