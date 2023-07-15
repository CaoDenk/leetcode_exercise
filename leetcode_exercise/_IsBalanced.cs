using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static leetcode_exercise._Preorder;

namespace leetcode_exercise
{
    /// <summary>
    /// 110. 平衡二叉树
    /// </summary>
    internal class _IsBalanced
    {
        public bool IsBalanced(TreeNode root)
        {
            //int count=0;
            //PreVisit(root,ref count);
            try
            {
                GetDepth(root,0);
            }catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        int GetDepth(TreeNode root, int i)
        {
            if (root != null)
            {
                ++i;
                int leftHeight = GetDepth(root.left, i);
                int rightHeight= GetDepth(root.right, i);
                if (Math.Abs(leftHeight-rightHeight)>1)
                    throw new Exception();
                return Math.Max(leftHeight, rightHeight);
            }
            else
                return i;
        }

     

        static void Main(string[] args)
        {

            {
                TreeNode root = new TreeNode(3);
                root.left = new TreeNode(9);
                root.right = new TreeNode(20);
                root.right.left = new TreeNode(15);
                root.right.right = new TreeNode(7);
                _IsBalanced i = new();
                Console.WriteLine(i.IsBalanced(root));
            }
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(2);
                root.left.left = new TreeNode(3);
                root.left.right = new TreeNode(3);
                root.left.left.left = new TreeNode(4);
                root.left.left.right = new TreeNode(4);
                _IsBalanced i = new();
                Console.WriteLine(i.IsBalanced(root));
            }
            {
                TreeNode root = new TreeNode(3);
                //root.left = new TreeNode(9);
                //root.right = new TreeNode(20);
                //root.right.left = new TreeNode(15);
                //root.right.right = new TreeNode(7);
                _IsBalanced i = new();
                Console.WriteLine(i.IsBalanced(root));
            }
            {
                TreeNode root = new TreeNode(1);
                root.left = new TreeNode(2);
                root.right = new TreeNode(3);
                root.left.left = new TreeNode(4);
                root.left.right = new TreeNode(5);
                root.right.left = new TreeNode(6);
                root.left.left.left=new TreeNode(8);
                //root.right.right = new TreeNode(7);
                _IsBalanced i = new();
                Console.WriteLine(i.IsBalanced(root));
            }

        }
    }
}
