using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * 36. Valid Sudoku
         * Medium
         * 
         * Determine if a 9 x 9 Sudoku board is valid. 
         * Only the filled cells need to be validated according to the following rules:
         * Each row must contain the digits 1-9 without repetition.
         * Each column must contain the digits 1-9 without repetition.
         * Each of the nine 3 x 3 sub-boxes of the grid must contain the digits 1-9 without repetition.
        Note:

    A Sudoku board (partially filled) could be valid but is not necessarily solvable.
    Only the filled cells need to be validated according to the mentioned rules.
        
        Constraints:

    board.length == 9
    board[i].length == 9
    board[i][j] is a digit 1-9 or '.'.

         */
        internal const ulong _0 = 0x0;
        internal const ulong _1 = 0x1;
        internal const ulong _2 = 0x10;
        internal const ulong _3 = 0x100;
        internal const ulong _4 = 0x1000;
        internal const ulong _5 = 0x10000;
        internal const ulong _6 = 0x100000;
        internal const ulong _7 = 0x1000000;
        internal const ulong _8 = 0x10000000;
        internal const ulong _9 = 0x100000000;
        internal static ulong Convert(char ch) {
            int n = ch - '1';
            if (n >= 0 & n < 10) {
                return 1UL << n * 4;
            }
            return 0;
        }
        internal static ulong Convert_I(char ch) {
            return ch switch {
                '1' => _1,
                '2' => _2,
                '3' => _3,
                '4' => _4,
                '5' => _5,
                '6' => _6,
                '7' => _7,
                '8' => _8,
                '9' => _9,
                _ => _0,
            };
        }
        private static ulong uniqueMask = ~(Convert('1')
                             + Convert('2')
                             + Convert('3')
                             + Convert('4')
                             + Convert('5')
                             + Convert('6')
                             + Convert('7')
                             + Convert('8')
                             + Convert('9'));
        public static bool IsValidSudoku(char[][] board) {
            
            ulong[] sumColumns = new ulong[9];
            ulong[] sumBoxes = new ulong[9];
            char[] row;

            for (int rowInd = 0; rowInd < 9; rowInd++) {
                int boxRow = rowInd / 3;
                row = board[rowInd];
                ulong s_row = 0;
                for (int boxCol = 0; boxCol < 3; boxCol++) {
                    int boxInd = boxRow * 3 + boxCol;
                    ulong s_box = sumBoxes[boxInd];
                    ulong ch;
                    int colInd = boxCol * 3;
                    {
                        ch = Convert(row[colInd]);
                        sumColumns[colInd] = sumColumns[colInd] + ch;
                        s_box += ch;
                        s_row += ch;
                    }
                    {
                        ch = Convert(row[colInd + 1]);
                        sumColumns[colInd + 1] = sumColumns[colInd + 1] + ch;
                        s_box += ch;
                        s_row += ch;
                    }
                    {
                        ch = Convert(row[colInd + 2]);
                        sumColumns[colInd + 2] = sumColumns[colInd + 2] + ch;
                        s_box += ch;
                        s_row += ch;
                    }
                    if ((rowInd % 3 == 2)
                        && ((s_box & uniqueMask) != 0 )) {
                        return false;
                    }

                    sumBoxes[boxInd] = s_box;
                }
                if ((s_row & uniqueMask) != 0 )
                    return false;
               
            }

            bool isColumnsHaveRepetition =
                (sumColumns[0] & uniqueMask
                | sumColumns[1] & uniqueMask
                | sumColumns[2] & uniqueMask
                | sumColumns[3] & uniqueMask
                | sumColumns[4] & uniqueMask
                | sumColumns[5] & uniqueMask
                | sumColumns[6] & uniqueMask
                | sumColumns[7] & uniqueMask
                | sumColumns[8] & uniqueMask)
                != 0;
            
            return !isColumnsHaveRepetition;
        }
    }
}
