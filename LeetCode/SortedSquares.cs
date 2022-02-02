using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {

    public static partial class Solution {
        /*
         * Given an integer array nums sorted in non-decreasing order, 
         * return an array of the squares of each number 
         * sorted in non-decreasing order.
         Constraints:

    1 <= nums.length <= 10^4
    -10^4 <= nums[i] <= 10^4
    nums is sorted in non-decreasing order.
*/
        public static int[] SortedSquares(int[] nums) {
            if (nums == null) {
                return null;
            }
            if (nums.Length == 0) {
                return Array.Empty<int>();
            }
            if (nums.Length == 1)
                return new int[] { nums[0] * nums[0] };
            int[] vals = new int[nums.Length];
            int center = Array.BinarySearch(nums, 0), i, j, k = 0;
            center = center < 0 ? ~center : center;
            i = center - 1;
            j = center;
            if (i >= 0 & j < nums.Length) {
                int i_sq = nums[i] * nums[i];
                int j_sq = nums[j] * nums[j];
                while (true) {
                    if (i_sq < j_sq) {
                        vals[k++] = i_sq;
                        i--;
                        if (i < 0) {
                            break;
                        }
                        i_sq = nums[i] * nums[i];
                        continue;
                    }
                    else {
                        vals[k++] = j_sq;
                        j++;
                        if (j == nums.Length) {
                            break;
                        }
                        j_sq = nums[j] * nums[j];
                        continue;
                    }
                }
            }
            while (i >= 0) {
                vals[k++] = nums[i] * nums[i];
                i--;
            }
            while (j < nums.Length) {
                vals[k++] = nums[j] * nums[j];
                j++;
            }
            return vals;
        }
    }
}
