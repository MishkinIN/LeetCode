using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * 421. Maximum XOR of Two Numbers in an Array
         * Medium
         * Given an integer array nums, return the maximum result of nums[i] XOR nums[j],
         * where 0 <= i <= j < n.
         * Constraints:

    1 <= nums.length <= 2 * 10^5
    0 <= nums[i] <= 2^31 - 1

         */
        public static int FindMaximumXOR(int[] nums) {
            if (nums.Length < 2) {
                return 0;
            }
            Array.Sort<int>(nums);
            if (nums[0] == nums[^1]) {
                return 0;
            }

            int a = nums[^1];
            int a_mask = GetMask(a);
            int pattern = a_mask ^ a_mask >> 1;
            return GetBestXOR(nums, pattern, 0, a_mask >> 1, a_mask);
        }

        private static int GetBestXOR(int[] nums, int fi_pattern, int si_pattern, int step_mask, int a_mask) {
            var fi = getInterval(nums, fi_pattern, step_mask);
            var si = getInterval(nums, si_pattern, step_mask);
            if (IsEmpty(si)) {
                if (IsEmpty(fi)) {
                    return 0;
                }
                var xor1 = GetBestXOR(nums, fi_pattern | (step_mask ^ (step_mask >> 1)), fi_pattern, step_mask >> 1, a_mask);
                return xor1;

            }
            if (IsEmpty(fi)) {
                if (IsEmpty(si)) {
                    return 0;
                }
                var xor1 = GetBestXOR(nums, si_pattern | (step_mask ^ (step_mask >> 1)), si_pattern, step_mask >> 1, a_mask);
                return xor1;
            }
            if (fi.max - fi.min == 1 & si.max - si.min == 1) {
                return nums[fi.min] ^ nums[si.min];
            }
            {
                if (fi.max - fi.min == 1) {
                    var a = nums[fi.min];
                    var b = GetBestPair(nums, a, si_pattern,step_mask);
                    return a ^ b;
                }
                if (si.max - si.min == 1) {
                    var a = nums[si.min];
                    var b = GetBestPair(nums, a, fi_pattern, step_mask);
                    return a ^ b;
                }
                var xor1 = GetBestXOR(nums, fi_pattern , si_pattern, step_mask >> 1, a_mask);
                var xor2 = GetBestXOR(nums, fi_pattern, si_pattern | (step_mask ^ (step_mask >> 1)), step_mask >> 1, a_mask);
                var xor3 = GetBestXOR(nums, fi_pattern | (step_mask ^ (step_mask >> 1)), si_pattern, step_mask >> 1, a_mask);
                var xor4 = GetBestXOR(nums, fi_pattern | (step_mask ^ (step_mask >> 1)), si_pattern | (step_mask ^ (step_mask >> 1)), step_mask >> 1, a_mask);
                return Math.Max(Math.Max(xor1, xor2), Math.Max(xor3, xor4));
            }
        }
        private static int GetBestPair(int[] nums, int a, int pattern, int step_mask) {
            if ((a & (step_mask ^ (step_mask >> 1))) > 0) {
                var fi = getInterval(nums, pattern, step_mask>>1);
                if (IsEmpty(fi)) {
                    pattern |= (step_mask ^ step_mask >> 1);
                }
                else if (fi.max - fi.min == 1) {
                    return nums[fi.min];
                }
                return GetBestPair(nums, a, pattern, step_mask >> 1);
            }
            else {
                var fi = getInterval(nums, pattern | (step_mask ^ step_mask >> 1), step_mask >> 1);
                if (IsEmpty(fi)) {
                    //pattern = pattern | (step_mask ^ step_mask >> 1);
                }
                else if (fi.max - fi.min == 1) {
                    return nums[fi.min];
                }
                else {
                    pattern |= (step_mask ^ step_mask >> 1);
                }
                return GetBestPair(nums, a, pattern, step_mask >> 1);

            }
        }
        private static (int min, int max) getInterval(int[] nums, int pattern, int mask) {
            int min = Array.BinarySearch(nums, pattern);
            min = min < 0 ? ~min : min;
            int max = Array.BinarySearch(nums, pattern + mask);
            max = max < 0 ? ~max : max+1;
            return (min, max);
        }
        private static bool IsEmpty((int min, int max) interval) {
            return interval.max <= interval.min;
        }

        private static int GetMask(int x) {
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            return x;
        }
        //public class XORComparer : IComparer<int> {
        //    int bestComplement;
        //    int mask;
        //    public XORComparer(int val) {
        //        mask = GetMask(val);
        //        bestComplement = ~val & mask;
        //    }
        //    public int Compare(int x, int y) {
        //        return y - mask & ~x;
        //    }
        //}
    }
}
