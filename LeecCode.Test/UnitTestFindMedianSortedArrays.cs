using NUnit.Framework;
using LeetCode;
using System;

namespace LeecCode.Test
{
    public class UnitTestFindMedianSortedArrays
    {
        int[] nums1, nums2;

        [SetUp]
        public void Setup()
        {
            nums1 = new int[1000];
            nums2 = new int[1000];
            Random rand = new Random();
            for (int i = 0; i < 1000; i++)
            {
                nums1[i] = rand.Next(-1000000, 1000000);
                nums2[i] = rand.Next(-1000000, 1000000);
            }
            Array.Sort<int>(nums1);
            Array.Sort<int>(nums2);
        }

        [Test]
        public void Test1()
        {
            {
                int[] nums1 = new int[] { 1, 2 };
                int[] nums2 = new int[] { 3, 4 };
                double output = 2.5;
                Assert.AreEqual(output, Solution.FindMedianSortedArrays(nums1, nums2));
            }
            {
                int[] nums1 = new int[] { 1, 3 };
                int[] nums2 = new int[] { 2 };
                double output = 2.0;
                Assert.AreEqual(output, Solution.FindMedianSortedArrays(nums1, nums2));
            }

            {
                int[] nums1 = new int[] { 3 };
                int[] nums2 = new int[] { };
                double output = 3.0;
                Assert.AreEqual(output, Solution.FindMedianSortedArrays(nums1, nums2));
            }
            {
                int[] nums1 = new int[] { };
                int[] nums2 = new int[] { 4 };
                double output = 4.0;
                Assert.AreEqual(output, Solution.FindMedianSortedArrays(nums1, nums2));
            }
            {
                int[] nums1 = new int[] { };
                int[] nums2 = new int[] {1, 2, 3, 4 };
                double output = 2.5;
                Assert.AreEqual(output, Solution.FindMedianSortedArrays(nums1, nums2));
            }

            {
                int[] nums1 = new int[] { 1 };
                int[] nums2 = new int[] { 2 };
                double output = 1.5;
                Assert.AreEqual(output, Solution.FindMedianSortedArrays(nums1, nums2));
            }
            {
                int[] nums1 = new int[] { 1, 2, 3 };
                int[] nums2 = new int[] { -1 };
                double output = 1.5;
                Assert.AreEqual(output, Solution.FindMedianSortedArrays(nums1, nums2));
            }
            {
                int[] nums1 = new int[] { 1, 2, 3 };
                int[] nums2 = new int[] { 6 };
                double output = 2.5;
                Assert.AreEqual(output, Solution.FindMedianSortedArrays(nums1, nums2));
            }
        }
        [Test]
        public void Test2()
        {
            Solution.FindMedianSortedArrays(nums1, nums2);
        }
    }
}