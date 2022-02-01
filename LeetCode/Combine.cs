using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {

    public static partial class Solution {
        /*
         * 77. Combinations
         * Medium
         * Given two integers n and k, return all possible combinations of k numbers out of the range [1, n].
         * You may return the answer in any order.
         * Constraints:

    1 <= n <= 20
    1 <= k <= n
         
         */
        public static IList<IList<int>> Combine(int n, int k) {
            List<IList<int>> lists = new();
            int[] vs = new int[k];
            Combine(lists, vs, n, k);
            return lists;
        }
        private static void Combine(List<IList<int>> lists, int[] vs, int n, int k) {
            if (k == 1) {
                for (int i = 1; i < n + 1; i++) {
                    vs[0] = i;
                    lists.Add(new List<int>(vs));
                }
            }
            else {
                for (int i = k; i < n+1; i++) {
                    vs[k-1] = i;
                    Combine(lists, vs, i-1, k-1);
                }
            }
        }
    }
}
