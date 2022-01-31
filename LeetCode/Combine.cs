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
            if (k == 1) {
                List<IList<int>> lists = new();
                for (int i = 0; i < n; i++) {
                    var list = new List<int> { i + 1 };
                    lists.Add(list);
                }
                return lists;
            }
            else {
                var lists = Combine(n, k - 1);
                for (int i = lists.Count - 1; i > -1; i--) {
                    var list = lists[i];
                    if (list[k - 2] == n) {
                        lists.Remove(list);
                        continue;
                    }
                    for (int j = list[k - 2]+1; j < n; j++) {
                        var lst = new List<int>(list) { j };
                        lists.Add(lst);
                    }
                    list.Add(n);
                }
                return lists;
            }
        }

    }
}
