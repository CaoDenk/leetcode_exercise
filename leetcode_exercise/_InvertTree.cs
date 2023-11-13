using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace leetcode_exercise
{
    /// <summary>
    ///226. 翻转二叉树
    /// </summary>
    internal class _InvertTree
    {
        public TreeNode InvertTree(TreeNode root)
        {
            if (root == null)return null;
            TreeNode treeNode;
            PreVisit(root, out  treeNode);
            return treeNode;
        }

        void PreVisit(TreeNode n,out  TreeNode gen)
        {
            gen=new TreeNode(n.val);
            if (n.left != null)
            {
                PreVisit(n.left,out  gen.right);
            }
            if (n.right != null)
                PreVisit(n.right,out gen.left);

        }
    }
}
