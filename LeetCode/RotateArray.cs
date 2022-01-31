using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {

    public static partial class Solution {
        /*
        Given an array, rotate the array to the right by k steps, where k is non-negative.
        Constraints:

    1 <= nums.length <= 10^5
    -2^31 <= nums[i] <= 2^31 - 1
    0 <= k <= 10^5

*/
        public static void Rotate(int[] nums, int k) {
            if (nums.Length < 2) {
                return;
            }
            int nLength = nums.Length;
            int shift = k % nLength;
            if (shift == 0)
                return;
            int n = nums.Length - shift;
            int[] shiftNums = new int[n];
            Array.Copy(nums, 0, shiftNums, 0, n);
            Array.Copy(nums, n, nums, 0, shift);
            Array.Copy(shiftNums, 0, nums, shift, n);
        }
        public static void Rotate_lc(int[] nums, int k) {
            var length = nums.Length;
            k %= length;
            var arr = new int[length];
            for (int j = 0; j < length; j++) {
                arr[(j + k) % length] = nums[j];
            }
            Array.Copy(arr, 0, nums, 0, length);
            
        }
            public static void Rotate_I(int[] nums, int k) {
            if (nums.Length < 2) {
                return;
            }
            int nLength = nums.Length;
            int i = nLength - 1, _j = i, shift = k % nLength, j = _j - shift;
            if (shift == 0)
                return;
            ;
            int acc = nums[_j];
            //int _lcm = lcm(shift, nLength);
            int count = -1;
            while (++count < nLength) {
                if (j < 0) {
                    j += nLength;
                    if (j == i) {
                        nums[_j] = acc;
                        i--;
                        _j = i;
                        acc = nums[_j];
                        j = _j - shift;
                        continue;
                    }
                }
                nums[_j] = nums[j];
                _j = j;
                j -= shift;

            };
        }
 
    }
}
