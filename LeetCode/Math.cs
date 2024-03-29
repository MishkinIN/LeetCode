﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {

    public static class Math {
        /*
         * 509. Fibonacci Number
         * Easy
         * The Fibonacci numbers, commonly denoted F(n) form a sequence, called the Fibonacci sequence,
         * such that each number is the sum of the two preceding ones, starting from 0 and 1. That is,
         * F(0) = 0, F(1) = 1
         * F(n) = F(n - 1) + F(n - 2), for n > 1.
         * Given n, calculate F(n).
         * 
         * Constraints:

    0 <= n <= 30

         */
        public static int Fib(int n) {
            return GetFib(n).fib;
        }
        private static (int fib, int prev) GetFib(int n) {
            switch (n) {
                case 0:
                    return (0, 0);
                case 1:
                    return (1, 0);
                default:
                    var prev = GetFib(n - 1);
                    return (prev.fib + prev.prev, prev.fib);
            }
        }
        /*
         * 1137. N-th Tribonacci Number
         * Easy
         * The Tribonacci sequence Tn is defined as follows: 
         * T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0.
         * Given n, return the value of Tn.
         * Constraints:

    0 <= n <= 37
    The answer is guaranteed to fit within a 32-bit integer, ie. answer <= 2^31 - 1.

        */
        public static int Tribonacci(int n) {
            return GetTribonacci(n).n2;
        }
        private static (int n, int n1, int n2) GetTribonacci(int n) {
            switch (n) {
                case 0:
                    return (0, 0, 0);
                case 1:
                    return (0, 0, 1);
                case 2:
                    return (0, 1, 1);
                case 3:
                    return (1, 1, 2);
                default:
                    var p = GetTribonacci(n - 1);
                    return (p.n1, p.n2, p.n + p.n1 + p.n2);
            }
        }
        /*
         * 70. Climbing Stairs
         * Easy
         * You are climbing a staircase. It takes n steps to reach the top.
         * Each time you can either climb 1 or 2 steps. In how many distinct ways can you climb to the top?
         * 
         * Constraints:

    1 <= n <= 45

         */
        public static int ClimbStairs(int n) {
            return GetClimb(n).n0;

        }
        private static (int n1, int n0) GetClimb(int n) {
            switch (n) {
                case 1:
                    return (0, 1);
                case 2:
                    return (1, 2);
                default:
                    var cl = GetClimb(n - 1);
                    return (cl.n0, cl.n0 + cl.n1);
            }
        }
        /*
         * 258. Add Digits
         * Easy
         * Given an integer num, repeatedly add all its digits
         * until the result has only one digit, and return it.
         * 
         * Constraints:

    0 <= num <= 2^31 - 1

        */
        public static int AddDigits(int n) {
            if (n == 0)
                return 0;
            return 1 + (n - 1) % 9;
        }
        public static int HammingWeight(uint n) {
            return System.Numerics.BitOperations.PopCount(n);
        }
        /*
         * 264. Ugly Number II
         * Medium
         * An ugly number is a positive integer whose prime factors are limited to 2, 3, and 5.
         * Given an integer n, return the nth ugly number.
         *
         *Example 1:
Input: n = 10
Output: 12
Explanation: [1, 2, 3, 4, 5, 6, 8, 9, 10, 12] is the sequence of the first 10 ugly numbers.
         *
         *Constraints:

    1 <= n <= 1690

         */
        /* не стоит вычислять то, что давно известно - список первых 500 простых чисел, исключая 2,3,5
         * */
        internal static readonly int[] primes1 = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511, 1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657, 1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733, 1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811, 1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889, 1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987, 1993, 1997, 1999, 2003, 2011, 2017, 2027, 2029, 2039, 2053, 2063, 2069, 2081, 2083, 2087, 2089, 2099, 2111, 2113, 2129, 2131, 2137, 2141, 2143, 2153, 2161, 2179, 2203, 2207, 2213, 2221, 2237, 2239, 2243, 2251, 2267, 2269, 2273, 2281, 2287, 2293, 2297, 2309, 2311, 2333, 2339, 2341, 2347, 2351, 2357, 2371, 2377, 2381, 2383, 2389, 2393, 2399, 2411, 2417, 2423, 2437, 2441, 2447, 2459, 2467, 2473, 2477, 2503, 2521, 2531, 2539, 2543, 2549, 2551, 2557, 2579, 2591, 2593, 2609, 2617, 2621, 2633, 2647, 2657, 2659, 2663, 2671, 2677, 2683, 2687, 2689, 2693, 2699, 2707, 2711, 2713, 2719, 2729, 2731, 2741, 2749, 2753, 2767, 2777, 2789, 2791, 2797, 2801, 2803, 2819, 2833, 2837, 2843, 2851, 2857, 2861, 2879, 2887, 2897, 2903, 2909, 2917, 2927, 2939, 2953, 2957, 2963, 2969, 2971, 2999, 3001, 3011, 3019, 3023, 3037, 3041, 3049, 3061, 3067, 3079, 3083, 3089, 3109, 3119, 3121, 3137, 3163, 3167, 3169, 3181, 3187, 3191, 3203, 3209, 3217, 3221, 3229, 3251, 3253, 3257, 3259, 3271, 3299, 3301, 3307, 3313, 3319, 3323, 3329, 3331, 3343, 3347, 3359, 3361, 3371, 3373, 3389, 3391, 3407, 3413, 3433, 3449, 3457, 3461, 3463, 3467, 3469, 3491, 3499, 3511, 3517, 3527, 3529, 3533, 3539, 3541, 3547, 3557, 3559, 3571 };
        internal static readonly int[] primes = new int[] { 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151, 157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251, 257, 263, 269, 271, 277, 281, 283, 293, 307, 311, 313, 317, 331, 337, 347, 349, 353, 359, 367, 373, 379, 383, 389, 397, 401, 409, 419, 421, 431, 433, 439, 443, 449, 457, 461, 463, 467, 479, 487, 491, 499, 503, 509, 521, 523, 541, 547, 557, 563, 569, 571, 577, 587, 593, 599, 601, 607, 613, 617, 619, 631, 641, 643, 647, 653, 659, 661, 673, 677, 683, 691, 701, 709, 719, 727, 733, 739, 743, 751, 757, 761, 769, 773, 787, 797, 809, 811, 821, 823, 827, 829, 839, 853, 857, 859, 863, 877, 881, 883, 887, 907, 911, 919, 929, 937, 941, 947, 953, 967, 971, 977, 983, 991, 997, 1009, 1013, 1019, 1021, 1031, 1033, 1039, 1049, 1051, 1061, 1063, 1069, 1087, 1091, 1093, 1097, 1103, 1109, 1117, 1123, 1129, 1151, 1153, 1163, 1171, 1181, 1187, 1193, 1201, 1213, 1217, 1223, 1229, 1231, 1237, 1249, 1259, 1277, 1279, 1283, 1289, 1291, 1297, 1301, 1303, 1307, 1319, 1321, 1327, 1361, 1367, 1373, 1381, 1399, 1409, 1423, 1427, 1429, 1433, 1439, 1447, 1451, 1453, 1459, 1471, 1481, 1483, 1487, 1489, 1493, 1499, 1511, 1523, 1531, 1543, 1549, 1553, 1559, 1567, 1571, 1579, 1583, 1597, 1601, 1607, 1609, 1613, 1619, 1621, 1627, 1637, 1657, 1663, 1667, 1669, 1693, 1697, 1699, 1709, 1721, 1723, 1733, 1741, 1747, 1753, 1759, 1777, 1783, 1787, 1789, 1801, 1811, 1823, 1831, 1847, 1861, 1867, 1871, 1873, 1877, 1879, 1889, 1901, 1907, 1913, 1931, 1933, 1949, 1951, 1973, 1979, 1987 };

        public static int NthUglyNumber(int n) {
            int[] uglyes = new int[n];
            uglyes[0] = 1;
            int u2 = 0, u3 = 0, u5 = 0, ugly;
            for (int i = 1; i < n; i++) {
                int ugly2 = 2 * uglyes[u2], ugly3 = 3 * uglyes[u3], ugly5 = 5 * uglyes[u5];
                if (ugly2 <= ugly3) {
                    if (ugly2 <= ugly5) {
                        ugly = ugly2;
                    }
                    else {
                        ugly = ugly5;
                    }
                }
                else if (ugly3 <= ugly5) {
                    ugly = ugly3;
                }
                else {
                    ugly = ugly5;
                }
                if (ugly2 == ugly) {
                    u2++;
                }
                if (ugly3 == ugly) {
                    u3++;
                }
                if (ugly5 == ugly) {
                    u5++;
                }
                uglyes[i] = ugly;
            }
            return uglyes[^1];
        }

    }
}
