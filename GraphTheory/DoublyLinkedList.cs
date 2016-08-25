using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class DNode
    {
        public int data;
        public DNode next;
        public DNode prev;
    }

    public class DoublyLinkedList
    {
        public static DNode AddHead(DNode head, int data)
        {
            DNode newNode = new DNode { data = data };
            newNode.next = head;

            if (head != null)
            {
                head.prev = newNode;
            }

            return newNode;
        }

        public static DNode AddTail(DNode head, int data)
        {
            DNode newNode = new DNode { data = data };

            // List doesn't exist, just return the new node.
            if (head == null)
            {
                return newNode;
            }

            DNode tmp = head;

            // Iterate to end of list.
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }

            // Add the new node.
            tmp.next = newNode;
            newNode.prev = tmp;

            return head;
        }
    }
}
