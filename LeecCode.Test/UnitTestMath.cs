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
        [Test]
        public void GetUglyArg() {
            int n = 1690, argUgly;
            //argUgly = LeetCode.Math.GetUglyArg(1);
            //Assert.AreEqual(1, argUgly);
            argUgly = LeetCode.Math.GetUglyArg(6);
            Assert.AreEqual(6, argUgly);
            argUgly = LeetCode.Math.GetUglyArg(8);
            Assert.AreEqual(7, argUgly);
            argUgly = LeetCode.Math.GetUglyArg(12);
            Assert.AreEqual(10, argUgly);
            argUgly = LeetCode.Math.GetUglyArg(25);
            Assert.AreEqual(16, argUgly);
            argUgly = LeetCode.Math.GetUglyArg(576);
            Assert.AreEqual(70, argUgly);
        }
        [Test]
        public static void Primes() {
            var primes = LeetCode.Math.primes1;
            int mul = 1;
            for (int i = 0; i < primes.Length; i++) {
                for (int j = 0; j < i; j++) {
                    Assert.AreNotEqual(0, mul);
                }
            }

            for (int i = primes[^2] + 1; i < primes[^1]; i++) {
                bool haveDivides = false;
                for (int j = 0; j < primes.Length; j++) {
                    haveDivides = haveDivides | i % primes[j] == 0;
                }
                Assert.IsTrue(haveDivides);
            }
        }
        [Test]
        public void Primes2() {
            var primes = LeetCode.Math.primes1;
            //int primeIndex = Array.BinarySearch(primes, ugly);
            for (int primeIndex = 1; primeIndex < primes.Length; primeIndex++) {
                int primeVal = primes[primeIndex];
                int lastPrime = primes[0];
                int uglyDiv = primeVal / lastPrime;
                for (int i = 1; i < primeIndex; i++) {
                    int prime = primes[i];
                    uglyDiv += primeVal / prime - primeVal / (lastPrime * prime);
                    lastPrime = prime;
                }
                Assert.AreEqual(primeVal, uglyDiv + 2);
            }
        }
    }

}