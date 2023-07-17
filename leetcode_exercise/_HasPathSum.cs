using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode_exercise._Preorder;

namespace leetcode_exercise
{
    internal class _HasPathSum
    {
        public bool HasPathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return false;
            int sum = 0;
            bool ret = false;
            PreVisit(root ,ref sum, targetSum,ref ret);
            return ret;
        }
        void PreVisit(TreeNode n,ref int sum,int target,ref bool ret)
        {
            if (ret)
                return;
            sum += n.val;
            switch(n.left,n.right)
            {
                case (null, null):
                    ret = sum == target;
                    break;                      
                case (_, null):
                    PreVisit(n.left,ref sum,target,ref ret);
                    break;
                case (null, _):
                    PreVisit(n.right, ref sum, target, ref ret);
                    break;
                default:
                    PreVisit(n.left, ref sum, target, ref ret); 
                    PreVisit(n.right, ref sum, target,ref ret);
                    break;
            }
            sum -= n.val;
        }
        static void Main(string[] args)
        {
            var root= Utils.Make(new int?[] {1, -2, -3, 1, 3, -2, null, -1 });
            _HasPathSum sum= new _HasPathSum();
            Console.WriteLine(sum.HasPathSum(root,3));


        }

    }
}
