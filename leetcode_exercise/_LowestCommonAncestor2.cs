using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 236. 二叉树的最近公共祖先
    /// </summary>
    internal class _LowestCommonAncestor2
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            if(root==null)
                return null;
            if (root == p || root == q)
                return root;

            TreeNode left=LowestCommonAncestor(root.left, p, q);
            TreeNode right=LowestCommonAncestor(root.right, p, q);
            if (left != null && right != null)
                return root;
            if (left == null)
                return right;
            if(right == null)
                return left;
            return root;
        }
    }
}
