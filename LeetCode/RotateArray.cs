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
        Given an array, rotate the array to the right by k steps, where k is non-negative.
        Constraints:

    1 <= nums.length <= 10^5
    -2^31 <= nums[i] <= 2^31 - 1
    0 <= k <= 10^5

*/
        public static void Rotate(int[] nums, int k)
        {
            if (nums.Length < 2)
            {
                return;
            }
            int i = 0, j, _j, shift = k % nums.Length;
            int acc;
            for (i = 0; i < shift; i++)
            {
                j = nums.Length + nums.Length % shift;
                acc = nums[i + shift];
                while (j > i + shift)
                {
                    j -= shift;
                    nums[j] = nums[j-shift];
                };
                nums[i + shift] = acc;
            }
        }
        static int gcf(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        static int lcm(int a, int b)
        {
            return (a / gcf(a, b)) * b;
        }
    }
}
