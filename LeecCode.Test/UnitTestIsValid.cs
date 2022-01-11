using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestIsValid
    {
        [Test]
        public void Test1()
        {
            string s = "([]{[]})";
            Assert.IsTrue(Solution.IsValid(s));
             s = "()";
            Assert.IsTrue(Solution.IsValid(s));
             s = "()[]{}";
            Assert.IsTrue(Solution.IsValid(s));
             s = "(}";
            Assert.IsFalse(Solution.IsValid(s));
             s = "}";
            Assert.IsFalse(Solution.IsValid(s));
        }

    }
}