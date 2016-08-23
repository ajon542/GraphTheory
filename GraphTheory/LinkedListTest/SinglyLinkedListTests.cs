using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using GraphTheory;

namespace LinkedListTest
{
    [TestClass]
    public class SinglyLinkedListTests
    {
        #region AddHead Tests
        [TestMethod]
        public void TestMethod1()
        {
            SNode head = null;
            head = SinglyLinkedList.AddHead(head, 1);

            Assert.AreEqual(1, head.data);
            Assert.IsNull(head.next);
        }

        [TestMethod]
        public void TestMethod2()
        {
            SNode head = null;
            head = SinglyLinkedList.AddHead(head, 1);
            head = SinglyLinkedList.AddHead(head, 2);

            Assert.AreEqual(2, head.data);
            Assert.AreEqual(1, head.next.data);
            Assert.IsNull(head.next.next);
        }

        [TestMethod]
        public void TestMethod3()
        {
            SNode head = null;
            head = SinglyLinkedList.AddHead(head, 1);
            head = SinglyLinkedList.AddHead(head, 2);
            head = SinglyLinkedList.AddHead(head, 3);

            Assert.AreEqual(3, head.data);
            Assert.AreEqual(2, head.next.data);
            Assert.AreEqual(1, head.next.next.data);
            Assert.IsNull(head.next.next.next);
        }
        #endregion

        #region AddTail Tests
        [TestMethod]
        public void TestMethod4()
        {
            SNode head = null;
            head = SinglyLinkedList.AddTail(head, 1);

            Assert.AreEqual(1, head.data);
            Assert.IsNull(head.next);
        }

        [TestMethod]
        public void TestMethod5()
        {
            SNode head = null;
            head = SinglyLinkedList.AddTail(head, 1);
            head = SinglyLinkedList.AddTail(head, 2);

            Assert.AreEqual(1, head.data);
            Assert.AreEqual(2, head.next.data);
            Assert.IsNull(head.next.next);
        }

        [TestMethod]
        public void TestMethod6()
        {
            SNode head = null;
            head = SinglyLinkedList.AddTail(head, 1);
            head = SinglyLinkedList.AddTail(head, 2);
            head = SinglyLinkedList.AddTail(head, 3);

            Assert.AreEqual(1, head.data);
            Assert.AreEqual(2, head.next.data);
            Assert.AreEqual(3, head.next.next.data);
            Assert.IsNull(head.next.next.next);
        }
        #endregion

        #region Insert Tests
        [TestMethod]
        public void TestMethod7()
        {
            SNode head = null;
            head = SinglyLinkedList.Insert(head, 1, 0);

            Assert.AreEqual(1, head.data);
            Assert.IsNull(head.next);
        }

        [TestMethod]
        public void TestMethod8()
        {
            SNode head = null;
            head = SinglyLinkedList.Insert(head, 1, 0);
            head = SinglyLinkedList.Insert(head, 2, 0);

            Assert.AreEqual(2, head.data);
            Assert.AreEqual(1, head.next.data);
            Assert.IsNull(head.next.next);
        }

        [TestMethod]
        public void TestMethod9()
        {
            SNode head = null;
            head = SinglyLinkedList.Insert(head, 1, 0);
            head = SinglyLinkedList.Insert(head, 2, 0);
            head = SinglyLinkedList.Insert(head, 3, 1);

            Assert.AreEqual(2, head.data);
            Assert.AreEqual(3, head.next.data);
            Assert.AreEqual(1, head.next.next.data);
            Assert.IsNull(head.next.next.next);
        }

        [TestMethod]
        public void TestMethod10()
        {
            SNode head = null;
            head = SinglyLinkedList.Insert(head, 1, 0);
            head = SinglyLinkedList.Insert(head, 2, 0);
            head = SinglyLinkedList.Insert(head, 3, 2);

            Assert.AreEqual(2, head.data);
            Assert.AreEqual(1, head.next.data);
            Assert.AreEqual(3, head.next.next.data);
            Assert.IsNull(head.next.next.next);
        }

        [TestMethod]
        public void TestMethod11()
        {
            SNode head = null;
            head = SinglyLinkedList.Insert(head, 1, 0);
            head = SinglyLinkedList.Insert(head, 2, 0);
            head = SinglyLinkedList.Insert(head, 3, 100);

            Assert.AreEqual(2, head.data);
            Assert.AreEqual(1, head.next.data);
            Assert.AreEqual(3, head.next.next.data);
            Assert.IsNull(head.next.next.next);
        }

        #endregion
    }
}
