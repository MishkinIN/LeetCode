using System;
using System.Collections.Generic;

namespace LeetCode {

    public static partial class Solution {
        /*
         * 77. Combinations
         * Medium
         * Given two integers n and k, return all possible combinations of k numbers out of the range [1, n].
         * You may return the answer in any order.
         * Constraints:

    1 <= n <= 20
    1 <= k <= n
         
         */
        public static IList<IList<int>> Combine(int n, int k) {
            List<IList<int>> lists = new();
            int[] vs = new int[k];
            Combine(lists, vs, n, k);
            return lists;
        }
        private static void Combine(List<IList<int>> lists, int[] vs, int n, int k) {
            if (k == 1) {
                for (int i = 1; i < n + 1; i++) {
                    vs[0] = i;
                    lists.Add(new List<int>(vs));
                }
            }
            else {
                for (int i = k; i < n + 1; i++) {
                    vs[k - 1] = i;
                    Combine(lists, vs, i - 1, k - 1);
                }
            }
        }
        /*
         * 46. Permutations
         * Medium
         * Given an array nums of distinct integers, return all the possible permutations.
         * You can return the answer in any order.
         * 
         * Constraints:

    1 <= nums.length <= 6
    -10 <= nums[i] <= 10
    All the integers of nums are unique.

         */
        public static IList<IList<int>> Permute(int[] nums) {
            List<IList<int>> lists = new();
            foreach (var list in GetPermutes(nums, nums.Length)) {
                lists.Add(new List<int>(list));
            }
            return lists;
        }
        private static IEnumerable<IEnumerable<int>> GetPermutes(int[] nums, int len) {
            switch (len) {
                case 0:
                case 1:
                    yield return Insert(nums, 0, 0, nums[0]);
                    ;
                    break;
                default:
                    var val = nums[len - 1];
                    foreach (var list in GetPermutes(nums, len - 1)) {
                        for (int i = 0; i < len; i++) {
                            yield return Insert(list, len, i, val);
                        }
                    }
                    break;
            };
        }
        private static IEnumerable<int> Insert(IEnumerable<int> source, int len, int pos, int val) {

            var cursor = source.GetEnumerator();
            int count = 0;
            while (count++ < pos && cursor.MoveNext()) {
                yield return cursor.Current;
            }
            yield return val;
            while (count++ < len && cursor.MoveNext())
                yield return cursor.Current;
        }

        /*
 * 78. Subsets
 * Medium
 * Given an integer array nums of unique elements, return all possible subsets (the power set).
 * The solution set must not contain duplicate subsets. Return the solution in any order.
 * 
 * Constraints:

1 <= nums.length <= 10
-10 <= nums[i] <= 10
All the numbers of nums are unique.

 */
        public static IList<IList<int>> Subsets(int[] nums) {
            List<IList<int>> subsets = new List<IList<int>>();
            int numsLength = nums.Length;
            uint subsetMaxCode = uint.MaxValue >> 32 - numsLength;
            for (uint subsetCode = 0; subsetCode < subsetMaxCode + 1; subsetCode++) {
                var list = new List<int>();
                var code = subsetCode;
                //foreach (var item in nums) {
                //    if ((code & 0x1) == 0x1)
                //        list.Add(item);
                //    code >>= 1;
                //}
                for (int i = 0; i < numsLength; i++) {
                    if ((code & 0x1) == 0x1)
                        list.Add(nums[i]);
                    code >>= 1;
                }
                subsets.Add(list);
            }
            return subsets;
        }
        public static IList<IList<int>> Subsets_I(int[] nums) {
            List<IList<int>> subsets = new List<IList<int>>();
            int numsLength = nums.Length;
            uint subsetMaxCode = uint.MaxValue >> 32 - numsLength;
            for (uint subsetCode = 0; subsetCode < subsetMaxCode + 1; subsetCode++) {
                subsets.Add(new List<int>(GetSubset(nums, subsetCode)));
            }
            return subsets;
        }

        public static IList<IList<int>> Subsets_LC(int[] nums) {
            var result = new List<IList<int>>();
            //use bit index to find sets
            for (int i = 0; i < System.Math.Pow(2, nums.Length); i++) {
                int c = 0;
                int j = i;
                var aSet = new List<int>();
                while (j != 0) {
                    if ((j & 1) == 1) {
                        aSet.Add(nums[c]);
                    }

                    j = j >> 1;
                    c++;
                }

                result.Add(aSet);
            }

            return result;
        }

        private static IEnumerable<int> GetSubset(int[] nums, uint subsetCode) {
            foreach (var item in nums) {
                if ((subsetCode & 0x1) == 0x1)
                    yield return item;
                subsetCode >>= 1;
            }
        }

        private static IEnumerable<int> ArrayEnumerator(int[] nums, int start, int length) {
            for (int i = start; i < start + length; i++) {
                yield return nums[i];
            }
        }
        private static void Swap(int[] nums, int start, int end) {
            var acc = nums[start];
            nums[start] = nums[end];
            nums[end] = acc;
        }

    }
}
