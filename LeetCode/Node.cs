using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public sealed record Node {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
        public static Node Create(int[] vals) {
            Queue<Node> currentLevel = new ();
            Queue<Node> nextLevel = new ();
            Node root = default, node = default;

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
                            root = new Node { val = vals[i++] };
                            node = root;
                            nextLevel.Enqueue(root);
                        }
                    }
                }
                else //(node!=default)
                {
                    if (node.left == default) {
                        var left = new Node { val = (vals[i++]) };
                        node.left = left;
                        nextLevel.Enqueue(left);
                    }
                    else if (node.right == default) {
                        var right = new Node { val = (vals[i++]) };
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
        public static Node Create(int?[] vals) {
            Queue<Node> currentLevel = new ();
            Queue<Node> nextLevel = new ();
            if (vals == null || vals.Length == 0 || !vals[0].HasValue)
                return null;
            Node root = new(vals[0].Value);

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
                    var node = currentLevel.Dequeue();
                    int? val = vals[i++];
                    if (val.HasValue) {
                        var left = new Node(val.Value);
                        nextLevel.Enqueue(left);
                        node.left = left;
                    }
                    if (i == vals.Length)
                        break;
                    val = vals[i++];
                    if (val.HasValue) {
                        var right = new Node(val.Value);
                        nextLevel.Enqueue(right);
                        node.right = right;
                    }

                }
            }
            return root;
        }
        /*
         * 116. Populating Next Right Pointers in Each Node
         * Medium
         * You are given a perfect binary tree where all leaves are on the same level,
         * and every parent has two children. 
         * 
         * Populate each next pointer to point to its next right node.
         * If there is no next right node, the next pointer should be set to NULL.
         * Initially, all next pointers are set to NULL.
         * Constraints:

    The number of nodes in the tree is in the range [0, 2^12 - 1].
    -1000 <= Node.val <= 1000

         */
        public static Node Connect(Node root) {
            if (root==null) {
                return root;
            }
            List<Node> parents = new();
            int level = 0;
            Connect(parents, level, root);
            return root;
        }
        private static void Connect(List<Node> parents, int level, Node node) {
            if (parents.Count > level) {
                node.next = parents[level];
                parents[level] = node;
            }
            else
                parents.Add(node);
            level++;
            if (node.right != null) {
                Connect(parents, level, node.right);
            }
            if (node.left != null) {
                Connect(parents, level, node.left);
            }

        }
    }
}
