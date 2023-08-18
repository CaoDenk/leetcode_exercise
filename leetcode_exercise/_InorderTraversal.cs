using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _InorderTraversal
    {
        List<int> ret= new List<int>();
        public IList<int> InorderTraversal(TreeNode root)
        {
            if(root==null)
                return ret;
            Recur(root);
            return ret;
        }
        void Recur(TreeNode root)
        {
            if(root.left != null)
            {
                Recur(root.left);
            }
            ret.Add(root.val);
            if(root.right != null)
            {
                Recur(root.right); 
            }
        }
    }
}
