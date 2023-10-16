using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 路径和
    /// </summary>
    internal class _PathSum
    {
        public IList<IList<int>> PathSum(TreeNode root, int targetSum)
        {
            if (root == null) return result;
            bool ret = false;
            int sum = 0;
            PreVisit(root,ref sum, new Stack<int>(), targetSum, ref ret);

            return result;

        }
        List<IList<int>> result = new();
        void PreVisit(TreeNode n, ref int sum, Stack<int> stack,  int target, ref bool ret)
        {       
            stack.Push(n.val);
            sum += n.val;
            switch (n.left, n.right)
            {
                case (null, null):
                    ret = sum == target;
                    if (ret)
                    {
                        result.Add(stack.Reverse().ToList());
                        ret = false;
                    }
                    break;
                case (_, null):
                    PreVisit(n.left, ref sum, stack, target, ref ret);
                    break;
                case (null, _):
                    PreVisit(n.right, ref sum, stack, target, ref ret);
                    break;
                default:
                    PreVisit(n.left, ref sum, stack, target, ref ret);
                    PreVisit(n.right, ref sum, stack, target, ref ret);
                    break;
            }
            sum -= n.val;
            stack.Pop();                   
        }

        static void Main(string[] args)
        {
            _PathSum p = new();

            var root = Utils.Make(new int?[] { 5, 4, 8, 11, null, 13, 4, 7, 2, null, null, 5, 1 });

            var ret = p.PathSum(root, 22);
            foreach(var n in ret)
            {
                Console.WriteLine(string.Join(",",n));
            }


        }
    }
}
