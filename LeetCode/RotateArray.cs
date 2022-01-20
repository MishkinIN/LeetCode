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
            int i = nLength - 1, _j = i, shift = k % nLength, j = _j - shift;
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
        static int gcf(int a, int b) {
            while (b != 0) {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static int lcm(int a, int b) {
            if (b == 1 | a == 1)
                return 1;
            return (a / gcf(a, b)) * b;
        }
    }
}
