using System;
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
    }
}
