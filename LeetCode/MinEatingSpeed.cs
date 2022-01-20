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
        public static int MinEatingSpeed(int[] piles, int h) {
            int maxpile = 0;
            Int64 totalBananas = 0;
            int pilesLength = piles.Length;
            foreach (var pileCount in piles) {
                totalBananas += pileCount;
                maxpile = maxpile > pileCount ? maxpile : pileCount;
            }
            if (h==pilesLength) {
                return maxpile;
            }
            int kMax = (int)Math.Min(maxpile, (totalBananas - pilesLength) / (h - pilesLength) + 1);
            int kMin = (int)Math.Max(1, (totalBananas-pilesLength) / h);
            if (kMin==kMax) {
                return kMin;
            }
            //Func<int, int> Fh = k => {
            //    int h = 0;
            //    foreach (var item in piles) {
            //        h += (item-1) / k;
            //    }
            //    h += pilesLength;
            //    return h;
            //};
            while (kMin+1<kMax) {
                int center = (kMin + kMax) / 2;
                int hc = Fh(piles, center);
                if (hc > h) {
                    kMin = center;
                }
                else
                    kMax = center;
            }
            return kMax;
        }
        private static int Fh(int[] piles, int k) {
            int h = 0;
            foreach (var pile in piles) {
                h += (pile - 1) / k;
            }
            h += piles.Length;
            return h;

        }
    }
}
