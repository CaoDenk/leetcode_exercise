using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 106. 从中序与后序遍历序列构造二叉树
    /// </summary>
    internal class BuildTree3_
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0)
                return null;
            return Dfs(inorder, postorder);
        }
      
        int Find(Span<int> arr, int val)
        {
            int i = 0;
            for (; i < arr.Length; i++)if (arr[i] == val)break;
            return i;
        }
        TreeNode Dfs(Span<int> inorder, Span<int> postorder)
        {
            TreeNode root = new TreeNode(postorder[^1]);
            int index = Find(inorder, postorder[^1]);//找到主根          
            if (index != 0)
                root.left = Dfs(inorder[..index], postorder[..index]);
            if (index + 1 < inorder.Length)
                root.right = Dfs(inorder[(index + 1)..], postorder[index..(postorder.Length - 1)]);
            return root;
        }
        void PreVisit(TreeNode n)
        {
            Console.Write(n.val + ",");
            if (n.left != null)
            {
                PreVisit(n.left);
            }
            if (n.right != null)
                PreVisit(n.right);
        }

        void InVisit(TreeNode n)
        {

            if (n.left != null)
            {
                InVisit(n.left);
            }
            Console.Write(n.val + ",");
            if (n.right != null)
                InVisit(n.right);
        }
        void PostVisit(TreeNode n)
        {
            if (n.left != null)
            {
                PostVisit(n.left);
            }
            if (n.right != null)
                PostVisit(n.right);
            Console.Write(n.val+",");
        }
        static void Main(string[] args)
        {
            BuildTree3_ b = new();
            {
                int[] pre = [9,3, 15,20, 7];
                int[] inodr = [9,  15, 7,20, 3];
                var node = b.BuildTree(pre, inodr);
                b.InVisit(node);
                Console.WriteLine();
                b.PostVisit(node);


            }
        }

    }
}
