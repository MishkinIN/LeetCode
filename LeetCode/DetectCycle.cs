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
    }
}
