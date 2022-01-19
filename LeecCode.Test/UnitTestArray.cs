using NUnit.Framework;
using LeetCode;
using System;
using System.Collections.Generic;

namespace LeecCode.Test
{
    public class UnitTestArray {
        private int[] bigNumsContainsDuplicate;
        private int[] bigNumsNotContainsDuplicate;

        [SetUp]
        public void Setup() {
            int arrSize = 10_000_000;
            bigNumsContainsDuplicate = new int[arrSize];
            var random = new Random();
            for (int i = 0; i < arrSize; i++) {
                bigNumsContainsDuplicate[i] = random.Next(int.MinValue+1,int.MaxValue-1);
            }
            var hashSet = new HashSet<int>(arrSize);
            while (hashSet.Count< arrSize) {
                hashSet.Add(random.Next(int.MinValue + 1, int.MaxValue - 1));
            }
            bigNumsNotContainsDuplicate = new int[arrSize];
            hashSet.CopyTo(bigNumsNotContainsDuplicate);
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
            nums = new int[] {1, 0 };
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
        public void RotateArray()
        {
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

        }
        private bool Equal(int[] left, int[] right)
        {
            if (left == right)
            {
                return true;
            }
            if ((left == null | right==null) || left.Length!=right.Length)
            {
                return false;
            }
            bool isEquals = true;
            for (int i = 0; i < left.Length & isEquals; i++)
            {
                isEquals = isEquals & left[i] == right[i];
            }
            return isEquals;
        }
    }
}