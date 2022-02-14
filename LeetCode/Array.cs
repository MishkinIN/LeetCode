using System;
using System.Collections.Generic;
using System.Linq;


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
 * 74. Search a 2D Matrix
 * Medium
 * Write an efficient algorithm that searches for a value in an m x n matrix.
 * This matrix has the following properties:
 * Integers in each row are sorted from left to right.
 * The first integer of each row is greater than the last integer of the previous row.
Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 100
-10^4 <= matrix[i][j], target <= 10^4


 */
        public static bool SearchMatrix(int[][] matrix, int target) {
            if (target < matrix[0][0] || target > matrix[^1][^1]) {
                return false;
            }
            int[] targetRow = GetTargetRow(matrix, target);

            return Array.BinarySearch(targetRow, target) >= 0;
        }
        private static int[] GetTargetRow(int[][] matrix, int target) {
            int minInd = 0;
            int maxInd = matrix.Length - 1;
            int[] row = matrix[0];
            while (minInd < maxInd) {
                int center = (maxInd + minInd) / 2;
                row = matrix[center];
                if (target < row[0]) {
                    maxInd = center;
                }
                else {
                    if (target <= row[^1]) {
                        return row;
                    }
                    else {
                        minInd = center + 1;
                        row = matrix[minInd];
                    };
                }
            }
            return row;
        }
        public static bool SearchMatrix_I(int[][] matrix, int target) {
            SortedSet<int> set = new();
            foreach (var item in matrix) {
                set.UnionWith(item);
            }
            return set.Contains(target);
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
         * 918. Maximum Sum Circular Subarray
         * Medium
         * Given a circular integer array nums of length n, return the maximum possible sum of a non-empty subarray of nums.
         * A circular array means the end of the array connects to the beginning of the array. 
         * Formally, the next element of nums[i] is nums[(i + 1) % n] and the previous element of nums[i] is nums[(i - 1 + n) % n].
         * A subarray may only include each element of the fixed buffer nums at most once.
         * Formally, for a subarray nums[i], nums[i + 1], ..., nums[j], there does not exist i <= k1, k2 <= j with k1 % n == k2 % n.
         * 
         * Constraints:

    n == nums.length
    1 <= n <= 3 * 10^4
    -3 * 10^4 <= nums[i] <= 3 * 10^4

         */
        public static int MaxSubarraySumCircular(int[] nums) {
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            int lSum = nums[0], minSum = 0, lMin = 0, lMax = nums[0], k = 0;
            for (int i = 1; i < 2 * n & i % n != k; i++) {
                int val = nums[i % n];
                lMin = lMin > 0 ? val : lMin + val;
                if (minSum > lMin) {
                    minSum = lMin;
                    k = i;
                    lSum = val;
                }
                else {
                    lSum = lSum < 0 ? val : lSum + val;
                }
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
         * 122. Best Time to Buy and Sell Stock II
         * Medium
         * You are given an integer array prices where prices[i] is the price of a given stock on the ith day.
         * On each day, you may decide to buy and/or sell the stock. 
         * You can only hold at most one share of the stock at any time. 
         * However, you can buy it then immediately sell it on the same day.
         * Find and return the maximum profit you can achieve.
         * 
         * Constraints:

    1 <= prices.length <= 3 * 10^4
    0 <= prices[i] <= 10^4

         */
        public static int MaxProfit_II(int[] prices) {
            var profit = prices
                .Aggregate((last: int.MaxValue, profit: 0)
                    , (acc, val) => (val, val > acc.last ? acc.profit + val - acc.last : acc.profit)
                    , acc => acc.profit);
            return profit;
        }
        /*
         * 309. Best Time to Buy and Sell Stock with Cooldown
         * Medium
         * You are given an array prices where prices[i] is the price of a given stock on the ith day.
         * Find the maximum profit you can achieve. 
         * You may complete as many transactions as you like 
         * (i.e., buy one and sell one share of the stock multiple times) with the following restrictions:
         * After you sell your stock, you cannot buy stock on the next day (i.e., cooldown one day).
         * Note: You may not engage in multiple transactions simultaneously 
         * (i.e., you must sell the stock before you buy again).
         * 
         * Constraints:

    1 <= prices.length <= 5000
    0 <= prices[i] <= 1000

         */
        public static int MaxProfit_III_LC(int[] prices) {
            int n = prices.Length;
            if (n < 2) {
                return 0;
            }
            int[] dp = new int[n];
            dp[1] = System.Math.Max(0, prices[1] - prices[0]);
            //previous cost, it maybe negative, the more smaller the more profit it obtained.
            // first, the previous cost is the lower price.
            int prevCost = System.Math.Min(prices[0], prices[1]);
            for (int i = 2; i < n; ++i) {
                // if we sell it yestoday, the profit is dp[i - 1], if we sell it today, then we need to remove the previous cost.
                // so we select the larger profit between yestoday and today's sale.
                dp[i] = System.Math.Max(dp[i - 1], prices[i] - prevCost);
                // update previous cost, if today's cost is the today's price remove the day before yestoday's profit,
                // we use the lower cost between today's cost and previous cost.
                prevCost = System.Math.Min(prevCost, prices[i] - dp[i - 2]);
            }
            return dp[n - 1];
        }
        public static int MaxProfit_III_Recurent(int[] prices) {
            return MaxProfit_III_Reccurent(prices, prices.Length - 1);
        }
        private static int MaxProfit_III_Reccurent(int[] prices, int day) {
            switch (day) {
                case -1:
                case 0:
                    return 0;
                case 1:
                    return prices[1] > prices[0] ? prices[1] - prices[0] : 0;
                default:
                    break;
            }
            int profit0 = MaxProfit_III_Reccurent(prices, day - 3) - prices[day - 1] + prices[day];
            int profit1 = MaxProfit_III_Reccurent(prices, day - 1);
            return System.Math.Max(profit0, profit1);
        }
        private static void TradingSession(Broker br1, Broker br2, ref int pr2, ref int pr1, int pr) {
            if (!br1.canBuy) {
                br1.canBuy = true;
                br1.buyPrice = pr;
            }
            else if (pr1 > pr) {
                if (br1.buyPrice < pr1) {
                    br1.profit = br1.profit + pr1 - br1.buyPrice;
                    br1.buyPrice = int.MaxValue;
                    br1.canBuy = false;
                }
                else if (br1.buyPrice > pr)
                    br1.buyPrice = pr;
                br1.canBuy = false;
            }

            if (!br2.canBuy) {
                br2.canBuy = true;
            }
            else if (br2.buyPrice > pr2)
                br2.buyPrice = pr2;
            else if (pr2 > pr) {
                if (br2.buyPrice < pr2) {
                    br2.profit = br2.profit + pr2 - br2.buyPrice;
                    br2.buyPrice = int.MaxValue;
                    br2.canBuy = false;
                }

            }
            pr2 = pr1;
            pr1 = pr;
        }
        private record Broker() {
            public int profit { get; set; }
            public int buyPrice { get; set; }
            public bool canBuy { get; set; }
        }
        public static int MaxProfit_III_v1(int[] prices) {
            Broker_v1 br1 = new(0, int.MaxValue, true), br2 = new(0, int.MaxValue, true);
            int pr2 = int.MaxValue, pr1 = int.MaxValue;
            TradingSession_v1(ref br1, ref br2, ref pr2, ref pr1, prices[0]);
            foreach (var pr in prices) {
                TradingSession_v1(ref br1, ref br2, ref pr2, ref pr1, pr);
            }
            TradingSession_v1(ref br1, ref br2, ref pr2, ref pr1, pr1);
            TradingSession_v1(ref br1, ref br2, ref pr2, ref pr1, 0);

            return System.Math.Max(br1.profit, br2.profit);
        }
        private static void TradingSession_v1(ref Broker_v1 br1, ref Broker_v1 br2, ref int pr2, ref int pr1, int pr) {
            if (!br1.canBuy) {
                br1 = br1 with { canBuy = true, buyPrice = pr };
            }
            else if (pr1 > pr) {
                if (br1.buyPrice < pr1) {
                    br1 = new(br1.profit + pr1 - br1.buyPrice, int.MaxValue, false);
                }
                else if (br1.buyPrice > pr)
                    br1 = br1 with { buyPrice = pr, canBuy = false };
            }

            if (!br2.canBuy) {
                br2 = br2 with { canBuy = true };
            }
            else if (br2.buyPrice > pr2)
                br2 = br2 with { buyPrice = pr2 };
            else if (pr2 > pr) {
                if (br2.buyPrice < pr2) {
                    br2 = new(br2.profit + pr2 - br2.buyPrice, int.MaxValue, false);
                }

            }
            pr2 = pr1;
            pr1 = pr;
        }
        private record Broker_v1(int profit, int buyPrice, bool canBuy) {

        }
        /*
         * 714. Best Time to Buy and Sell Stock with Transaction Fee
         * Medium
         * You are given an array prices where prices[i] is the price of a given stock on the ith day,
         * and an integer fee representing a transaction fee.
         * Find the maximum profit you can achieve. 
         * You may complete as many transactions as you like, 
         * but you need to pay the transaction fee for each transaction.
         * Note: You may not engage in multiple transactions simultaneously 
         * (i.e., you must sell the stock before you buy again).
         * 
         * Constraints:

    1 <= prices.length <= 5 * 10^4
    1 <= prices[i] < 5 * 10^4
    0 <= fee < 5 * 10^4

        */
        public static int MaxProfit_IV(int[] prices, int fee) {
            if (prices.Length < 2) {
                return 0;
            }
            else if (prices.Length == 2) {
                return prices[1] - prices[0] - fee > 0 ? prices[1] - prices[0] : 0;
            }
            int maxProfit = 0, pr1 = prices[0], pr2 = pr1,
                dp1 = 0, dp2,
                lastpriceToBuy = pr1 + fee, lastPriceToCell = 0;
            bool haveStock = false;
            foreach (var price in prices) {
                dp2 = dp1;
                dp1 = price - pr1;
                if (haveStock) {
                    if ((dp1 > 0) & (dp2 <= 0) & (lastPriceToCell > pr1 + fee)) {
                        maxProfit += lastPriceToCell - lastpriceToBuy;
                        lastpriceToBuy = pr1 + fee;
                        if (lastpriceToBuy < price) {
                            lastPriceToCell = price;
                            haveStock = true;
                        }
                        else {
                            haveStock = false;
                        }
                    }
                    else {
                        lastPriceToCell = lastPriceToCell < price ? price : lastPriceToCell;
                    }
                }
                else {
                    if (lastpriceToBuy > price + fee) {
                        lastpriceToBuy = price + fee;
                    }
                    else if (lastpriceToBuy < price) {
                        lastPriceToCell = price;
                        haveStock = true;
                    }
                }
                pr2 = pr1;
                pr1 = price;
            }
            if (haveStock & lastpriceToBuy < lastPriceToCell)
                maxProfit += lastPriceToCell - lastpriceToBuy;
            return maxProfit;
        }
        /*
         * 1014. Best Sightseeing Pair
         * Medium
         * You are given an integer array values where values[i] represents 
         * the value of the ith sightseeing spot. 
         * Two sightseeing spots i and j have a distance j - i between them.
         * The score of a pair (i < j) of sightseeing spots 
         * is values[i] + values[j] + i - j: the sum of the values of the sightseeing spots,
         * minus the distance between them.
         * Return the maximum score of a pair of sightseeing spots.
         * 
         * Constraints:

    2 <= values.length <= 5 * 10^4
    1 <= values[i] <= 1000

         */
        public static int MaxScoreSightseeingPair(int[] values) {
            int bestScopeInLeft = 0, maxScope = 0;
            foreach (var val in values) {
                maxScope = System.Math.Max(maxScope, bestScopeInLeft + val - 1);
                bestScopeInLeft = System.Math.Max(bestScopeInLeft - 1, val);
            }
            return maxScope;
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
            var rob1 = GetRob_II(nums, nums.Length - 2, start: 0);
            var rob2 = GetRob_II(nums, nums.Length - 1, start: 1);
            return System.Math.Max(rob1.r0, rob2.r0);
        }
        private static (int r1, int r0) GetRob_II(int[] nums, int i, int start = 0) {
            switch (i - start) {
                case < 0:
                    return (0, nums[0]);
                case 0:
                    return (0, nums[i]);
                case 1:
                    return (nums[start], System.Math.Max(nums[i], nums[start]));
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
        /*
         * 525. Contiguous Array
         * Medium
         * Given a binary array nums, return the maximum length of a contiguous subarray
         * with an equal number of 0 and 1.
         * 
         * Example 2:

    Input: nums = [0,1,0]
    Output: 2
    Explanation: [0, 1] (or [1, 0]) is a longest contiguous subarray with equal number of 0 and 1.
    Input: nums =         [0,1,0,1]
    Output = 4

         * Constraints:

    1 <= nums.length <= 10^5
    nums[i] is either 0 or 1.

         */
        public static int FindMaxLength(int[] nums) { // идея нерабочая
            int maxLength = 0;
            Nexus last = new(0, 0);
            int n = nums[0], sign = 1, zl = 0;
            foreach (var item in nums) {
                if (item == n) {
                    zl += sign;
                }
                else {
                    last = last + zl;
                    sign *= -1;
                    zl = sign;
                    n = item;
                }
            }
            last = last + zl;
            while (last != null) {
                maxLength = System.Math.Max(maxLength, last.p);
                last = last.parent;
            }

            return maxLength;
        }
        private record Nexus(int z, int p, Nexus parent = null) {
            static public Nexus operator +(Nexus left, int zr) {
                if (left == null)
                    return new Nexus(zr, 0);
                var (zl, pl, nextl) = left;
                if (zr == 0) {
                    return left;
                }
                if (zl > 0 ^ zr >= 0) {
                    int mzl = zl > 0 ? zl : -zl;
                    int mzr = zr > 0 ? zr : -zr;
                    if (mzl > mzr) {
                        return left.parent + new Nexus(zl + zr, pl + (2 * mzr));
                    }
                    else {
                        return left.parent + new Nexus(zl + zr, pl + 2 * mzl);
                    }
                }
                else if (pl == 0)
                    return new Nexus(zr + zl, 0, left.parent);
                else
                    return new Nexus(zr, 0, left);
            }
            // right.parent must be null
            static public Nexus operator +(Nexus left, Nexus right) {
                if (left == null)
                    return right;
                if (right == null) {
                    return left;
                }
                var (zl, pl, nextl) = left;
                var (zr, pr, nextr) = right;
                if (zr == 0) {
                    return new Nexus(zl, pl + pr, nextl);
                }
                if (zl > 0 ^ zr > 0) {
                    int mzl = zl > 0 ? zl : -zl;
                    int mzr = zr > 0 ? zr : -zr;
                    if (mzl > mzr) {
                        return new Nexus(zl + zr, pl + pr + (2 * mzr), nextl);
                    }
                    else {
                        return (nextl + new Nexus(0, pl + 2 * mzl)) + new Nexus(zl + zr, pr);
                    }
                }
                else if (pl == 0) {
                    return new Nexus(zr + zl, pr, left.parent);
                }
                else {
                    return new Nexus(zr, pr, left);
                }
            }
        }
        /*
         * 55. Jump Game
         * Medium
         * You are given an integer array nums. 
         * You are initially positioned at the array's first index, 
         * and each element in the array represents your maximum jump length at that position.
         * Return true if you can reach the last index, or false otherwise.
         * 
         * Constraints:

    1 <= nums.length <= 10^4
    0 <= nums[i] <= 10^5

         */
        public static bool CanJump(int[] nums) {
            int lastIndex = nums.Length - 1;
            for (int i = lastIndex - 1; i >= 0; i--) {
                if (lastIndex - i <= nums[i]) {
                    lastIndex = i;
                }
            }
            return lastIndex == 0;
        }
        /*
         * 45. Jump Game II
         * Medium
         * Given an array of non-negative integers nums, 
         * you are initially positioned at the first index of the array.
         * Each element in the array represents your maximum jump length at that position.
         * Your goal is to reach the last index in the minimum number of jumps.
         * You can assume that you can always reach the last index.
         *
         *Constraints:

    1 <= nums.length <= 10^4
    0 <= nums[i] <= 1000

         */
        public static int Jump_II(int[] nums) {
            int m = nums.Length;
            int[] stack = new int[m + 1];
            int st_current = 0;
            stack[st_current] = m - 1;
            for (int i = m - 2; i >= 0; i--) {
                int maxJumpIndex = i + nums[i];
                int j;
                for (j = 0; j < st_current; j++) {
                    if (stack[j] <= maxJumpIndex)
                        break;
                }
                st_current = j + 1;
                stack[st_current] = i;
            }
            return st_current;
        }
        public static int Jump_II_slow(int[] nums) {
            int m = nums.Length;
            int[] jumps = new int[m];
            for (int i = m - 2; i >= 0; i--) {
                int val = nums[i];
                if (val == 0) {
                    jumps[i] = int.MaxValue;
                    continue;
                }
                else if (val > m - i - 2) {
                    jumps[i] = 1;
                    continue;
                }
                int minJ = int.MaxValue;
                for (int j = i + val; j > i; j--) {
                    minJ = System.Math.Min(minJ, Inc(jumps[j]));
                }
                jumps[i] = minJ;
            }
            return jumps[0];
        }
        private static int Inc(int i) {
            return i == int.MaxValue ? int.MaxValue : i + 1;
        }
        /*
         * 80. Remove Duplicates from Sorted Array II
         * Medium
         * Given an integer array nums sorted in non-decreasing order, 
         * remove some duplicates in-place such that each unique element appears at most twice. каждый элемент не более двух раз
         * The relative order of the elements should be kept the same.
         * Since it is impossible to change the length of the array in some languages, 
         * you must instead have the result be placed in the first part of the array nums. 
         * More formally, if there are k elements after removing the duplicates, 
         * then the first k elements of nums should hold the final result. 
         * It does not matter what you leave beyond the first k elements.
         * Return k after placing the final result in the first k slots of nums.
         * Do not allocate extra space for another array. 
         * You must do this by modifying the input array in-place with O(1) extra memory.
         * Custom Judge:
         * The judge will test your solution with the following code:

    int[] nums = [...]; // Input array
    int[] expectedNums = [...]; // The expected answer with correct length

    int k = removeDuplicates(nums); // Calls your implementation

    assert k == expectedNums.length;
    for (int i = 0; i < k; i++) {
    assert nums[i] == expectedNums[i];
    }
         *If all assertions pass, then your solution will be accepted.
         *
         *Constraints:

    1 <= nums.length <= 3 * 10^4
    -10^4 <= nums[i] <= 10^4
    nums is sorted in non-decreasing order.

         */
        public static int RemoveDuplicates(int[] nums) {
            int m = nums.Length;
            if (m < 3) {
                return m;
            }
            int n2 = nums[0], n1 = nums[1], n0, n = 2;
            for (int i = 2; i < m; i++) {
                n0 = nums[i];
                if (n0 != n2) {
                    nums[n++] = n0;
                    n2 = n1;
                    n1 = n0;
                }
            }
            return n;
        }
        /*
         * 152. Maximum Product Subarray
         * Medium
         * Given an integer array nums, find a contiguous non-empty subarray 
         * within the array that has the largest product, and return the product.
         * The test cases are generated so that the answer will fit in a 32-bit integer.
         * A subarray is a contiguous subsequence of the array.
         * 
         * Constraints:

    1 <= nums.length <= 2 * 10^4
    -10 <= nums[i] <= 10
    The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit integer.
                 */
        public static int MaxProduct(int[] nums) {
            int n = nums.Length;
            if (n == 1)
                return nums[0];
            int lpr = 0, lpr1 = 0, lprMax = int.MinValue;
            foreach (int val in nums) {
                if (val == 0) {
                    lpr = lpr1 = 0;
                }
                else {
                    lpr1 = (lpr < 0 & lpr1 == 0) ? val : lpr1 * val;
                    lpr = lpr == 0 ? val : lpr * val;
                }
                lprMax = lprMax > lpr ? lprMax : lpr;
                lprMax = lprMax > lpr1 ? lprMax : lpr1;
            }
            return lprMax;
        }
        /*
         * 1567. Maximum Length of Subarray With Positive Product
         * Medium
         * Given an array of integers nums, find the maximum length of a subarray where the product of all its elements is positive.
         * A subarray of an array is a consecutive sequence of zero or more values taken out of that array.
         * Return the maximum length of a subarray with positive product.
         * 
         * Constraints:

    1 <= nums.length <= 10^5
    -10^9 <= nums[i] <= 10^9

         */
        public static int GetMaxLen(int[] nums) {
            int n = nums.Length;
            if (n == 1)
                return nums[0] > 0 ? 1 : 0;
            int zstart = -1, pstart = -1, lMax = 0;
            bool eddge1 = false, eddge2 = false;
            for (int i = 0; i < n; i++) {
                int val = nums[i];
                if (val == 0) {
                    pstart = zstart = i;
                    eddge1 = eddge2 = false;
                    continue;
                }
                if (val < 0) {
                    if (eddge1) {
                        eddge2 = !eddge2;
                    }
                    else {
                        eddge1 = true;
                        pstart = i;
                    }
                }
                if (eddge1) {
                    if (eddge2) {
                        lMax = lMax > i - zstart ? lMax : i - zstart;
                    }
                    else {
                        lMax = lMax > i - pstart ? lMax : i - pstart;
                    }
                }
                else {
                    lMax = lMax > i - zstart ? lMax : i - zstart;
                }
            }
            return lMax;
        }
        /*
         * 532. K-diff Pairs in an Array
         * Medium
         * Given an array of integers nums and an integer k, 
         * return the number of unique k-diff pairs in the array.
         * A k-diff pair is an integer pair (nums[i], nums[j]), where the following are true:
         * 0 <= i < j < nums.length
         * |nums[i] - nums[j]| == k
         * Notice that |val| denotes the absolute value of val.
         * 
         * Constraints:

    1 <= nums.length <= 10^4
    -10^7 <= nums[i] <= 10^7
    0 <= k <= 10^7

         */
        public static int FindPairs(int[] nums, int k) {
            if (nums.Length == 1)
                return 0;
            Array.Sort(nums);
            int count = 0;
            var cursor = nums.AsEnumerable().GetEnumerator();
            bool cursorMoved = cursor.MoveNext();
            int m = cursor.Current;
            cursorMoved = cursor.MoveNext();
            if (k == 0) {
                bool mAlreadyCounted = false;
                while (cursorMoved) {
                    if (cursor.Current == m) {
                        if (!mAlreadyCounted) {
                            count++;
                            mAlreadyCounted = true;
                        }
                    }
                    else {
                        m = cursor.Current;
                        mAlreadyCounted = false;
                    }
                    cursorMoved = cursor.MoveNext();
                }
            }
            else {
                int startSearchPos = 0;
                int n = nums.Length;
                while (cursorMoved) {
                    if (cursor.Current != m) {
                        startSearchPos = Array.BinarySearch<int>(nums, startSearchPos, n - startSearchPos, m + k);
                        if (startSearchPos > 0) {
                            count++;
                        }
                        else {
                            startSearchPos = ~startSearchPos;
                            if (startSearchPos >= n)
                                break;
                        }
                        m = cursor.Current;
                    }
                    cursorMoved = cursor.MoveNext();
                }
            }
            return count;
        }
        public static int FindPairs_brutforce(int[] nums, int k) {//[3,1,4,1,5], k = 2
            int count = 0;
            SortedSet<int> set = new();
            for (int i = 0; i < nums.Length - 1; i++) {
                for (int j = i + 1; j < nums.Length; j++) {
                    int min = nums[i] > nums[j] ? nums[j] : nums[i];
                    int max = nums[i] > nums[j] ? nums[i] : nums[j];
                    var sum = max - min;
                    if (sum == k)
                        if (set.Add(max * 20_000_000 + min))
                            count++;
                }
            }
            return count;
        }
        /*
         * 42. Trapping Rain Water
         * Hard
         * Given n non-negative integers representing an elevation map 
         * where the width of each bar is 1, compute how much water it can trap after raining.
         * 
         * Constraints:

    n == height.length
    1 <= n <= 2 * 10^4
    0 <= height[i] <= 10^5

         */
        public static int Trap(int[] height) {
            if (height.Length < 3)
                return 0;
            int left = 0, right = height.Length - 1;
            int trap = 0;
            int leftBorder = height[left++], leftValue = height[left];
            int rightBorder = height[right--], rightValue = height[right];
            int trapLevel = System.Math.Min(leftBorder, rightBorder);
            while (left <= right) {
                if (rightBorder < leftBorder) {
                    while (rightValue <= rightBorder && left <= right) {
                        trap += trapLevel - rightValue;
                        right--;
                        rightValue = height[right];
                    }
                    rightBorder = rightValue;
                    trapLevel = System.Math.Min(leftBorder, rightBorder);
                    right--;
                    if (left > right)
                        break;
                    rightValue = height[right];

                }
                else {
                    while (leftValue <= leftBorder && left <= right) {
                        trap += trapLevel - leftValue;
                        left++;
                        leftValue = height[left];
                    }
                    leftBorder = leftValue;
                    trapLevel = System.Math.Min(leftBorder, rightBorder);
                    left++;
                    if (left > right)
                        break;
                    leftValue = height[left];
                }
            }
            return trap;
        }
        /*
         * 560. Subarray Sum Equals K
         * Medium
         * Given an array of integers nums and an integer k, 
         * return the total number of continuous subarrays whose sum equals to k.
         * 
         * Constraints:

    1 <= nums.length <= 2 * 10^4
    -1000 <= nums[i] <= 1000
    -10^7 <= k <= 10^7

         */
        public static int SubarraySum(int[] nums, int k) {
            Dictionary<int, int> sums = new();
            int sum = 0, count = 0;
            if (k == 0) { // must exlude empty subarrays
                foreach (var val in nums) {
                    sum += val;
                    if (sum == 0) {
                        count++;
                    }
                    if (!sums.TryAdd(sum, 1)) {
                        count += sums[sum];
                        sums[sum] += 1;
                    }
                }
            }
            else {
                foreach (var val in nums) {
                    sum += val;
                    if (sum == k) {
                        count++;
                    }
                    if (!sums.TryAdd(sum, 1)) {
                        sums[sum] += 1;
                    }
                    if (sums.ContainsKey(sum - k)) {
                        count += sums[sum - k];
                    }
                }
            }
            return count;
        }
        /*
         * 413. Arithmetic Slices
         * Medium
         * An integer array is called arithmetic if it consists of at least three elements 
         * and if the difference between any two consecutive elements is the same.
         * 
         * For example, [1,3,5,7,9], [7,7,7,7], and [3,-1,-5,-9] are arithmetic sequences.
         * Given an integer array nums, return the number of arithmetic subarrays of nums.
         * A subarray is a contiguous subsequence of the array.
Example 1:

Input: nums = [1,2,3,4]
Output: 3
Explanation: We have 3 arithmetic slices in nums: [1, 2, 3], [2, 3, 4] and [1,2,3,4] itself.

         */
        public static int NumberOfArithmeticSlices(int[] nums) {
            int startSlice = 0;
            if (nums.Length < 3)
                return 0;
            int count = 0;
            for (int i = 2; i < nums.Length; i++) {
                if (nums[i] - nums[i - 1] != nums[i - 1] - nums[i - 2]) {
                    count += Slices(i - startSlice);
                    startSlice = i - 1;
                }
            }
            if (nums.Length - startSlice > 2)
                count += Slices(nums.Length - startSlice);
            return count;
        }
        internal static int Slices(int n) {
            //if (n < 3) return 0;
            return (n - 2) * (n - 1) / 2;
        }
        public static int NumberOfArithmeticSlices_LC(int[] nums) {
            int count = 0, d = 0;
            for (int i = 2; i < nums.Length; i++) {
                if (nums[i] - nums[i - 1] == nums[i - 1] - nums[i - 2]) {
                    d += 1;
                    count += d;
                }
                else {
                    d = 0;
                }
            }
            return count;
        }
        /*
         * 931. Minimum Falling Path Sum
         * Medium
         * Given an n x n array of integers matrix, return the minimum sum of any falling path through matrix.
         * A falling path starts at any element in the first row and chooses the element in the next row 
         * that is either directly below or diagonally left/right. 
         * Specifically, the next element from position (row, col) will be (row + 1, col - 1), (row + 1, col), or (row + 1, col + 1).
         * 
         * Constraints:
    n == matrix.length == matrix[i].length
    1 <= n <= 100
    -100 <= matrix[i][j] <= 100
         */
        public static int MinFallingPathSum(int[][] matrix) {
            int n = matrix.Length;
            if (n == 1)
                return matrix[0][0];
            for (int i = n - 2; i >= 0; i--) {
                var nextrow = matrix[i + 1];
                for (int j = 0; j < n; j++) {
                    //matrix[i][j] += GetMin(nextrow, n, j);
                    int nextmin = j > 0 ? System.Math.Min(nextrow[j], nextrow[j - 1]) : nextrow[j];
                    nextmin = j < n - 1 ? System.Math.Min(nextrow[j + 1], nextmin) : nextmin;
                    matrix[i][j] += nextmin;
                }
            }
            int min = matrix[0][0];
            var firstRow = matrix[0];
            for (int i = 0; i < n; i++) {
                min = System.Math.Min(min, firstRow[i]);
            }
            return min;
        }
        private static int GetMin(int[] nums, int n, int col) {
            int min = col > 0 ? System.Math.Min(nums[col], nums[col - 1]) : nums[col];
            min = col < n - 1 ? System.Math.Min(nums[col + 1], min) : min;
            return min;
        }
        /*
         * 136. Single Number
         * Easy
         * Given a non-empty array of integers nums, every element appears twice except for one. 
         * Find that single one.
         * You must implement a solution with a linear runtime complexity and use only constant extra space.
         *
         *Constraints:
    1 <= nums.length <= 3 * 10^4
    -3 * 10^4 <= nums[i] <= 3 * 10^4
    Each element in the array appears twice except for one element which appears only once.
         */
        public static int SingleNumber(int[] nums) {
            Array.Sort<int>(nums);
            int n2 = 0, n1 = 0;
            foreach (var n in nums) {
                if (n2 != n1 && n1 != n)
                    return n1;
                n2 = n1;
                n1 = n;
            }
            if (n2 != n1)
                return n1;
            throw new ArgumentOutOfRangeException();
        }
        /*
         * 1314. Matrix Block Sum
         * Medium
         * Given a m x n matrix mat and an integer k, 
         * return a matrix answer where each answer[i][j] is the sum of all elements mat[r][c] for:
         * i - k <= r <= i + k,
         * j - k <= c <= j + k, and
         * (r, c) is a valid position in the matrix.
         * 
         * Constraints:

    m == mat.length
    n == mat[i].length
    1 <= m, n, k <= 100
    1 <= mat[i][j] <= 100

         */
        public static int[][] MatrixBlockSum(int[][] mat, int k) {
            int m = mat.Length;
            int n = mat[0].Length;
            if (m == 1 & n == 1)
                return mat;
            int[][] blockSums = new int[m][];
            int[][] sums = new int[m][];
            int i;
            for (i = 0; i < m; i++) {
                blockSums[i] = new int[n];
                sums[i] = new int[n];
            }
            i = 0;
            foreach (var row in mat) {
                int sum = 0;
                int j = 0;
                foreach (var val in row) {
                    sum += val;
                    sums[i][j++] = sum;
                }
                i++;
            }
            for (int j = 0; j < n; j++) {
                int sum = 0;
                for (i = 0; i < m; i++) {
                    sum += sums[i][j];
                    sums[i][j] = sum;
                }
            }
            for (i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    int min_i_Index = i - k - 1;
                    int max_i_Index = System.Math.Min(m - 1, i + k);
                    int min_j_index = j - k - 1;
                    int max_j_Index = System.Math.Min(n - 1, j + k);
                    int div = min_i_Index >= 0 & min_j_index >= 0 ? sums[min_i_Index][min_j_index]
                        : 0;
                    int div1 = min_j_index >= 0 ? sums[max_i_Index][min_j_index]
                        : 0;
                    int div2 = min_i_Index >= 0 ? sums[min_i_Index][max_j_Index]
                        :  0;
                    blockSums[i][j] = sums[max_i_Index][max_j_Index] - div1 - div2 + div;
                }
            }
            return blockSums;
        }
    }

}
