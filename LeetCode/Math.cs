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
             return _Fib(n).fib;
        }
        private static (int fib, int prev) _Fib( int n) {
            switch (n) {
                case 0:
                    return (0, 0) ;
                case 1:
                    return (1,0);
                default:
                    var prev = _Fib( n - 1);
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
            return _Tribonacci(n).n2;
        }
        private static (int n, int n1, int n2) _Tribonacci(int n) {
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
                    var p = _Tribonacci(n - 1);
                    return (p.n1, p.n2 , p.n+p.n1+p.n2);
            }
        }
    }
}
