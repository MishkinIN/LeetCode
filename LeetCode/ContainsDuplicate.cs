using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * Given an integer array nums, 
         * return true if any value appears at least twice in the array, 
         * and return false if every element is distinct.  
         * 
    1 <= nums.length <= 10^5
    -10^9 <= nums[i] <= 10^9

         */
        public static bool ContainsDuplicate_WidthHashSet(int[] nums) {
            HashSet<int> hs = new();
            foreach (var item in nums) {
                if (!hs.Add(item)) {
                    return true;
                }
            }
            return false;
        }
        public static bool ContainsDuplicate(int[] nums) {
            return !NotFindDuplicateAndSort(nums, 0, (uint)nums.Length);


        }
        private static bool NotFindDuplicateAndSort(int[] nums, uint start, uint end) {
            var lenght = end - start;
            int acc;
            if (lenght < 2)
                return true;
            if (lenght == 2) {
                if (nums[start] == nums[end - 1]) {
                    return false;
                }
                else {
                    if (nums[start] > nums[end - 1]) {
                        acc = nums[start];
                        nums[start] = nums[end - 1];
                        nums[end - 1] = acc;
                    }
                    return true;
                }
            }
            var center = (end + start) / 2;
            if (NotFindDuplicateAndSort(nums, start, center) && NotFindDuplicateAndSort(nums, center, end)) {
                uint leftindex = start, rightindex = center;
                Queue<int> queue = new();
                while (leftindex < center) {
                    queue.Enqueue(nums[leftindex]);
                    acc = queue.Peek() - nums[rightindex];
                    if (acc == 0) {
                        return false;
                    }
                    else {
                        if (acc < 0) {
                            nums[leftindex++] = queue.Dequeue();
                        }
                        else {
                            nums[leftindex++] = nums[rightindex++];
                        }
                    }
                }
                while (queue.Count > 0 & rightindex < end) {
                    acc = queue.Peek() - nums[rightindex];
                    if (acc == 0) {
                        return false;
                    }
                    else {
                        if (acc < 0) {
                            nums[leftindex++] = queue.Dequeue();
                        }
                        else {
                            nums[leftindex] = nums[rightindex];
                            leftindex++;
                            rightindex++;
                        }
                    }
                }
                while (queue.Count > 0) {
                    nums[leftindex++] = queue.Dequeue();
                }

                return true;
            }
            else
                return false;
        }
    }
}
