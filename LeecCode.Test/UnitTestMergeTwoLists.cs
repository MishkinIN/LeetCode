using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestMergeTwoLists
    {
        [Test]
        public void TestListNode()
        {
            ListNode node = ListNode.Create(null);
            Assert.IsNull(node);
            node = ListNode.Create(new int[0]);
            Assert.IsNull(node);
            node = ListNode.Create(new int[] { 1, 2, 4 });
            ListNode node1 = ListNode.Create(new int[] { 1, 2, 4 });
            ListNode node2 = ListNode.Create(new int[] { 1, 2 });
            Assert.IsTrue(node.AreEquals(node));
            Assert.IsTrue(node.AreEquals(node1));
            Assert.IsFalse(node.AreEquals(node2));

        }
        [Test]
        public void Test1()
        {
            TestListNode();
            ListNode l1 = ListNode.Create(new int[] { 1, 2, 4 });
            ListNode l2 = ListNode.Create(new int[] { 1, 3, 4 });
            ListNode l3 = ListNode.Create(new int[] { 1, 1, 2, 3, 4, 4 });
            Assert.IsTrue(Solution.MergeTwoLists(l1, l2).AreEquals(l3));
            Assert.IsTrue(Solution.MergeTwoLists(null, null) == null);
            l2 = ListNode.Create(new int[] { 0 });
            Assert.IsTrue(Solution.MergeTwoLists(null, l2) == l2);

            l1 = ListNode.Create(new int[] { 1, 2, 4, 6 });
            l2 = ListNode.Create(new int[] { 3, 4 });
            l3 = ListNode.Create(new int[] { 1, 2, 3, 4, 4, 6 });
            Assert.IsTrue(Solution.MergeTwoLists(l1, l2).AreEquals(l3));
        }

    }
}