using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestSumRootToLeaf
    {
        private TreeNode bigTree;
        [SetUp]
        public void Setup()
        {
            int[] nums = new int[1000];
            nums[999] = 1;
            nums[998] = 1;
            bigTree = TreeNode.Create(nums);
        }

        [Test]
        public void Test1()
        {
            {
                int[] nums = new int[] { 1 };
                var root = TreeNode.Create(nums);
                int target = 1;
                Assert.AreEqual(target, Solution.SumRootToLeaf(root));

                nums = new int[] { 1 ,1 };
                root = TreeNode.Create(nums);
                target = 3;
                Assert.AreEqual(target, Solution.SumRootToLeaf(root));
                nums = new int[] { 1, 1 };
                root = TreeNode.Create(nums);
                target = 3;
                Assert.AreEqual(target, Solution.SumRootToLeaf(root));
                nums = new int[] { 1, 1, 1 };
                root = TreeNode.Create(nums);
                target = 6;
                Assert.AreEqual(target, Solution.SumRootToLeaf(root));
                nums = new int[14];
                nums[13] = 1;
                nums[9] = 1;
                root = TreeNode.Create(nums);
                target = 2;
                Assert.AreEqual(target, Solution.SumRootToLeaf(root));

                for (int i = 0; i < 1000; i++)
                {
                    Assert.AreEqual(target, Solution.SumRootToLeaf(bigTree)); 
                }
            }
        }
        [Test]
        public void TestMySumRootToLeaf()
        {
            {
                int[] nums = new int[] { 1 };
                var root = TreeNode.Create(nums);
                int target = 1;
                Assert.AreEqual(target, Solution.MySumRootToLeaf(root));

                nums = new int[] { 1 ,1 };
                root = TreeNode.Create(nums);
                target = 3;
                Assert.AreEqual(target, Solution.MySumRootToLeaf(root));
                nums = new int[] { 1, 1 };
                root = TreeNode.Create(nums);
                target = 3;
                Assert.AreEqual(target, Solution.MySumRootToLeaf(root));
                nums = new int[] { 1, 1, 1 };
                root = TreeNode.Create(nums);
                target = 6;
                Assert.AreEqual(target, Solution.MySumRootToLeaf(root));
                nums = new int[14];
                nums[13] = 1;
                nums[9] = 1;
                root = TreeNode.Create(nums);
                target = 2;
                Assert.AreEqual(target, Solution.MySumRootToLeaf(root));

                for (int i = 0; i < 1000; i++)
                {
                    Assert.AreEqual(target, Solution.MySumRootToLeaf(bigTree)); 
                }
            }
        }

    }
}