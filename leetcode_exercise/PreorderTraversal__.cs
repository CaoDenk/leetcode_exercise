using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 二叉树的前序递归遍历
    /// </summary>
    internal class PreorderTraversal__
    {
        List<int> ret=new List<int>();
        public IList<int> PreorderTraversal(TreeNode root)
        {
            if (root != null)
                Pre(root);
            return ret;
        }

        void Pre(TreeNode root)
        {
            if (root.left != null)
            {
                PreorderTraversal(root.left);
            }
            ret.Add(root.val);
            if (root.right != null)
            {
                PreorderTraversal(root.right);
            }
        }
    }
}
