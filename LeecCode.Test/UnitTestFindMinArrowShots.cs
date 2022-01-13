using NUnit.Framework;
using LeetCode;
using System;

namespace LeecCode.Test
{
    public class UnitTestFindMinArrowShots
    {
        int[][] points1, points2, points3;

        [SetUp]
        public void Setup()
        {
            points1 = new int[][] { new int[] {10, 16},new int[] {2,8},new int[] {1,6},new int[] {7,12}};
            points2 = new int[][] { new int[] {1,2},new int[] {3,4},new int[] {5,6},new int[] {7,8} };
            points3 = new int[][] {new int[] {1,2},new int[] {2,3},new int[] {3,4},new int[] {4,5}};

        }

        [Test]
        public void FindMinArrowShots()
        {
            Assert.AreEqual(2, Solution.FindMinArrowShots(points1));
            Assert.AreEqual(4, Solution.FindMinArrowShots(points2));
            Assert.AreEqual(2, Solution.FindMinArrowShots(points3));
        }
    }
}