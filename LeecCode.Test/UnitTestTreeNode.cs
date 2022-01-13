using NUnit.Framework;
using LeetCode;

namespace LeecCode.Test
{
    public class UnitTestTreeNode
    {
        private TreeNode bigTree;
        private TreeNode[] roots;
        [SetUp]
        public void Setup()
        {
            int[] nums = new int[1000];
            nums[999] = 1;
            nums[998] = 1;
            bigTree = TreeNode.Create(nums);
            roots = new TreeNode[7];
            nums = new int[] { 1 };
            roots[0] = TreeNode.Create(nums);
            nums = new int[] { 1, 1 };
            roots[1] = TreeNode.Create(nums);
            nums = new int[] { 1, 1, 1 };
            roots[2] = TreeNode.Create(nums);
            nums = new int[] { 1, 1, 1, 0, 1, 1 };
            roots[3] = TreeNode.Create(nums);
            nums = new int[] { 1, 1, 1, 0, 1, 1, 0 };
            roots[4] = TreeNode.Create(nums);
            roots[5] = bigTree;
            nums = new int[1 + 2 + 4 + 8 + 16 + 32 + 64 + 128 + 256 + 512 + 1024 + 2048];
            nums[1 + 2 + 4 + 8 + 16 + 32 + 64 + 128 + 256 + 512 + 1024 + 1024] = 1;
            roots[6] = TreeNode.Create(nums);
        }

        [Test]
        public void SumRootToLeaf()
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
        [Test]
        public void IsSymmetric()
        {
            TreeNode root = roots[0];
            Assert.IsTrue(TreeNode.IsSymmetric(root));
            root = roots[1];
            Assert.IsFalse(TreeNode.IsSymmetric(root));
            root = roots[2];
            Assert.IsTrue(TreeNode.IsSymmetric(root));
            root = roots[3];
            Assert.IsFalse(TreeNode.IsSymmetric(root));
            root = roots[4];
            Assert.IsTrue(TreeNode.IsSymmetric(root));
            root = roots[5];
            Assert.IsFalse(TreeNode.IsSymmetric(root));
            root = roots[6];
            for (int i = 0; i < 1000; i++)
            {
                Assert.IsFalse(TreeNode.IsSymmetric(root));
            }
        }
         [Test]
        public void FindTilt()
        {
            TreeNode root = roots[0];
            Assert.AreEqual(0,TreeNode.FindTilt(root));
            root = roots[1];
            Assert.AreEqual(1, TreeNode.FindTilt(root));
            root = roots[2];
            Assert.AreEqual(0, TreeNode.FindTilt(root));
            root = roots[3];
            Assert.AreEqual(2, TreeNode.FindTilt(root));
            root = roots[4];
            Assert.AreEqual(2, TreeNode.FindTilt(root));
            int?[] nums = new int?[3] { 1,2,3};
            root = TreeNode.Create(nums);
            Assert.AreEqual(1, TreeNode.FindTilt(root));
            nums = new int?[] { 4, 2, 9, 3, 5, null, 7 };
            root = TreeNode.Create(nums);
            Assert.AreEqual(15, TreeNode.FindTilt(root));
            nums = new int?[] { 21, 7, 14, 1, 1, 2, 2, 3, 3 };
            root = TreeNode.Create(nums);
            Assert.AreEqual(9, TreeNode.FindTilt(root));

        }
   }
}