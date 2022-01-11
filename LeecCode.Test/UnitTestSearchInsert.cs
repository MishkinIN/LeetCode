using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestSearchInsert
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            {
                int[] nums = new int[] { 10 };
                int target = 5;
                Assert.AreEqual(0, Solution.SearchInsert(nums, target));
            }
            {
                int[] nums = new int[] { 1 };
                int target = 5;
                Assert.AreEqual(1, Solution.SearchInsert(nums, target));
            }
            {
                int[] nums = new int[] { 1, 3, 5, 6 };
                int target = 5;
                Assert.AreEqual(2, Solution.SearchInsert(nums, target));
            }
            {
                int[] nums = new int[] { 1, 3, 5, 6 };
                int target = 2;
                Assert.AreEqual(1, Solution.SearchInsert(nums, target));
            }
            {
                int[] nums = new int[] { 1, 3, 5, 6 };
                int target = 7;
                Assert.AreEqual(4, Solution.SearchInsert(nums, target));
            }
        }

    }
}