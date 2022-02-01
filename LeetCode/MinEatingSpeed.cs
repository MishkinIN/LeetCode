using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{

    public static partial class Solution
    {
        /*        875. Koko Eating Bananas
         *        Medium
         * Koko loves to eat bananas. There are n piles of bananas,
         * the ith pile has piles[i] bananas. The guards have gone and will come back in h hours.
         * Koko can decide her bananas-per-hour eating speed of k. 
         * Each hour, she chooses some pile of bananas and eats k bananas from that pile.
         * If the pile has less than k bananas, she eats all of them instead 
         * and will not eat any more bananas during this hour.
         * Koko likes to eat slowly but still wants to finish eating all the bananas
         * before the guards return.
         * 
         * Return the minimum integer k such that she can eat all the bananas within h hours.
         Constraints:

  
    1 <= piles.length <= 10^4
    piles.length <= h    <= 10^9
    1 <= piles[i] <= 10^9

*/
        public static (int MinEatingSpeed, int stepCount) MinEatingSpeed(int[] piles, int h) {
            int maxpile = 0;
            double totalBananas = 0;
            int pilesLength = piles.Length;
            foreach (var pileCount in piles) {
                totalBananas += pileCount;
                maxpile = maxpile > pileCount ? maxpile : pileCount;
            }
            if (h==pilesLength) {
                return (maxpile,1);
            }
            int kMax = (int)System.Math.Min(maxpile, (totalBananas - pilesLength) / (h - pilesLength) + 1);
            int kMin = (int)System.Math.Max(1, (totalBananas-pilesLength) / h);
            if (kMin==kMax) {
                return (kMin, 1);
            }
            int stepcount = 0;
            while (kMin+1<kMax) {
                stepcount++;
                int center = (kMin + kMax) / 2;
                if (IsFhMoreThan_H(piles, (UInt64)h, center)) {
                    kMin = center;
                }
                else
                    kMax = center;
            }
            return (kMax, stepcount);
        }
        private static bool IsFhMoreThan_H(int[] piles, UInt64 h, int k) {
            UInt64 _h = (UInt64)piles.Length;
            foreach (var pile in piles) {
                _h += (UInt64)((pile - 1) / k);
                if (_h>h) {
                    return true;
                }
            }
            return false;
            
        }
        public static bool hoursOK(int[] piles, int k, int h) {
            int total = 0;
            foreach (int pile in piles) {
                total += (pile + k - 1) / k;
                if (total > h) { return false; }
            }
            return true;
        }

        public static (int MinEatingSpeed, int stepCount) MinEatingSpeed_LeetCode(int[] piles, int h) {
            long sum = 0;
            int b = 0;
            foreach (int pile in piles) {
                sum += pile;
                b = System.Math.Max(b, pile);
            }
            int a = (int)((sum + h - 1) / h);
            b = System.Math.Min(b, (int)((sum - piles.Length) / (h - piles.Length + 1)) + piles.Length);
            int stepcount = 0;

            while (a < b) {
                stepcount++;
                int half = (a + b) >> 1;
                if (hoursOK(piles, half, h)) {
                    b = half;
                }
                else {
                    a = half + 1;
                }
            }
            return (a, stepcount);
        }
    }
}
