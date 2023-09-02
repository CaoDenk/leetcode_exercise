using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 437. 路径总和 III
    /// </summary>
    internal class PathSum3
    {
        int count = 0;
        public int PathSum(TreeNode root, int targetSum)
        {
            if (root == null)
                return count;
            Visit(root,0, targetSum);
            PathSum(root.left, targetSum);
            PathSum(root.right, targetSum);
            return count;
        }
        public void Visit(TreeNode root,long sum,int target) 
        {

            if(root==null)
            {
                return;
            }
            sum += root.val;
            if(sum==target)
                count++;
            Visit(root.left, sum  , target);
            Visit(root.right, sum , target);

        }


    }
}
