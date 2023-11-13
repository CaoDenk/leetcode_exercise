using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 中序遍历
    /// </summary>
    internal class _InorderTraversal
    {
        List<int> ret= new List<int>();
        public IList<int> InorderTraversal(TreeNode root)
        {
            if(root==null)
                return ret;
            Dfs(root);
            return ret;
        }
        void Dfs(TreeNode root)
        {
            if(root.left != null)
            {
                Dfs(root.left);
            }
            ret.Add(root.val);
            if(root.right != null)
            {
                Dfs(root.right); 
            }
        }
    }
}
