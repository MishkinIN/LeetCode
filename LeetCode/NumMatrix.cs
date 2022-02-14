using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.net5 {
    /*
 * 304. Range Sum Query 2D - Immutable
 * Medium
 * Given a 2D matrix matrix, handle multiple queries of the following type:
 * Calculate the sum of the elements of matrix inside the rectangle 
 * defined by its upper left corner (row1, col1) and lower right corner (row2, col2).
 * 
 * Implement the NumMatrix class:
 * NumMatrix(int[][] matrix) Initializes the object with the integer matrix matrix.
 * int sumRegion(int row1, int col1, int row2, int col2) 
 * Returns the sum of the elements of matrix inside the rectangle 
 * defined by its upper left corner (row1, col1) and lower right corner (row2, col2).
 * 
 * Constraints:

m == matrix.length
n == matrix[i].length
1 <= m, n <= 200
-10^5 <= matrix[i][j] <= 10^5
0 <= row1 <= row2 < m
0 <= col1 <= col2 < n
At most 10^4 calls will be made to sumRegion.
 */

    public class NumMatrix {
        private readonly int[][] sums;
        private readonly int m;
        private readonly int n;

        public NumMatrix(int[][] matrix) {
            m = matrix.Length;
            n = matrix[0].Length;
            sums = new int[m][];
            for (int i = 0; i < m; i++) {
                sums[i] = new int[n];
            }
            {
                int i = 0;
                foreach (var row in matrix) {
                    int sum = 0;
                    int j = 0;
                    foreach (var val in row) {
                        sum += val;
                        sums[i][j++] = sum;
                    }
                    i++;
                }
                for (int j = 0; j < n; j++) {
                    int sum = 0;
                    for (i = 0; i < m; i++) {
                        sum += sums[i][j];
                        sums[i][j] = sum;
                    }
                }
            }
        }
        public int SumRegion(int row1, int col1, int row2, int col2) {
            int min_i_Index = row1 - 1;
            int min_j_index = col1 - 1;
            int div = min_i_Index >= 0 & min_j_index >= 0 ? sums[min_i_Index][min_j_index]
                : 0;
            int div1 = min_j_index >= 0 ? sums[row2][min_j_index]
                : 0;
            int div2 = min_i_Index >= 0 ? sums[min_i_Index][col2]
                : 0;
            return sums[row2][col2] - div1 - div2 + div;
        }
    }
}
