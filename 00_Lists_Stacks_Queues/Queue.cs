using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedLists
{
    class Queue<T> : DoublyLinkedList<T>
    {
        public void Enqueue(T toAdd)
        {
            this.AddHead(toAdd);
        }

        public bool CanDequeue()
        {
            return this.HasTail ();
        }

        public T Dequeue()
        {
            return this.RemoveTail ();
        }

        public T Preview()
        {
            return this.GetTailValue ();
        }

    }
}
