using System;
using System.Collections.Generic;


namespace LeetCode {

    public static partial class Solution {
        /*
        Given an array, rotate the array to the right by k steps, where k is non-negative.
        Constraints:

    1 <= nums.length <= 10^5
    -2^31 <= nums[i] <= 2^31 - 1
    0 <= k <= 10^5

*/
        const int IntSize = 4;
        public static void Rotate(int[] nums, int k) {
            if (nums.Length < 2) {
                return;
            }
            int nLength = nums.Length;
            int shift = k % nLength;
            int n = nums.Length - shift;
            if (shift > n) {
                int[] shiftNums = new int[n];
                //Array.Copy(nums, 0, shiftNums, 0, n);
                Buffer.BlockCopy(nums, 0, shiftNums, 0, n * IntSize);
                //Array.Copy(nums, n, nums, 0, shift);
                Buffer.BlockCopy(nums, n * IntSize, nums, 0, shift * IntSize);
                //shiftNums.CopyTo(nums, shift);
                Buffer.BlockCopy(shiftNums, 0, nums, shift * IntSize, n * IntSize);
            }
            else {
                int[] shiftNums = new int[shift];
                //Array.Copy(nums, n, shiftNums, 0, shift);
                Buffer.BlockCopy(nums, n * IntSize, shiftNums, 0, shift * IntSize);
                //Array.Copy(nums, 0, nums, shift, n);
                Buffer.BlockCopy(nums, 0, nums, shift * IntSize, n * IntSize);
                //shiftNums.CopyTo(nums,0);
                Buffer.BlockCopy(shiftNums, 0, nums, 0, shift * IntSize);
            }
        }
        public static void Rotate_lc(int[] nums, int k) {
            var length = nums.Length;
            k %= length;
            var arr = new int[length];
            for (int j = 0; j < length; j++) {
                arr[(j + k) % length] = nums[j];
            }
            Array.Copy(arr, 0, nums, 0, length);

        }
        public static void Rotate_I(int[] nums, int k) {
            if (nums.Length < 2) {
                return;
            }
            int nLength = nums.Length;
            int i = nLength - 1, _j = i, shift = k % nLength, j = _j - shift;
            if (shift == 0)
                return;
            ;
            int acc = nums[_j];
            //int _lcm = lcm(shift, nLength);
            int count = -1;
            while (++count < nLength) {
                if (j < 0) {
                    j += nLength;
                    if (j == i) {
                        nums[_j] = acc;
                        i--;
                        _j = i;
                        acc = nums[_j];
                        j = _j - shift;
                        continue;
                    }
                }
                nums[_j] = nums[j];
                _j = j;
                j -= shift;

            };
        }
        /*
         * 704. Binary Search
         * Easy
         * Given an array of integers nums which is sorted in ascending order, and an integer target, 
         * write a function to search target in nums. If target exists, then return its index. Otherwise, return -1.
         * You must write an algorithm with O(log n) runtime complexity.
         * Constraints:

    1 <= nums.length <= 10^4
    -10^4 < nums[i], target < 10^4
    All the integers in nums are unique.
    nums is sorted in ascending order.

         */
        public static int Search(int[] nums, int target) {
            int i = Array.BinarySearch(nums, target);
            return i < 0 ? -1 : i;
        }
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

        public static int SearchInsert(int[] nums, int target) {
            int k = 0, k1 = nums.Length, i;
            do {
                i = (k + k1) / 2;
                if (nums[i] == target) {
                    return i;
                }
                if (nums[i] < target) {
                    k = i + 1;
                }
                else {
                    k1 = i;
                }
            } while (k < k1);
            return k;


        }
        /*
 * Given an integer array nums, 
 * return true if any value appears at least twice in the array, 
 * and return false if every element is distinct.  
 * 
1 <= nums.length <= 10^5
-10^9 <= nums[i] <= 10^9

 */
        public static bool ContainsDuplicate_WidthHashSet(int[] nums) {
            SortedSet<int> hs = new();
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

        /*
         * 53. Maximum Subarray
         * Easy
         * Given an integer array nums, find the contiguous subarray (containing at least one number)
         * which has the largest sum and return its sum.
         * A subarray is a contiguous part of an array.
         * 
         * Constraints:

    1 <= nums.length <= 10^5
    -10^4 <= nums[i] <= 10^4

         */
        public static int MaxSubArray(int[] nums) {
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            int lSum = 0, lMax = int.MinValue;
            foreach (int val in nums) {
                lSum = lSum < 0 ? val : lSum + val;
                lMax = lMax > lSum ? lMax : lSum;
            }
            return lMax;
        }
        /*
         * 121. Best Time to Buy and Sell Stock
         * Easy
         * You are given an array prices where prices[i] is the price of a given stock on the ith day.
         * You want to maximize your profit by choosing a single day to buy one stock 
         * and choosing a different day in the future to sell that stock.
         * Return the maximum profit you can achieve from this transaction.
         * If you cannot achieve any profit, return 0.
         * 
         * Constraints:

    1 <= prices.length <= 10^5
    0 <= prices[i] <= 10^4

         */
        public static int MaxProfit(int[] prices) {
            if (prices.Length < 2) {
                return 0;
            }
            else if (prices.Length == 2) {
                return prices[1] - prices[0] > 0 ? prices[1] - prices[0] : 0;
            }
            int bestPriceToBuy = int.MaxValue;
            int maxProfit = 0;
            foreach (var price in prices) {
                if (price < bestPriceToBuy) {
                    bestPriceToBuy = price;
                }
                else if (price - bestPriceToBuy > maxProfit) {
                    maxProfit = price - bestPriceToBuy;
                }
            }
            return maxProfit;
        }
        /*
         * 746. Min Cost Climbing Stairs
         * Easy
         * You are given an integer array cost where cost[i] is the cost of ith step on a staircase.
         * Once you pay the cost, you can either climb one or two steps.
         * You can either start from the step with index 0, or the step with index 1.
         * Return the minimum cost to reach the top of the floor.
         * 
         * Constraints:

    2 <= cost.length <= 1000
    0 <= cost[i] <= 999

         */
        public static int MinCostClimbingStairs(int[] costs) {
            var mc = GetMinCostClimbing(costs, costs.Length);
            return mc.n0;
        }
        private static (int n1, int n0) GetMinCostClimbing(int[] costs, int n) {
            switch (n) {
                case 1:
                    return (0, 0);
                case 2:
                    return (0, System.Math.Min(costs[n - 1], costs[n - 2]));
                default:
                    var mc = GetMinCostClimbing(costs, n - 1);
                    return (mc.n0, System.Math.Min(mc.n0 + costs[n - 1], mc.n1 + costs[n - 2]));
            }
        }
        /*
         * 198. House Robber
         * Medium
         * You are a professional robber planning to rob houses along a street. 
         * Each house has a certain amount of money stashed, 
         * the only constraint stopping you from robbing each of them is 
         * that adjacent houses have security systems connected and 
         * it will automatically contact the police if two adjacent houses were broken into on the same night.
         * Given an integer array nums representing the amount of money of each house, 
         * return the maximum amount of money you can rob tonight without alerting the police.
         * 
         * Constraints:

    1 <= nums.length <= 100
    0 <= nums[i] <= 400

         */
        public static int Rob(int[] nums) {
            var rob = GetRob(nums, nums.Length - 1);
            return rob.r0;
        }
        private static (int r1, int r0) GetRob(int[] nums, int i) {
            switch (i) {
                case 0:
                    return (0, nums[0]);
                case 1:
                    return (nums[0], System.Math.Max(nums[0], nums[1]));
                default:
                    break;
            }
            var getRob = GetRob(nums, i - 1);
            return (getRob.r0, System.Math.Max(getRob.r0, getRob.r1 + nums[i]));
        }

        /*
         * 213. House Robber II
         * Medium
         * You are a professional robber planning to rob houses along a street. 
         * Each house has a certain amount of money stashed.
         * All houses at this place are arranged in a circle.
         * That means the first house is the neighbor of the last one.
         * Meanwhile, adjacent houses have a security system connected,
         * and it will automatically contact the police if two adjacent houses were broken into on the same night.
         * Given an integer array nums representing the amount of money of each house,
         * return the maximum amount of money you can rob tonight without alerting the police.
         * 
         * Constraints:

    1 <= nums.length <= 100
    0 <= nums[i] <= 1000

         */
        public static int Rob_II(int[] nums) {
            var rob1 = GetRob_II(nums, nums.Length - 1);
            var rob2 = GetRob_II(nums, nums.Length - 1, start: 1);
            return System.Math.Max(rob1.r0, rob2.r0);
        }
        private static (int r1, int r0) GetRob_II(int[] nums, int i, int start = 0) {
            switch (i - start) {
                case 0:
                    return (0, nums[start]);
                case 1:
                    return (nums[start], System.Math.Max(nums[start], nums[start + 1]));
                default:
                    break;
            }
            var getRob = GetRob_II(nums, i - 1, start);
            return (getRob.r0, System.Math.Max(getRob.r0, getRob.r1 + nums[i]));
        }

        /*
         * 454. 4Sum II
         * Medium
         * Given four integer arrays nums1, nums2, nums3, and nums4 all of length n,
         * return the number of tuples (i, j, k, l) such that:
         * 0 <= i, j, k, l < n
         * nums1[i] + nums2[j] + nums3[k] + nums4[l] == 0
         * 
         * Constraints:

    n == nums1.length
    n == nums2.length
    n == nums3.length
    n == nums4.length
    1 <= n <= 200
    -228 <= nums1[i], nums2[i], nums3[i], nums4[i] <= 228

         */
        public static int FourSumCount(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
            Dictionary<int, int> dic1 = new();
            foreach (var n1 in nums1) {
                foreach (var n2 in nums2) {
                    int sum = n1 + n2;
                    dic1.TryGetValue(sum, out int c);
                    dic1[sum] = c + 1;
                }
            }
            Dictionary<int, int> dic2 = new();
            foreach (var n in nums3) {
                foreach (var d in dic1.Keys) {
                    int sum = n + d;
                    dic2.TryGetValue(sum, out int c);
                    dic2[sum] = c + dic1[d];
                }
            }
            int count = 0;
            foreach (var n in nums4) {
                if (dic2.ContainsKey(-1 * n)) {
                    count += dic2[-1 * n];
                }
            }
            return count;
        }
        public static int FourSumCount_II(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
            int count = 0;
            foreach (var n1 in nums1) {
                foreach (var n2 in nums2) {
                    foreach (var n3 in nums3) {
                        foreach (var n4 in nums4) {
                            if (n1 + n2 + n3 + n4 == 0)
                                count++;
                        }
                    }
                }
            }
            return count;
        }
        public static int FourSumCount_I(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
            Dictionary<int, int> dic1 = new();
            foreach (var n1 in nums1) {
                foreach (var n2 in nums2) {
                    if (dic1.ContainsKey(n1 + n2)) {
                        dic1[n1 + n2]++;
                    }
                    else {
                        dic1[n1 + n2] = 1;
                    }
                }
            }
            Dictionary<int, int> dic2 = new();
            foreach (var n3 in nums3) {
                foreach (var d1 in dic1.Keys) {
                    if (dic2.ContainsKey(n3 + d1)) {
                        dic2[n3 + d1] += dic1[d1];
                    }
                    else
                        dic2[n3 + d1] = dic1[d1];
                }
            }
            Dictionary<int, int> dic3 = new();
            foreach (var n4 in nums4) {
                foreach (var d2 in dic2.Keys) {
                    if (dic3.ContainsKey(n4 + d2)) {
                        dic3[n4 + d2] += dic2[d2];
                    }
                    else
                        dic3[n4 + d2] = dic2[d2];
                }
            }
            if (dic3.ContainsKey(0)) {
                return dic3[0];
            }
            else
                return 0;
        }
        public static int FourSumCount_Slow(int[] nums1, int[] nums2, int[] nums3, int[] nums4) {
            Array.Sort(nums1);
            Array.Sort(nums2);
            Array.Sort(nums3);
            Array.Sort(nums4);
            var vs1 = GetAllSums(nums1, nums2);
            var vs2 = GetAllSums(nums3, nums4);
            int i = 0, j = vs2.Length - 1, count = 0;
            while (i < vs1.Length && j >= 0) {
                int sum = vs1[i] + vs2[j];
                if (sum == 0) {
                    int count_i = 0;
                    int count_j = 0;
                    int vs_i = vs1[i];
                    int vs_j = vs2[j];
                    while (vs1[i] == vs_i) {
                        count_i++;
                        if (++i == vs1.Length)
                            break;
                    }
                    while (vs2[j] == vs_j) {
                        count_j++;
                        if (--j < 0)
                            break;
                    }
                    count += count_i * count_j;
                }
                else if (sum > 0) {
                    j--;
                }
                else {
                    i++;
                }
            }
            return count;
        }
        internal static int[] GetAllSums(int[] nums1, int[] nums2) {
            int n = nums1.Length;
            int m = nums2.Length;
            int nm = n * m;
            int[] vs = new int[nm];
            int index = (n - 1) * m;
            int n1 = nums1[^1];
            foreach (var item in nums2) {
                vs[index++] = n1 + item;
            }
            for (int i = n - 2; i >= 0; i--) {
                n1 = nums1[i];
                index = i * m;
                int cursor = index + m;
                foreach (var item in nums2) {
                    //vs[index++] += n1 + item;
                    int sum = item + n1;
                    while (cursor < nm && sum > vs[cursor]) {
                        vs[index++] = vs[cursor++];
                    }
                    vs[index++] = sum;
                }
            }
            return vs;
        }
        /*
         * 740. Delete and Earn
         * Medium
         * You are given an integer array nums. You want to maximize the number of points you get
         * by performing the following operation any number of times:
         * Pick any nums[i] and delete it to earn nums[i] points. 
         * Afterwards, you must delete every element equal to nums[i] - 1 
         * and every element equal to nums[i] + 1.
         * Return the maximum number of points you can earn 
         * by applying the above operation some number of times.
         * 
         * Constraints:

    1 <= nums.length <= 2 * 10^4
    1 <= nums[i] <= 10^4

         */
        public static int DeleteAndEarn(int[] nums) {
            SortedDictionary<int, int> dic = new();
            foreach (var n in nums) {
                dic.TryGetValue(n, out int c);
                dic[n] = c + n;
            }

            int lastKey, val_1, val_2, val;
            var en = dic.GetEnumerator();
            en.MoveNext();
            var kvp = en.Current;
            if (dic.Count == 1) {
                return kvp.Value;
            }
            lastKey = kvp.Key;
            val_2 = kvp.Value;
            en.MoveNext();
            kvp = en.Current;
            val = val_1 = System.Math.Max(val_2
                , kvp.Key - lastKey > 1 ? val_2 + kvp.Value : kvp.Value);
            lastKey = kvp.Key;
            int i = 2;
            while (en.MoveNext()) {
                kvp = en.Current;
                val = System.Math.Max(val_1
                    , kvp.Key - lastKey > 1 ? val_1 + kvp.Value : val_2 + kvp.Value);
                lastKey = kvp.Key;
                i++;
                val_2 = val_1;
                val_1 = val;
            }
            return val;
        }
    }
}
