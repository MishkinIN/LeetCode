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

    }
}
