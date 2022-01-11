using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static partial class Solution
    {
        /*
         * You are given two integer arrays nums1 and nums2, sorted in non-decreasing order,
         * and two integers m and n, representing the number of elements in nums1 and nums2 respectively.
         * Merge nums1 and nums2 into a single array sorted in non-decreasing order.
         * The final sorted array should not be returned by the function, 
         * but instead be stored inside the array nums1. 
         * To accommodate this, nums1 has a length of m + n, 
         * where the first m elements denote the elements that should be merged, 
         * and the last n elements are set to 0 and should be ignored. nums2 has a length of n.
         */

        public static int SearchInsert(int[] nums, int target)
        {
            int k = 0, k1 = nums.Length, i;
            do
            {
                i = (k + k1) / 2;
                if (nums[i] == target)
                {
                    return i;
                }
                if (nums[i] < target)
                {
                    k = i + 1;
                }
                else
                {
                    k1 = i;
                }
            } while (k < k1);
            return k;


        }

    }
}
