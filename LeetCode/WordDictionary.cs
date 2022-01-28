using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    /*
     * 211. Design Add and Search Words Data Structure
     * Medium
     * Design a data structure that supports adding new words and finding if a string
     * matches any previously added string.
     * Implement the WordDictionary class:
    WordDictionary() Initializes the object.
    void addWord(word) Adds word to the data structure, it can be matched later.
    bool search(word) Returns true if there is any string in the data structure that matches word or false otherwise. word may contain dots '.' where dots can be matched with any letter.
     *
     *Constraints:

    1 <= word.length <= 500
    word in addWord consists lower-case English letters.
    word in search consist of  '.' or lower-case English letters.
    At most 50000 calls will be made to addWord and search.


     */
    public partial class WordDictionary {
        private class DicNode {
            public static readonly DicNode EndOfWord = new DicNode();
            public Dictionary<char, DicNode> Nexts = new();
        }
        public const char CR = '\r';
        public const char Dot = '.';
        private DicNode words = new DicNode();
        public WordDictionary() {
        }

        public void AddWord(string word) {
            var node = words;
            foreach (var ch in word) {
                if (!node.Nexts.ContainsKey(ch)) {
                    node.Nexts[ch] = new DicNode();
                }
                node = node.Nexts[ch];
            }
            node.Nexts[CR] = DicNode.EndOfWord;
        }

        public bool Search(string word) {
            return Search(words, word, start:0);

        }
        private bool Search(DicNode node, string word, int start) {
            for (int i = start; i < word.Length; i++) {
                var ch = word[i];
                if (ch == Dot) {
                    foreach (var nextNode in node.Nexts.Values) {
                        if (Search(nextNode, word, i+1)) {
                            return true;
                        }
                    }
                    return false;
                }
                else {
                    if (node.Nexts.ContainsKey(ch)) {
                        node = node.Nexts[ch];
                    }
                    else
                        return false;
                }
            }
            return node.Nexts.ContainsKey(CR);

        }
    }
}
