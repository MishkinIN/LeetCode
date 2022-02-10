using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test {
    public class UnitTestListNode {
        [Test]
        public void TestListNode() {
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
            ListNode node3 = ListNode.Create(new int[] { 1, 2, 4 }, pos: 1, isFreeze: true);
            Assert.IsTrue(node3.next.next.next == node3.next);

        }
        [Test]
        public void TestLestNodeFreeze() {

            ListNode node1 = ListNode.Create(new int[] { 1, 2, 4 }, isFreeze: true);
            Assert.IsFalse(node1.IsLinkedListChanged());
            Assert.IsFalse(node1.next.IsLinkedListChanged());
            node1.next.next.val = int.MaxValue;
            Assert.IsTrue(node1.IsLinkedListChanged());
            Assert.IsTrue(node1.next.IsLinkedListChanged());
            ListNode node2 = ListNode.Create(new int[] { 1, 2, 4 }, isFreeze: false);
            Assert.Throws<System.InvalidOperationException>(() => node2.IsLinkedListChanged());
            ListNode node3 = ListNode.Create(new int[] { 1, 2, 4 }, pos: 1, isFreeze: true);
            node3.next = node3.next.next;
            Assert.IsTrue(node3.IsLinkedListChanged());
        }
        [Test]
        public void MergeTwoLists() {
            TestListNode();
            ListNode l1 = ListNode.Create(new int[] { 1, 2, 4 });
            ListNode l2 = ListNode.Create(new int[] { 1, 3, 4 });
            ListNode l3 = ListNode.Create(new int[] { 1, 1, 2, 3, 4, 4 });
            ListNode actual = ListNode.MergeTwoLists(l1, l2);
            Assert.IsTrue(l3.AreEquals(actual));
            Assert.IsTrue(ListNode.MergeTwoLists(null, null) == null);
            l2 = ListNode.Create(new int[] { 0 });
            Assert.IsTrue(ListNode.MergeTwoLists(null, l2) == l2);

            l1 = ListNode.Create(new int[] { 1, 2, 4, 6 });
            l2 = ListNode.Create(new int[] { 3, 4 });
            l3 = ListNode.Create(new int[] { 1, 2, 3, 4, 4, 6 });
            actual = ListNode.MergeTwoLists(l1, l2);
            Assert.IsTrue(l3.AreEquals(actual));
        }
        [Test]
        public void MergeKLists() {
            ListNode[] lists;
            ListNode ln_expected;
            lists = new ListNode[] {/*[[1,4,5],[1,3,4],[2,6]]*/
                ListNode.Create(new int[] {1, 4, 5}),
                ListNode.Create(new int[] {1, 3, 4}),
                ListNode.Create(new int[] {2, 6}),
            };
            ln_expected = ListNode.Create(new int[] { 1, 1, 2, 3, 4, 4, 5, 6 });
            var mlist = ListNode.MergeKLists(lists);
            Assert.IsNotNull(mlist);
            Assert.IsTrue(ln_expected.AreEquals(mlist));
            lists = new ListNode[] {
                
            };
            mlist = ListNode.MergeKLists(lists);
            Assert.IsNull(mlist);
            
        }
        [Test]
        public void DetectCycle() {
            ListNode root = ListNode.Create(new int[] { });
            Assert.AreEqual((ListNode)null, ListNode.DetectCycle(root));

            root = ListNode.Create(new int[] { 0 }, isFreeze: true);
            Assert.AreEqual((ListNode)null, ListNode.DetectCycle(root));
            Assert.IsFalse(root.IsLinkedListChanged());

            root = ListNode.Create(new int[] { 0 }, 0, isFreeze: true);
            Assert.AreEqual(root, ListNode.DetectCycle(root));
            Assert.IsFalse(root.IsLinkedListChanged());

            root = ListNode.Create(new int[] { 0, 1, 2, 3 }, pos: 1, isFreeze: true);
            Assert.AreEqual(root.next, ListNode.DetectCycle(root));
            Assert.IsFalse(root.IsLinkedListChanged());

        }
    }
}
