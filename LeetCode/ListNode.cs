using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /**
    * Definition for singly-linked list.
    */
    public partial class ListNode
    {
        public int val;
        private int initValue;
        public ListNode next;
        private (ListNode[] nodes, int pos) linkedNodes = default;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
        /// <summary>
        /// Create instance of linked list of ListNode's
        /// </summary>
        /// <param name="vals">Array of values for nodes</param>
        /// <param name="pos">Position of the loop. If pos<0 or pos >= vals.Lenght, linked list haven't loop</param>
        /// <param name="isFreeze">Freeze all nodes of linked list, so your can call IsChanged() for check modifications</param>
        /// <returns></returns>
        public static ListNode Create(int[] vals, int pos = -1, bool isFreeze = false)
        {
            if (vals == null || vals.Length == 0)
                return null;
            (ListNode[] nodes, int pos) linkedNodes = default;
            var nodes = new ListNode[vals.Length];
            if (isFreeze)
            {
                linkedNodes = new();
                linkedNodes.nodes = nodes;
                linkedNodes.pos = pos;
            }
            ListNode next=null, node=null;
            for (int i = vals.Length - 1; i >= 0; i--)
            {
                node = new ListNode(vals[i], next);
                if (isFreeze)
                {
                    node.initValue = vals[i];
                    node.linkedNodes = linkedNodes;
                }
                nodes[i] = node;
                next = node;
           }
            if (pos>=0 & pos<vals.Length)
            {
                nodes[vals.Length - 1].next = nodes[pos];
            }
            return node;
        }
        public bool AreEquals(ListNode other)
        {
            ListNode shuttle = this;
            do
            {
                if (other == null || shuttle.val != other.val)
                {
                    return false;
                }
                other = other.next;
                shuttle = shuttle.next;
            } while (shuttle != null);
            return other == null;
        }
 
        /// <summary>
        /// Check for changes in linked list
        /// </summary>
        /// <returns></returns>
        public bool IsLinkedListChanged()
        {
            if (linkedNodes==default)
            {
                throw new InvalidOperationException("Linked list not freezed. To test the modification, you need to create linked list width ListNode.Create(vals, isFreeze = frue)");
            }
            var nodes = linkedNodes.nodes;
            ListNode node;
            int i;
            for ( i= 0; i < nodes.Length-1; i++)
            {
                node = nodes[i];
                if (!(node.next == nodes[i+1] & node.val == node.initValue))
                {
                    return true;
                }
            }
            int pos = linkedNodes.pos;
            node = nodes[i];
            if (pos < 0 | pos >= nodes.Length)
            {
                return !(node.val == node.initValue);
            }
            else
                return !(node.val == node.initValue & node.next == nodes[pos]);
        }
        /*876. Middle of the Linked List
         * Easy
         * Given the head of a singly linked list, return the middle node of the linked list.
         * If there are two middle nodes, return the second middle node.
         Constraints:

    The number of nodes in the list is in the range [1, 100].
    1 <= Node.val <= 100

         */
        public static ListNode MiddleNode(ListNode head) {
            ListNode middle = head, last = head.next;
            if (last == null) {
                return head;
            }
            do {
                middle = middle.next;
                last = last.next?.next;
            } while (last != null);
            return middle;
        }
        /*
         19. Remove Nth Node From End of List
        Medium
        Given the head of a linked list, remove the nth node from the end of the list and return its head.
        Constraints:

    The number of nodes in the list is sz.
    1 <= sz <= 30
    0 <= Node.val <= 100
    1 <= n <= sz

         */
        public static ListNode RemoveNthFromEnd(ListNode head, int n) {
            var last = head;
            for (int i = 0; i < n; i++) {
                last = last.next;
            }
            if (last==null) {
                return head.next;
            }
            last = last.next;
            var node = head;
            while (last!=null) {
                node = node.next;
                last = last.next;
            }
            node.next = node.next?.next;
            return head;
        }
        /*
 * 21. Merge Two Sorted Lists
 * Easy
 * You are given the heads of two sorted linked lists list1 and list2.
 * Merge the two lists in a one sorted list. 
 * The list should be made by splicing together the nodes of the first two lists.
 * Return the head of the merged linked list.
 * Constraints:

The number of nodes in both lists is in the range [0, 50].
-100 <= Node.val <= 100
Both list1 and list2 are sorted in non-decreasing order.
 */
        public static ListNode MergeTwoLists(ListNode list1, ListNode list2) {
            if (list1 == null | list2 == null) {
                return list1 ?? list2;
            }
            ListNode shuttle, root;
            if (list1.val < list2.val) {
                root = list1;
                list1 = list2;
            }
            else {
                root = list2;
            }
            shuttle = root;
            while (list1 != null ) {
                if (shuttle.next == null) {
                    shuttle.next = list1;
                    break;
                }

                if (list1.val < shuttle.next.val) {
                    var node = shuttle.next;
                    shuttle.next = list1;
                    list1 = node;
                }
                shuttle = shuttle.next;
            }
            return root;
        }
        public static ListNode MergeTwoLists_I(ListNode list1, ListNode list2) {
            if (list1 == null) {
                return list2;
            }
            if (list2 == null) {
                return list1;
            }
            ListNode shuttle, root;

            if (list2.val < list1.val) {
                shuttle = list1;
                root = list1 = list2;
            }
            else {
                shuttle = list2;
                root = list1;
            }
            while (list1.next != null && shuttle != null) {
                if (list1.next.val > shuttle.val) {
                    list2 = list1.next;
                    list1 = list1.next = shuttle;
                    shuttle = list2;
                }
                else
                    list1 = list1.next;
            }
            if (shuttle != null) {
                list1.next = shuttle;
            }
            return root;
        }
        /*
         * 23. Merge k Sorted Lists
         * Hard
         * You are given an array of k linked-lists lists,
         * each linked-list is sorted in ascending order.
         * Merge all the linked-lists into one sorted linked-list and return it.
         * 
         * Constraints:

    k == lists.length
    0 <= k <= 10^4
    0 <= lists[i].length <= 500
    -10^4 <= lists[i][j] <= 10^4
    lists[i] is sorted in ascending order.
    The sum of lists[i].length won't exceed 10^4.

         */
        public static ListNode MergeKLists(ListNode[] lists) {
            var lists1 = MergeKSortedLists(lists);
            return lists1[0];
        }
        private static ListNode[] MergeKSortedLists(ListNode[] lists) {
            if (lists.Length == 1) {
                return lists;
            }
            else if (lists.Length == 2) {
                return new ListNode[] {
                    MergeTwoLists(lists[0], lists[1])
                };
            }
            else {
                ListNode[] lists1 = new ListNode[lists.Length / 2];
                Array.Copy(lists, 0, lists1, 0, lists.Length / 2);
                var l1 = MergeKSortedLists(lists1);
                ListNode[] lists2 = new ListNode[lists.Length - lists1.Length];
                Array.Copy(lists, lists.Length / 2, lists2, 0, lists.Length - lists1.Length);
                var l2 = MergeKSortedLists(lists2);
                ListNode[] lists3 = new ListNode[l1.Length + l2.Length];
                l1.CopyTo(lists3, 0);
                l2.CopyTo(lists3, l1.Length);
                return MergeKSortedLists(lists3);
            }
        }

    }

}
