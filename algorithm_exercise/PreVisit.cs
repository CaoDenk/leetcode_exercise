using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using leetcode_exercise;
namespace algorithm_exercise
{
    /// <summary>
    /// 挖坑前序遍历，不使用递归，使用迭代
    /// 坑还真多
    /// </summary>
    internal class PreVisit
    {

        public static List<TreeNode> Visit(TreeNode root)
        {
            if(root==null)
                return new List<TreeNode>();
            if(root.left==null&&root.right==null)
                return new List<TreeNode>() { root};

            TreeNode node = root;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(node);
            List<TreeNode> ans = new List<TreeNode>() ;
            while(stack.Count > 0&&node.left==null&&node.right==null)
            {
                if(node.left!=null)
                {
                    stack.Push(node.left);
                    node = node.left;
                }else
                {
                    node=stack.Pop();
                    ans.Add(node);

                    if(node.right!=null)
                    {
                      
                        stack.Push(node.right);
                        node = node.right;
                    }
                }

            }
           ///代码有错
            return ans;

        }
        static void Main(string[] args)
        {
            TreeNode root = Utils.Make(new int?[] { 1, null, 2, 3 });
            LevelOrder2_ l = new();
            var ret= l.LevelOrder(root);
            foreach(var i in ret)
            {
                Console.Write(string.Join(",", i)+",");

            }
         
        }

    }
}
