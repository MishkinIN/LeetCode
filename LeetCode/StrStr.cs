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
    }
}
