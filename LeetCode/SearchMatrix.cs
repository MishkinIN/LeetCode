using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * 74. Search a 2D Matrix
         * Medium
         * Write an efficient algorithm that searches for a value in an m x n matrix.
         * This matrix has the following properties:
         * Integers in each row are sorted from left to right.
         * The first integer of each row is greater than the last integer of the previous row.
        Constraints:

    m == matrix.length
    n == matrix[i].length
    1 <= m, n <= 100
    -10^4 <= matrix[i][j], target <= 10^4


         */
        public static bool SearchMatrix(int[][] matrix, int target) {
            int indRow = GetTargetRow(matrix, target);
            if (indRow < 0) {
                return false;
            }
            return Array.BinarySearch(matrix[indRow], target) > 0;
        }
        private static int GetTargetRow(int[][] matrix, int target) {

            if (target < matrix[0][0]) {
                return -1;
            }
            int minInd = 0;
            if (target >= matrix[^1][0]) {
                return matrix.Length - 1;
            }
            int maxInd = matrix.Length - 1;
            while (minInd + 1 < maxInd) {
                int center = (maxInd + minInd) / 2;
                if (center == minInd) {
                    return center;
                }
                if (matrix[center][0] <= target) {
                    minInd = center;
                }
                else {
                    maxInd = center;
                }
            }
            return minInd;

        }
        public static bool SearchMatrix_I(int[][] matrix, int target) {
            SortedSet<int> set = new();
            foreach (var item in matrix) {
                set.UnionWith(item);
            }
            return set.Contains(target);
        }
    }
}
