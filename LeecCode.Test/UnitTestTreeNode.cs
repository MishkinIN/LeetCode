using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
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

                nums = new int[] { 1, 1 };
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

                nums = new int[] { 1, 1 };
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
            Assert.AreEqual(0, TreeNode.FindTilt(root));
            root = roots[1];
            Assert.AreEqual(1, TreeNode.FindTilt(root));
            root = roots[2];
            Assert.AreEqual(0, TreeNode.FindTilt(root));
            root = roots[3];
            Assert.AreEqual(2, TreeNode.FindTilt(root));
            root = roots[4];
            Assert.AreEqual(2, TreeNode.FindTilt(root));
            int?[] nums = new int?[3] { 1, 2, 3 };
            root = TreeNode.Create(nums);
            Assert.AreEqual(1, TreeNode.FindTilt(root));
            nums = new int?[] { 4, 2, 9, 3, 5, null, 7 };
            root = TreeNode.Create(nums);
            Assert.AreEqual(15, TreeNode.FindTilt(root));
            nums = new int?[] { 21, 7, 14, 1, 1, 2, 2, 3, 3 };
            root = TreeNode.Create(nums);
            Assert.AreEqual(9, TreeNode.FindTilt(root));

        }
        [Test]
        public void GenerateTrees()
        {
           System.Collections.Generic.List<TreeNode> expected = new();
            int?[] nums = new int?[] { 1, null, 2, null, 3 };
            expected.Add(TreeNode.Create(nums));
            nums = new int?[] { 1, null, 3, 2 };
            expected.Add(TreeNode.Create(nums));
            nums = new int?[] { 2, 1, 3 };
            expected.Add(TreeNode.Create(nums));
            nums = new int?[] { 3, 1, null, null, 2 };
            expected.Add(TreeNode.Create(nums));
            nums = new int?[] { 3, 2, null, 1 };
            expected.Add(TreeNode.Create(nums));
            IList<TreeNode> actual = TreeNode.GenerateTrees(3);
            Assert.AreEqual(5, actual.Count);
            foreach (var item in expected)
            {
                TreeNode node = actual.FirstOrDefault(n => TreeNode.Equals(item, n));
                Assert.IsNotNull(node);
                actual.Remove(node);
            }
            Assert.AreEqual(0, actual.Count);
            
        }
        [Test]
        public void GenerateTrees_12()
        {
           var actual = TreeNode.GenerateTrees(12);
        }
        [Test]
        public void GenerateTrees_12_LeetCode()
        {
            var leetCode = new LeetCode.LeetCode();
            IList<TreeNode> actual = leetCode.GenerateTrees(12);
        }
        [Test]
        public void GetAllElements() {
            int?[] lNums = new int?[] { };
            int?[] rNums = new int?[] { };

            lNums = new int?[] { 8, 3,null,2, null, 1};
            rNums = new int?[] { };
            TreeNode left = TreeNode.Create(lNums);
            TreeNode rigth = TreeNode.Create(rNums);
            var actual = TreeNode.GetAscendingAllElements(left, rigth);
            Assert.AreEqual(4, actual.Count);
            int lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }

            lNums = new int?[] { 8, null, 9, null, 10, null, 11 };
            rNums = new int?[] { };
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            Assert.AreEqual(4, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }
            lNums = new int?[] { 8, 3, null, 2, 5, 1, null, null, 7, null, null, 6 };
            rNums = new int?[] { };
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            var expectedCount = 0;
            foreach (var item in lNums) {
                if (item.HasValue) {
                    expectedCount++;
                }
            }
            foreach (var item in rNums) {
                if (item.HasValue) {
                    expectedCount++;
                }
            }
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            Assert.AreEqual(expectedCount, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }

            lNums = new int?[] { 1, 0, 3 };
            rNums = new int?[] { };
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            Assert.AreEqual(lNums.Length + rNums.Length, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }

            lNums = new int?[] { };
            rNums = new int?[] { 1, 0, 3 };
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            Assert.AreEqual(lNums.Length + rNums.Length, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }

            lNums = new int?[] { };
            rNums = new int?[] { };
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            Assert.AreEqual(lNums.Length + rNums.Length, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }

            lNums = new int?[] { 2, 1, 4 };
            rNums = new int?[] { 1, 0, 3 };
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            Assert.AreEqual(lNums.Length + rNums.Length, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }

            lNums = new int?[] { 1, null, 8 };
            rNums = new int?[] { 8, 1 };
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            Assert.AreEqual(lNums.Length + rNums.Length-1, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }
            lNums = new int?[] {99, 90, null, 8, null, 7, 85, null, null, null, 87 };
            rNums = new int?[] {};
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            expectedCount = 0;
            foreach (var item in lNums) {
                if (item.HasValue) {
                    expectedCount++;
                }
            }
            foreach (var item in rNums) {
                if (item.HasValue) {
                    expectedCount++;
                }
            }
            Assert.AreEqual(expectedCount, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }
            lNums = System.Array.Empty<int?>();
            rNums = new int?[] { 50, 2, 73, null, 34, 58, 80, 21, null, null, 64, 74, 92, 10, null, null, 68, null, null, 89, 100, null, null, 66, null, 84 };
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            expectedCount = 0;
            foreach (var item in lNums) {
                if (item.HasValue) {
                    expectedCount++;
                }
            }
            foreach (var item in rNums) {
                if (item.HasValue) {
                    expectedCount++;
                }
            }
            Assert.AreEqual(expectedCount, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }

            lNums = new int?[] {99, 90, null, 8, null, 7, 85, null, null, null, 87 };
            rNums = new int?[] {50, 2, 73, null, 34, 58, 80, 21, null, null, 64, 74, 92, 10, null, null, 68, null, null, 89, 100, null, null, 66, null, 84 };
            left = TreeNode.Create(lNums);
            rigth = TreeNode.Create(rNums);
            actual = TreeNode.GetAscendingAllElements(left, rigth);
            expectedCount = 0;
            foreach (var item in lNums) {
                if (item.HasValue) {
                    expectedCount++;
                }
            }
            foreach (var item in rNums) {
                if (item.HasValue) {
                    expectedCount++;
                }
            }
            Assert.AreEqual(expectedCount, actual.Count);
            lastVal = int.MinValue;
            foreach (var item in actual) {
                Assert.IsTrue(lastVal <= item);
                lastVal = item;
            }
        }

    }
}