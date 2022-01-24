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
         * Given two integer arrays nums1 and nums2, return an array of their intersection.
         * Each element in the result must appear as many times as it shows in both arrays
         * and you may return the result in any order.
         * 
         * Constraints:

    1 <= nums1.length, nums2.length <= 1000
    0 <= nums1[i], nums2[i] <= 1000
        Follow up:

    What if the given array is already sorted? How would you optimize your algorithm?
    What if nums1's size is small compared to nums2's size? Which algorithm is better?
    What if elements of nums2 are stored on disk, and the memory is limited such that you cannot load all elements into the memory at once?

         */
        public static int[] Intersect(int[] nums1, int[] nums2) {
            Array.Sort(nums1);
            List<int> intersec = new();
            int[] marks = new int[nums1.Length];
            foreach (var val in nums2) {
                foreach (var k in SearceAll(nums1, val)) {
                    if (marks[k]==0) {
                        intersec.Add(nums1[k]);
                        marks[k] = 1;
                        break;
                    }
                }
            }
            return intersec.ToArray();
        }
        private static IEnumerable<int> SearceAll(int[] keys, int value) {
            int point = Array.BinarySearch<int>(keys, value);
            if (point > -1) {
                for (int k = point; k < keys.Length && keys[k] == value; k++) {
                    yield return k;
                }
                for (int k = point - 1; k >= 0 && keys[k] == value; k--) {
                    yield return k;
                }
            }
        }
    }
}
