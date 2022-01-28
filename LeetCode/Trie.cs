using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    /*
     * 208. Implement Trie (Prefix Tree)
     * Medium
     * A trie (pronounced as "try") or prefix tree is a tree data structure 
     * used to efficiently store and retrieve keys in a dataset of strings. 
     * There are various applications of this data structure, such as autocomplete and spellchecker.
     * Implement the Trie class:
     * Trie() Initializes the trie object.
     * void insert(String word) Inserts the string word into the trie.
     * boolean search(String word) Returns true if the string word is in the trie (i.e., was inserted before), and false otherwise.
     * boolean startsWith(String prefix) Returns true if there is a previously inserted string word that has the prefix prefix, and false otherwise.
     * 
     * Constraints:

    1 <= word.length, prefix.length <= 2000
    word and prefix consist only of lowercase English letters.
    At most 3 * 10^4 calls in total will be made to insert, search, and startsWith.

     */
    public class Trie {

        private record DicNode(string key) {
            public DicNode left { get; set; }
            public DicNode right { get; set; }
        }
        private DicNode root;
        public uint Count { get; private set; } = 0;
        public Trie() {

        }

        public void Insert(string word) {
            if (root == null) {
                root = new DicNode(word);
                Count++;
                return;
            }
            var node = root;
            while (true) {
                int comp = string.CompareOrdinal(node.key, word);
                if (comp == 0) {
                    return;
                }
                else if (comp > 0) {
                    if (node.left==null) {
                        node.left = new DicNode(word);
                        Count++;
                        return;
                    }
                    node = node.left;
                }
                else {
                    if (node.right==null) {
                        node.right= new DicNode(word);
                        Count++;
                        return;
                    }
                    node = node.right;
                }
            }
            
        }

        public bool Search(string word) {
            var node = root;
            if (root == null) {
                return false;
            }
            while (node!=null) {
                var comp = string.CompareOrdinal(node.key, word);
                if (comp == 0) {
                    return true;
                }
                else if (comp > 0) {
                    node = node.left;
                }
                else {
                    node = node.right;
                }
            }
            return false;
        }

        public bool StartsWith(string prefix) {
            var node = root;
            if (root == null) {
                return false;
            }
            while (node !=null) {
                if (node.key.StartsWith(prefix)) {
                    return true;
                }
                var comp = string.CompareOrdinal(node.key, prefix);
                if (comp == 0) {
                    return true;
                }
                else if (comp > 0) {
                    node = node.left;
                }
                else {
                    node = node.right;
                }
            }
            return false;
        }
    }
}
