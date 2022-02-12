using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{

    public static partial class Solution
    {
        /*
         * 120. Triangle
         * Medium
         * Given a triangle array, return the minimum path sum from top to bottom.
         * For each step, you may move to an adjacent number of the row below. 
         * More formally, if you are on index i on the current row, you may move to either index i or index i + 1 on the next row.
         * 
         * Constraints:

    1 <= triangle.length <= 200
    triangle[0].length == 1
    triangle[i].length == triangle[i - 1].length + 1
    -10^4 <= triangle[i][j] <= 10$4

         */
        public static int MinimumTotal(IList<IList<int>> triangle) {
            int m = triangle.Count;
            if (m == 1)
                return triangle[0][0];
            for (int i = m-2; i >0; i--) {
                var lvl = triangle[i];
                var nextlvl=triangle[i+1];
                for (int j = 0; j < lvl.Count; j++) {
                    lvl[j] = System.Math.Min(nextlvl[j], nextlvl[j+1]) + lvl[j];
                }
            }
            return System.Math.Min(triangle[1][0], triangle[1][1])+ triangle[0][0];
        }
    }
}
