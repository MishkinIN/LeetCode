using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestLongestCommonPrefix
    {
        [Test]
        public void Test1()
        {
            {
                string[] strs = { "dog", "racecar", "car" };
                Assert.That(Solution.LongestCommonPrefix(strs) == "");
            }
            {
                string[] strs = { "flower", "flow", "flight" };
                Assert.That(Solution.LongestCommonPrefix(strs) == "fl");
            }
            {
                string[] strs = {"ab", "a" };
                Assert.That(Solution.LongestCommonPrefix(strs) == "a");
            }
            
        }
         [Test]
       public void Test2()
        {
            {
                string[] strs = { "dog", "racecar", "car" };
                Assert.That(Solution.LongestCommonPrefix_1(strs) == "");
            }
            {
                string[] strs = { "flower", "flow", "flight" };
                Assert.That(Solution.LongestCommonPrefix_1(strs) == "fl");
            }
            {
                string[] strs = {"ab", "a" };
                Assert.That(Solution.LongestCommonPrefix_1(strs) == "a");
            }
            
        }

    }
}