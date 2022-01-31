using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static partial class Solution {
        /*
         * 1672. Richest Customer Wealth
         * Easy
         * You are given an m x n integer grid accounts where accounts[i][j] is the amount of money the i​​​​​​​​​​​th​​​​ customer has in the j​​​​​​​​​​​th​​​​ bank.
         * Return the wealth that the richest customer has.
         * A customer's wealth is the amount of money they have in all their bank accounts.
         * The richest customer is the customer that has the maximum wealth.
         * Constraints:

        m == accounts.length
        n == accounts[i].length
        1 <= m, n <= 50
        1 <= accounts[i][j] <= 100

        */
        public static int MaximumWealth(int[][] accounts) {
            int maxWealth = 0;
            foreach (var cust in accounts) {
                var custWealth = cust.Sum();
                maxWealth = Math.Max(maxWealth, custWealth);
            }
            return maxWealth;
        }
    }
}
