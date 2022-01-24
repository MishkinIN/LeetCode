using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         566. Reshape the Matrix
        Easy
        In MATLAB, there is a handy function called reshape which can reshape an m x n matrix into a new one
        with a different size r x c keeping its original data.
        You are given an m x n matrix mat and two integers r and c representing the number of rows
        and the number of columns of the wanted reshaped matrix.
        The reshaped matrix should be filled with all the elements of the original matrix
        in the same row-traversing order as they were.
        If the reshape operation with given parameters is possible and legal, 
        output the new reshaped matrix; Otherwise, output the original matrix.
        Constraints:

    m == mat.length
    n == mat[i].length
    1 <= m, n <= 100
    -1000 <= mat[i][j] <= 1000
    1 <= r, c <= 300

         */
        public static int[][] MatrixReshape(int[][] mat, int r, int c) {
            if (r * c == 0) {
                return mat;
            }
            int[][] res = new int[r][];
            var cursor = All(mat).GetEnumerator();
            for (int i = 0; i < r; i++) {
                var row = new int[c];
                res[i] = row;
                for (int j = 0; j < c; j++) {
                    if (cursor.MoveNext()) {
                        row[j] = cursor.Current;
                    }
                    else
                        return mat;
                }

            }
            if (cursor.MoveNext()) {
                return mat;
            }
            else
                return res;
        }
        public static IEnumerable<int> All(int[][] mat) {
            foreach (var row in mat) {
                foreach (var val in row) {
                    yield return val;
                }
            }
        }
    }
}
