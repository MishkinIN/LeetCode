using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    public static partial class Solution
    {
        /*
         * You are given the root of a binary tree where each node has a value 0 or 1. 
         * Each root-to-leaf path represents a binary number starting with the most significant bit.
         * For example, if the path is 0 -> 1 -> 1 -> 0 -> 1, then this could represent 01101 in binary, which is 13.
         * For all leaves in the tree, consider the numbers represented by the path from the root to that leaf. 
         * Return the sum of these numbers.
         * 
         * The test cases are generated so that the answer fits in a 32-bits integer.
         * Constraints:
         *   The number of nodes in the tree is in the range [1, 1000].
         *   Node.val is 0 or 1.
         */
        public static int SumRootToLeaf(TreeNode root)
        {
            int sum2 = 0;
            SumRootToLeaf_DFS(root, root.val, ref sum2);
            return sum2;
        }

        private static void SumRootToLeaf_DFS(TreeNode node, int val, ref int sum2)
        {
            if (node.left == null && node.right == null)
            {
                sum2 += val;
                return;
            }
            if (node.left != null)
            {
                SumRootToLeaf_DFS(node.left, val <<1 | node.left.val, ref sum2);
            }
            if (node.right != null)
            {
                SumRootToLeaf_DFS(node.right, val <<1 | node.right.val, ref sum2);
            }

        }
        public static int MySumRootToLeaf(TreeNode root)
        {
            // Дополнительное требование: реализовать как "чистую" функцию. 
            // Для определенности, назовем "number" из задания - весом вершины.
            // Мой план:
            // 1. поскольку  наложено ограничение на максимальное число вершин, вместо стека используем дополнительный массив stack.
            //     1.1 В стеке храним указатель на узел node вес wt
            // 2. поскольку известно, что сумма весов листьев не превысит 32-bits integer, а все веса  больше нуля, старший бит
            //    значения nums[i] будет показывать, посещался ли узел.
            //  2.1 Обрабатываем вершину: приписываем вес
            // 3. Обработка node:
            //        
            //    3.1 если node является листом, суммируем вес узла и выталкиваем из стека узел node.
            //      3.1.1 если вес узла меньше нуля, переходим к предыдущему элементу стека.
            //      3.1.2 иначе обрабатываем правую ветвь. Если её нет, переходим к предыдущему элементу стека.
            //    3.2 если существует левый узел, приписываем node положительный вес, толкаем в стек и обрабатываем левый узел.
            //      3.2.1 иначе, приписываем node отрицательный вес, толкаем в стек и обрабатываем правый узел.
            Int32 sum = 0;
            TreeNode node = root;
            Int32 weight = node.val & 0b1;

            WtNode wtNode = new(node: node, wt: weight);
            bool is_wtNodeFromStack = false;
            int i = 0;
            WtNode[] stack = new WtNode[1000];

            do
            {
                if (wtNode.wt < 0)
                {
                    if (--i < 0)
                    {
                        break;
                    }
                    wtNode = stack[i];
                    weight >>= 1;
                    is_wtNodeFromStack = true;
                }
                else
                {
                    node = wtNode.node;
                    if (!is_wtNodeFromStack)
                    {
                        if (node.left != null)
                        {
                            stack[i++] = wtNode;
                            node = node.left;
                            weight = Increment(weight, node.val);
                            wtNode = new WtNode(node: node, wt: weight);
                        }
                        else if (node.right != null)
                        {
                            wtNode = wtNode with { wt = ~wtNode.wt };
                            stack[i++] = wtNode;
                            node = node.right;
                            weight = Increment(weight, node.val);
                            wtNode = new WtNode(node: node, wt: weight);
                        }
                        else
                        {
                            sum += weight;
                            if (sum < 0)
                            {
                                throw new ArgumentOutOfRangeException(nameof(root), $"The sum of weights is not fit in a 32-bits integer.");
                            }
                            wtNode = wtNode with { wt = ~wtNode.wt };
                        }
                    }
                    else
                    {
                        wtNode = wtNode with { wt = ~wtNode.wt };
                        if (node.right != null)
                        {
                            stack[i++] = wtNode;
                            node = node.right;
                            weight = Increment(weight, node.val);
                            wtNode = new WtNode(node: node, wt: weight);
                            is_wtNodeFromStack = false;
                        }
                    }
                }
            } while (i >= 0);
            return sum;
        }
        private static int Increment(int weight, int val)
        {
            weight = weight << 1 | (val & 0b1);
            if (weight < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(weight),$"Weight for node more than 2**31-1.");
            }
            return weight;
        }
        private record WtNode(TreeNode node, Int32 wt);
        //{
        //    public TreeNode node { get; init;}
        //    public Int32 wt { get; init; }
        //}


    }
}
