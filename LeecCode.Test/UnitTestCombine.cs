using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test {
    public class UnitTestCombine {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void Combine() {
            var comb = Solution.Combine(1, 1);
            Assert.AreEqual(1, comb.Count);
            Assert.AreEqual(1, comb[0][0]);
            comb = Solution.Combine(2, 2);
            Assert.AreEqual(1, comb.Count);
            comb = Solution.Combine(4, 2);
            Assert.AreEqual(6, comb.Count);
            comb = Solution.Combine(5, 5);
            Assert.AreEqual(1, comb.Count);
            comb = Solution.Combine(5, 4);
            Assert.AreEqual(5, comb.Count);
            comb = Solution.Combine(5, 3);
            Assert.AreEqual(10, comb.Count);
            comb = Solution.Combine(5, 2);
            Assert.AreEqual(10, comb.Count);
            comb = Solution.Combine(5, 1);
            Assert.AreEqual(5, comb.Count);
            comb = Solution.Combine(20, 16);
            Assert.AreEqual(4845, comb.Count);
        }
        [Test]
        public void Permute() {
            int[] nums;
            int[][] expected;
            nums = new int[] { 1 };
            var permute = Solution.Permute(nums);
            Assert.AreEqual(1, permute.Count);
            nums = new int[] { 1, 2};
            permute = Solution.Permute(nums);
            Assert.AreEqual(2, permute.Count);
            nums = new int[] { 1, 2, 3 };
            permute = Solution.Permute(nums);
            Assert.AreEqual(6, permute.Count);
            
        }

    }
}