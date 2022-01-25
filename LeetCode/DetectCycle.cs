using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public partial class ListNode
    {
        /*
         * 
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) {
 *         val = x;
 *         next = null;
 *     }
 * }
 
         * 
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

        public static ListNode DetectCycle(ListNode head)
        {

            if (head==null || head.next == null)
                return null;
            int lastDistance = 0, distance;
            ListNode node = head.next;
            while (node != null)
            {
                distance = GetDistance(head, node);
                if (distance <= lastDistance)
                {
                    break;
                }
                else
                {
                    lastDistance = distance;
                    node = node.next;
                }
            }
            return node;
        }
        private static int GetDistance(ListNode head, ListNode node)
        {
            int distance = 0;
            while (head != node)
            {
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
        public bool HasCycle(ListNode head) {
            var ln2 = head?.next?.next;
            var ln3 = head?.next?.next?.next;
            while (head!=ln2 && head !=ln3) {
                head = head.next;
                ln2 = ln2?.next?.next;
                ln3 = ln3?.next?.next?.next;
            }
            return head != null;
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
        public ListNode MergeTwoLists(ListNode list1, ListNode list2) {
            if (list1==null) {
                return list2;
            }
            if (list2 == null) {
                return list1;
            }
            ListNode shuttle, root;

            if (list2.val<list1.val) {
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
            if (shuttle!=null) {
                list1.next = shuttle;
            }
            return root;
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
        public ListNode RemoveElements(ListNode head, int val) {
            while (head!=null && head.val==val) {
                head = head.next;
            }
            if (head==null) {
                return null;
            }
            var shuttle = head;
            while (shuttle.next!=null) {
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
        public ListNode ReverseList(ListNode head) {
            if (head==null) {
                return null;
            }
            ListNode tail = new ListNode(head.val), shuttle;
            head = head.next;
            while (head!=null) {
                shuttle = head.next;
                head.next = tail;
                tail = head;
                head = shuttle;
            }
            return tail;
        }
    }
}
