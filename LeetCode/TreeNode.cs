using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode {

    //Definition for a binary tree node.
    public sealed record TreeNode //(int val, TreeNode left, TreeNode right)
    {
        public int val { get; private set; }
        public TreeNode left { get; private set; }
        public TreeNode right { get; private set; }
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null) {
            this.val = val;
            this.left = left;
            this.right = right;
        }
        public static TreeNode Create(int[] vals) {
            Queue<TreeNode> currentLevel = new Queue<TreeNode>();
            Queue<TreeNode> nextLevel = new Queue<TreeNode>();
            TreeNode root = default, node = default;

            for (int i = 0; i < vals.Length;) {
                if (node == default) {
                    if (currentLevel.Count > 0) {
                        node = currentLevel.Dequeue();
                    }
                    else {
                        var sw = currentLevel;
                        currentLevel = nextLevel;
                        nextLevel = sw;
                        if (currentLevel.Count > 0) {
                            node = currentLevel.Dequeue();
                        }
                        else {
                            root = new TreeNode { val = vals[i++] };
                            node = root;
                            nextLevel.Enqueue(root);
                        }
                    }
                }
                else //(node!=default)
                {
                    if (node.left == default) {
                        var left = new TreeNode { val = (vals[i++]) };
                        node.left = left;
                        nextLevel.Enqueue(left);
                    }
                    else if (node.right == default) {
                        var right = new TreeNode { val = (vals[i++]) };
                        node.right = right;
                        nextLevel.Enqueue(right);
                    }
                    else {
                        node = default;
                    }
                }
            }

            return root;
        }
        public static TreeNode Create(int?[] vals) {
            Queue<TreeNode> currentLevel = new Queue<TreeNode>();
            Queue<TreeNode> nextLevel = new Queue<TreeNode>();
            if (vals == null || vals.Length == 0 || !vals[0].HasValue)
                return null;
            TreeNode root = new TreeNode(vals[0].Value), node = default, left, right;

            currentLevel.Enqueue(root);
            int i = 1;
            int? val = null;
            while (i < vals.Length) {
                if (currentLevel.Count == 0) {
                    if (nextLevel.Count == 0) {
                        break;
                    }
                    var sw = currentLevel;
                    currentLevel = nextLevel;
                    nextLevel = sw;
                }
                else {
                    node = currentLevel.Dequeue();
                    val = vals[i++];
                    if (val.HasValue) {
                        left = new TreeNode(val.Value);
                        nextLevel.Enqueue(left);
                        node.left = left;
                    }
                    if (i == vals.Length)
                        break;
                    val = vals[i++];
                    if (val.HasValue) {
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
        public static bool IsSymmetric(TreeNode node) {
            return IsSymmetric(node.left, node.right);
        }
        private static bool IsSymmetricRecursion(TreeNode left, TreeNode right) {
            return (left == null && right == null)
                || (!(left == null || right == null)
                    && (left.val == right.val)
                    && IsSymmetricRecursion(left.left, right.right)
                    && IsSymmetricRecursion(left.right, right.left));
        }
        private static bool IsSymmetric(TreeNode left, TreeNode right) {
            if (left == null && right == null)
                return true;
            if (left == null || right == null)
                return false;
            Stack<TreeNode> stack = new Stack<TreeNode>(2000);
            stack.Push(left.right);
            stack.Push(right.left);
            stack.Push(left.left);
            stack.Push(right.right);
            while (stack.Count > 0) {
                right = stack.Pop();
                left = stack.Pop();
                if (left == null && right == null)
                    continue;
                if (left == null || right == null || left.val != right.val)
                    return false;
                else {
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
        public static int FindTilt(TreeNode root) {
            int tiltSum = 0;
            if (root == null) {
                return 0;
            }
            var nodeTilt = GetSumAndTilt(root, tiltSum);
            return nodeTilt.tiltSum;
        }
        private static (int sum, int tilt, int tiltSum) GetSumAndTilt(TreeNode node, int tiltSum) {
            if (node == null) {
                return (0, 0, tiltSum);
            }
            if (node.left == null && node.right == null) {
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
        public TreeNode SearchBST(TreeNode root, int val) {
            if (root == null || root.val == val) {
                return root;
            }
            if (root.val < val) {
                return SearchBST(root.right, val);
            }
            else
                return SearchBST(root.left, val);
        }

        /* Unique Binary Search Trees II
         * Given an integer n, return all the structurally unique BST's (binary search trees), 
         * which has exactly n nodes of unique values from 1 to n. 
         * eturn the answer in any order*/
        public static IList<TreeNode> GenerateTrees(int n) {
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
        private static List<TreeNode> GetTreeNodes(int min, int max) {
            List<TreeNode> list = new();
            if (min > max) {
                list.Add(null);
                return list;
            }
            else if (min == max) {
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
            for (int val = min; val <= max; val++) {
                var leftList = GetTreeNodes(min, val - 1);
                var rightList = GetTreeNodes(val + 1, max);
                foreach (var left in leftList) {
                    foreach (var right in rightList) {
                        list.Add(new TreeNode(val, left, right));
                    }
                }
            }
            cache.Add(range, list);
            return list;
        }
        private static IEnumerable<TreeNode> GetChilds(int min, int max) {
            if (min >= max) {
                yield return null;

            }
            else
                for (int i = min; i < max; i++) {

                    foreach (var left in GetChilds(min, i)) {
                        foreach (var right in GetChilds(i + 1, max)) {
                            TreeNode child = new TreeNode(i);
                            child.left = left;
                            child.right = right;
                            yield return child;
                        }
                    }
                }
        }
        public static bool Equals(TreeNode left, TreeNode right) {
            if (Object.ReferenceEquals(left, right)) {
                return true;
            }
            return (left != null && right != null)
                && left.val == right.val
                && TreeNode.Equals(left.left, right.left)
                && TreeNode.Equals(left.right, right.right);
        }
        /*
         * 617. Merge Two Binary Trees
         * Easy
         * You are given two binary trees root1 and root2.
         * Imagine that when you put one of them to cover the other, 
         * some nodes of the two trees are overlapped while the others are not.
         * You need to merge the two trees into a new binary tree. 
         * The merge rule is that if two nodes overlap, 
         * then sum node values up as the new value of the merged node. 
         * Otherwise, the NOT null node will be used as the node of the new tree.
         * Return the merged tree.
         * 
         * Constraints:

    The number of nodes in both trees is in the range [0, 2000].
    -10^4 <= Node.val <= 10^4

         */
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2) {
            if (root1 == null) {
                return root2;
            }
            if (root2 == null) {
                return root1;
            }
            var node = new TreeNode(root1.val + root2.val,
                left: MergeTrees(root1.left, root2.left),
                right: MergeTrees(root1.right, root2.right));
            return node;
        }
        /*
         * 1305. All Elements in Two Binary Search Trees
         * Medium
         * Given two binary search trees root1 and root2, return a list containing all the integers
         * from both trees sorted in ascending order.
         * Constraints:

    The number of nodes in each tree is in the range [0, 5000].
    -10^5 <= Node.val <= 10^5

         */
        public static IList<int> GetAscendingAllElements(TreeNode root1, TreeNode root2) {
            List<int> list = new();
            if (!(root1 == null & root2 == null)) {
                if (root1 == null) {
                    using (IEnumerator<int> en = new EnumeratorIterativeInorder(root2)) {
                        while (en.MoveNext()) {
                            list.Add(en.Current);
                        }
                    }
                }
                else if (root2 == null) {
                    using (IEnumerator<int> en = new EnumeratorIterativeInorder(root1)) {

                        while (en.MoveNext()) {
                            list.Add(en.Current);
                        }
                    }
                }
                else {

                    using (IEnumerator<int> en2 = new EnumeratorIterativeInorder(root2))
                    using (IEnumerator<int> en1 = new EnumeratorIterativeInorder(root1)) {

                        bool en1_moved = en1.MoveNext();
                        bool en2_moved = en2.MoveNext();
                        do {
                            if (en1.Current < en2.Current) {
                                list.Add(en1.Current);
                                en1_moved = en1.MoveNext();
                            }
                            else {
                                list.Add(en2.Current);
                                en2_moved = en2.MoveNext();
                            }
                        } while (en1_moved & en2_moved);
                        if (en1_moved) {
                            do {
                                list.Add(en1.Current);
                                en1_moved = en1.MoveNext();
                            } while (en1_moved);
                        }
                        else {
                            do {
                                list.Add(en2.Current);
                                en2_moved = en2.MoveNext();
                            } while (en2_moved);
                        }
                    }

                }
            }
            return list;
        }
        public enum EnumerateStrategy {
            Left,
            Center,
            Right,
        }
        private class EnumeratorIterativeInorder : IEnumerator<int>, IDisposable {
            const int maxStackCount = 50_000;
            private Stack<TreeNode> stack;
            private TreeNode node;
            private readonly TreeNode root;
            private bool isInitialized = false;
            public EnumeratorIterativeInorder(TreeNode tree) {
                stack = new();
                root = tree ?? throw new ArgumentNullException();
                Reset();
            }
            public int Current {
                get {
                    if (node != null) {
                        return node.val;
                    }
                    else
                        throw new InvalidOperationException();
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose() {
                node = null;
                stack.Clear();
                stack = null;
            }

            private void DownLeft() {
                if (stack.Count > maxStackCount) {
                    throw new StackOverflowException($"Size of TreeNode elements more than {maxStackCount}");
                }
                while (node.left != null) {
                    stack.Push(node);
                    node = node.left;
                }
            }
            public bool MoveNext() {
                if (stack == null) {
                    throw new ObjectDisposedException(nameof(EnumeratorIterativeInorder));
                }

                if (isInitialized) {
                    node = node.right;
                    while (stack.Count > 0 || node != null) {
                        if (node != null) {
                            stack.Push(node);
                            node = node.left;
                        }
                        else {
                            node = stack.Pop();
                            return true;
                        }
                    }
                    return false;
                }
                else {
                    node = root;
                    while (node.left != null) {
                        stack.Push(node);
                        node = node.left;
                    }
                    isInitialized = true;
                    return true;
                }
            }

            public void Reset() {
                stack.Clear();
                node = null;
                isInitialized = false;
            }
        }

    }
}
