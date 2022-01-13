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

    }
}
