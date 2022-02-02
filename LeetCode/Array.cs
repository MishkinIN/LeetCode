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
            if (shift>n) {
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
                Buffer.BlockCopy(nums, 0, nums, shift*IntSize, n*IntSize);
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
                if (price< bestPriceToBuy) {
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
                    return (mc.n0, System.Math.Min(mc.n0 + costs[n - 1], mc.n1 + costs[n-2]));
            }
        }
    }
}
