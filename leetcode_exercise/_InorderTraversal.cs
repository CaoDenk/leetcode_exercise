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
            Cur(root);
            return ret;
        }
        void Cur(TreeNode root)
        {
            if(root.left != null)
            {
                Cur(root.left);
            }
            ret.Add(root.val);
            if(root.right != null)
            {
                Cur(root.right); 
            }
        }
    }
}
