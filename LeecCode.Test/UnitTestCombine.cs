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
            comb = Solution.Combine(20, 16);
            Assert.AreEqual(4845, comb.Count);
        }

    }
}