using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 剑指 Offer 28. 对称的二叉树
    /// </summary>
    internal class IsSymmetric_
    {
        public bool IsSymmetric(TreeNode root)
        {
            if (root == null) return true;
            bool flag = true;
            Recur(root.right,root.left,ref flag);
            return flag;
        }
        /// <summary>
        /// flag false 的时候不对称
        /// </summary>
        /// <param name="node1"></param>
        /// <param name="node2"></param>
        /// <param name="flag"></param>
        void Recur(TreeNode node1,TreeNode node2,ref bool flag)
        {

            if(node1!=null &&node2!=null )
            {
                if (node1.val == node2.val)
                {
                    Recur(node1.left,node2.right,ref flag);
                    if (!flag)
                        return;
                    Recur(node1.right, node2.left, ref flag);
                }
                else
                {
                    flag = false; 
                }

            }else if(node1!=node2)
            {
                flag = false;
            }
               
        }
    }
}
