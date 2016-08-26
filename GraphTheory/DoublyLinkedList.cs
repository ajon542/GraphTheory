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

        public static DNode Insert(DNode head, int data, int position)
        {
            // Adding position 0 is the same as AddHead.
            if (position == 0)
            {
                return AddHead(head, data);
            }

            int index = 0;
            DNode curr = head;

            while (curr.next != null && index < position)
            {
                curr = curr.next;
                index++;
            }

            // Say we have two items in the list at index 0 and 1,
            // then we try to insert an item a index 2. We could do a couple
            // of things.
            // 1. Fail and say that position does not exist, can't insert.
            // 2. Insert that item at the end of the list.

            if (index != position)
            {
                InsertAfter(curr, data);
            }
            else
            {
                // We are at the correct position here, need to append rest of
                // list to the new node.
                InsertBefore(curr, data);
            }

            return head;
        }

        public static void InsertAfter(DNode node, int data)
        {
            // There are two cases we need to handle here.
            // 1. Adding the new node after the last node in the list.
            // 2. Adding the new node in the middle of the list.
            DNode newNode = new DNode { data = data };

            if (node.next == null)
            {
                // Add node to end of list.
                node.next = newNode;
                newNode.prev = node;
                return;
            }

            // Add node in middle of list.
            newNode.next = node.next;
            newNode.prev = node;
            node.next.prev = newNode;
            node.next = newNode;
        }

        public static void InsertBefore(DNode node, int data)
        {
            // There are two cases we need to handle here.
            // 1. Adding the new node before the first node in the list.
            // 2. Adding the new node in the middle of the list.
            DNode newNode = new DNode { data = data };

            if (node.prev == null)
            {
                // Add node to start of list.
                node.prev = newNode;
                newNode.next = node;
                return;
            }

            // Add node in middle of list.
            newNode.prev = node.prev;
            newNode.next = node;
            node.prev.next = newNode;
            node.prev = newNode;
        }

        public static DNode DeleteFirstOf(DNode head, int data)
        {
            DNode curr = head;

            while (curr != null)
            {
                // The current node data matches.
                if (curr.data == data)
                {
                    // Head node.
                    if (curr.prev == null)
                    {
                        head = curr.next;
                        
                        // The node may have been the last node in the list, if not:
                        if (head != null)
                        {
                            // Remove reference to previous node.
                            head.prev = null;
                        }
                    }
                    // Tail node.
                    else if (curr.next == null)
                    {
                        // Remove the previous node's reference to the current node.
                        curr.prev.next = null;
                    }
                    // Middle node.
                    else
                    {
                        // Unlink the node.
                        curr.prev.next = curr.next;
                        curr.next.prev = curr.prev;
                    }

                    // Remove the final reference to the node.
                    curr = null;
                }
                else
                {
                    curr = curr.next;
                }
            }

            return head;
        }

        public static void Delete(ref DNode node)
        {
            node.next.prev = node.prev;
            node.prev.next = node.next;
            node = null;
        }
    }
}
