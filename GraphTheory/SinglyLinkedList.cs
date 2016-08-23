using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphTheory
{
    public class SNode
    {
        public int data;
        public SNode next;
    }

    public class SinglyLinkedList
    {
        public static SNode AddHead(SNode head, int data)
        {
            SNode newNode = new SNode { data = data };
            newNode.next = head;
            return newNode;
        }

        public static SNode AddTail(SNode head, int data)
        {
            SNode newNode = new SNode { data = data };

            // List doesn't exist, just return the new node.
            if (head == null)
            {
                return newNode;
            }

            SNode tmp = head;

            // Iterate to end of list.
            while (tmp.next != null)
            {
                tmp = tmp.next;
            }

            // Add the new node.
            tmp.next = newNode;

            return head;
        }

        public static SNode Insert(SNode head, int data, int position)
        {
            SNode newNode = new SNode { data = data };

            // Adding position 0 is the same as AddHead.
            if (position == 0)
            {
                return AddHead(head, data);
            }

            int index = 0;
            SNode curr = head;
            SNode prev = null;

            while (curr != null && index < position)
            {
                prev = curr;
                curr = curr.next;
                index++;
            }

            // Add the new node.
            newNode.next = curr;
            prev.next = newNode;

            return head;
        }
    }
}
