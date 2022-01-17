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
         * Given a pattern and a string s, find if s follows the same pattern.
         * Here follow means a full match, such that there is a bijection 
         * between a letter in pattern and a non-empty word in s.
         * Constraints:

    1 <= pattern.length <= 300
    pattern contains only lower-case English letters.
    1 <= s.length <= 3000
    s contains only lowercase English letters and spaces ' '.
    s does not contain any leading or trailing spaces.
    All the words in s are separated by a single space.

         */

        public static bool WordPattern(string pattern, string s)
        {
            string[] words = s.Split(' ');
            if (words.Length != pattern.Length)
            {
                return false;
            }
            if (pattern.Length == 1)
            {
                return true;
            }
            Dictionary<char, string> dic = new();
            HashSet<string> dicValues = new();
            int i = 0;
            foreach (var ch in pattern)
            {
                var word = words[i];
                if (dic.ContainsKey(ch))
                {
                    if (word != dic[ch])
                        return false;
                }
                else
                {
                    if (dicValues.Contains(word))
                    {
                        return false;
                    }
                    dic[ch] = word;
                    dicValues.Add(word);
                }
                i++;
            }
            return true;
        }
    }
}
