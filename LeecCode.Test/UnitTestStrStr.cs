using NUnit.Framework;
using LeetCode;
using System.Text;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Diagnostics;

namespace LeecCode.Test
{
    public class UnitTestString {
        private string bigPattern;
        private string bigPatternString;
        private string bigNotPatternString;
        private readonly Stopwatch sw = new();

        [SetUp]
        public void Setup() {
            StringBuilder sbBigPattern = new();
            StringBuilder sbBigPatternString = new();
            StringBuilder sbBignotPatternString = new();
            Dictionary<char, string> dic = new();
            char ch = 'a';
            string word = "a";
            sbBigPattern.Append(ch);
            sbBigPatternString.Append(word);
            sbBignotPatternString.Append(word);
            for (int i = 0; i < 100000; i++) {
                word = char.ConvertFromUtf32((int)'a' + i % 28);
                ch = word[0];
                sbBigPattern.Append(ch);
                sbBigPatternString.Append(" ");
                sbBignotPatternString.Append(" ");
                sbBigPatternString.Append(word);
                sbBignotPatternString.Append(word);
            }
            sbBigPattern.Append(ch);
            sbBigPatternString.Append(" ");
            sbBignotPatternString.Append(" ");
            sbBigPatternString.Append(word);
            sbBignotPatternString.Append(char.ConvertFromUtf32((int)'a' + 1000 % 28));
            bigPattern = sbBigPattern.ToString();
            bigPatternString = sbBigPatternString.ToString();
            bigNotPatternString = sbBignotPatternString.ToString();
        }
        [Test]
        public void StrStr() {
            string haystack, needle;
            haystack = "";
            needle = "";
            Assert.AreEqual(0, Solution.StrStr(haystack, needle));
            haystack = "hello";
            needle = "ll";
            Assert.AreEqual(2, Solution.StrStr(haystack, needle));
            haystack = "aaaaa";
            needle = "abba";
            Assert.AreEqual(-1, Solution.StrStr(haystack, needle));
            haystack = "mississippi";
            needle = "issip";
            Assert.AreEqual(4, Solution.StrStr(haystack, needle));
        }
        [Test]
        public void WordPattern() {

            Assert.IsTrue(Solution.WordPattern("q", "ddf"));
            Assert.IsTrue(Solution.WordPattern("abba", "dog cat cat dog"));
            Assert.IsFalse(Solution.WordPattern("abba", "dog cat cat fish"));
            Assert.False(Solution.WordPattern("aaaa", "dog cat cat dog"));
            Assert.IsTrue(Solution.WordPattern("q", "ddf"));
            Assert.IsTrue(Solution.WordPattern("q", "ddf"));
            Assert.IsTrue(Solution.WordPattern("q", "ddf"));
            Assert.IsTrue(Solution.WordPattern("q", "ddf"));
            Assert.IsTrue(Solution.WordPattern("q", "ddf"));
            Assert.IsTrue(Solution.WordPattern("q", "ddf"));
        }
        [Test]
        public void WordPattert_bigPattern() {
            Assert.IsTrue(Solution.WordPattern(bigPattern, bigPatternString));
            Assert.IsFalse(Solution.WordPattern(bigPattern, bigNotPatternString));

        }
        [Test]
        public void ReverseString() {
            char[] s = new char[] {'h', 'e', 'l', 'l', 'o' };
            char[] expected = new char[] {'o', 'l', 'l', 'e', 'h'};
            Solution.ReverseString(s);
            for (int i = 0; i < s.Length; i++) {
                Assert.AreEqual(expected[i], s[i]);
            }
        }
        [Test]
        public void LengthOfLongestSubstring() {
            var s = "";
            Assert.AreEqual(0, Solution.LengthOfLongestSubstring(s));
            s = "a";
            Assert.AreEqual(1, Solution.LengthOfLongestSubstring(s));
            s = "abcabcbb";
            Assert.AreEqual(3, Solution.LengthOfLongestSubstring(s));
            s = "bbbbb";
            Assert.AreEqual(1, Solution.LengthOfLongestSubstring(s));
            s = "pwwkew";
            Assert.AreEqual(3, Solution.LengthOfLongestSubstring(s));
            s = "abcdefga";
            Assert.AreEqual(7, Solution.LengthOfLongestSubstring(s));
            s = "aaaa123";
            Assert.AreEqual(4, Solution.LengthOfLongestSubstring(s));
            Console.WriteLine(Solution.LengthOfLongestSubstring(bigPatternString));
        }
        [Test]
        public void FindAnagrams() {
            string s, p;
            s = "cbaebabacd";
            p = "abc";
            var actual = Solution.FindAnagrams(s, p)
                .ToArray();
            int[] expected = new int[] { 0, 6 };
            Assert.IsTrue(UnitTestArray.Equal(expected, actual));

            s = "abab";
            p = "ab";
            actual = Solution.FindAnagrams(s, p)
                .ToArray();
            expected = new int[] { 0,1,2};
            Assert.IsTrue(UnitTestArray.Equal(expected, actual));
        }
        [Test]
        public void FindAnagrams_w30_000() {
            Random random = new ();
            StringBuilder sb = new ();
            for (int i = 0; i < 3_000_000; i++) {
                sb.Append((char)random.Next('a', 'z'));
            }
            string s = sb.ToString();
            string p = s.Substring(10_000, 25);
            sw.Restart();
            var actual = Solution.FindAnagrams(s, p);
            sw.Stop();
            Console.WriteLine($"Time Solution.FindAnagrams in {sw.Elapsed}");
            Assert.IsTrue(actual.Contains(10_000)); 
        }
        [Test]
        public void FindAnagrams_w30_000_LC() {
            Random random = new ();
            StringBuilder sb = new ();
            for (int i = 0; i < 3_000_000; i++) {
                sb.Append((char)random.Next('a', 'z'));
            }
            string s = sb.ToString();
            string p = s.Substring(10_000, 25);
            sw.Restart();
            var actual = Solution.FindAnagrams_LC(s, p);
            sw.Stop();
            Console.WriteLine($"Time Solution.FindAnagrams in {sw.Elapsed}");
            Assert.IsTrue(actual.Contains(10_000)); 
        }
        [Test]
        public void CheckInclusion() {
            string s1, s2;
            s1 = "ab"; s2 = "eidbaooo";
            Assert.IsTrue(Solution.CheckInclusion(s1 , s2));
            s1 = "ab"; s2 = "eidboaoo";
            Assert.IsFalse(Solution.CheckInclusion(s1, s2));
        }
        [Test]
        public void FindTheDifference() {
            string s = bigPattern;
            string t = s + "z";
            sw.Restart();
            var ch = Solution.FindTheDifference(s, t);
            sw.Stop();
            Console.WriteLine($"FindTheDifference complete, {sw.Elapsed}");
            Assert.AreEqual('z', ch);
        }
        [Test]
        public void FindTheDifference_LC() {
            string s = bigPattern;
            string t = s + "z";
            sw.Restart();
            var ch = Solution.FindTheDifference_LC(s, t);
            sw.Stop();
            Console.WriteLine($"FindTheDifference complete, {sw.Elapsed}");
            Assert.AreEqual('z', ch);
        }
         [Test]
        public void WordBreak() {
            string s = "leetcode";
            List<string> dict = new List<string>(new string[] { "leet", "code" });
            var canSegmented = Solution.WordBreak(s, dict);
            Assert.IsTrue(canSegmented);

            s = "applepenapple";
            dict = new List<string>(new string[] { "apple", "pen" });
            canSegmented = Solution.WordBreak(s, dict);
            Assert.IsTrue(canSegmented);

            s = "goalspecial";
            dict = new List<string>(new string[] { "go", "goal", "goals", "special" });
            canSegmented = Solution.WordBreak(s, dict);
            Assert.IsTrue(canSegmented);

           s = "catsandog";
            //dict = new List<string>(new string[] { "cats", "dog", "sand", "and", "cat" });
            dict = new List<string>(new string[] { "cats", "dog", "sand", "and", "cat" });
            canSegmented = Solution.WordBreak(s, dict);
            Assert.IsFalse(canSegmented);

            s = "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaab";

            dict = new List<string>(new string[] { "a", "aa", "aaa", "aaaa", "aaaaa", "aaaaaa", "aaaaaaa", "aaaaaaaa", "aaaaaaaaa", "aaaaaaaaaa" });
            sw.Restart();
            canSegmented = Solution.WordBreak(s, dict);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            Assert.IsFalse(canSegmented);

        }
         [Test]
        public void NumDecodings() {
            string s;
            int expected, actual;
            s = "12";
            expected = 2;
            actual = Solution.NumDecodings(s);
            Assert.AreEqual(expected, actual);

            s = "226";
            expected = 3;
            actual = Solution.NumDecodings(s);
            Assert.AreEqual(expected, actual);

            s = "06";
            expected = 0;
            actual = Solution.NumDecodings(s);
            Assert.AreEqual(expected, actual);

            s = "120012";
            expected = 0;
            actual = Solution.NumDecodings(s);
            Assert.AreEqual(expected, actual);


        }
    }
}