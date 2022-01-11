using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestRomanToInt
    {
        [Test]
        public void Test1()
        {
            Assert.IsTrue(2== Solution.RomanToInt("II"));
            Assert.IsTrue(5== Solution.RomanToInt("V"));
            Assert.IsTrue(4== Solution.RomanToInt("IV"));
            Assert.IsTrue(58== Solution.RomanToInt("LVIII"));
            Assert.IsTrue(1994== Solution.RomanToInt("MCMXCIV"));
        }
    }
}
