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
        public ListNode MiddleNode(ListNode head) {
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
        public ListNode RemoveNthFromEnd(ListNode head, int n) {
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
    }

}
