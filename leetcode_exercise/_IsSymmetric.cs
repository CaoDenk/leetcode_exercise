using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 101. 对称二叉树
    /// </summary>
    internal class _IsSymmetric
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            if(root.left==null&&root.right==null) return true;
            try
            {
                Cur(root.left,root.right);
            }catch (Exception)
            {
                return false;
            }

            return true;
        }

        void Cur(TreeNode node1,TreeNode node2)
        {
            if (node1.val != node2.val)
                throw new Exception();
            else
            {   if(node1.left!=null||node2.right!=null)
                    Cur(node1.left,node2.right);
                if (node1.right != null || node2.left != null)
                    Cur(node1.right, node2.left);
            }

        }
    }
}
