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
        public static int[][] UpdateMatrix1(int[][] mat) {
            var m = mat.Length;
            var n = mat[0].Length;
            mask = mat;
            matrix = new int[m][];
            for (int i = 0; i < m; i++) {
                matrix[i] = new int[n];
            }
            u_matrix = new bool[m, n];
            for (int row = 0; row < m; row++) {
                for (int col = 0; col < n; col++) {
                    if (mat[row][col] == 0 && !u_matrix[row, col]) {
                        Wave(row, col, 0);
                    }
                }
            }
            return matrix;
        }
        public static int[][] UpdateMatrix(int[][] mat) {
            int dist = 0;
            matrix = mat;
            for (int row = 0; row < matrix.Length; row++) {
                for (int col = 0; col < matrix[0].Length; col++) {
                    if (matrix[row][col] == 1) {
                        matrix[row][col] = int.MaxValue;
                    }
                }
            }
            for (int row = 0; row < matrix.Length; row++) {
                for (int col = 0; col < matrix[0].Length; col++) {
                    if (matrix[row][col] == 0) {
                        if (row - 1 >= 0) {
                            Wave1(row - 1, col, dist + 1);
                        }
                        if (col - 1 >= 0) {
                            Wave1(row, col - 1, dist + 1);
                        }
                        if (row + 1 < matrix.Length) {
                            Wave1(row + 1, col, dist + 1);
                        }
                        if (col + 1 < matrix[0].Length) {
                            Wave1(row, col + 1, dist + 1);
                        }
                    }
                }
            }
            return matrix;
        }
        private static void Wave1(int row, int col, int dist) {
            if (matrix[row][col] > dist) {
                matrix[row][col] = dist;
                if (row - 1 >= 0) {
                    Wave1(row - 1, col, dist + 1);
                }
                if (col - 1 >= 0) {
                    Wave1(row, col - 1, dist + 1);
                }
                if (row + 1 < matrix.Length) {
                    Wave1(row + 1, col, dist + 1);
                }
                if (col + 1 < matrix[0].Length) {
                    Wave1(row, col + 1, dist + 1);
                }
            }
        }
        private static int[][] mask;
        private static int[][] matrix;
        private static bool[,] u_matrix;
        private static void Wave(int sr, int sc, int dist) {
            if (u_matrix[sr, sc]) {
                if (matrix[sr][sc] <= dist) {
                    return;
                }
                matrix[sr][sc] = dist;
            }
            else {
                if (mask[sr][sc] == 0) {
                    dist = 0;
                }
                else
                    matrix[sr][sc] = dist;
                u_matrix[sr, sc] = true;
            }
            if (sr - 1 >= 0) {
                Wave(sr - 1, sc, dist + 1);
            }
            if (sc - 1 >= 0) {
                Wave(sr, sc - 1, dist + 1);
            }
            if (sr + 1 < matrix.Length) {
                Wave(sr + 1, sc, dist + 1);
            }
            if (sc + 1 < matrix[0].Length) {
                Wave(sr, sc + 1, dist + 1);
            }
        }
    }
}
