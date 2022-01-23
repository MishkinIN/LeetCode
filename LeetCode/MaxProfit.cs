using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    /*
     121. Best Time to Buy and Sell Stock
Easy

You are given an array prices where prices[i] is the price of a given stock on the ith day.

You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.

Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
    */
    public static partial class Solution
    {
        public static int MaxProfit(int[] prices) {
            if (prices.Length < 2) {
                return 0;
            }
            else if (prices.Length == 2) {
                return prices[1] - prices[0] > 0 ? prices[1] - prices[0] : 0;
            }
            int lastPriceToBuy= prices[0];
            int maxProfit = 0, profit;
            for (int today = 1; today < prices.Length; today++) {
                if (prices[today] < lastPriceToBuy) {
                    lastPriceToBuy = prices[today];
                }
                else {
                    profit = prices[today] - lastPriceToBuy;
                    if (profit > maxProfit) {
                        maxProfit = profit;
                    }
                }
            }
            return maxProfit > 0 ? maxProfit : 0;
        }
    }
}
