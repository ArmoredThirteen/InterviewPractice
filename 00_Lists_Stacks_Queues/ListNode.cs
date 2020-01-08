using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LinkedLists
{
    class ListNode<T>
    {
        public T value;

        public ListNode<T> prev;
        public ListNode<T> next;


        public ListNode(T theValue)
        {
            value = theValue;
            prev = null;
            next = null;
        }

        public ListNode(T theValue, ListNode<T> thePrev, ListNode<T> theNext)
        {
            value = theValue;
            prev = thePrev;
            next = theNext;
        }
    }
}
