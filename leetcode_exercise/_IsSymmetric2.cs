using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _IsSymmetric2
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            

            return Cur(root.left,root.right);
        }

        bool Cur(TreeNode node1, TreeNode node2)
        {
            if(node1!=null && node2!=null)
            {
                if (node1.val != node2.val)
                    return false;
                else
                    return Cur(node1.left, node2.right) && Cur(node1.right, node2.left);
            }else
                return node1 == node2;
         
            
        }
        //bool Cur2(TreeNode node1, TreeNode node2)
        //{
            
        //}
    }
}
