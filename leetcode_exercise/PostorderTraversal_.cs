using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class PostorderTraversal_
    {

        public IList<int> PostorderTraversal(TreeNode root)
        {
            List<int> result = new List<int>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            while (stack.Count > 0)
            {
                TreeNode node = stack.Pop();
                if (node == null)
                    continue;
                else
                {
                    result.Add(node.val);
                    stack.Push(node.right);
                    stack.Push(node.left);
                }
            }
            result.Reverse();
            return result;
        }
    }
}
