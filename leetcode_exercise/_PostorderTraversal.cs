using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 二叉树后序遍历
    /// </summary>
    internal class _PostorderTraversal
    {
        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            if(root == null) 
                return result;
            PostVisit(root, result);
            return result;

        }
        void PostVisit(TreeNode n,List<int> l)
        {
            if (n.left != null)
            {
                PostVisit(n.left,l);
            }
            if (n.right != null)
                PostVisit(n.right, l);
            l.Add(n.val); 
        }
    }
}
