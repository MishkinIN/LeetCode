using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{

    //Definition for a binary tree node.
    public sealed record TreeNode //(int val, TreeNode left, TreeNode right)
    {
        public int val { get; private set; }
        public TreeNode left { get; private set; }
        public TreeNode right { get; private set; }
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        public static TreeNode Create(int[] vals)
        {
            Queue<TreeNode> currentLevel = new Queue<TreeNode>();
            Queue<TreeNode> nextLevel = new Queue<TreeNode>();
            TreeNode root = default, node = default;

            for (int i = 0; i < vals.Length;)
            {
                if (node == default)
                {
                    if (currentLevel.Count > 0)
                    {
                        node = currentLevel.Dequeue();
                    }
                    else
                    {
                        var sw = currentLevel;
                        currentLevel = nextLevel;
                        nextLevel = sw;
                        if (currentLevel.Count > 0)
                        {
                            node = currentLevel.Dequeue();
                        }
                        else
                        {
                            root = new TreeNode { val = vals[i++] };
                            node = root;
                            nextLevel.Enqueue(root);
                        }
                    }
                }
                else //(node!=default)
                {
                    if (node.left == default)
                    {
                        var left = new TreeNode { val = (vals[i++]) };
                        node.left = left;
                        nextLevel.Enqueue(left);
                    }
                    else if (node.right == default)
                    {
                        var right = new TreeNode { val = (vals[i++]) };
                        node.right = right;
                        nextLevel.Enqueue(right);
                    }
                    else
                    {
                        node = default;
                    }
                }
            }

            return root;
        }
        public static TreeNode Create(int?[] vals)
        {
            Queue<TreeNode> currentLevel = new Queue<TreeNode>();
            Queue<TreeNode> nextLevel = new Queue<TreeNode>();
            if (vals == null || vals.Length == 0 || !vals[0].HasValue)
                return null;
            TreeNode root = new TreeNode(vals[0].Value), node = default, left, right;

            currentLevel.Enqueue(root);
            int i = 1;
            int? val = null;
            while (i < vals.Length)
            {
                if (currentLevel.Count == 0)
                {
                    if (nextLevel.Count == 0)
                    {
                        break;
                    }
                    var sw = currentLevel;
                    currentLevel = nextLevel;
                    nextLevel = sw;
                }
                else
                {
                    node = currentLevel.Dequeue();
                    val = vals[i++];
                    if (val.HasValue)
                    {
                        left = new TreeNode(val.Value);
                        nextLevel.Enqueue(left);
                        node.left = left;
                    }
                    if (i == vals.Length)
                        break;
                    val = vals[i++];
                    if (val.HasValue)
                    {
                        right = new TreeNode(val.Value);
                        nextLevel.Enqueue(right);
                        node.right = right;
                    }

                }
            }
            return root;
        }
        /// <summary>
        /// Given the node of a binary tree, check whether it is a mirror of itself (i.e., symmetric around its center).
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public static bool IsSymmetric(TreeNode node)
        {
            return IsSymmetric(node.left, node.right);
        }
        private static bool IsSymmetricRecursion(TreeNode left, TreeNode right)
        {
            return (left == null && right == null)
                || (!(left == null || right == null)
                    && (left.val == right.val)
                    && IsSymmetricRecursion(left.left, right.right)
                    && IsSymmetricRecursion(left.right, right.left));
        }
        private static bool IsSymmetric(TreeNode left, TreeNode right)
        {
            if (left == null && right == null)
                return true;
            if (left == null || right == null)
                return false;
            Stack<TreeNode> stack = new Stack<TreeNode>(2000);
            stack.Push(left.right);
            stack.Push(right.left);
            stack.Push(left.left);
            stack.Push(right.right);
            while (stack.Count > 0)
            {
                right = stack.Pop();
                left = stack.Pop();
                if (left == null && right == null)
                    continue;
                if (left == null || right == null || left.val != right.val)
                    return false;
                else
                {
                    stack.Push(left.right);
                    stack.Push(right.left);
                    stack.Push(left.left);
                    stack.Push(right.right);
                }
            }
            return true;
        }
        /*
         * Given the root of a binary tree, return the sum of every tree node's tilt.
         * The tilt of a tree node is the absolute difference between the sum 
         * of all left subtree node values and all right subtree node values. 
         * If a node does not have a left child, then the sum of the left subtree node values is treated as 0. 
         * The rule is similar if the node does not have a right child.
         * 
Example 2:

Input: root = [4, 2,9, 3,5,null,7]
Output: 15
Explanation: 
Tilt of node 3 : |0-0| = 0 (no children)
Tilt of node 5 : |0-0| = 0 (no children)
Tilt of node 7 : |0-0| = 0 (no children)
Tilt of node 2 : |3-5| = 2 (left subtree is just left child, so sum is 3; right subtree is just right child, so sum is 5)
Tilt of node 9 : |0-7| = 7 (no left child, so sum is 0; right subtree is just right child, so sum is 7)
Tilt of node 4 : |(3+5+2)-(9+7)| = |10-16| = 6 (left subtree values are 3, 5, and 2, which sums to 10; right subtree values are 9 and 7, which sums to 16)
Sum of every tilt : 0 + 0 + 0 + 2 + 7 + 6 = 15

         */
        public static int FindTilt(TreeNode root)
        {
            int tiltSum = 0;
            if (root == null)
            {
                return 0;
            }
            var nodeTilt = GetSumAndTilt(root, tiltSum);
            return nodeTilt.tiltSum;
        }
        private static (int sum, int tilt, int tiltSum) GetSumAndTilt(TreeNode node, int tiltSum)
        {
            if (node == null)
            {
                return (0, 0, tiltSum);
            }
            if (node.left == null && node.right == null)
            {
                return (node.val, 0, tiltSum);
            }
            var left = GetSumAndTilt(node.left, tiltSum);
            var right = GetSumAndTilt(node.right, left.tiltSum);
            var tilt = left.sum - right.sum;
            tilt = tilt < 0 ? -1 * tilt : tilt;
            tiltSum = right.tiltSum + tilt;
            return (node.val + left.sum + right.sum, tilt, tiltSum);

        }
        /*
         * You are given the root of a binary search tree (BST) and an integer val.
         * Find the node in the BST that the node's value equals val 
         * and return the subtree rooted with that node. 
         * If such a node does not exist, return null.
         */
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root == null || root.val == val)
            {
                return root;
            }
            if (root.val < val)
            {
                return SearchBST(root.right, val);
            }
            else
                return SearchBST(root.left, val);
        }

        /* Unique Binary Search Trees II
         * Given an integer n, return all the structurally unique BST's (binary search trees), 
         * which has exactly n nodes of unique values from 1 to n. 
         * eturn the answer in any order*/
        public static IList<TreeNode> GenerateTrees(int n)
        {
            //List<TreeNode> list = new List<TreeNode>();
            //n++;
            //for (int i = 1; i < n; i++)
            //{

            //    foreach (var left in GetChilds(1, i))
            //    {
            //        foreach (var right in GetChilds(i+1, n))
            //        {
            //            TreeNode node = new TreeNode(i);
            //            node.left = left; node.right = right;
            //            list.Add(node);
            //        }
            //    }
            //}

            //list.AddRange(GetTreeNodes(1, n));
            var list = GetTreeNodes(1, n);
            return list;
        }
        private static Dictionary<int, List<TreeNode>> cache = new Dictionary<int, List<TreeNode>>();
        private static List<TreeNode> GetTreeNodes(int min, int max)
        {
            List<TreeNode> list = new();
            if (min > max)
            {
                list.Add(null);
                return list;
            }
            else if (min == max)
            {
                list.Add(new TreeNode(min));
                return list;
            }
            var range = min + max * Int16.MaxValue;
            if (cache.ContainsKey(range))
                return cache[range];
            //{
            //    for (int i = min; i <=max; i++)
            //    {
            //        foreach (var left in GetTreeNodes(min,i-1))
            //        {
            //            foreach (var right in GetTreeNodes(i+1,max))
            //            {
            //                 list.Add(new TreeNode(i, left, right));
            //            }
            //        }
            //    }
            //}
            for (int val = min; val <= max; val++)
            {
                var leftList = GetTreeNodes(min, val - 1);
                var rightList = GetTreeNodes(val + 1, max);
                foreach (var left in leftList)
                {
                    foreach (var right in rightList)
                    {
                        list.Add(new TreeNode(val, left, right));
                    }
                }
            }
            cache.Add(range, list);
            return list;
        }
        private static IEnumerable<TreeNode> GetChilds(int min, int max)
        {
            if (min >= max)
            {
                yield return null;

            }
            else
                for (int i = min; i < max; i++)
                {

                    foreach (var left in GetChilds(min, i))
                    {
                        foreach (var right in GetChilds(i + 1, max))
                        {
                            TreeNode child = new TreeNode(i);
                            child.left = left; child.right = right;
                            yield return child;
                        }
                    }
                }
        }
        public static bool Equals(TreeNode left, TreeNode right)
        {
            if (Object.ReferenceEquals(left, right))
            {
                return true;
            }
            return (left != null && right != null)
                && left.val == right.val
                && TreeNode.Equals(left.left, right.left)
                && TreeNode.Equals(left.right, right.right);
        }
    }
}
