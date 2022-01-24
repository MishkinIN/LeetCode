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
         1. Two Sum
Easy

Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.

You may assume that each input would have exactly one solution, and you may not use the same element twice.

You can return the answer in any order.*/
        public static int[] TwoSumI(int[] nums, int target) {
            Dictionary<int, int> dic = new();
            for (int i = 0; i < nums.Length; i++) {
                if (dic.ContainsKey(target - nums[i])) {
                    return new int[] { i, dic[target - nums[i]] };
                }
                else
                    dic.TryAdd(nums[i], i);
            }
            throw new ArgumentOutOfRangeException();
        }
    }
}
