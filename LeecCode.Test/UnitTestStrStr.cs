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
        public void LongestPalindrome() {
            string s, actual;
            string[] expected;
            s = "babad";
            expected = new string[] { "bab", "aba" };
            Assert.IsTrue(Array.IndexOf(expected, Solution.LongestPalindrome(s)) >= 0);
            s = "baaad";
            expected = new string[] { "aaa" };
            actual = Solution.LongestPalindrome(s);
            Assert.IsTrue(Array.IndexOf(expected, actual) >= 0);
            s = "babadeqrgj6t8k890yl0arv";
            expected = new string[] { "bab", "aba" };
            actual = Solution.LongestPalindrome(s);
            Assert.IsTrue(Array.IndexOf(expected, actual) >= 0);
            s = "zudfweormatjycujjirzjpyrmaxurectxrtqedmmgergwdvjmjtstdhcihacqnothgttgqfywcpgnuvwglvfiuxteopoyizgehkwuvvkqxbnufkcbodlhdmbqyghkojrgokpwdhtdrwmvdegwycecrgjvuexlguayzcammupgeskrvpthrmwqaqsdcgycdupykppiyhwzwcplivjnnvwhqkkxildtyjltklcokcrgqnnwzzeuqioyahqpuskkpbxhvzvqyhlegmoviogzwuiqahiouhnecjwysmtarjjdjqdrkljawzasriouuiqkcwwqsxifbndjmyprdozhwaoibpqrthpcjphgsfbeqrqqoqiqqdicvybzxhklehzzapbvcyleljawowluqgxxwlrymzojshlwkmzwpixgfjljkmwdtjeabgyrpbqyyykmoaqdambpkyyvukalbrzoyoufjqeftniddsfqnilxlplselqatdgjziphvrbokofvuerpsvqmzakbyzxtxvyanvjpfyvyiivqusfrsufjanmfibgrkwtiuoykiavpbqeyfsuteuxxjiyxvlvgmehycdvxdorpepmsinvmyzeqeiikajopqedyopirmhymozernxzaueljjrhcsofwyddkpnvcvzixdjknikyhzmstvbducjcoyoeoaqruuewclzqqqxzpgykrkygxnmlsrjudoaejxkipkgmcoqtxhelvsizgdwdyjwuumazxfstoaxeqqxoqezakdqjwpkrbldpcbbxexquqrznavcrprnydufsidakvrpuzgfisdxreldbqfizngtrilnbqboxwmwienlkmmiuifrvytukcqcpeqdwwucymgvyrektsnfijdcdoawbcwkkjkqwzffnuqituihjaklvthulmcjrhqcyzvekzqlxgddjoir";
            expected = new string[] { "gykrkyg" };
            sw.Restart();
            actual = Solution.LongestPalindrome(s);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            var index = Array.IndexOf(expected, actual);
            if (index < 0)
                Console.WriteLine(actual);
            Assert.IsTrue(index >= 0);
             s = "ujtofmboiyyrjzbonysurqfxylvhuzzrzqwcjxibhawifptuammlxstcjmcmfvjuphyyfflkcbwimmpehqrqcdqxglqciduhhuhbjnwaaywofljhwzuqsnhyhahtkilwggineoosnqhdluahhkkbcwbupjcuvzlbzocgmkkyhhglqsvrxsgcglfisbzbawitbjwycareuhyxnbvounqdqdaixgqtljpxpyrccagrkdxsdtvgdjlifknczaacdwxropuxelvmcffiollbuekcfkxzdzuobkrgjedueyospuiuwyppgiwhemyhdjhadcabhgtkotqyneioqzbxviebbvqavtvwgyyrjhnlceyedhfechrbhugotqxkndwxukwtnfiqmstaadlsebfopixrkbvetaoycicsdndmztyqnaehnozchrakt";
            expected = new string[] { "uhhu" };
            sw.Restart();
            actual = Solution.LongestPalindrome(s);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            index = Array.IndexOf(expected, actual);
            if (index < 0)
                Console.WriteLine(actual);
            Assert.IsTrue(index >= 0);
             s = "esbtzjaaijqkgmtaajpsdfiqtvxsgfvijpxrvxgfumsuprzlyvhclgkhccmcnquukivlpnjlfteljvykbddtrpmxzcrdqinsnlsteonhcegtkoszzonkwjevlasgjlcquzuhdmmkhfniozhuphcfkeobturbuoefhmtgcvhlsezvkpgfebbdbhiuwdcftenihseorykdguoqotqyscwymtjejpdzqepjkadtftzwebxwyuqwyeegwxhroaaymusddwnjkvsvrwwsmolmidoybsotaqufhepinkkxicvzrgbgsarmizugbvtzfxghkhthzpuetufqvigmyhmlsgfaaqmmlblxbqxpluhaawqkdluwfirfngbhdkjjyfsxglsnakskcbsyafqpwmwmoxjwlhjduayqyzmpkmrjhbqyhongfdxmuwaqgjkcpatgbrqdllbzodnrifvhcfvgbixbwywanivsdjnbrgskyifgvksadvgzzzuogzcukskjxbohofdimkmyqypyuexypwnjlrfpbtkqyngvxjcwvngmilgwbpcsseoywetatfjijsbcekaixvqreelnlmdonknmxerjjhvmqiztsgjkijjtcyetuygqgsikxctvpxrqtuhxreidhwcklkkjayvqdzqqapgdqaapefzjfngdvjsiiivnkfimqkkucltgavwlakcfyhnpgmqxgfyjziliyqhugphhjtlllgtlcsibfdktzhcfuallqlonbsgyyvvyarvaxmchtyrtkgekkmhejwvsuumhcfcyncgeqtltfmhtlsfswaqpmwpjwgvksvazhwyrzwhyjjdbphhjcmurdcgtbvpkhbkpirhysrpcrntetacyfvgjivhaxgpqhbjahruuejdmaghoaquhiafjqaionbrjbjksxaezosxqmncejjptcksnoq";
            expected = new string[] { "yvvy" };
            sw.Restart();
            actual = Solution.LongestPalindrome(s);
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
            index = Array.IndexOf(expected, actual);
            if (index < 0)
                Console.WriteLine(actual);
            Assert.IsTrue(index >= 0);
       }
        [Test]
        public void LongestPalindromeSubseq() {
            string s;
            int actual, expected;
            s = "a";
            expected = 1;
            actual = Solution.LongestPalindromeSubseq(s);
            Assert.AreEqual(expected, actual);
            s = "ab";
            expected = 1;
            actual = Solution.LongestPalindromeSubseq(s);
            Assert.AreEqual(expected, actual);
            s = "cbbd";
            expected = 2;
            actual = Solution.LongestPalindromeSubseq(s);
            Assert.AreEqual(expected, actual);
             s = "gabbabba";
            expected = 7;
            actual = Solution.LongestPalindromeSubseq(s);
            Assert.AreEqual(expected, actual);
           s = "abbasent";
            expected = 4;
            actual = Solution.LongestPalindromeSubseq(s);
            Assert.AreEqual(expected, actual);
            s = "wetrgabbabbasesrg";
            expected = 9;
            actual = Solution.LongestPalindromeSubseq(s);
            Assert.AreEqual(expected, actual);

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
         [Test]
        public void LetterCasePermutation() {
            string s;    
            IList<string> expected, actual;
            s = "a1b2";
            actual = Solution.LetterCasePermutation(s);
            Assert.AreEqual(4, actual.Count);

            s = "3z4";
            actual = Solution.LetterCasePermutation(s);
            Assert.AreEqual(2, actual.Count);


        }
        [Test]
        public void LadderLength() {
            string beginWord, endWord;
            IList<string> wordList;
            beginWord = "a";
            endWord = "c";
            wordList = new List<string>(new string[] { "a", "b", "c" });
            Assert.AreEqual(2, Solution.LadderLength(beginWord, endWord, wordList));
            beginWord = "hit";
            endWord = "cog";
            wordList = new List<string>(new string[] { "hot", "dot", "dog", "lot", "log", "cog" });
            Assert.AreEqual(5, Solution.LadderLength(beginWord, endWord, wordList));

            beginWord = "hit";
            endWord = "cit";
            wordList = new List<string>(new string[] { "cit", "dot", "dog", "lot", "log", "cog" });
            Assert.AreEqual(2, Solution.LadderLength(beginWord, endWord, wordList));

            beginWord = "hit";
            endWord = "mmm";
            wordList = new List<string>(new string[] { "hot", "dot", "dog", "lot", "log", "mmm" });
            Assert.AreEqual(0, Solution.LadderLength(beginWord, endWord, wordList));

            beginWord = "hit";
            endWord = "cog";
            wordList = new List<string>(new string[] { "hot", "cog", "dot", "dog", "hit", "lot", "log" });
            Assert.AreEqual(5, Solution.LadderLength(beginWord, endWord, wordList));

        }
        [Test]
        public void RemoveKdigits() {
            string s_num, expected, actual;
            int k;
            s_num = "10";
            k = 1;
            expected = "0";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected== actual);
            s_num = "12";
            k = 1;
            expected = "1";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected == actual);
            s_num = "21";
            k = 1;
            expected = "1";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected == actual);
            s_num = "1000";
            k = 1;
            expected = "0";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected == actual);

            s_num = "3251990";
            k = s_num.Length - 2;
            expected = "10";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected== actual);
           s_num = "3251993";
            k = s_num.Length - 2;
            expected = "13";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected == actual);
            s_num = "32519293";
            k = s_num.Length - 2;
            expected = "12";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected == actual);
            s_num = "32519203";
            k = s_num.Length - 4;
            expected = "1203";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected == actual);
            s_num = "1432219";
            k = s_num.Length - 4;
            expected = "1219";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected == actual);
            s_num = "1432259";
            k = s_num.Length - 4;
            expected = "1225";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected == actual);
            s_num = "1432231";
            k = s_num.Length - 4;
            expected = "1221";
            actual = Solution.RemoveKdigits(s_num, k);
            Assert.IsTrue(expected == actual);
        }
        [Test]
        public void TitleToNumber() {
            string title;
            int expected;
            title = "A";
            expected = 1;
            Assert.AreEqual(expected, Solution.TitleToNumber(title));
            title = "A";
            expected = 1;
            Assert.AreEqual(expected, Solution.TitleToNumber(title));
            title = "B";
            expected = 2;
            Assert.AreEqual(expected, Solution.TitleToNumber(title));
            title = "Z";
            expected = 26;
            Assert.AreEqual(expected, Solution.TitleToNumber(title));
            title = "AA";
            expected = 27;
            Assert.AreEqual(expected, Solution.TitleToNumber(title));
            title = "ZY";
            expected = 701;
            Assert.AreEqual(expected, Solution.TitleToNumber(title));
            title = "AB";
            expected = 28;
            Assert.AreEqual(expected, Solution.TitleToNumber(title));
        }

    }
}