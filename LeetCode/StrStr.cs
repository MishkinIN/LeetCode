﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
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

        public static int StrStr(string haystack, string needle) {
            int retcode, nCursor;
            if (needle.Length == 0) {
                return 0;
            }
            if (haystack.Length - needle.Length < 0)
                return -1;
            for (int i = 0; i < haystack.Length - needle.Length + 1; i++) {
                if (haystack[i] == needle[0]) {
                    retcode = i;
                    nCursor = 1;
                    while (nCursor < needle.Length && haystack[i + nCursor] == needle[nCursor]) {
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
        /*
         * 557. Reverse Words in a String III
         * Easy
         * Given a string s, reverse the order of characters in each word 
         * within a sentence while still preserving whitespace and initial word order.
         * 
         * Constraints:

    1 <= s.length <= 5 * 10^4
    s contains printable ASCII characters.
    s does not contain any leading or trailing spaces.
    There is at least one word in s.
    All the words in s are separated by a single space.
         */
        public static string ReverseWords(string s) {
            StringBuilder sb = new();
            var space = " ";
            var words = s.Split(' '); // Split(string s, char sep) is better
            foreach (string word in words) {
                for (int i = word.Length - 1; i >= 0; i--) {
                    sb.Append(word[i]);
                }
                sb.Append(space);
            }
            sb.Remove(sb.Length - 1, 1);
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
                        if (s[pos] == ch) {
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
                if (pos[p] == 0) {
                    pos[p] = i + 1;
                }
                else if (pos[p] < int.MaxValue) {
                    pos[p] = int.MaxValue;
                }
            }
            int minPos = int.MaxValue;
            foreach (var p in pos) {
                if (p > 0) {
                    minPos = p < minPos ? p : minPos;
                }
            }
            return minPos == int.MaxValue ? -1 : minPos - 1;

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
            if (ransomNote.Length > magazine.Length) {
                return false;
            }
            int charCount = ransomNote.Length;
            CharsBuffer chars = new();
            foreach (var ch in ransomNote) {
                chars.Add(ch);
            }
            foreach (var ch in magazine) {
                if (chars.Contain(ch)) {
                    chars.Remove(ch);
                    charCount--;
                    if (charCount == 0) {
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
            CharsBuffer chars = new();
            foreach (var ch in s) {
                chars.Add(ch);
            }
            foreach (var ch in t) {
                chars.Remove(ch);
            }
            return chars.AllDefault();
            
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
            if (s.Length < 2) {
                return s.Length;
            }
            int ls = 0;
            int left = 0, right = 1;
            SortedSet<char> chars = new();
            chars.Add(s[left]);
            while (right < s.Length) {
                if (!chars.Add(s[right])) {
                    ls = ls < right - left ? right - left : ls;
                    while (s[left] != s[right]) {
                        chars.Remove(s[left++]);
                    }
                    left++;
                }
                right++;
            }
            ls = ls < right - left ? right - left : ls;
            return ls;
        }
        public static int LengthOfLongestSubstring_I(string s) {
            if (s.Length < 2) {
                return s.Length;
            }
            int ls = 0;
            int left = 0, right = 1;
            SortedSet<char> chars = new();
            chars.Add(s[left]);
            while (right < s.Length) {
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

            CharsBuffer chars = new();
            int start = 0, end = 0;
            for (; end < s1.Length; end++) {
                chars.Add(s1[end]);
                chars.Remove(s2[end]);
            }
            if (chars.AllDefault()) {
                return true;
            }
            while (end < s2.Length) {
                chars.Remove(s2[end++]);
                chars.Add(s2[start++]);
                if (chars.AllDefault()) {
                    return true;
                }
            }
            return false;
        }
        private class CharsBuffer {
            int nums0 = 0, nums1 = 0, nums2 = 0, nums3 = 0, nums4 = 0, nums5 = 0, nums6 = 0, nums7 = 0, nums8 = 0, nums9 = 0
                , nums10 = 0, nums11 = 0, nums12 = 0, nums13 = 0, nums14 = 0, nums15 = 0, nums16 = 0, nums17 = 0, nums18 = 0, nums19 = 0
                , nums20 = 0, nums21 = 0, nums22 = 0, nums23 = 0, nums24 = 0, nums25 = 0;
            internal void Add(char ch) {
                switch (ch) {
                    case 'a':   nums0++;    break;
                    case 'b': nums1++; break;
                    case 'c': nums2++; break;
                    case 'd': nums3++; break;
                    case 'e': nums4++; break;
                    case 'f': nums5++; break;
                    case 'g': nums6++; break;
                    case 'h': nums7++; break;
                    case 'i': nums8++; break;
                    case 'j': nums9++; break;
                    case 'k': nums10++; break;
                    case 'l': nums11++; break;
                    case 'm': nums12++; break;
                    case 'n': nums13++; break;
                    case 'o': nums14++; break;
                    case 'p': nums15++; break;
                    case 'q': nums16++; break;
                    case 'r': nums17++; break;
                    case 's': nums18++; break;
                    case 't': nums19++; break;
                    case 'u': nums20++; break;
                    case 'v': nums21++; break;
                    case 'w': nums22++; break;
                    case 'x': nums23++; break;
                    case 'y': nums24++; break;
                    case 'z': nums25++; break;
                    default:
                        break;
                }
            }
            internal void Remove(char ch) {
                switch (ch) {
                    case 'a': nums0--; break;
                    case 'b': nums1--; break;
                    case 'c': nums2--; break;
                    case 'd': nums3--; break;
                    case 'e': nums4--; break;
                    case 'f': nums5--; break;
                    case 'g': nums6--; break;
                    case 'h': nums7--; break;
                    case 'i': nums8--; break;
                    case 'j': nums9--; break;
                    case 'k': nums10--; break;
                    case 'l': nums11--; break;
                    case 'm': nums12--; break;
                    case 'n': nums13--; break;
                    case 'o': nums14--; break;
                    case 'p': nums15--; break;
                    case 'q': nums16--; break;
                    case 'r': nums17--; break;
                    case 's': nums18--; break;
                    case 't': nums19--; break;
                    case 'u': nums20--; break;
                    case 'v': nums21--; break;
                    case 'w': nums22--; break;
                    case 'x': nums23--; break;
                    case 'y': nums24--; break;
                    case 'z': nums25--; break;
                    default:
                        break;
                }
            }
            internal bool Contain(char ch) {
                switch (ch) {
                    case 'a': return nums0>0;
                    case 'b': return nums1>0;
                    case 'c': return nums2>0;
                    case 'd': return nums3>0;
                    case 'e': return nums4>0;
                    case 'f': return nums5>0;
                    case 'g': return nums6>0;
                    case 'h': return nums7>0;
                    case 'i': return nums8>0;
                    case 'j': return nums9>0;
                    case 'k': return nums10>0;
                    case 'l': return nums11>0;
                    case 'm': return nums12>0;
                    case 'n': return nums13>0;
                    case 'o': return nums14>0;
                    case 'p': return nums15>0;
                    case 'q': return nums16>0;
                    case 'r': return nums17>0;
                    case 's': return nums18>0;
                    case 't': return nums19>0;
                    case 'u': return nums20>0;
                    case 'v': return nums21>0;
                    case 'w': return nums22>0;
                    case 'x': return nums23>0;
                    case 'y': return nums24>0;
                    case 'z': return nums25>0;
                    default:
                        return false;
                        ;
                }
            }

            internal bool AllDefault() {
                return (nums0 | nums1 | nums2 | nums3 | nums4 | nums5 | nums6 | nums7 | nums8 | nums9
                    | nums10 | nums11 | nums12 | nums13 | nums14 | nums15 | nums16 | nums17 | nums18 | nums19
                    | nums20 | nums21 | nums22 | nums23 | nums24 | nums25) == 0;
            }

        }
        private static bool AllDefault(int[] nums) {
            return (nums[0] | nums[1] | nums[2] | nums[3] | nums[4] | nums[5] | nums[6] | nums[7] | nums[8] | nums[9]
                | nums[10] | nums[11] | nums[12] | nums[13] | nums[14] | nums[15] | nums[16] | nums[17] | nums[18] | nums[19]
                | nums[20] | nums[21] | nums[22] | nums[23] | nums[24] | nums[25]) == 0;
        }
        /*
         * 438. Find All Anagrams in a String
         * Medium
         * Given two strings s and p, return an array of all the start indices of p's anagrams in s.
         * You may return the answer in any order.
         * An Anagram is a word or phrase formed by rearranging the letters of a different word or phrase,
         * typically using all the original letters exactly once.
         * 
         * Constraints:

    1 <= s.length, p.length <= 3 * 10^4
    s and p consist of lowercase English letters.

        */
        public static IList<int> FindAnagrams(string s, string p) {
            List<int> lists = new();
            if (p.Length > s.Length) {
                return lists;
            }
            int n = p.Length;
            int i = 0;
            var pHash = GetHash(p);
            int sHash = 0;
            for (; i < n - 1; i++) {
                sHash += GetHash(s[i]);
            }
            int j = 0;
            for (; i < s.Length; i++) {
                sHash += GetHash(s[i]);
                if (sHash == pHash && IsSubstrAnagram(s, start: j, template: p)) {
                    lists.Add(j);
                }
                sHash -= GetHash(s[j]);
                j++;
            }
            return lists;
        }
        private static int GetHash(char ch) {
            return (ch - 'a') * 32 + 1;
        }
        private static int GetHash(string s) {
            int hash = 0;
            foreach (var ch in s) {
                hash += GetHash(ch);
            }
            return hash;
        }
        private static bool IsSubstrAnagram(string s, int start, string template) {
            int[] chars = new int[26];
            for (int i = start; i < start + template.Length; i++) {
                chars[s[i] - 'a']++;
            }
            foreach (var ch in template) {
                chars[ch - 'a']--;
            }
            foreach (var item in chars) {
                if (item != 0) {
                    return false;
                }
            }
            return true;
        }

        public static IList<int> FindAnagrams_LC(string s, string p) {
            int ns = s.Length, np = p.Length;
            if (ns < np)
                return new List<int>();

            int[] pCount = new int[26];
            int[] sCount = new int[26];
            for (int i = 0; i < p.Length; i++) {
                pCount[p[i] - 'a']++;
            }

            List<int> output = new List<int>();
            for (int i = 0; i < ns; ++i) {
                // add one more letter 
                // on the right side of the window
                sCount[s[i] - 'a']++;
                // remove one letter 
                // from the left side of the window
                if (i >= np) {
                    sCount[s[i - np] - 'a']--;
                }
                // compare array in the sliding window
                // with the reference array
                if (isarrayequal(sCount, pCount)) {
                    output.Add(i - np + 1);
                }
            }
            return output;
        }

        private static bool isarrayequal(int[] a, int[] b) {
            for (int i = 0; i < a.Length; i++) {
                if (a[i] != b[i])
                    return false;
            }
            return true;
        }
    }
}
