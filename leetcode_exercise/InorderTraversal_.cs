using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 二叉树的中序遍历 迭代
    /// </summary>
    /// 
    internal class InorderTraversal_
    {


        
        public IList<int> InorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            LinkedList<TreeNode> list = new LinkedList<TreeNode>();
            list.AddLast(root);
            //while (list.Count>0)
            //{
            //    if(list.)

            //}

            return result;

        }

    }
}
