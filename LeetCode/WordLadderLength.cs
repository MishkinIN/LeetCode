using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * 127. Word Ladder
         * Hard
         * A transformation sequence from word beginWord to word endWord using a dictionary wordList 
         * is a sequence of words beginWord -> s1 -> s2 -> ... -> sk such that:
         * Every adjacent pair of words differs by a single letter.
         * Every si for 1 <= i <= k is in wordList. Note that beginWord does not need to be in wordList.
         * sk == endWord
         * Given two words, beginWord and endWord, and a dictionary wordList, 
         * return the number of words in the shortest transformation sequence from beginWord to endWord, or 0 if no such sequence exists.
         * 
         * Constraints:

    1 <= beginWord.length <= 10
    endWord.length == beginWord.length
    1 <= wordList.length <= 5000
    wordList[i].length == beginWord.length
    beginWord, endWord, and wordList[i] consist of lowercase English letters.
    beginWord != endWord
    All the words in wordList are unique.


         */

        public static int LadderLength(string beginWord, string endWord, IList<string> wordList) {
            if (beginWord == endWord)
                return 1;
            HashSet<UInt64>[] words = new HashSet<UInt64>[10];
            int i;
            for (i = 0; i < 10; i++) { words[i] = new HashSet<ulong>(); }
            var bw = Convert(beginWord);
            var ew=Convert(endWord);
            Queue<ulong> queue = new Queue<ulong>();
            foreach (var s in wordList) {
                var w = Convert(s);
                var dist = Distance(bw, w);
                if (dist == 1) {
                    queue.Enqueue(w);
                }
                {
                    words[dist].Add(w);
                }
            }
            if (!words[Distance(bw, ew)].Contains(ew)) { return 0; }
            else if (Distance(bw, ew) == 1) { return 2; }
            words[0].Clear();
            words[1].Clear();
            int stepCount = queue.Count;
            int step = 2;
            while (stepCount > 0) {
                var w= queue.Dequeue();
                var w_dist = Distance(bw, w);
                if (w == ew)
                    return step + 1;
                foreach (var nextWord in words[w_dist - 1]) {
                    if (Distance(w, nextWord) == 1) {
                        if (nextWord == ew)
                            return step + 1;
                        queue.Enqueue(nextWord);
                        words[w_dist - 1].Remove(nextWord);
                    }
                }
                foreach (var nextWord in words[w_dist]) {
                    if (Distance(w, nextWord) == 1) {
                        if (nextWord == ew)
                            return step + 1;
                        queue.Enqueue(nextWord);
                        words[w_dist].Remove(nextWord);
                    }
                }
                foreach (var nextWord in words[w_dist + 1]) {
                    if (Distance(w, nextWord) == 1) {
                        if (nextWord == ew)
                            return step + 1;
                        queue.Enqueue(nextWord);
                        words[w_dist + 1].Remove(nextWord);
                    }
                }

                if (--stepCount == 0) {
                    stepCount = queue.Count;
                    step++;
                }
            }
            return 0;
        }
        /// <summary>
        /// Represent word as bitmask
        /// </summary>
        /// <param name="s">Word</param>
        /// <remarks>Word.length <= 10, Word consist of lowercase English letters</remarks>
        /// <returns></returns>
        internal static UInt64 Convert(string s) {
            // System.Diagnostics.Debug.Assert(s.Length < 11);
            UInt64 result = 0;
            foreach (var ch in s) {
                result <<= 5;
                result |= (UInt64)(ch - 'A') & 0x1f;
            }
            return result;
        }
        internal static int Distance(UInt64 w1, UInt64 w2) {
            int result = 0;
            var xor = w1 ^ w2;
            ulong mask = 0b00001000010000100001000010000100001000010000100001;
            var diff = xor & mask;
            xor >>= 1;
            diff = diff | (xor & mask);
            xor >>= 1;
            diff = diff | (xor & mask);
            xor >>= 1;
            diff = diff | (xor & mask);
            xor >>= 1;
            diff = diff | (xor & mask);

            result += (int)diff & 0x1;
            diff >>= 5;
            result += (int)diff & 0x1;
            diff >>= 5;
            result += (int)diff & 0x1;
            diff >>= 5;
            result += (int)diff & 0x1;
            diff >>= 5;
            result += (int)diff & 0x1;
            diff >>= 5;
            result += (int)diff & 0x1;
            diff >>= 5;
            result += (int)diff & 0x1;
            diff >>= 5;
            result += (int)diff & 0x1;
            diff >>= 5;
            result += (int)diff & 0x1;
            diff >>= 5;
            result += (int)diff & 0x1;

            return result;
        }
    }
}
