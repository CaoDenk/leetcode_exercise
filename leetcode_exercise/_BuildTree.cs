using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace leetcode_exercise
{
    /// <summary>
    /// 前序和中序 构建二叉树
    /// </summary>
    internal class _BuildTree
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
                return null;          
            return Cur(preorder, inorder);
        }
        int Find(Span<int> arr,int val)
        {
            int i = 0;
            for(; i<arr.Length; i++) {
                if (arr[i] == val)
                    break;
            }
            return i;
        }
        TreeNode Cur(Span<int> preorder, Span<int> inorder)
        {            
            TreeNode root = new TreeNode(preorder[0]);
            int index = Find(inorder, preorder[0]);//找到主根          
            if(index==0)
            {
                root.left = null;
            }else
            {
                root.left = Cur(preorder[1..(index + 1)], inorder[..index]);
            }
            if(index+1>=preorder.Length)
            {
                root.right = null;
            } else
            {

                root.right = Cur(preorder[(index + 1)..], inorder[(index + 1)..]);
            }
          
            return root;
        }
        void PreVisit(TreeNode n)
        {
            Console.Write(n.val+",");
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
            Console.Write(n.val+",");
            if (n.right != null)
                InVisit(n.right);
        }
        static void Main(string[] args)
        {
            _BuildTree b = new();
            {
                int[] pre = new int[] { 3, 9, 20, 15, 7 };
                int[] inodr = new int[] { 9, 3, 15, 20, 7 };
                var node=b.BuildTree(pre, inodr);
                b.PreVisit(node);
                Console.WriteLine();
                b.InVisit(node);
               

            }
        }
    }
}
