using System;
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
        private static (int fib, int prev) GetFib( int n) {
            switch (n) {
                case 0:
                    return (0, 0) ;
                case 1:
                    return (1,0);
                default:
                    var prev = GetFib( n - 1);
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
                    return (p.n1, p.n2 , p.n+p.n1+p.n2);
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
    }
}
