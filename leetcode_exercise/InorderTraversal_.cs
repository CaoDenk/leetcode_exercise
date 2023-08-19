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
            if (root == null)
                return result;
            
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);
            TreeNode node = root;
            node = node.left;
            while(stack.Count>0)
            {
                if(node!=null)
                {
                    stack.Push(node);
                    node = node.left;
                }else
                {
                    node=stack.Pop();
                    result.Add(node.val);
                    if(node.right!=null)
                    {
                        stack.Push(node.right);
                        node = node.right;
                        node = node.left;
                    }else
                        node = node.right;
                }

            }
            return result;

        }
        static void Main(string[] args)
        {
            TreeNode root = Utils.Make(new int?[] { 1, null, 2, 3 });
            InorderTraversal_ i = new();
            var res=i.InorderTraversal(root);
            Console.WriteLine(string.Join(",",res));
        }
    }
}
