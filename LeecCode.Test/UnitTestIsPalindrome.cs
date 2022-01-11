using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestIsPalindrome
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(Solution.IsPalindrome(121));
        }
    }
}
