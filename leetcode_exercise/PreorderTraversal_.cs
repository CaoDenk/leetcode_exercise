﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 线序遍历不使用递归，使用迭代
    /// </summary>
    public class PreorderTraversal_
    {
        public IList<int> PreorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while(stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                if (node == null)
                    continue;
                else
                {
                    result.Add(node.val);
                    stack.Push(node.left);
                    stack.Push(node.right);
                }
            }
            return result;
        }
    }
}
