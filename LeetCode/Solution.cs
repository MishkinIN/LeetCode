using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        public static int[] TwoSum(int[] nums, int target) {
            int length = nums.Length;
            int[] keys = new int[length];
            for (int k = 0; k < length; k++) {
                keys[k] = k;
            }
            Array.Sort(nums, keys);
            int i, j = 0;
            for (i = 0; i < length - 1; i++) {
                j = Array.BinarySearch(nums, i + 1, length - i - 1, target - nums[i]);
                if (j > 0) {
                    return new int[] { keys[i], keys[j] };
                }
            }
            throw new ArgumentOutOfRangeException();
        }
        public static bool IsPalindrome(int x) {
            if (x < 0)
                return false;
            else if (x == 0)
                return true;
            int[] digits = new int[10];
            int i = 0, j = -1;
            do {
                digits[++j] = x % 10;
                x /= 10;
            } while (x > 0);
            do {
                if (digits[i] != digits[j])
                    return false;
                if (i + 1 == j && (digits[i] == digits[j]))
                    return true;
                i++;
                j--;
            } while (i < j);
            return i == j;
        }
        public static int RomanToInt(string s) {
            int sub = 1;
            int sum = 0;
            for (int k = s.Length - 1; k >= 0; k--) {
                switch (s[k]) {
                    case 'I':
                        sub = sub > 1 ? -1 : 1;
                        break;
                    case 'V':
                        sub = 5;
                        break;
                    case 'X':
                        sub = sub > 10 ? -10 : 10;
                        break;
                    case 'L':
                        sub = 50;
                        break;
                    case 'C':
                        sub = sub > 100 ? -100 : 100;
                        break;
                    case 'D':
                        sub = 500;
                        break;
                    case 'M':
                        sub = 1000;
                        break;
                    default:
                        break;
                }
                sum += sub;
            }
            return sum;
        }
        public static string LongestCommonPrefix(string[] strs) {
            string prefix = strs[0];
            int prefixLength = prefix.Length;
            string current;
            for (int k = 1; k < strs.Length; k++) {
                current = strs[k];
                if (prefixLength > current.Length) {
                    prefixLength = current.Length;
                    prefix = prefix[0..current.Length];
                }

                while (current[0..prefixLength] != prefix) {
                    prefixLength--;
                    prefix = prefix[0..prefixLength];
                }
                if (prefixLength == 0)
                    return "";
            }
            return prefix;
        }
        public static string LongestCommonPrefix_1(string[] strs) {
            if (strs.Length == 1) {
                return strs[0];
            }
            var enums = strs.Select(str => str.GetEnumerator()).ToArray();
            int prefLength = 0;
            Char current = '_';
            while (enums.All(en => en.MoveNext()) && enums.All(en => {
                if (current == '_') {
                    current = en.Current;
                    return true;
                }
                else
                    return current == en.Current;
            })) {
                current = '_';
                prefLength++;
            }
            return strs[0].Substring(0, prefLength);

        }
        /// <summary>
        /// Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', 
        /// determine if the input string is valid.
        /// </summary>
        /// <param name="s">s.Length>1</param>
        /// <returns></returns>
        public static bool IsValid(string s) {
            byte a = 1, b = 2, c = 4;
            var stack = new Stack<byte>(10000);
            foreach (var ch in s) {
                switch (ch) {
                    case '(':
                        stack.Push(a);
                        break;
                    case '{':
                        stack.Push(b);
                        break;
                    case '[':
                        stack.Push(c);
                        break;
                    case ')':
                        if (stack.Count == 0 || stack.Pop() != a) {
                            return false;
                        }
                        break;
                    case '}':
                        if (stack.Count == 0 || stack.Pop() != b) {
                            return false;
                        }
                        break;
                    case ']':
                        if (stack.Count == 0 || stack.Pop() != c) {
                            return false;
                        }
                        break;
                    default:
                        return false;
                }
            }
            return stack.Count == 0;
        }

        public static bool CanPlaceFlowers(int[] fl, int n) {
            int i = 0;
            if (n == 0)
                return true;
            int flLength = fl.Length;
            if (2 * n > flLength + 1)
                return false;
            bool isRightAdjanced = false;
            while (i < flLength - 1) {
                isRightAdjanced = fl[i + 1] != 0;
                if (isRightAdjanced) {
                    i += 3;
                    //isRightAdjanced=false;
                }
                else if (fl[i] == 0) {
                    if (--n == 0)
                        return true;
                    i += 2;
                }
                else
                    i += 2;
            }
            if (i < flLength)
                return fl[i] == 0 && --n == 0;
            else
                return false;
        }
        public static int Search(int[] nums, int target) {
            return Array.BinarySearch(nums, target) < 0 ? -1 : Array.BinarySearch(nums, target);
        }
 
    }
}
