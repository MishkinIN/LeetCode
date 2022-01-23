using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * An integer has sequential digits if and only if each digit in the number is one more than the previous digit.
         * Return a sorted list of all the integers in the range [low, high] inclusive that have sequential digits.
         * 
         * Constraints:

    10 <= low <= high <= 10^9

         */
        public static IList<int> SequentialDigits(int low, int high) {
            // [12,23,34,45,56,67,78,89,123,234,345,456,567,678,789,1234,2345,3456,4567,5678,6789,12345,23456,34567,45678,56789,123456,234567,345678,456789,3456789,2345678,3456789,12345678,23456789,123456789]
            // [12,23,34,45,56,67,78,89,123,234,345,456,567,678,789,1234,2345,3456,4567,5678,6789,12345,23456,34567,45678,56789,123456,234567,345678,456789,1234567,2345678,3456789,12345678,23456789,123456789]

            List<int> result = new();
            UInt16 range =
                high > 123456789 ? (UInt16)9 :
                high > 12345678 ? (UInt16)8 :
                high > 1234567 ? (UInt16)7 :
                high > 123456 ? (UInt16)6 :
                high > 12345 ? (UInt16)5 :
                high > 1234 ? (UInt16)4 :
                high > 123 ? (UInt16)3 :
                high > 12 ? (UInt16)2 :
                (UInt16)1;
            var cursor = AllSequential(range).GetEnumerator();
            bool haveValue = cursor.MoveNext();
            while (haveValue && cursor.Current > high) {
                haveValue = cursor.MoveNext();
            }
            while (haveValue && cursor.Current >= low) {
                result.Add(cursor.Current);
                haveValue = cursor.MoveNext();
            }
            result.Reverse();
            return result;
        }
        private static IEnumerable<int> AllSequential(UInt16 range) {
            if (range > 9) {
                foreach (var item in AllSequential(9)) {
                    yield return item;
                }
            }
            else if (range == 9) {
                yield return 123_456_789;
                foreach (var item in AllSequential(8)) {
                    yield return item;
                }
            }
            else if (range == 8) {
                yield return 23456789;
                yield return 12345678;
                foreach (var item in AllSequential(7)) {
                    yield return item;
                }
            }
            else if (range == 7) {
                yield return 3456789;
                yield return 2345678;
                yield return 1234567;
                foreach (var item in AllSequential(6)) {
                    yield return item;
                }
            }
            else if (range == 6) {
                yield return 456789;
                yield return 345678;
                yield return 234567;
                yield return 123456;
                foreach (var item in AllSequential(5)) {
                    yield return item;
                }

            }
            else if (range == 5) {
                yield return 56789;
                yield return 45678;
                yield return 34567;
                yield return 23456;
                yield return 12345;
                foreach (var item in AllSequential(4)) {
                    yield return item;
                }
            }
            else if (range == 4) {
                yield return 6789;
                yield return 5678;
                yield return 4567;
                yield return 3456;
                yield return 2345;
                yield return 1234;
                foreach (var item in AllSequential(3)) {
                    yield return item;
                }
            }
            else if (range == 3) {
                yield return 789;
                yield return 678;
                yield return 567;
                yield return 456;
                yield return 345;
                yield return 234;
                yield return 123;
                foreach (var item in AllSequential(2)) {
                    yield return item;
                }
            }
            else if (range == 2) {
                yield return 89;
                yield return 78;
                yield return 67;
                yield return 56;
                yield return 45;
                yield return 34;
                yield return 23;
                yield return 12;
            }
            else
                yield break;
        }
    }
}
