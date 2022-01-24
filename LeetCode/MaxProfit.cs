using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * You are given an array prices where prices[i] is the price of a given stock on the ith day.
         * You want to maximize your profit by choosing a single day to buy one stock 
         * and choosing a different day in the future to sell that stock.
         * Return the maximum profit you can achieve from this transaction. 
         * If you cannot achieve any profit, return 0.
         * Constraints:

    1 <= prices.length <= 10^5
    0 <= prices[i] <= 10^4

         */
        public static int MaxProfit(int[] prices) {
            if (prices.Length < 2) {
                return 0;
            }
            else if (prices.Length == 2) {
                return prices[1] - prices[0] > 0 ? prices[1] - prices[0] : 0;
            }
            int dayToBuy = 0, dayToSell = 1;
            int lastDelta = prices[1] - prices[0], delta;

            int maxProfit = lastDelta, profit;
            for (int today = 2; today < prices.Length; today++) {
                delta = prices[today] - prices[today - 1];
                if (lastDelta > 0 & delta < 0) { // last day maybe the time to cell
                    dayToSell = today - 1;
                    for (int day = dayToBuy; day < dayToSell; day++) {
                        profit = prices[dayToSell] - prices[day];
                        if (profit > maxProfit) {
                            dayToBuy = day;
                            maxProfit = profit;
                        }
                    }
                }
                lastDelta = delta;
            }
            if (lastDelta>0) {
                dayToSell = prices.Length - 1;
                for (int day = dayToBuy; day < dayToSell; day++) {
                    profit = prices[dayToSell] - prices[day];
                    if (profit > maxProfit) {
                        maxProfit = profit;
                    }
                }
            }
            return maxProfit > 0 ? maxProfit : 0;
        }
    }
}
