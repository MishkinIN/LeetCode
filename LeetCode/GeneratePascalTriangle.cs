using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * 118. Pascal's Triangle
         * Easy
         * Given an integer numRows, return the first numRows of Pascal's triangle.
         * In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
         Constraints:

    1 <= numRows <= 30

         */
        public static IList<IList<int>> GeneratePascalTriangle(int numRows) {
            List<IList<int>> pt = new ();
            int[] lastrow = null;
            if (numRows > 0) {
                pt.Add(new List<int>(new int[] { 1 }));
            }
            if (numRows >1) {
                pt.Add(new List<int>(new int[] { 1, 1}));
            }
            if (numRows >2) {
                pt.Add(new List<int>(new int[] { 1, 2, 1}));
            }
            if (numRows >3) {
                lastrow = new int[] { 1, 3, 3, 1 };
                pt.Add(new List<int>(lastrow));
            }
            if (numRows>4) {
                for (int rowInd = 4; rowInd < numRows; rowInd++) {
                    var row = new int[rowInd+1];
                    row[0] = row[rowInd] = 1;
                    row[1] = row[rowInd - 1] = rowInd;
                    int rowCenter = (rowInd - 1) / 2+ (rowInd - 1) % 2;
                    for (int c = 2; c < rowCenter+1; c++) {
                        row[c] = row[rowInd - c] = lastrow[c - 1] + lastrow[c];
                    }
                    pt.Add(new List<int>(row));
                    lastrow = row;
                }
            }
            return pt;

        }

        /*
         * 119. Pascal's Triangle II
         * Easy
         * Given an integer rowIndex, return the rowIndexth (0-indexed) row of the Pascal's triangle.
         * In Pascal's triangle, each number is the sum of the two numbers directly above it as shown:
         * 
         * Constraints:

    0 <= rowIndex <= 33

         */
        public static IList<int> GetRow(int rowInd) {
            var row = new int[rowInd + 1];
            row[0] = row[rowInd] = 1;
            row[1] = row[rowInd - 1] = rowInd;
            int rowCenter = (rowInd - 1) / 2 + (rowInd - 1) % 2;
            for (int c = 2; c < rowCenter + 1; c++) {
                row[c] = row[rowInd - c] = GetCellValue(rowInd-1, c - 1) + GetCellValue(rowInd-1, c);
            }
            return row;
        }
        private static int GetCellValue(int rowInd, int index) {
            if (index == 1)
                return 1;
            if (index == 2)
                return rowInd;
            if (rowInd >3)
                return GetCellValue(rowInd - 1, index-1)+ GetCellValue(rowInd - 1, index);
            if (rowInd == 3 & (index == 1 | index == 2))
                return 3;
            if (rowInd == 2 & index == 1) {
                    return 2;
            }
            return 1;

        }
        public static IList<int> GetRow_I(int numRows) {
            List<IList<int>> pt = new();
            int[] lastrow = null;
            if (numRows > 0) {
                pt.Add(new List<int>(new int[] { 1 }));
            }
            if (numRows > 1) {
                pt.Add(new List<int>(new int[] { 1, 1 }));
            }
            if (numRows > 2) {
                pt.Add(new List<int>(new int[] { 1, 2, 1 }));
            }
            if (numRows > 3) {
                lastrow = new int[] { 1, 3, 3, 1 };
                pt.Add(new List<int>(lastrow));
            }
            if (numRows > 4) {
                for (int rowInd = 4; rowInd < numRows; rowInd++) {
                    var row = new int[rowInd + 1];
                    row[0] = row[rowInd] = 1;
                    row[1] = row[rowInd - 1] = rowInd;
                    int rowCenter = (rowInd - 1) / 2 + (rowInd - 1) % 2;
                    for (int c = 2; c < rowCenter + 1; c++) {
                        row[c] = row[rowInd - c] = lastrow[c - 1] + lastrow[c];
                    }
                    pt.Add(new List<int>(row));
                    lastrow = row;
                }
            }
            return pt[numRows-1];
            
        }
    }
}
