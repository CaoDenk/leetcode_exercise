using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode_exercise._Preorder;

namespace leetcode_exercise
{
    /// <summary>
    /// 后序和中序构建二叉树
    /// 挖坑
    /// </summary>
    internal class _BuildTree3
    {
        public TreeNode BuildTree(int[] inorder, int[] postorder)
        {
            if (inorder.Length == 0)
                return null;
            return Cur(inorder, postorder);
        }
      
        int Find(Span<int> arr, int val)
        {
            int i = 0;
            for (; i < arr.Length; i++)
            {
                if (arr[i] == val)
                    break;
            }
            return i;
        }
        TreeNode Cur(Span<int> inorder, Span<int> postorder)
        {
            TreeNode root = new TreeNode(postorder[postorder.Length-1]);
            int index = Find(inorder, postorder[postorder.Length - 1]);//找到主根          
            if (index == 0)
            {
                root.left = null;
            }
            else
            {
                root.left = Cur(inorder[..index], postorder[..index]);
            }
            if (index + 1 >= inorder.Length)
            {
                root.right = null;
            }
            else
            {
                root.right = Cur(inorder[(index + 1)..], postorder[index..(postorder.Length-1)]);
            }

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
            _BuildTree3 b = new();
            {
                int[] pre = new int[] {  9,3, 15,20, 7 };
                int[] inodr = new int[] { 9,  15, 7,20, 3};
                var node = b.BuildTree(pre, inodr);
                b.InVisit(node);
                Console.WriteLine();
                b.PostVisit(node);


            }
        }

    }
}
