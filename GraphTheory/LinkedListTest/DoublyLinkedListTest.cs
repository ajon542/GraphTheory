using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GraphTheory;

namespace LinkedListTest
{
    [TestClass]
    public class DoublyLinkedListTest
    {
        #region AddHead Tests
        [TestMethod]
        public void TestMethod1()
        {
            DNode head = null;
            head = DoublyLinkedList.AddHead(head, 1);

            // 1 <-> null
            Assert.AreEqual(1, head.data);
            Assert.IsNull(head.next);
        }

        [TestMethod]
        public void TestMethod2()
        {
            DNode head = null;
            head = DoublyLinkedList.AddHead(head, 1);
            head = DoublyLinkedList.AddHead(head, 2);

            // 2 <-> 1 <-> null
            Assert.AreEqual(2, head.data);
            Assert.AreEqual(1, head.next.data);
            Assert.AreEqual(2, head.next.prev.data);
            Assert.IsNull(head.next.next);
        }

        [TestMethod]
        public void TestMethod3()
        {
            DNode head = null;
            head = DoublyLinkedList.AddHead(head, 1);
            head = DoublyLinkedList.AddHead(head, 2);
            head = DoublyLinkedList.AddHead(head, 3);

            // 3 <-> 2 <-> 1 <-> null
            Assert.AreEqual(3, head.data);
            Assert.AreEqual(2, head.next.data);
            Assert.AreEqual(3, head.next.prev.data);
            Assert.AreEqual(1, head.next.next.data);
            Assert.AreEqual(2, head.next.next.prev.data);
            Assert.IsNull(head.next.next.next);
        }
        #endregion

        #region AddTail Tests
        [TestMethod]
        public void TestMethod4()
        {
            DNode head = null;
            head = DoublyLinkedList.AddTail(head, 1);

            // 1 <-> null
            Assert.AreEqual(1, head.data);
            Assert.IsNull(head.next);
        }

        [TestMethod]
        public void TestMethod5()
        {
            DNode head = null;
            head = DoublyLinkedList.AddTail(head, 1);
            head = DoublyLinkedList.AddTail(head, 2);

            // 1 <-> 2 <-> null
            Assert.AreEqual(1, head.data);
            Assert.AreEqual(2, head.next.data);
            Assert.AreEqual(1, head.next.prev.data);
            Assert.IsNull(head.next.next);
        }

        [TestMethod]
        public void TestMethod6()
        {
            DNode head = null;
            head = DoublyLinkedList.AddTail(head, 1);
            head = DoublyLinkedList.AddTail(head, 2);
            head = DoublyLinkedList.AddTail(head, 3);

            // 1 <-> 2 <-> 3 <-> null
            Assert.AreEqual(1, head.data);
            Assert.AreEqual(2, head.next.data);
            Assert.AreEqual(1, head.next.prev.data);
            Assert.AreEqual(3, head.next.next.data);
            Assert.AreEqual(2, head.next.next.prev.data);
            Assert.IsNull(head.next.next.next);
        }
        #endregion

        #region Insert Tests
        [TestMethod]
        public void TestMethod7()
        {
            DNode head = null;
            head = DoublyLinkedList.Insert(head, 1, 0);

            // 1 <-> null
            Assert.AreEqual(1, head.data);
            Assert.IsNull(head.next);
        }

        [TestMethod]
        public void TestMethod8()
        {
            DNode head = null;
            head = DoublyLinkedList.Insert(head, 1, 0);
            head = DoublyLinkedList.Insert(head, 2, 0);

            // 2 <-> 1 <-> null
            Assert.AreEqual(2, head.data);
            Assert.AreEqual(1, head.next.data);
            Assert.AreEqual(2, head.next.prev.data);
            Assert.IsNull(head.next.next);
        }

        [TestMethod]
        public void TestMethod9()
        {
            DNode head = null;
            head = DoublyLinkedList.Insert(head, 1, 0);
            head = DoublyLinkedList.Insert(head, 2, 0);
            head = DoublyLinkedList.Insert(head, 3, 1);

            // 2 <-> 3 <-> 1 <-> null
            Assert.AreEqual(2, head.data);
            Assert.AreEqual(3, head.next.data);
            Assert.AreEqual(2, head.next.prev.data);
            Assert.AreEqual(1, head.next.next.data);
            Assert.AreEqual(3, head.next.next.prev.data);
            Assert.IsNull(head.next.next.next);
        }

        [TestMethod]
        public void TestMethod10()
        {
            DNode head = null;
            head = DoublyLinkedList.Insert(head, 1, 0);
            head = DoublyLinkedList.Insert(head, 2, 0);
            head = DoublyLinkedList.Insert(head, 3, 2);

            // 2 <-> 1 <-> 3 <-> null 
            Assert.AreEqual(2, head.data);
            Assert.AreEqual(1, head.next.data);
            Assert.AreEqual(2, head.next.prev.data);
            Assert.AreEqual(3, head.next.next.data);
            Assert.AreEqual(1, head.next.next.prev.data);
            Assert.IsNull(head.next.next.next);
        }

        [TestMethod]
        public void TestMethod11()
        {
            DNode head = null;
            head = DoublyLinkedList.Insert(head, 1, 0);
            head = DoublyLinkedList.Insert(head, 2, 0);
            head = DoublyLinkedList.Insert(head, 3, 100);

            // 2 <-> 1 <-> 3 <-> null 
            Assert.AreEqual(2, head.data);
            Assert.AreEqual(1, head.next.data);
            Assert.AreEqual(2, head.next.prev.data);
            Assert.AreEqual(3, head.next.next.data);
            Assert.AreEqual(1, head.next.next.prev.data);
            Assert.IsNull(head.next.next.next);
        }
        #endregion

        #region Delete Tests
        [TestMethod]
        public void TestMethod12()
        {
            DNode head = null;
            head = DoublyLinkedList.AddTail(head, 1);
            head = DoublyLinkedList.DeleteFirstOf(head, 1);
            Assert.IsNull(head);
        }

        [TestMethod]
        public void TestMethod13()
        {
            DNode head = null;
            head = DoublyLinkedList.AddTail(head, 1);
            head = DoublyLinkedList.AddTail(head, 2);
            head = DoublyLinkedList.DeleteFirstOf(head, 1);

            ValidateList(head, new List<int> { 2 });
        }

        [TestMethod]
        public void TestMethod14()
        {
            DNode head = null;
            head = DoublyLinkedList.AddTail(head, 1);
            head = DoublyLinkedList.AddTail(head, 2);
            head = DoublyLinkedList.DeleteFirstOf(head, 2);

            ValidateList(head, new List<int> { 1 });
        }

        [TestMethod]
        public void TestMethod15()
        {
            DNode head = null;
            head = DoublyLinkedList.AddTail(head, 1);
            head = DoublyLinkedList.AddTail(head, 2);
            head = DoublyLinkedList.AddTail(head, 3);
            head = DoublyLinkedList.AddTail(head, 4);
            head = DoublyLinkedList.AddTail(head, 5);
            head = DoublyLinkedList.DeleteFirstOf(head, 5);

            ValidateList(head, new List<int> { 1, 2, 3, 4 });
        }

        [TestMethod]
        public void TestMethod16()
        {
            DNode head = null;
            head = DoublyLinkedList.AddTail(head, 1);
            head = DoublyLinkedList.AddTail(head, 2);
            head = DoublyLinkedList.AddTail(head, 3);
            head = DoublyLinkedList.AddTail(head, 4);
            head = DoublyLinkedList.AddTail(head, 5);
            head = DoublyLinkedList.DeleteFirstOf(head, 5);
            head = DoublyLinkedList.DeleteFirstOf(head, 4);
            head = DoublyLinkedList.DeleteFirstOf(head, 2);
            head = DoublyLinkedList.DeleteFirstOf(head, 3);
            head = DoublyLinkedList.DeleteFirstOf(head, 1);

            ValidateList(head, new List<int> ());
        }
        #endregion

        private void ValidateList(DNode head, List<int> expected)
        {
            int count = 0;
            DNode curr = head;

            // Validate count of items in each list is equal.
            while (curr != null)
            {
                count++;
                curr = curr.next;
            }

            // Ensure the lists contain the same number of elements.
            Assert.AreEqual(count, expected.Count);

            curr = head;
            count = 0;
            while (curr != null)
            {
                // Head node.
                if (count == 0)
                {
                    Assert.IsNull(curr.prev);

                    // If the head node, is not also the tail node.
                    if (expected.Count > 1)
                    {
                        Assert.AreEqual(expected[count + 1], curr.next.data);
                    }
                }
                // Tail node.
                else if (count == expected.Count - 1)
                {
                    Assert.IsNull(curr.next);
                }
                // Middle node.
                else
                {
                    Assert.AreEqual(expected[count + 1], curr.next.data);
                    Assert.AreEqual(expected[count - 1], curr.prev.data);
                }

                // Ensure data for the current node is valid.
                Assert.AreEqual(expected[count], curr.data);

                count++;
                curr = curr.next;
            }

        }
    }
}
