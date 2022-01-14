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
         * Implement the myAtoi(string s) function, 
         * which converts a string to a 32-bit signed integer (similar to C/C++'s atoi function).
         */
        private const int MaxInt32Digits = 10;
        private const int char_0_to_int = 48;
        public static int MyAtoi(string s)
        {
            if (s.Length==0)
            {
                return 0;
            }
            int[] vs = new int[MaxInt32Digits];
            int i_vs = 0;
            int i = 0;
            int digit = 1;
            int myAtoi = 0;
            while (i < s.Length-1 && s[i] == ' ') { i++; }
            if (s[i]==' ')
            {
                return 0;
            }
            else if (s[i] == '-')
            {
                digit = -1;
                i++;
            }
            else if (s[i]=='+')
            {
                i++;
            }
            while (i < s.Length && s[i] == '0') { i++; }
            while (i < s.Length && (s[i]>='0' & s[i] <= '9'))
            {
                if (i_vs== MaxInt32Digits)
                {
                    return digit > 0 ? int.MaxValue : int.MinValue;

                }
                vs[i_vs++] = (int)s[i++] - char_0_to_int;
            }
            int j;
            
            if (digit==1 )
            {
                for (j = 0; j < i_vs - 1; j++)
                {
                    myAtoi = myAtoi * 10 + vs[j]; //2147483647
                }
                return (myAtoi > 214748364) ||((myAtoi == 214748364) & vs[j] >7) ? int.MaxValue: myAtoi * 10 + vs[j];
            }
            else
            {
                for (j = 0; j < i_vs - 1; j++)
                {
                    myAtoi = myAtoi * 10 - vs[j];
                }
                return (myAtoi < -214748364)|| ((myAtoi == -214748364) & vs[j] >8) ? int.MinValue: myAtoi * 10 - vs[j];
            }
        }

    }
}
