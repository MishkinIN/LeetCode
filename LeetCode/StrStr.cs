using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        private class CharsBuffer {
            int nums0 = 0, nums1 = 0, nums2 = 0, nums3 = 0, nums4 = 0, nums5 = 0, nums6 = 0, nums7 = 0, nums8 = 0, nums9 = 0
                , nums10 = 0, nums11 = 0, nums12 = 0, nums13 = 0, nums14 = 0, nums15 = 0, nums16 = 0, nums17 = 0, nums18 = 0, nums19 = 0
                , nums20 = 0, nums21 = 0, nums22 = 0, nums23 = 0, nums24 = 0, nums25 = 0;
            internal void Add(char ch) {
                switch (ch) {
                    case 'a':
                        nums0++;
                        break;
                    case 'b':
                        nums1++;
                        break;
                    case 'c':
                        nums2++;
                        break;
                    case 'd':
                        nums3++;
                        break;
                    case 'e':
                        nums4++;
                        break;
                    case 'f':
                        nums5++;
                        break;
                    case 'g':
                        nums6++;
                        break;
                    case 'h':
                        nums7++;
                        break;
                    case 'i':
                        nums8++;
                        break;
                    case 'j':
                        nums9++;
                        break;
                    case 'k':
                        nums10++;
                        break;
                    case 'l':
                        nums11++;
                        break;
                    case 'm':
                        nums12++;
                        break;
                    case 'n':
                        nums13++;
                        break;
                    case 'o':
                        nums14++;
                        break;
                    case 'p':
                        nums15++;
                        break;
                    case 'q':
                        nums16++;
                        break;
                    case 'r':
                        nums17++;
                        break;
                    case 's':
                        nums18++;
                        break;
                    case 't':
                        nums19++;
                        break;
                    case 'u':
                        nums20++;
                        break;
                    case 'v':
                        nums21++;
                        break;
                    case 'w':
                        nums22++;
                        break;
                    case 'x':
                        nums23++;
                        break;
                    case 'y':
                        nums24++;
                        break;
                    case 'z':
                        nums25++;
                        break;
                    default:
                        break;
                }
            }
            internal void Remove(char ch) {
                switch (ch) {
                    case 'a':
                        nums0--;
                        break;
                    case 'b':
                        nums1--;
                        break;
                    case 'c':
                        nums2--;
                        break;
                    case 'd':
                        nums3--;
                        break;
                    case 'e':
                        nums4--;
                        break;
                    case 'f':
                        nums5--;
                        break;
                    case 'g':
                        nums6--;
                        break;
                    case 'h':
                        nums7--;
                        break;
                    case 'i':
                        nums8--;
                        break;
                    case 'j':
                        nums9--;
                        break;
                    case 'k':
                        nums10--;
                        break;
                    case 'l':
                        nums11--;
                        break;
                    case 'm':
                        nums12--;
                        break;
                    case 'n':
                        nums13--;
                        break;
                    case 'o':
                        nums14--;
                        break;
                    case 'p':
                        nums15--;
                        break;
                    case 'q':
                        nums16--;
                        break;
                    case 'r':
                        nums17--;
                        break;
                    case 's':
                        nums18--;
                        break;
                    case 't':
                        nums19--;
                        break;
                    case 'u':
                        nums20--;
                        break;
                    case 'v':
                        nums21--;
                        break;
                    case 'w':
                        nums22--;
                        break;
                    case 'x':
                        nums23--;
                        break;
                    case 'y':
                        nums24--;
                        break;
                    case 'z':
                        nums25--;
                        break;
                    default:
                        break;
                }
            }
            internal bool Contain(char ch) {
                switch (ch) {
                    case 'a':
                        return nums0 > 0;
                    case 'b':
                        return nums1 > 0;
                    case 'c':
                        return nums2 > 0;
                    case 'd':
                        return nums3 > 0;
                    case 'e':
                        return nums4 > 0;
                    case 'f':
                        return nums5 > 0;
                    case 'g':
                        return nums6 > 0;
                    case 'h':
                        return nums7 > 0;
                    case 'i':
                        return nums8 > 0;
                    case 'j':
                        return nums9 > 0;
                    case 'k':
                        return nums10 > 0;
                    case 'l':
                        return nums11 > 0;
                    case 'm':
                        return nums12 > 0;
                    case 'n':
                        return nums13 > 0;
                    case 'o':
                        return nums14 > 0;
                    case 'p':
                        return nums15 > 0;
                    case 'q':
                        return nums16 > 0;
                    case 'r':
                        return nums17 > 0;
                    case 's':
                        return nums18 > 0;
                    case 't':
                        return nums19 > 0;
                    case 'u':
                        return nums20 > 0;
                    case 'v':
                        return nums21 > 0;
                    case 'w':
                        return nums22 > 0;
                    case 'x':
                        return nums23 > 0;
                    case 'y':
                        return nums24 > 0;
                    case 'z':
                        return nums25 > 0;
                    default:
                        return false;
                        ;
                }
            }
            internal int this[char ch] {
                get {
                    switch (ch) {
                        case 'a':
                            return nums0;
                        case 'b':
                            return nums1;
                        case 'c':
                            return nums2;
                        case 'd':
                            return nums3;
                        case 'e':
                            return nums4;
                        case 'f':
                            return nums5;
                        case 'g':
                            return nums6;
                        case 'h':
                            return nums7;
                        case 'i':
                            return nums8;
                        case 'j':
                            return nums9;
                        case 'k':
                            return nums10;
                        case 'l':
                            return nums11;
                        case 'm':
                            return nums12;
                        case 'n':
                            return nums13;
                        case 'o':
                            return nums14;
                        case 'p':
                            return nums15;
                        case 'q':
                            return nums16;
                        case 'r':
                            return nums17;
                        case 's':
                            return nums18;
                        case 't':
                            return nums19;
                        case 'u':
                            return nums20;
                        case 'v':
                            return nums21;
                        case 'w':
                            return nums22;
                        case 'x':
                            return nums23;
                        case 'y':
                            return nums24;
                        case 'z':
                            return nums25;
                        default:
                            return 0;
                    }
                }
            }
            internal IEnumerable<KeyValuePair<char, int>> All() {
                yield return KeyValuePair.Create('a', nums0);
                yield return KeyValuePair.Create('b', nums1);
                yield return KeyValuePair.Create('c', nums2);
                yield return KeyValuePair.Create('d', nums3);
                yield return KeyValuePair.Create('e', nums4);
                yield return KeyValuePair.Create('f', nums5);
                yield return KeyValuePair.Create('g', nums6);
                yield return KeyValuePair.Create('h', nums7);
                yield return KeyValuePair.Create('i', nums8);
                yield return KeyValuePair.Create('j', nums9);
                yield return KeyValuePair.Create('k', nums10);
                yield return KeyValuePair.Create('l', nums11);
                yield return KeyValuePair.Create('m', nums12);
                yield return KeyValuePair.Create('n', nums13);
                yield return KeyValuePair.Create('o', nums14);
                yield return KeyValuePair.Create('p', nums15);
                yield return KeyValuePair.Create('q', nums16);
                yield return KeyValuePair.Create('r', nums17);
                yield return KeyValuePair.Create('s', nums18);
                yield return KeyValuePair.Create('t', nums19);
                yield return KeyValuePair.Create('u', nums20);
                yield return KeyValuePair.Create('v', nums21);
                yield return KeyValuePair.Create('w', nums22);
                yield return KeyValuePair.Create('x', nums23);
                yield return KeyValuePair.Create('y', nums24);
                yield return KeyValuePair.Create('z', nums25);
            }
            internal bool AllDefault() {
                return (nums0 | nums1 | nums2 | nums3 | nums4 | nums5 | nums6 | nums7 | nums8 | nums9
                    | nums10 | nums11 | nums12 | nums13 | nums14 | nums15 | nums16 | nums17 | nums18 | nums19
                    | nums20 | nums21 | nums22 | nums23 | nums24 | nums25) == 0;
            }

        }

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
         * 392. Is Subsequence
         * Easy
         * Given two strings s and t, return true if s is a subsequence of t, or false otherwise.
         * A subsequence of a string is a new string that is formed from the original string 
         * by deleting some (can be none) of the characters 
         * without disturbing the relative positions of the remaining characters. 
         * (i.e., "ace" is a subsequence of "abcde" while "aec" is not).
         *
         *Constraints:
    0 <= s.length <= 100
    0 <= t.length <= 10^4
    s and t consist only of lowercase English letters.
Follow up: Suppose there are lots of incoming s, say s1, s2, ..., sk where k >= 10^9, and you want to check one by one to see if t has its subsequence. In this scenario, how would you change your code?
         */
        public static bool IsSubsequence(string s, string t) {

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
        /*. Longest Palindromic Substring
         * Medium
         * Given a string s, return the longest palindromic substring in s
         * 
         * Constraints:
    1 <= s.length <= 1000
    s consist of only digits and English letters.
         */
        public static string LongestPalindrome(string s) {
            if (IsPalindrome(s)) {
                return s;
            }
            int sLength = s.Length;
            int maxPalingdromeLength = sLength - 1;
            while (maxPalingdromeLength > 1) {
                for (int i = 0; i < sLength - maxPalingdromeLength + 1; i++) {
                    var s1 = s[i..(i + maxPalingdromeLength)];
                    if (IsPalindrome(s1))
                        return s1;
                }
                maxPalingdromeLength--;
            }
            return s.Substring(0, 1);
        }
        public static bool IsPalindrome(string s) {
            for (int i = 0; i < s.Length / 2; i++) {
                if (s[i] != s[^(i + 1)]) {
                    return false;
                }
            }
            return true;
        }
        /*
         * 516. Longest Palindromic Subsequence
         * Medium
         * Given a string s, find the longest palindromic subsequence's length in s.
         * A subsequence is a sequence that can be derived from another sequence 
         * by deleting some or no elements without changing the order of the remaining elements.
         * 
         * Constraints:
    1 <= s.length <= 1000
    s consists only of lowercase English letters.
         */
        public static int LongestPalindromeSubseq(string s) {
            int maxLength = 1;
            if (s.Length == 1) {
                return 1;
            }
            int[] leftChars = new int['z' - 'a' + 1];
            Array.Fill(leftChars, -1);
            int[] distances = new int[s.Length];
            int i = 0;
            foreach (var ch in s) {
                if (leftChars[ch - 'a'] >= 0)
                    distances[leftChars[ch - 'a']] = i;
                leftChars[ch - 'a'] = i;
                i++;
            }
            Container root = new Container(0, 1000);
            for (i = 0; i < distances.Length; i++) {
                int right = distances[i];
                while (right > 0) {
                    var dept = root.Add(new Container(i, right));
                    right = distances[right];
                    maxLength = System.Math.Max(maxLength, dept);
                }
            }
            return maxLength;
        }
        private static int AddChields(int[] distances, Container container) {
            int min = container.Left;
            int max = container.Right;
            if (min == max - 1)
                return 0;
            int maxDept = 1;
            for (int i = min + 1; i < max; i++) {
                int right = distances[i];
                while (right > 0 & distances[right] < max) { right = distances[right]; }
                if (right > 0)
                    return container.Add(new Container(i, right)) + 2;
            }
            throw new NotImplementedException();
        }
        private class Container {
            public int Left { get; init; }
            public int Right { get; init; }
            public Container(int left, int right) {
                Left = left;
                Right = right;
            }
            List<Container> Chields { get; init; } = new();
            public bool IsCover(Container other) {
                return Left <= other.Left & Right >= other.Right;
            }
            public int Add(Container other) {
                foreach (var chield in Chields) {
                    if (chield.IsCover(other))
                        return chield.Add(other) + 2;
                }
                Chields.Add(other);
                return other.Right - other.Left > 1 ? 3 : 2;
            }
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
        /*
         * 389. Find the Difference
         * Easy
         * You are given two strings s and t.
         * String t is generated by random shuffling string s 
         * and then add one more letter at a random position.
         * Return the letter that was added to t.
         * 
         * Constraints:

    0 <= s.length <= 1000
    t.length == s.length + 1
    s and t consist of lowercase English letters.

         */
        public static char FindTheDifference(string s, string t) {
            CharsBuffer chars = new();
            foreach (var ch in s) {
                chars.Add(ch);
            }
            foreach (var ch in t) {
                chars.Remove(ch);
            }
            var kvp = chars.All()
                .First(kv => kv.Value < 0);
            return kvp.Key;
        }
        public static char FindTheDifference_LC(string s, string t) {
            var chCode = $"{s}{t}".Aggregate(0, (acc, ch) => acc ^ ch);
            return (char)chCode;
        }
        /*
         * 139. Word Break
         * Medium
         * Given a string s and a dictionary of strings wordDict,
         * return true if s can be segmented into a space-separated sequence
         * of one or more dictionary words.
         * Note that the same word in the dictionary may be reused multiple times in the segmentation.
         * 
         * Constraints:

    1 <= s.length <= 300
    1 <= wordDict.length <= 1000
    1 <= wordDict[i].length <= 20
    s and wordDict[i] consist of only lowercase English letters.
    All the strings of wordDict are unique.

         */
        public static bool WordBreak(string s, IList<string> wordDict) {
            var dict = new HashSet<string>(wordDict);
            SortedSet<int> dictWordLenghts = new();
            cache.Clear();
            foreach (var item in wordDict) {
                dictWordLenghts.Add(item.Length);
            }
            int maxWodrLenght = dictWordLenghts.Max();
            int minWordLength = dictWordLenghts.Min();
            return WordBreak(s, dict, dictWordLenghts.Reverse(), maxWodrLenght, minWordLength);
        }
        public const int MaxWordLength = 20;
        private static Dictionary<string, bool> cache = new();
        private static bool WordBreak(string s, HashSet<string> dict, IEnumerable<int> wordLenghts, int maxWordrLength, int minWordLength) {
            if (s == String.Empty || s.Length < minWordLength)
                return false;
            else if (cache.ContainsKey(s)) {
                return cache[s];
            }
            else if (s.Length == 1) {
                var wb = dict.Contains(s);
                cache[s] = wb;
                return wb;
            }
            else if (s.Length <= maxWordrLength) {
                foreach (var len in wordLenghts) {
                    if (len > s.Length)
                        continue;
                    if (len == s.Length) {
                        if (dict.Contains(s)) {
                            var wb = dict.Contains(s);
                            cache[s] = wb;
                            return wb;
                        }

                        else
                            continue;
                    }
                    if (dict.Contains(s.Substring(0, len))) {
                        var isWordBreak = WordBreak(s.Substring(len, s.Length - len), dict, wordLenghts, maxWordrLength, minWordLength);
                        if (isWordBreak) {
                            cache[s] = true;
                            return true;
                        }
                    }
                }
                cache[s] = false;
                return false;
            }
            int l1 = System.Math.Max((s.Length - maxWordrLength) / 2, minWordLength);
            int l2 = System.Math.Min(s.Length - l1, l1 + maxWordrLength) + 1;
            for (int i = l1; i < l2; i++) {
                var iwb1 = WordBreak(s.Substring(0, i), dict, wordLenghts, maxWordrLength, minWordLength);
                if (!iwb1)
                    continue;
                var iwb2 = WordBreak(s.Substring(i, s.Length - i), dict, wordLenghts, maxWordrLength, minWordLength);
                if (iwb2) {
                    cache[s] = true;
                    return true;
                }
            }
            cache[s] = false;
            return false;
        }
        public static bool WordBreak_LC(string s, IList<string> wordDict) {
            bool[] dp = new bool[s.Length + 1];

            dp[0] = true;

            for (int i = 0; i < s.Length; i++) {
                if (dp[i] == true) {
                    foreach (string word in wordDict) {
                        if ((word.Length + i) <= s.Length && word == s.Substring(i, word.Length)) {
                            dp[word.Length + i] = true;
                        }


                    }
                }
            }
            return dp[dp.Length - 1];
        }
        /*
         * 91. Decode Ways
         * Medium
         * A message containing letters from A-Z can be encoded into numbers using the following mapping:
         * 'A' -> "1"
         * 'B' -> "2"
         * ...
         * 'Z' -> "26"
         * To decode an encoded message, all the digits must be grouped 
         * then mapped back into letters using the reverse of the mapping above
         * (there may be multiple ways). 
         * For example, "11106" can be mapped into:
         * "AAJF" with the grouping (1 1 10 6)
         * "KJF" with the grouping (11 10 6)
         * Note that the grouping (1 11 06) is invalid 
         * because "06" cannot be mapped into 'F' since "6" is different from "06".
         * Given a string s containing only digits, return the number of ways to decode it.
         * The test cases are generated so that the answer fits in a 32-bit integer.
         * 
         * Example 2:
Input: s = "226"
Output: 3
Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6).
         *
         *Constraints:
    1 <= s.length <= 100
    s contains only digits and may contain leading zero(s).
         */
        public static int NumDecodings(string s) {
            int c0 = 1; // the number of ways to decode substring [0,i)
            int c1 = 1, c2 = 1; // the number of ways to decode substring [0,i-1)
            char ch1 = '0';
            foreach (var ch in s) {
                c0 = c1 * (ch == '0' ? 0 : 1)
                    + c2 * ((ch1 == '1' || (ch1 == '2' && ch - '0' < 7)) ? 1 : 0);
                if (c0 == 0)
                    return 0;
                ch1 = ch;
                c2 = c1;
                c1 = c0;
            }
            return c0;
        }
        private static int Decode(char ch) {
            return ch == '0' ? 0 : 1;


        }
        private static int Decode(char ch1, char ch) {
            switch (ch1) {
                case '1':
                    return 1;
                case '2':
                    switch (ch) {
                        case '0':
                        case '1':
                        case '2':
                        case '3':
                        case '4':
                        case '5':
                        case '6':
                            return 1;
                        default:
                            return 0;
                    }
                default:
                    return 0;
            }
        }

        /*
         * 784. Letter Case Permutation
         * Medium
         * Given a string s, you can transform every letter individually to be lowercase or uppercase
         * to create another string.
         * Return a list of all possible strings we could create. Return the output in any order.
         * 
         * Constraints:

    1 <= s.length <= 12
    s consists of lowercase English letters, uppercase English letters, and digits.

         */
        public static IList<string> LetterCasePermutation(string s) {
            List<string> list = new List<string>(LetterCasePermutation(s, s.Length - 1));
            return list;
        }
        private static IEnumerable<string> LetterCasePermutation(string s, int pos) {
            if (pos == 0) {
                foreach (var ch in GetCaseVariants(s[0])) {
                    yield return $"{ch}";
                }
            }
            else {
                foreach (var substr in LetterCasePermutation(s, pos - 1)) {
                    foreach (var ch in GetCaseVariants(s[pos])) {
                        yield return $"{substr}{ch}";
                    }
                }
            }
        }
        private static IEnumerable<char> GetCaseVariants(char ch) {
            yield return ch;
            if (Char.IsLower(ch))
                yield return Char.ToUpper(ch);
            else if (Char.IsUpper(ch))
                yield return Char.ToLower(ch);
        }
        /*
         * 402. Remove K Digits
         * Medium
         * Given string num representing a non-negative integer num, and an integer k, 
         * return the smallest possible integer after removing k digits from num.
         * 
         * Constraints:
    1 <= k <= num.length <= 10^5
    num consists of only digits.
    num does not have any leading zeros except for the zero itself.
         */
        public static string RemoveKdigits(string s_num, int k) {/*Runtime: 76 ms, faster than 96.75% of C# online*/
            int m = s_num.Length;
            if (k == m || s_num == "0")
                return "0";
            if (k == 0)
                return s_num;
            int[] nums = new int[m];
            int[] digits = new int[10];
            int[] shuttle = new int[10];
            Array.Fill<int>(digits, -1);
            Array.Fill<int>(nums, -1);
            int i = 0;
            foreach (var ch in s_num) {
                int ch_num = ch - '0';
                if (digits[ch_num] == -1) {
                    shuttle[ch_num] = digits[ch_num] = i++;
                }
                else {
                    nums[shuttle[ch_num]] = i;
                    shuttle[ch_num] = i++;
                }
            }
            StringBuilder sb = new();
            int length = s_num.Length - k; // длина осташейся части выходной строки
            int cursor = 0; // текущая позиция курсора исходной строки
        
            for (int n = 0; n < digits.Length & length > 0; n++) {
                int indx = digits[n];
                while (0 <= indx & indx < cursor) {
                    indx= digits[n] = nums[indx];
                }
                if (indx >= 0 & indx <= s_num.Length - length) {
                    if(sb.Length>0 | n>0)
                        sb.Append((char)(n + '0'));
                    cursor = indx + 1;
                    indx = nums[indx];
                    length--;
                    if (length == 0)
                        break;
                    n = -1;
                }
            }
            return sb.Length==0? "0": sb.ToString();
        }

    }
}

