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
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
        public static ListNode Create(int[] vals)
        {
            if (vals == null || vals.Length == 0)
                return null;
            ListNode l1 = null;
            for (int i = vals.Length - 1; i >= 0; i--)
            {
                l1 = new ListNode(vals[i], l1);
            }
            return l1;
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
    }

}
