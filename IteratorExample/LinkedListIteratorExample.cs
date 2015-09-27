using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IteratorExample
{
    public class LinkedListIteratorExample : Iterable<int>
    {
        ListNode current;
        ListNode first;

        public LinkedListIteratorExample(int size)
        {
            first = new ListNode();
            current = first;

            for(int i = 1; i < size; i++)
            {
                current.next = new ListNode();
                current = current.next;
            }

            Random gen = new Random();
            current = first;
            while(current != null)
            {
                current.data = gen.Next(1000);
                current = current.next;
            }

            current = first;
        }

        public int GetFirst()
        {
            return first.data;
        }

        public void Advance()
        {
            current = current.next;
        }

        public int GetCurrent()
        {
            return current.data;
        }

        public bool AtEnd()
        {
            return current == null;
        }

        public void Reset()
        {
            current = first;
        }
    }

    class ListNode
    {
        public int data;
        public ListNode next = null;
    }
}
