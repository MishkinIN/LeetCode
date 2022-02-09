using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * 542. 01 Matrix
         * Medium
         * Given an m x n binary matrix mat, return the distance of the nearest 0 for each cell.
         * The distance between two adjacent cells is 1.
         * Constraints:

    m == mat.length
    n == mat[i].length
    1 <= m, n <= 10^4
    1 <= m * n <= 10^4
    mat[i][j] is either 0 or 1.
    There is at least one 0 in mat.

         */
        public static int[][] UpdateMatrix(int[][] mat) {
            int m = mat.Length;
            int n = mat[0].Length;
            if (m < 3 & n < 3)
                return mat;
            List<(int, int)> current = new(), next = new();
            int i = 0, j, dist = 1;
            u_matrix = new bool[m, n];
            foreach (var row in mat) {
                j = 0;
                foreach (var val in row) {
                    if (val == 0) {
                        u_matrix[i, j] = true;
                        UpdateNeigbours(mat, current, (i, j), val: dist);
                    }
                    j++;
                }
                i++;
            }
            while (current.Count>0) {
                dist++;
                next.Clear();
                foreach (var cell in current) {

                    UpdateNeigbours(mat, next, cell, val: dist);
                }
                var tmp = current;
                current = next;
                next = tmp;
            }
            return mat;
        }

        private static void UpdateNeigbours(int[][] mat, List<(int, int)> current, (int i, int j) cell, int val) {
            var (i, j) = cell;
            int row = i - 1, col = j;
            if (row >= 0 && !u_matrix[row,col] && mat[row][col]==1) {
                mat[row][col] = val;
                current.Add((row,col));
                u_matrix[row, col] = true;
            }
            row = i + 1;
            if (row < mat.Length && !u_matrix[row, col] && mat[row][col] == 1) {
                mat[row][col] = val;
                current.Add((row, col));
                u_matrix[row, col] = true;
            }
            row = i; col = j - 1;
            if (col >= 0 && !u_matrix[row, col] && mat[row][col] == 1) {
                mat[row][col] = val;
                current.Add((row, col));
                u_matrix[row, col] = true;
            }
            col = j + 1;
            if (col < mat[0].Length && !u_matrix[row, col] && mat[row][col] == 1) {
                mat[row][col] = val;
                current.Add((row, col));
                u_matrix[row, col] = true;
            }
        }
        private static bool[,] u_matrix;
     }
}
