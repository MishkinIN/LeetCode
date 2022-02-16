using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    /**
    * Definition for singly-linked list.
    */
    public partial class ListNode {
        public int val;
        private int initValue;
        public ListNode next;
        private (ListNode[] nodes, int pos) linkedNodes = default;
        public ListNode(int val = 0, ListNode next = null) {
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
        public static ListNode Create(int[] vals, int pos = -1, bool isFreeze = false) {
            if (vals == null || vals.Length == 0)
                return null;
            (ListNode[] nodes, int pos) linkedNodes = default;
            var nodes = new ListNode[vals.Length];
            if (isFreeze) {
                linkedNodes = new();
                linkedNodes.nodes = nodes;
                linkedNodes.pos = pos;
            }
            ListNode next = null, node = null;
            for (int i = vals.Length - 1; i >= 0; i--) {
                node = new ListNode(vals[i], next);
                if (isFreeze) {
                    node.initValue = vals[i];
                    node.linkedNodes = linkedNodes;
                }
                nodes[i] = node;
                next = node;
            }
            if (pos >= 0 & pos < vals.Length) {
                nodes[vals.Length - 1].next = nodes[pos];
            }
            return node;
        }
        public bool AreEquals(ListNode other) {
            ListNode shuttle = this;
            do {
                if (other == null || shuttle.val != other.val) {
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
        public bool IsLinkedListChanged() {
            if (linkedNodes == default) {
                throw new InvalidOperationException("Linked list not freezed. To test the modification, you need to create linked list width ListNode.Create(vals, isFreeze = frue)");
            }
            var nodes = linkedNodes.nodes;
            ListNode node;
            int i;
            for (i = 0; i < nodes.Length - 1; i++) {
                node = nodes[i];
                if (!(node.next == nodes[i + 1] & node.val == node.initValue)) {
                    return true;
                }
            }
            int pos = linkedNodes.pos;
            node = nodes[i];
            if (pos < 0 | pos >= nodes.Length) {
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
            if (last == null) {
                return head.next;
            }
            last = last.next;
            var node = head;
            while (last != null) {
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
            ListNode shuttle = new(), root = shuttle;
            while (list1 != null & list2 != null) {
                if (list1.val < list2.val) {
                    shuttle = shuttle.next = list1;
                    list1 = list1.next;
                }
                else {
                    shuttle = shuttle.next = list2;
                    list2 = list2.next;
                }
            }
            shuttle.next = list1 ?? list2;
            return root.next;
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
            if (lists == null || lists.Length == 0)
                return null;
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
        /* 
 Given the head of a linked list, return the node where the cycle begins. 
 If there is no cycle, return null.
 There is a cycle in a linked list if there is some node in the list
 that can be reached again by continuously following the next pointer. 
 Internally, pos is used to denote the index of the node 
 that tail's next pointer is connected to (0-indexed).
 It is -1 if there is no cycle. Note that pos is not passed as a parameter.
 Do not modify the linked list.  

 Constraints:

The number of the nodes in the list is in the range [0, 10^4].
-10^5 <= Node.val <= 10^5
pos is -1 or a valid index in the linked-list.

  */

        public static ListNode DetectCycle(ListNode head) {

            if (head == null || head.next == null)
                return null;
            int lastDistance = 0, distance;
            ListNode node = head.next;
            while (node != null) {
                distance = GetDistance(head, node);
                if (distance <= lastDistance) {
                    break;
                }
                else {
                    lastDistance = distance;
                    node = node.next;
                }
            }
            return node;
        }
        private static int GetDistance(ListNode head, ListNode node) {
            int distance = 0;
            while (head != node) {
                distance++;
                head = head.next;
            }
            return distance;
        }

        /*
         * 141. Linked List Cycle
         * Easy
         * Given head, the head of a linked list, determine if the linked list has a cycle in it.
         * There is a cycle in a linked list if there is some node in the list 
         * that can be reached again by continuously following the next pointer. 
         * Internally, pos is used to denote the index of the node that tail's next pointer is connected to. 
         * Note that pos is not passed as a parameter.
         * Return true if there is a cycle in the linked list. Otherwise, return false.
         * Constraints:

    The number of the nodes in the list is in the range [0, 10^4].
    -10^5 <= Node.val <= 10^5
    pos is -1 or a valid index in the linked-list.

         */
        public static bool HasCycle(ListNode head) {
            var ln2 = head?.next?.next;
            var ln3 = head?.next?.next?.next;
            while (head != ln2 && head != ln3) {
                head = head.next;
                ln2 = ln2?.next?.next;
                ln3 = ln3?.next?.next?.next;
            }
            return head != null;
        }
        /*
         * 203. Remove Linked List Elements
         * Easy
         * Given the head of a linked list and an integer val, 
         * remove all the nodes of the linked list that has Node.val == val, 
         * and return the new head.
         * Constraints:

    The number of nodes in the list is in the range [0, 10^4].
    1 <= Node.val <= 50
    0 <= val <= 50

         */
        public static ListNode RemoveElements(ListNode head, int val) {
            while (head != null && head.val == val) {
                head = head.next;
            }
            if (head == null) {
                return null;
            }
            var shuttle = head;
            while (shuttle.next != null) {
                if (shuttle.next.val == val) {
                    shuttle.next = shuttle.next.next;
                }
                else
                    shuttle = shuttle.next;
            }
            return head;
        }
        /*
         * 206. Reverse Linked List
         * Easy
         * Given the head of a singly linked list, reverse the list, and return the reversed list.
         * Constraints:

    The number of nodes in the list is the range [0, 5000].
    -5000 <= Node.val <= 5000
        Follow up: A linked list can be reversed either iteratively or recursively. 
        Could you implement both?
         */
        public static ListNode ReverseList(ListNode head) {
            if (head == null) {
                return null;
            }

            ListNode tail = new(head.val), shuttle;
            head = head.next;
            while (head != null) {
                shuttle = head.next;
                head.next = tail;
                tail = head;
                head = shuttle;
            }
            return tail;
        }
        /*
         * 24. Swap Nodes in Pairs
         * Medium
         * Given a linked list, swap every two adjacent nodes and return its head. 
         * You must solve the problem without modifying the values in the list's nodes 
         * (i.e., only nodes themselves may be changed.)
         * 
         * Constraints:

    The number of nodes in the list is in the range [0, 100].
    0 <= Node.val <= 100
         
         */
        public static ListNode SwapPairs(ListNode head) {
            var root = new ListNode(0, head);
            var shuttle = root;
            var node = head;
            var nextNode = node?.next;
            while (nextNode != null) {
                node.next = nextNode.next;
                nextNode.next = node;
                shuttle.next = nextNode;
                shuttle = node;
                node = node.next;
                nextNode = node?.next;
            }
            return root.next;
        }
    }

}
