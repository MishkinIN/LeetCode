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
         * 994. Rotting Oranges
         * Medium
         * You are given an m x n grid where each cell can have one of three values:
         * 0 representing an empty cell,
         * 1 representing a fresh orange, or
         * 2 representing a rotten orange.
         * Every minute, any fresh orange that is 4-directionally adjacent to a rotten orange becomes rotten.
         * Return the minimum number of minutes that must elapse 
         * until no cell has a fresh orange. 
         * If this is impossible, return -1.
         * Constraints:

    m == grid.length
    n == grid[i].length
    1 <= m, n <= 10
    grid[i][j] is 0, 1, or 2.


         */
        private const int maxGridLenght = 32;
        public static int OrangesRotting(int[][] grid) {
            int m = grid.Length;
            int n = grid[0].Length;
            HashSet<int> fresh = new HashSet<int>(m*n);
            HashSet<int> rotten = new HashSet<int>(m*n);
            HashSet<int> vs;
            for (int i = 0; i < m; i++) {
                for (int j = 0; j < n; j++) {
                    if (grid[i][j]==1) {
                        fresh.Add(i* maxGridLenght + j);
                    }
                    else if (grid[i][j] == 2) {
                        rotten.Add(i* maxGridLenght + j);
                    }
                }
            }
            int timeInterval = 0;
            while (rotten.Count>0 && fresh.Count>0) {
                vs = new HashSet<int>(m * n);
                foreach (var item in rotten) {
                    int i = item / 32, j = item % 32;
                    if (fresh.Contains(item + maxGridLenght)) { 
                        vs.Add(item+32);
                        fresh.Remove(item + maxGridLenght);
                    }
                    if (fresh.Contains(item- maxGridLenght)) {
                        vs.Add(item- maxGridLenght);
                        fresh.Remove(item - maxGridLenght);
                    }
                    if (fresh.Contains(item+1)) {
                        vs.Add(item + 1);
                        fresh.Remove(item + 1);
                    }
                    if (fresh.Contains(item-1)) {
                        vs.Add(item - 1);
                        fresh.Remove(item -1 );
                    }
                }
                rotten = vs;
                timeInterval++;
            }
            return fresh.Count > 0 ? -1 : timeInterval;
        }
    }
}
