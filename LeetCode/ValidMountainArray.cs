using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {
    public static partial class Solution {
        /*
         * 941. Valid Mountain Array
         * Easy
         * Given an array of integers arr, return true if and only if it is a valid mountain array.
         * Recall that arr is a mountain array if and only if:
         * 
         * arr.length >= 3
         * There exists some i with 0 < i < arr.length - 1 such that:
         * arr[0] < arr[1] < ... < arr[i - 1] < arr[i]
         * arr[i] > arr[i + 1] > ... > arr[arr.length - 1]
        Constraints:

    1 <= arr.length <= 10^4
    0 <= arr[i] <= 10^4

         */

        public static bool ValidMountainArray(int[] arr) {
            if (arr == null || arr.Length < 3) {
                return false;
            }
            int d1, v0, v1;
            v0 = arr[0];
            v1 = arr[1];
            d1 = v1 - v0;
            bool isValid = d1 > 0;
            if (!isValid) {
                return false;
            }
            bool hasMax = false;
            for (int i = 2; i < arr.Length; i++) {
                v0 = v1;
                v1 = arr[i];
                d1 = v1 - v0;
                hasMax |= d1 < 0;
                isValid = (hasMax & d1 < 0)
                    || (!hasMax & d1 > 0);
                if (!isValid) {
                    return false;
                }

            }
            return isValid & hasMax;
        }
    }
}
