using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestTwoSum
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int[] nums = new int[] { 2, 7, 11, 15 };
            int target = 9;
            int[] output = Solution.TwoSum(nums, target);
            Assert.That(output != null);
            Assert.That(output.Length == 2);
            Assert.That(nums[output[0]] + nums[output[1]] == target);
        }

    }
}