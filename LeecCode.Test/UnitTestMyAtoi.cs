using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestStr
    {

        const string long2147483646 = "                                                                                                                                                                                              2147483646";
        [Test]
        public void MyAtoi()
        {
            string s="";
            Assert.AreEqual(0, Solution.MyAtoi(s));
            s = "0";
            Assert.AreEqual(0, Solution.MyAtoi(s));
            s = "01";
            Assert.AreEqual(1, Solution.MyAtoi(s));
            s = "-02";
            Assert.AreEqual(-2, Solution.MyAtoi(s));
            s = "0000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000000001";
            Assert.AreEqual(1, Solution.MyAtoi(s));
            s = "                       -1";
            Assert.AreEqual(-1, Solution.MyAtoi(s));
            s = "-2147483648";
            Assert.AreEqual(int.MinValue, Solution.MyAtoi(s));
            s = "2147483647";
            Assert.AreEqual(int.MaxValue, Solution.MyAtoi(s));
            s = "2147483648";
            Assert.AreEqual(int.MaxValue, Solution.MyAtoi(s));
            s = "2147483646";
            Assert.AreEqual(2147483646, Solution.MyAtoi(s));
            s = "-21474836480";
            Assert.AreEqual(int.MinValue, Solution.MyAtoi(s));
            s = "  -2147483646Íœ‡";
            Assert.AreEqual(-2147483646, Solution.MyAtoi(s));
            s = "-2147.483648";
            Assert.AreEqual(-2147, Solution.MyAtoi(s));
            s = "-6147483648";
            Assert.AreEqual(int.MinValue, Solution.MyAtoi(s));
            s = "  0000000000012345678";
            Assert.AreEqual(12345678, Solution.MyAtoi(s));
            s = long2147483646;
            Assert.AreEqual(2147483646, Solution.MyAtoi(s));
        }
        //[Test]
        //public void CheckCostMyAtoi()
        //{
        //    for (int i = 0; i < 2*32; i++)
        //    {
        //        Assert.AreEqual(2147483646, Solution.MyAtoi(long2147483646));
        //    }
        //}
    }
}