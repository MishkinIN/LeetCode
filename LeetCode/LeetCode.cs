using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public class LeetCode
    {
        private Dictionary<string, List<TreeNode>> Memo { get; set; }

        public IList<TreeNode> GenerateTrees(int n)
        {
            Memo = new Dictionary<string, List<TreeNode>>();

            return Helper(1, n);
        }

        private List<TreeNode> Helper(int start, int end)
        {
            var key = string.Format("{0}_{1}", start, end);

            if (Memo.ContainsKey(key))
            {
                return Memo[key];
            }

            //Best case 1: subproblem's size is zero
            if (start > end)
            {
                return new List<TreeNode> { null };
            }

            //Best case 2: subproblem's size is one
            if (start == end)
            {
                return new List<TreeNode> { new TreeNode(start) };
            }

            //Recursive case
            var result = new List<TreeNode>();

            for (var val = start; val <= end; val++)
            {
                var left = Helper(start, val - 1);
                var right = Helper(val + 1, end);

                foreach (var lst in left)
                {
                    foreach (var rst in right)
                    {
                        result.Add(new TreeNode(val, lst, rst));
                    }
                }
            }

            Memo.Add(key, result);

            return result;
        }
    }
}
