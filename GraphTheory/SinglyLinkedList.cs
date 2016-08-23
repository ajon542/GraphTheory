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

        public static SNode Delete(SNode head, int data)
        {
            SNode curr = head;
            SNode prev = null;
            SNode toDelete = null;

            // Delete all nodes with the given data.
            while (curr != null)
            {
                if (curr.data == data)
                {
                    toDelete = curr;
                    if (prev == null)
                    {
                        head = curr.next;
                    }
                    else
                    {
                        prev.next = curr.next;
                    }
                }
                else
                {
                    prev = curr;
                }
                curr = curr.next;
                toDelete = null;
            }

            return head;
        }

        public static int CycleSize(SNode head, SNode curr)
        {
            SNode a = head;
            SNode b = curr;

            // Find the cycle start index.
            int cycleStartIndex = 0;
            while (a != b)
            {
                a = a.next;
                b = b.next;
                cycleStartIndex++;
            }

            // Count the cycle size.
            a = a.next;
            int cycleSize = 1;
            while (a != b)
            {
                a = a.next;
                cycleSize++;
            }
            Console.WriteLine("cycleStartIndex={0}, cycleSize={1}", cycleStartIndex, cycleSize);
            return cycleSize;
        }

        public static int FindCycle(SNode head)
        {
            int cycleSize = -1;

            if (head == null || head.next == null)
            {
                return cycleSize;
            }

            // "a" starts at index 0, "b" starts at index 2.
            SNode a = head;
            SNode b = head.next.next;

            while (b != null)
            {
                // Update "a" by one.
                a = a.next;

                if (a == b)
                {
                    // Found cycle.
                    cycleSize = CycleSize(head, b);
                    return cycleSize;
                }

                // Update "b" by two.
                b = b.next;
                if (b != null)
                {
                    b = b.next;
                }
            }
            // Reached end of list without cycle.
            return cycleSize;
        }
    }
}
