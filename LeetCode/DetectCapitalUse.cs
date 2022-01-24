using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * We define the usage of capitals in a word to be right when one of the following cases holds:

    All letters in this word are capitals, like "USA".
    All letters in this word are not capitals, like "leetcode".
    Only the first letter in this word is capital, like "Google".

Given a string word, return true if the usage of capitals in it is right.
         */
        public static bool DetectCapitalUse(string word) {
            if (word.Length<2) {
                return true;
            }
            if (Char.IsUpper(word, 0)) {
                if (Char.IsUpper(word, 1)) {
                    for (int i = 2; i < word.Length; i++) {
                        if (!Char.IsUpper(word, i)) {
                            return false;
                        }
                    }
                    return true;
                }
                else if (Char.IsLower(word, 1)) {
                    for (int i = 2; i < word.Length; i++) {
                        if (!Char.IsLower(word, i)) {
                            return false;
                        }
                    }
                    return true;

                }
            }
            else if (Char.IsLower(word, 0)) {
                    for (int i = 1; i < word.Length; i++) {
                        if (!Char.IsLower(word, i)) {
                            return false;
                        }
                    }
                    return true;
            }
            else
                throw new ArgumentOutOfRangeException();
            return false;
        }
    }
}
