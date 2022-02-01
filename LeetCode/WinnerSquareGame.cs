using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /* 1510. Stone Game IV
         * 
         * Alice and Bob take turns playing a game, with Alice starting first.
         * Initially, there are n stones in a pile. 
         * On each player's turn, that player makes a move consisting of removing any non-zero square number of stones in the pile.
         * Also, if a player cannot make a move, he/she loses the game.
         * 
         * Given a positive integer n, return true if and only if Alice wins the game
         * otherwise return false, assuming both players play optimally.
         * Constraints:

    1 <= n <= 10^5

         */
        public static bool WinnerSquareGame(int n) {
            switch (n) {
                case 0:
                case 2:
                case 5:
                case 7:
                case 10:
                case 12:
                case 15:
                    return false;
                case 1:
                case 3:
                case 4:
                case 6:
                case 8:
                case 9:
                case 11:
                case 13:
                case 14:
                case 16:
                    return true;
                default:
                    break;
            }
            HashSet<int> losers = new(new int[] { 2, 5, 7, 10, 12, 15 });
            int step = 17, nextSquare = 5;
            int sq = nextSquare * nextSquare;
            while (true) {
                bool isFoundWinner = false;
                int i = 1;
                //while (i * i < step - firstSerieStep) {
                //    i++;
                //}
                for (; i < nextSquare; i++) {
                    if (losers.Contains(step - i * i)) {
                        if (step == n) {
                            return true;
                        }
                        isFoundWinner = true;
                        break;
                    }
                }
              
                if (sq > step) {
                    if (step == n) {
                        LogLosers(losers);
                        return isFoundWinner;
                    }
                }
                else {
                    if (sq == step) {
                        if (sq == n) {
                            return true;
                        }
                        isFoundWinner=true;
                        nextSquare++;
                        sq = nextSquare * nextSquare;
                    }
                }
                if (!isFoundWinner) {
                    losers.Add(step);
                }
                step++;

            }
        }
        private static void LogLosers(HashSet<int> losers) {
            StringBuilder sb = new();
            foreach (int i in losers) {
                sb.Append($"{i},");
            }
            Console.WriteLine(sb.ToString());

        }
    }
}
