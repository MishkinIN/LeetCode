using NUnit.Framework;
using LeetCode;
using System.Diagnostics;
using System;

namespace LeecCode.Test {
    public class UnitTestMath {
        private readonly Stopwatch sw = new();
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void NthUglyNumber() {
            Assert.AreEqual(1, LeetCode.Math.NthUglyNumber(1));
            Assert.AreEqual(6, LeetCode.Math.NthUglyNumber(6));
            Assert.AreEqual(8, LeetCode.Math.NthUglyNumber(7));
            Assert.AreEqual(12, LeetCode.Math.NthUglyNumber(10));
            Assert.AreEqual(25, LeetCode.Math.NthUglyNumber(16));
            Assert.AreEqual(576, LeetCode.Math.NthUglyNumber(70));
        }
        [Test]
        public void NthUglyNumber_1690() {
            int n = 1690;
            sw.Restart();
            var NthUgly = LeetCode.Math.NthUglyNumber(n);
            sw.Stop();
            Console.WriteLine($"NthUglyNumber({n})= {NthUgly}.");
            Console.WriteLine($"Elapsed time is {sw.Elapsed}.");
        }

    }
}