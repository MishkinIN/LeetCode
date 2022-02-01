using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static partial class Solution
    {
        public static ListNode MergeTwoLists(ListNode l1, ListNode l2)
        {
            ListNode temp = new(-1);
            ListNode head = temp;
            while (l1 != null && l2 != null)
            {
                if (l1.val < l2.val)
                {
                    temp.next = l1;
                    l1 = l1.next;
                }
                else
                {
                    temp.next = l2;
                    l2 = l2.next;
                }
                temp = temp.next;
            }
            temp.next = l1 ?? l2;
            return head.next;

            //if (l1 == null)
            //    return l2;
            //if (l2 == null)
            //    return l1;
            //ListNode head, bough;
            //if (l1.val < l2.val)
            //{
            //    head = l1;
            //    l1 = l1.next;
            //}
            //else
            //{
            //    head = l2;
            //    l2 = l2.next;
            //}
            //bough = head;
            //while (l1 != null & l2 != null)
            //{
            //    if (l1.val < l2.val)
            //    {
            //        bough.next = l1;
            //        bough = l1;
            //        l1 = l1.next;
            //    }
            //    else
            //    {
            //        bough.next = l2;
            //        bough = l2;
            //        l2 = l2.next;
            //    }

            //}
            //bough.next = l1 == null ? l2 : l1;
            //return head;
        }

    }
}
