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
            else if (nums.Length == 2) {
                return nums[0] ^ nums[1];
            }
            Array.Sort<int>(nums);
            if (nums[0] == nums[^1]) {
                return 0;
            }

            int a = nums[^1];
            int a_mask = GetMask(a);
            int pattern1 = 0;
            (int st, int l) sec1 = new(0, nums.Length);
            var pair = FindBestPair(nums, sec1, pattern1, a_mask);
            return pair.a ^ pair.b;
        }

        private static (int a, int b) FindBestPair(int[] nums, (int st, int l) sec1, int pattern1, int a_mask) {
            int pattern2;
            (int st, int l) sec2;
            do {
                pattern2 = pattern1;
                pattern1 |= (a_mask ^ (a_mask >> 1));
                a_mask >>= 1;
                sec2 = FindInterval(nums, sec1, pattern2, a_mask);
                sec1 = FindInterval(nums, sec1, pattern1, a_mask);
                if (sec1.l < sec2.l) {
                    var s = sec2;
                    sec2 = sec1;
                    sec1 = s;
                    var p = pattern2;
                    pattern2 = pattern1;
                    pattern1 = p;
                }
            } while (sec2.l == 0);
            var xor = FindBestPair(nums, sec1, pattern1, sec2, pattern2, a_mask);
            return xor;
        }

        private static (int a, int b) FindBestPair(int[] nums, (int st, int l) sec1, int pattern1, (int st, int l) sec2, int pattern2, int mask) {
            if (sec1.l == 1 & sec2.l == 1) {
                return (nums[sec1.st], nums[sec2.st]);
            }
            var pattern11 = pattern1 | (mask ^ (mask >> 1));
            var pattern21 = pattern2 | (mask ^ (mask >> 1));
            mask >>= 1;
            var sec11 = FindInterval(nums, sec1, pattern11, mask);
            var sec20 = FindInterval(nums, sec2, pattern2, mask);
            var sec10 = FindInterval(nums, sec1, pattern1, mask);
            var sec21 = FindInterval(nums, sec2, pattern21, mask);

            if (sec11.l > 0 & sec20.l > 0) {
                var pair1 = FindBestPair(nums, sec11, pattern11, sec20, pattern2, mask);
                if (sec10.l > 0 & sec21.l > 0) {
                    var pair2 = FindBestPair(nums, sec10, pattern1, sec21, pattern21, mask);
                    if ((pair1.a ^ pair1.b) < (pair2.a ^ pair2.b)) {
                        return pair2;
                    }
                    else
                        return pair1;
                }
                else {
                    return pair1;
                }
            }
            if (sec10.l > 0 & sec21.l > 0) {
                var pair2 = FindBestPair(nums, sec10, pattern1, sec21, pattern21, mask);
                return pair2;
            }
            if (sec11.l > 0 & sec21.l > 0) {
                var pair1 = FindBestPair(nums, sec11, pattern11, sec21, pattern21, mask);
                if (sec10.l > 0 & sec20.l > 0) {
                    var pair2 = FindBestPair(nums, sec10, pattern1, sec20, pattern2, mask);
                    if ((pair1.a ^ pair1.b) < (pair2.a ^ pair2.b)) {
                        return pair2;
                    }
                    else
                        return pair1;
                }
                else {
                    return pair1;
                }
            }
            if (sec10.l > 0 & sec20.l > 0) {
                var pair2 = FindBestPair(nums, sec10, pattern1, sec20, pattern2, mask);
                return pair2;
            }
            return (0, 0);
        }
        //private static int GetBestXOR(int[] nums, int fi_pattern, int si_pattern, int step_mask, int a_mask) {
        //    var fi = getInterval(nums, fi_pattern | (step_mask ^ (step_mask >> 1)), step_mask);
        //    var si = getInterval(nums, si_pattern, step_mask);
        //    if (IsEmpty(si)) {
        //        if (IsEmpty(fi)) {
        //            return 0;
        //        }
        //        var xor1 = GetBestXOR(nums, fi_pattern | (step_mask ^ (step_mask >> 1)), fi_pattern, step_mask >> 1, a_mask);
        //        return xor1;

        //    }
        //    if (IsEmpty(fi)) {
        //        if (IsEmpty(si)) {
        //            return 0;
        //        }
        //        var xor1 = GetBestXOR(nums, si_pattern | (step_mask ^ (step_mask >> 1)), si_pattern, step_mask >> 1, a_mask);
        //        return xor1;
        //    }
        //    if (fi.max - fi.min == 1 & si.max - si.min == 1) {
        //        return nums[fi.min] ^ nums[si.min];
        //    }
        //    {
        //        if (fi.max - fi.min == 1) {
        //            var a = nums[fi.min];
        //            var b = GetBestPair(nums, a, si_pattern, step_mask);
        //            return a ^ b;
        //        }
        //        if (si.max - si.min == 1) {
        //            var a = nums[si.min];
        //            var b = GetBestPair(nums, a, fi_pattern, step_mask);
        //            return a ^ b;
        //        }
        //        var xor1 = GetBestXOR(nums, fi_pattern, si_pattern, step_mask >> 1, a_mask);
        //        var xor2 = GetBestXOR(nums, fi_pattern, si_pattern | (step_mask ^ (step_mask >> 1)), step_mask >> 1, a_mask);
        //        var xor3 = GetBestXOR(nums, fi_pattern | (step_mask ^ (step_mask >> 1)), si_pattern, step_mask >> 1, a_mask);
        //        var xor4 = GetBestXOR(nums, fi_pattern | (step_mask ^ (step_mask >> 1)), si_pattern | (step_mask ^ (step_mask >> 1)), step_mask >> 1, a_mask);
        //        return Math.Max(Math.Max(xor1, xor2), Math.Max(xor3, xor4));
        //    }
        //}
        //private static int GetBestPair(int[] nums, int a, int pattern, int step_mask) {
        //    if ((a & (step_mask ^ (step_mask >> 1))) > 0) {
        //        var fi = getInterval(nums, pattern, step_mask >> 1);
        //        if (IsEmpty(fi)) {
        //            pattern |= (step_mask ^ step_mask >> 1);
        //        }
        //        else if (fi.max - fi.min == 1) {
        //            return nums[fi.min];
        //        }
        //        return GetBestPair(nums, a, pattern, step_mask >> 1);
        //    }
        //    else {
        //        var fi = getInterval(nums, pattern | (step_mask ^ step_mask >> 1), step_mask >> 1);
        //        if (IsEmpty(fi)) {
        //            //pattern = pattern | (step_mask ^ step_mask >> 1);
        //        }
        //        else if (fi.max - fi.min == 1) {
        //            return nums[fi.min];
        //        }
        //        else {
        //            pattern |= (step_mask ^ step_mask >> 1);
        //        }
        //        return GetBestPair(nums, a, pattern, step_mask >> 1);

        //    }
        //}
        //private static (int min, int max) getInterval(int[] nums, int pattern, int mask) {
        //    int min = Array.BinarySearch(nums, pattern);
        //    min = min < 0 ? ~min : min;
        //    int max = Array.BinarySearch(nums, pattern + mask);
        //    max = max < 0 ? ~max : max + 1;
        //    return (min, max);
        //}
        private static (int st, int l) FindInterval(int[] nums, (int st, int l) section, int pattern, int mask) {
            int min = Array.BinarySearch(nums, section.st, section.l, pattern);
            if (mask==0) {
                if (min < 0) {
                    return (~min, 0);
                }
                else
                    return (min, 1);
            }
            min = min < 0 ? ~min : min;
            int max = Array.BinarySearch(nums, pattern + mask);
            max = max < 0 ? ~max : max + 1;
            int l = max - min;
            return (min, l);
        }
        //private static bool IsEmpty((int min, int max) interval) {
        //    return interval.max <= interval.min;
        //}

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
