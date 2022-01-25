using NUnit.Framework;
using LeetCode;
using System;
using System.Collections.Generic;

namespace LeecCode.Test
{
    public class UnitTestArray {
        private int[] bigNumsContainsDuplicate;
        private int[] bigNumsNotContainsDuplicate;
        private int[] piles;

        [SetUp]
        public void Setup() {
            int arrSize = 10_000_000;
            bigNumsContainsDuplicate = new int[arrSize];
            var random = new Random();
            for (int i = 0; i < arrSize; i++) {
                bigNumsContainsDuplicate[i] = random.Next(int.MinValue + 1, int.MaxValue - 1);
            }
            var hashSet = new HashSet<int>(arrSize);
            while (hashSet.Count < arrSize) {
                hashSet.Add(random.Next(int.MinValue + 1, int.MaxValue - 1));
            }
            bigNumsNotContainsDuplicate = new int[arrSize];
            hashSet.CopyTo(bigNumsNotContainsDuplicate);
            int[] nums = new int[10_000];
            for (int i = 0; i < nums.Length; i++) {
                nums[i] = random.Next(1, 1_000_000_000);
            }
            piles = nums;
        }
        [Test]
            public void MinJumps() {
                int[] nums;
            nums = new int[] { 1, 0 };
            Assert.AreEqual(1, Solution.MaxDistToClosest(nums));
            nums = new int[] { 0, 1 };
            Assert.AreEqual(1, Solution.MaxDistToClosest(nums));
            nums = new int[] { 1, 0, 0 };
            Assert.AreEqual(2, Solution.MaxDistToClosest(nums));
            nums = new int[] { 0, 1, 0 };
            Assert.AreEqual(1, Solution.MaxDistToClosest(nums));
            nums = new int[] { 0, 1, 0, 0 };
            Assert.AreEqual(2, Solution.MaxDistToClosest(nums));
            nums = new int[] { 0, 0, 1, 0 };
            Assert.AreEqual(2, Solution.MaxDistToClosest(nums));
            nums = new int[] { 0, 0, 1, 0, 0, 0, 0, 1 };
            Assert.AreEqual(2, Solution.MaxDistToClosest(nums));
            nums = new int[] { 0, 0, 1, 0, 0, 0, 0, 0, 1 };
            Assert.AreEqual(3, Solution.MaxDistToClosest(nums));
            nums = new int[] { 0, 0, 1, 0 };
            Assert.AreEqual(2, Solution.MaxDistToClosest(nums));
            nums = new int[] { 0, 0, 1, 0 };
            Assert.AreEqual(2, Solution.MaxDistToClosest(nums));
            nums = new int[] { 1, 0, 0, 0, 1, 0, 1 };
            Assert.AreEqual(2, Solution.MaxDistToClosest(nums));
            nums = new int[] { 1, 0, 0, 0 };
            Assert.AreEqual(3, Solution.MaxDistToClosest(nums));
            nums = new int[] { 1, 1, 0, 1, 0, 0, 0, 1, 0, 0, 1, 1 };
            Assert.AreEqual(2, Solution.MaxDistToClosest(nums));
            nums = new int[] { 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1 };
            Assert.AreEqual(3, Solution.MaxDistToClosest(nums));
        }
        [Test]
        public void ContainsDuplicate() {
            int[] nums;
            nums = new int[] { 0 };
            Assert.IsFalse(Solution.ContainsDuplicate(nums));
            nums = new int[] { 0, 1 };
            Assert.IsFalse(Solution.ContainsDuplicate(nums));
            nums = new int[] { 1, 0 };
            Assert.IsFalse(Solution.ContainsDuplicate(nums));
            nums = new int[] { 0, 0 };
            Assert.IsTrue(Solution.ContainsDuplicate(nums));
            nums = new int[] { 0, 1, 2 };
            Assert.IsFalse(Solution.ContainsDuplicate(nums));
            nums = new int[] { 2, 1, 0 };
            Assert.IsFalse(Solution.ContainsDuplicate(nums));
            nums = new int[] { 0, 2, 1, 0 };
            Assert.IsTrue(Solution.ContainsDuplicate(nums));
            nums = new int[] { 0, 2, 4, 8, 1, 3, 5, 7 };
            Assert.IsFalse(Solution.ContainsDuplicate(nums));
            nums = new int[] { 170, -368, 148, 672, 397, -629, -788, 192, 170, 309, -615, -237 };
            Assert.IsTrue(Solution.ContainsDuplicate(nums));

        }
        [Test]
        public void ContainsDuplicate_Big() {
            Assert.IsTrue(Solution.ContainsDuplicate(bigNumsContainsDuplicate));
            Assert.IsFalse(Solution.ContainsDuplicate(bigNumsNotContainsDuplicate));
        }
        [Test]
        public void ContainsDuplicate_WidthHashSet_Big() {
            Assert.IsTrue(Solution.ContainsDuplicate_WidthHashSet(bigNumsContainsDuplicate));
            Assert.IsFalse(Solution.ContainsDuplicate_WidthHashSet(bigNumsNotContainsDuplicate));
        }
        [Test]
        public void RotateArray() {
            int[] nums, vals;
            nums = new int[] { 0 };
            vals = new int[nums.Length];
            Array.Copy(nums, vals, nums.Length);
            Solution.Rotate(nums, 5);
            Assert.IsTrue(Equal(nums, vals));

            nums = new int[] { 0, 1, 2 };
            vals = new int[] { 2, 0, 1 };
            Solution.Rotate(nums, 1);
            Assert.IsTrue(Equal(nums, vals));

            nums = new int[] { 0, 1, 2 };
            vals = new int[] { 1, 2, 0 };
            Solution.Rotate(nums, 5);
            Assert.IsTrue(Equal(nums, vals));

            nums = new int[] { 0, 1, 2 };
            vals = new int[] { 1, 2, 0 };
            Solution.Rotate(nums, 5);
            Assert.IsTrue(Equal(nums, vals));

            nums = new int[] { 0, 1, 2, 3, 4, 5, 6 };
            vals = new int[] { 4, 5, 6, 0, 1, 2, 3 };
            Solution.Rotate(nums, 3);
            Assert.IsTrue(Equal(nums, vals));

            nums = new int[] { 0, 1, 2, 3, 4, 5, 6, };
            vals = new int[] { 2, 3, 4, 5, 6, 0, 1, };
            Solution.Rotate(nums, 5);
            Assert.IsTrue(Equal(nums, vals));

        }
        private bool Equal(int[] left, int[] right) {
            if (left == right) {
                return true;
            }
            if ((left == null | right == null) || left.Length != right.Length) {
                return false;
            }
            bool isEquals = true;
            for (int i = 0; i < left.Length & isEquals; i++) {
                isEquals = isEquals & left[i] == right[i];
            }
            return isEquals;
        }
        [Test]
        public void MinEatingSpeed() {
            int[] nums; int h, k;
            nums = new int[] { 3, 6, 7, 11 };
            h = 8; k = 4;
            var result = Solution.MinEatingSpeed(nums, h);
            Assert.AreEqual(k, result.MinEatingSpeed);
            Console.WriteLine(result.stepCount);
            nums = new int[] { 30, 11, 23, 4, 20 };
            h = 5;
            k = 30;
            result = Solution.MinEatingSpeed(nums, h);
            Assert.AreEqual(k, result.MinEatingSpeed);
            Console.WriteLine(result.stepCount);
            nums = new int[] { 30, 11, 23, 4, 20 };
            h = 6;
            k = 23;
            result = Solution.MinEatingSpeed(nums, h);
            Assert.AreEqual(k, result.MinEatingSpeed);
            Console.WriteLine(result.stepCount);
        }
        [Test]
        public void MinEatingSpeed_big() {
            int maxStepCount = 0, testH = 0;
            ;
            for (int h = piles.Length+1; h < 5 * piles.Length; h+=10) {
                {
                    var result1 = Solution.MinEatingSpeed(piles, h);
                    if (result1.stepCount > maxStepCount) {
                        maxStepCount = result1.stepCount;
                        testH = h;
                    }
                }
            }
            Console.WriteLine($"Width h={testH} MinEatingSpeed have max stepCount={maxStepCount}");

        }
        [Test]
        public void MinEatingSpeed_big_LeetCode() {
            int maxStepCount = 0, testH = 0;
            for (int h = piles.Length + 1; h < 5 * piles.Length; h += 10) {
                {
                    var result1 = Solution.MinEatingSpeed_LeetCode(piles, h);
                    if (result1.stepCount > maxStepCount) {
                        maxStepCount = result1.stepCount;
                        testH = h;
                    }
                }
            }
            Console.WriteLine($"Width h={testH} MinEatingSpeed have max stepCount={maxStepCount}");

        }
        [Test]
        public void MaxProfit() {
            int[] prices;
            int expected;
            prices = new int[] { 7, 1, 5, 3, 6, 4 };
            expected = 5;
            Assert.AreEqual(expected, Solution.MaxProfit(prices));
            prices = new int[] { 7, 6, 4, 3, 1 };
            expected = 0;
            Assert.AreEqual(expected, Solution.MaxProfit(prices));
            prices = new int[] { 7, 1, 5, 3, 6, 8 };
            expected = 7;
            Assert.AreEqual(expected, Solution.MaxProfit(prices));
            prices = new int[] { 7, 11, 5, 7, 6, 10 };
            expected = 5;
            Assert.AreEqual(expected, Solution.MaxProfit(prices));
        }
        [Test]
        public void CanCompleteCircuit() {
            int[] gas, cost;
            gas = new int[] {1, 2, 3, 4, 5};
            cost = new int[] { 3, 4, 5, 1, 2 };
            int startPos = 3;
            Assert.AreEqual(startPos, Solution.CanCompleteCircuit(gas, cost));
            
        }
        [Test]
        public void MatrixReshape() {
            int[][] mat = new int[2][];
            mat[0] = new int[] { 1, 2 };
            mat[1] = new int[] { 3, 4 };
            var res = Solution.MatrixReshape(mat, 1, 4);
            res = Solution.MatrixReshape(mat, 4, 1);
            res = Solution.MatrixReshape(mat, 2, 2);
        }
        [Test]
        public void GeneratePascalTriangle() {
            var res = Solution.GeneratePascalTriangle(7);

        }
        [Test]
        public void IsValidSudoku() {
            char[][] validSudoku = new char[][]{
                new char[] {'5', '3', '.', '.', '7', '.', '.', '.', '.'}
                ,new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'}
                ,new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'}
                ,new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'}
                ,new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'}
                ,new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'}
                ,new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'}
                ,new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'}
                ,new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'} };
            char[][] inValidSudoku = new char[][]{
                new char[] {'8', '3', '.', '.', '7', '.', '.', '.', '.'}
                ,new char[] {'6', '.', '.', '1', '9', '5', '.', '.', '.'}
                ,new char[] {'.', '9', '8', '.', '.', '.', '.', '6', '.'}
                ,new char[] {'8', '.', '.', '.', '6', '.', '.', '.', '3'}
                ,new char[] {'4', '.', '.', '8', '.', '3', '.', '.', '1'}
                ,new char[] {'7', '.', '.', '.', '2', '.', '.', '.', '6'}
                ,new char[] {'.', '6', '.', '.', '.', '.', '2', '8', '.'}
                ,new char[] {'.', '.', '.', '4', '1', '9', '.', '.', '5'}
                ,new char[] {'.', '.', '.', '.', '8', '.', '.', '7', '9'} };

            Assert.IsTrue(Solution.IsValidSudoku(validSudoku));
            Assert.IsFalse(Solution.IsValidSudoku(inValidSudoku));

        }
        [Test]
        public void ValidMountainArray() {
            int[] arr;
            arr = new int[] { 1, 3, 2, 0 };
            Assert.IsTrue(Solution.ValidMountainArray(arr));
              arr = new int[] {  0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.IsTrue(Solution.ValidMountainArray(arr));
        }
        [Test]
        public void FloodFill() {
            int[][] image = new int[][] {
                new int[]{ 0,0,0},
                new int[]{ 1,0,0},
            };
            Solution.FloodFill(image, sr:1, sc:0, newColor:2);
        }
    }
}