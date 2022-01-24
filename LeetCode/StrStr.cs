using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static partial class Solution
    {
        /*
        Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack
         */

        public static int StrStr(string haystack, string needle)
        {
            int retcode, nCursor;
            if (needle.Length == 0)
            {
                return 0;
            }
            if (haystack.Length - needle.Length < 0)
                return -1;
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
            {
                if (haystack[i] == needle[0])
                {
                    retcode = i;
                    nCursor = 1;
                    while (nCursor < needle.Length && haystack[i+nCursor] == needle[nCursor])
                    {
                        nCursor++;
                    }
                    if (nCursor == needle.Length)
                        return retcode;
                }
            }
            return -1;
            
        }

        public static void ReverseString(char[] s) {
            char acc;
            int left = 0, right = s.Length;
            for (left = 0; left < right; left++) {
                acc = s[left];
                s[left] = s[--right];
                s[right] = acc;
            }
        }
        public static string ReverseWords(string s) {
            StringBuilder sb = new();
            var space = "";
            foreach (string word in Split(s, ' ')) {
                sb.Append(space);
                space = " ";
                for (int i = word.Length-1; i >=0 ; i--) {
                    sb.Append(word[i]);
                }
            }
            return sb.ToString();
        }
        private static IEnumerable<string> Split(string s, char sep) {
            int startWord = 0, length = 0;
            for (int i = 0; i < s.Length; i++) {
                if (s[i] == sep) {
                    yield return s.Substring(startWord, length);
                    startWord = i + 1;
                    length = -1;
                }
                length++;
            }
            yield return s.Substring(startWord, length);
        }
        public static int FirstUniqChar(string s) {
            HashSet<char> duplicatesChars = new();
            List<int> charPos = new();
            int i = 0;
            foreach (var ch in s) {
                if (!duplicatesChars.Contains(ch)) {
                    bool foundCh = false;
                    foreach (var pos in charPos) {
                        if (s[pos]==ch) {
                            charPos.Remove(pos);
                            duplicatesChars.Add(ch);
                            foundCh = true;
                            break;
                        }
                    }
                    if (!foundCh) {
                        charPos.Add(i);
                    }
                }
                i++;
            }
            if (charPos.Count > 0) {
                return charPos[0];
            }
            else
                return -1;
        }
        public static int FirstUniqChar_I(string s) {
            int[] pos = new int[26];

            for (int i = 0; i < s.Length; i++) {
                int p = s[i] - 'a';
                if (pos[p]==0) {
                    pos[p] = i+1;
                }
                else if (pos[p]< int.MaxValue) {
                    pos[p] = int.MaxValue;
                }
            }
            int minPos = int.MaxValue;
            foreach (var p in pos) {
                if (p>0) {
                    minPos = p < minPos ? p : minPos;
                }
            }
            return minPos == int.MaxValue ? -1 : minPos-1;
           
        }
        /*
         * Given two strings ransomNote and magazine, 
         * return true if ransomNote can be constructed from magazine and false otherwise.
         * Each letter in magazine can only be used once in ransomNote.
         * Constraints:

    1 <= ransomNote.length, magazine.length <= 10^5
    ransomNote and magazine consist of lowercase English letters.

         */
        public static bool CanConstruct(string ransomNote, string magazine) {
            if (ransomNote.Length>magazine.Length) {
                return false;
            }
            int charCount = ransomNote.Length;
            int[] chars = new int[26];
            foreach (var ch in ransomNote) {
                chars[ch - 'a']++;
            }
            foreach (var ch in magazine) {
                if (chars[ch-'a']>0) {
                    chars[ch - 'a']--;
                    charCount--;
                    if (charCount==0) {
                        return true;
                    }
                }
            }
            return false;
        }
        /*
         * Given two strings s and t, return true if t is an anagram of s, 
         * and false otherwise.
         * An Anagram is a word or phrase formed by rearranging the letters 
         * of a different word or phrase, typically using all the original letters exactly once.
         * Constraints:

    1 <= s.length, t.length <= 5 * 10^4
    s and t consist of lowercase English letters.

         */
        public static bool IsAnagram(string s, string t) {
            if (s.Length > t.Length) {
                return false;
            }
            int charCount = s.Length;
            int[] chars = new int[26];
            foreach (var ch in s) {
                chars[ch - 'a']++;
            }
            foreach (var ch in t) {
                chars[ch - 'a']--;
            }
            foreach (var item in chars) {
                if (item!=0) {
                    return false;
                }
            }
            return true;
        }
    }
}
