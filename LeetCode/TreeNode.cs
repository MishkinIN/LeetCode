﻿using System;
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
            Queue<TreeNode> currentLevel = new();
            Queue<TreeNode> nextLevel = new();
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
            Queue<TreeNode> currentLevel = new();
            Queue<TreeNode> nextLevel = new();
            if (vals == null || vals.Length == 0 || !vals[0].HasValue)
                return null;
            TreeNode root = new(vals[0].Value), left, right;

            currentLevel.Enqueue(root);
            int i = 1;
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
                    TreeNode node = currentLevel.Dequeue();
                    int? val = vals[i++];
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
            Stack<TreeNode> stack = new(2000);
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
        public static bool Contains(TreeNode root, int val) {
            if (root.val == val)
                return true;
            if (root == null) {
                return false;
            }
            return Contains(root.right, val) || Contains(root.left, val);
        }
        public static bool ContainsBST(TreeNode bst, int val) {
            if (bst == null) {
                return false;
            }
            if (bst.val == val)
                return true;
            if (bst.val > val) {
                return ContainsBST(bst.left, val);
            }
            else {
                return ContainsBST(bst.right, val);
            }
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
        private static readonly Dictionary<int, List<TreeNode>> cache = new();
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
                            TreeNode child = new(i) {
                                left = left,
                                right = right
                            };
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
                    using IEnumerator<int> en = new EnumeratorIterativeInorder(root2);
                    while (en.MoveNext()) {
                        list.Add(en.Current);
                    }
                }
                else if (root2 == null) {
                    using IEnumerator<int> en = new EnumeratorIterativeInorder(root1);

                    while (en.MoveNext()) {
                        list.Add(en.Current);
                    }
                }
                else {

                    using IEnumerator<int> en2 = new EnumeratorIterativeInorder(root2);
                    using IEnumerator<int> en1 = new EnumeratorIterativeInorder(root1);

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
            return list;
        }
        public static int MaxDepth(TreeNode root) {
            if (root == null)
                return 0;
            return Dept(root);
        }
        private static int Dept(TreeNode node) {
            TreeNode grandChield = node.left?.left;
            int dept_ll = grandChield == null ? 1 : Dept(grandChield) + 2;
            grandChield = node.left?.right;
            int dept_lr = grandChield == null ? 1 : Dept(grandChield) + 2;
            grandChield = node.right?.left;
            int dept_rl = grandChield == null ? 1 : Dept(grandChield) + 2;
            grandChield = node.right?.right;
            int dept_rr = grandChield == null ? 1 : Dept(grandChield) + 2;
            int dept = System.Math.Max(
                System.Math.Max(dept_ll, dept_lr),
                System.Math.Max(dept_rl, dept_rr));
            if (dept == 1 && !(node.left == null && node.right == null)) {
                return 2;
            }
            return dept;
        }
        public static TreeNode InvertTree(TreeNode root) {
            if (root == null) {
                return null;
            }
            var left = InvertTree(root.right);
            root.right = InvertTree(root.left);
            root.left = left;
            return root;
        }
        public static bool HasPathSum(TreeNode root, int targetSum) {
            if (root == null) {
                return false;
            }
            if (root.left == null && root.right == null) {
                return root.val == targetSum;
            }
            return HasPathSum(root.left, targetSum - root.val)
                || HasPathSum(root.right, targetSum - root.val);
        }
        /*
         * 701. Insert into a Binary Search Tree
         * Medium
         * You are given the root node of a binary search tree (BST) and a value to insert into the tree. 
         * Return the root node of the BST after the insertion. 
         * It is guaranteed that the new value does not exist in the original BST.
         * Notice that there may exist multiple valid ways for the insertion, as long as the tree remains a BST after insertion.
         * You can return any of them.
         * Constraints:

    The number of nodes in the tree will be in the range [0, 10^4].
    -10^8 <= Node.val <= 10^8
    All the values Node.val are unique.
    -10^8 <= val <= 10^8
    It's guaranteed that val does not exist in the original BST.

         */
        public static TreeNode InsertIntoBST(TreeNode root, int val) {
            if (root == null) {
                return new TreeNode(val);
            }
            return Insert(root, val);
        }
        private static TreeNode Insert(TreeNode bstNode, int val) {
            if (bstNode.val < val) {
                if (bstNode.right == null) {
                    bstNode.right = new TreeNode(val);
                    return bstNode;
                }
                bstNode.right = Insert(bstNode.right, val);
                return bstNode;
            }
            else if (bstNode.val > val) {
                if (bstNode.left == null) {
                    bstNode.left = new TreeNode(val);
                    return bstNode;
                }
                bstNode.left = Insert(bstNode.left, val);
                return bstNode;
            }
            else
                throw new InvalidOperationException();
        }
        private struct BSTValidateResult {
            public readonly bool isValid;
            public readonly int leftValue;
            public readonly int rightValue;
            public BSTValidateResult(bool valid, int lv, int rv) {
                this.isValid = valid;
                this.leftValue = lv;
                this.rightValue = rv;
            }
        }
        private static TreeNode Insert_I(TreeNode bstNode, int val) {
            if (bstNode.val < val) {
                if (bstNode.right == null) {
                    bstNode.right = new TreeNode(val);
                    return bstNode;

                }
                //else if (bstNode.right.val > val) {
                //    TreeNode root = new TreeNode(val,
                //        left: bstNode,
                //        right: bstNode.right
                //        );
                //    bstNode.right = null;
                //    return root;
                //}
                //else
                //    return Insert(bstNode.right, val);
                bstNode.right = Insert(bstNode.right, val);
                return bstNode;
            }
            else if (bstNode.val > val) {
                if (bstNode.left == null) {
                    bstNode.left = new TreeNode(val);
                    return bstNode;
                }
                //else if (bstNode.left.val < val) {
                //    TreeNode root = new TreeNode(val,
                //        right: bstNode,
                //        left: bstNode.left
                //        );
                //    bstNode.left = null;
                //    return root;
                //}
                //else
                //    return Insert(bstNode.left, val);
                bstNode.left = Insert(bstNode.left, val);
                return bstNode;
            }
            else
                throw new InvalidOperationException();
        }
        public static bool IsValidBST(TreeNode root) {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            return IsValidLeft(root.left, root.val) && IsValidRight(root.right, root.val);
        }

        public static bool IsValidLeft(TreeNode node, int parentVal) {
            if (node == null) {
                return true;
            }
            if (node.val >= parentVal) {
                return false;
            }
            return IsValidLeft(node.left, node.val)
                && IsValidLeft(node.right, parentVal)
                && IsValidRight(node.right, node.val);
        }
        public static bool IsValidRight(TreeNode node, int parentVal) {
            if (node == null) {
                return true;
            }
            if (node.val <= parentVal) {
                return false;
            }
            return IsValidRight(node.left, parentVal)
                && IsValidLeft(node.left, node.val)
                && IsValidRight(node.right, node.val);
        }

        public bool IsValidBST() {
            return IsValidBST_LC(this, null, null);

        }

        private static bool IsValidBST_LC(TreeNode node, int? min, int? max) {
            if (node == null) {
                return true;
            }

            if ((max != null && node.val >= max)
               || (min != null && node.val <= min)) {
                return false;
            }

            return IsValidBST_LC(node.left, min, node.val) && IsValidBST_LC(node.right, node.val, max);

        }

        public static bool IsValidBST_I(TreeNode root) {
            if (root == null)
                throw new ArgumentNullException(nameof(root));
            var validate = ValidateBST(root);
            return validate.isValid;
        }
        private static BSTValidateResult ValidateBST(TreeNode node) {
            if (node.left == null & node.right == null) {
                return new BSTValidateResult(true, node.val, node.val);
            }
            if (node.left == null ^ node.right == null) {
                if (node.left == null) {
                    var _validate = ValidateBST(node.right);
                    var validate = new BSTValidateResult(
                        valid: _validate.isValid & node.val < _validate.leftValue,
                        lv: node.val,
                        rv: _validate.rightValue);
                    return validate;
                }
                if (node.right == null) {
                    var _validate = ValidateBST(node.left);
                    var validate = new BSTValidateResult(
                        valid: _validate.isValid & node.val > _validate.rightValue,
                        lv: _validate.leftValue,
                        rv: node.val);
                    return validate;
                }
            }
            {
                var l_validate = ValidateBST(node.left);
                var r_validate = ValidateBST(node.right);
                var validate = new BSTValidateResult(
                            valid: r_validate.isValid & l_validate.isValid
                            && node.val > l_validate.rightValue
                            && node.val < r_validate.leftValue,
                            lv: l_validate.leftValue,
                            rv: r_validate.rightValue);
                return validate;
            }
        }

        /*
         * 102. Binary Tree Level Order Traversal
         * Medium
         * Given the root of a binary tree, return the level order traversal of its nodes' values. 
         * (i.e., from left to right, level by level).
         * Constraints:
    The number of nodes in the tree is in the range [0, 10^5].
    -1000 <= Node.val <= 1000

         */
        public static IList<IList<int>> LevelOrder(TreeNode root) {
            List<IList<int>> lists = new(50000);
            if (root == null)
                return lists;
            int lvl = 0;
            TreeToLevelOrder_Recursion(lists, lvl, root);
            return lists;
        }
        public static IList<IList<int>> LevelOrder_recursion(TreeNode root) {
            List<IList<int>> lists = new();
            if (root == null)
                return lists;
            int lvl = 0;
            TreeToLevelOrder_Recursion(lists, lvl, root);
            return lists;
        }
        /*
         * 235. Lowest Common Ancestor of a Binary Search Tree
         * Easy
         * Given a binary search tree (BST), find the lowest common ancestor (LCA)
         * of two given nodes in the BST.
         * According to the definition of LCA on Wikipedia: 
         * “The lowest common ancestor is defined between two nodes p and q 
         * as the lowest node in T that has both p and q as descendants 
         * (where we allow a node to be a descendant of itself).”
         * 
         * Constraints:

    The number of nodes in the tree is in the range [2, 10^5].
    -10^9 <= Node.val <= 10^9
    All Node.val are unique.
    p != q
    p and q will exist in the BST.
         */
        public static TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
            int leftval, rightval;
            if (p.val > q.val) {
                leftval = q.val;
                rightval = p.val;
            }
            else {
                leftval = p.val;
                rightval = q.val;
            }
            if (leftval == root.val || rightval == root.val)
                return root;
            if (leftval < (root.val) ) {
                if (rightval > root.val)
                    return root;
                else
                    return LowestCommonAncestor(root.left, p, q);
            }
            return LowestCommonAncestor(root.right, p, q);
        }
        private static void TreeToLevelOrder_List(List<IList<int>> lists, List<TreeNode> lvlQueue) {
            List<int> lvlVals = new();
            lists.Add(lvlVals);
            List<TreeNode> nextQueue = new();
            foreach (var item in lvlQueue) {
                lvlVals.Add(item.val);
                if (item.left != null) {
                    nextQueue.Add(item.left);
                }
                if (item.right != null) {
                    nextQueue.Add(item.right);
                }
            }
            lvlQueue.Clear();
            if (nextQueue.Count > 0) {
                TreeToLevelOrder_List(lists, nextQueue);
            }
        }
        private static void TreeToLevelOrder_Recursion(List<IList<int>> lists, int lvl, TreeNode node) {
            IList<int> lvlVals;
            if (lists.Count > lvl) {
                lvlVals = lists[lvl];
            }
            else {
                lvlVals = new List<int>();
                lists.Add(lvlVals);
            }
            lvlVals.Add(node.val);
            if (node.left != null) {
                TreeToLevelOrder_Recursion(lists, lvl + 1, node.left);
            }
            if (node.right != null) {
                TreeToLevelOrder_Recursion(lists, lvl + 1, node.right);
            }
        }
        /*
        * 653. Two Sum IV - Input is a BST
        * Easy
        * Given the root of a Binary Search Tree and a target number k, 
        * return true if there exist two elements in the BST such that their sum is equal to the given target.
        * Constraints:

   The number of nodes in the tree is in the range [1, 10^4].
   -10^4 <= Node.val <= 10^4
   root is guaranteed to be a valid binary search tree.
   -10^5 <= k <= 10^5

        */
        public static bool FindTarget(TreeNode bstroot, int k) {
            foreach (var val in GetPreorderTraversal(bstroot)) {
                if (k - val == val)
                    continue;
                if (ContainsBST(bstroot, k - val))
                    return true;
            }
            return false;
        }

        private static IEnumerable<int> GetPreorderTraversal(TreeNode root) {
            Stack<TreeNode> stack = new();
            stack.Push(root);
            while (stack.Count > 0) {
                var node = stack.Pop();
                yield return node.val;
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }
        }

        /*
         * 144. Binary Tree Preorder Traversal
         * Easy
         * Given the root of a binary tree, return the preorder traversal of its nodes' values.
         * 
         * Constraints:

    The number of nodes in the tree is in the range [0, 100].
    -100 <= Node.val <= 100

         *Example 1:
Input: root = [1,null,2,3]
Output: [1,2,3]

         */
        public static IList<int> PreorderTraversal(TreeNode root) {
            List<int> list = new();
            Stack<TreeNode> stack = new();
            stack.Push(root);
            while (stack.Count > 0) {
                var node = stack.Pop();
                list.Add(node.val);
                if (node.right != null)
                    stack.Push(node.right);
                if (node.left != null)
                    stack.Push(node.left);
            }
            return list;
        }
        /*
         * 94. Binary Tree Inorder Traversal
         * Easy
         * Given the root of a binary tree, return the inorder traversal of its nodes' values.
         *
         *Example 1:

Input: root = [1,null,2,3]
Output: [1,3,2]

         */
        public static IList<int> InorderTraversal(TreeNode root) {
            List<int> list = new();
            if (root == null)
                return list;
            Stack<TreeNode> stack = new();
            var node = root;

            bool goLeft = true;
            while (true) {
                if (goLeft) {
                    if (node.left != null) {
                        stack.Push(node);
                        node = node.left;
                        continue;
                    }
                    list.Add(node.val);
                    if (node.right != null) {
                        node = node.right;
                        continue;
                    }
                    if (!stack.TryPop(out node))
                        break;
                    goLeft = false;
                }
                else {
                    list.Add(node.val);
                    if (node.right != null) {
                        node = node.right;
                        goLeft = true;
                        continue;
                    }
                    if (!stack.TryPop(out node))
                        break;
                    goLeft = false;
                }
            }
            return list;
        }
        public static IList<int> InorderTraversal_LC(TreeNode root) {

            List<int> result = new List<int>();

            Inorder_lc(root, result);
            return result;
        }

        public static IList<int> InorderTraversal_LC1(TreeNode root) {
            var result = new List<int>();

            if (root == null) {
                return result;
            }

            var stack = new Stack<TreeNode>();
            var currentNode = root;

            while (currentNode != null) {
                if (currentNode.left != null) {
                    stack.Push(currentNode);
                    currentNode = currentNode.left;
                    continue;
                }

                result.Add(currentNode.val);

                if (currentNode.right != null) {
                    currentNode = currentNode.right;
                    continue;
                }

                if (stack.Count > 0) {
                    currentNode = stack.Pop();
                    currentNode.left = null;
                }
                else {
                    currentNode = null;
                }

            }

            return result;
        }
        private static IList<int> Inorder_lc(TreeNode root, List<int> result) {
            if (root == null)
                return result;
            if (root.left == null && root.right == null) {
                result.Add(root.val);
                return result;
            }

            Inorder_lc(root.left, result);
            result.Add(root.val);
            Inorder_lc(root.right, result);
            return result;
        }
        /*
         * 145. Binary Tree Postorder Traversal
         * Easy
         * Given the root of a binary tree, return the postorder traversal of its nodes' values.
         * 
         * Example 1:
Input: root = [1,null,2,3]
Output: [3,2,1]
         */
        public static IList<int> PostorderTraversal(TreeNode root) {
            List<int> values = new();
            if (root == null)
                return values;
            PostorderTraversal(values, root);
            return values;
        }
        public static void PostorderTraversal(List<int> values, TreeNode node) {
            if (node.left != null)
                PostorderTraversal(values, node.left);
            if (node.right != null)
                PostorderTraversal(values, node.right);
            values.Add(node.val);
        }
        /*
         * 96. Unique Binary Search Trees
         * Medium
         * Given an integer n, return the number of structurally unique BST's (binary search trees)
         * which has exactly n nodes of unique values from 1 to n.
         * 
         * Constraints:
    1 <= n <= 19
         */
        public static int NumTrees(int n) {
            int[] vs = new int[n + 1];
            if (n == 1) {
                return 1;
            }
            vs[0] = 1;
            vs[1] = 1;
            vs[2] = 2;
            for (int i = 3; i <= n; i++) {
                int k = i - 1;
                for (int j = 0; j < i; j++) {
                    vs[i] += vs[k] * vs[j];
                    k--;
                }
            }
            return vs[^1];
        }
        public class TreeNodeCursor {
            private readonly Stack<TreeNode> stack = new();
            private readonly TreeNode root;
            public TreeNodeCursor(TreeNode root) {
                this.root = root;
            }
            public bool LeftDown() {
                throw new NotImplementedException();
            }
            public bool RightDown() {
                throw new NotImplementedException();

            }
            public TreeNode Current {
                get; private set;
            }
            public bool StepNext() {
                throw new NotImplementedException();
            }
            public bool StepPrevious() {
                throw new NotImplementedException();
            }
            public bool Find(int val) {
                do {
                    if (Current.val < val) {

                    }
                    else {

                    }
                } while (true);
            }

        }
        private class EnumeratorIterativeInorder : IEnumerator<int>, IDisposable {
            const int maxStackCount = 50_000;
            private Stack<TreeNode> stack;
            private TreeNode node;
            private readonly TreeNode root;
            private bool isInitialized = false;
            public EnumeratorIterativeInorder(TreeNode tree) {
                stack = new();
                root = tree ?? throw new ArgumentNullException(nameof(tree));
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
