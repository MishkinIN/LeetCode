using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestStrStr
    {
        

        [Test]
        public void Test1()
        {
            string haystack, needle;
            haystack = "";
            needle = "";
            Assert.AreEqual(0, Solution.StrStr(haystack, needle));
            haystack = "hello";
            needle = "ll";
            Assert.AreEqual(2, Solution.StrStr(haystack, needle));
            haystack = "aaaaa";
            needle = "abba";
            Assert.AreEqual(-1, Solution.StrStr(haystack, needle));
            haystack = "mississippi";
            needle = "issip";
            Assert.AreEqual(4, Solution.StrStr(haystack, needle));
        }

    }
}