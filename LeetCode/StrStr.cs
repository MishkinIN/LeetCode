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
         * 28. Implement strStr()
         * Easy
         * Implement strStr().
         * Return the index of the first occurrence of needle in haystack, or -1 if needle is not part of haystack.
         * Clarification:
         * What should we return when needle is an empty string? This is a great question to ask during an interview.
         * For the purpose of this problem, we will return 0 when needle is an empty string. 
         * This is consistent to C's strstr() and Java's indexOf().
         * Constraints:

    0 <= haystack.length, needle.length <= 5 * 10^4
    haystack and needle consist of only lower-case English characters.

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

            int right = s.Length;

            int left;
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
        /*
         * 3. Longest Substring Without Repeating Characters
         * Medium
         * Given a string s, find the length of the longest substring without repeating characters.
         * Constraints:

    0 <= s.length <= 5 * 10^4
    s consists of English letters, digits, symbols and spaces.

         */
        public static int LengthOfLongestSubstring(string s) {
            if (s.Length<2) {
                return s.Length;
            }
            int ls = 0;
            int left =0, right = 1;
            SortedSet<char> chars = new();
            chars.Add(s[left]);
            while (right<s.Length) {
                if (chars.Contains(s[right])) {
                   ls = ls < right - left ? right - left : ls;
                   while (s[left] != s[right]) {
                        chars.Remove(s[left++]);
                    }
                    left++;
                }
                else {
                    chars.Add(s[right]);
                }
                right++;
            }
            ls = ls < right - left ? right - left : ls;
            return ls;
        }
        /*
         * 567. Permutation in String
         * Medium
         * Given two strings s1 and s2, return true if s2 contains a permutation of s1, or false otherwise.
         * In other words, return true if one of s1's permutations is the substring of s2.
         * Имея две строки s1 и s2, вернуть true, если s2 содержит перестановку s1, или false в противном случае.
         * Другими словами, вернуть true, если одна из перестановок s1 является подстрокой s2.
         * Constraints:

    1 <= s1.length, s2.length <= 10^4
    s1 and s2 consist of lowercase English letters.

         */
        public static bool CheckInclusion(string s1, string s2) {
            if (s1.Length > s2.Length) {
                return false;
            }
            int[] chars = new int[26];
            int start = 0, end = 0;
            for (; end < s1.Length; end++) {
                chars[s1[end] - 'a']++;
                chars[s2[end] - 'a']--;
            }
            if (AllDefault(chars)) {
                return true;
            }
            while (end < s2.Length) {
                chars[s2[end++] - 'a']--;
                chars[s2[start++] - 'a']++;
                if (AllDefault(chars)) {
                    return true;
                }
            }
            return false;
        }
        private static bool AllDefault(int[] nums) {
            return 
                nums[0] ==0 && nums[1]==0 && nums[2] ==0 && nums[3] ==0 && nums[4] ==0 && nums[5] ==0 && nums[6] ==0 && nums[7] ==0 && nums[8] ==0 && nums[9]
                ==0 && nums[10] ==0 && nums[11] ==0 && nums[12] ==0 && nums[13] ==0 && nums[14] ==0 && nums[15] ==0 && nums[16] ==0 && nums[17] ==0 && nums[18] ==0 && nums[19]
                ==0 && nums[20] ==0 && nums[21] ==0 && nums[22] ==0 && nums[23] ==0 && nums[24] ==0 && nums[25]== 0;
        }

    }
}
