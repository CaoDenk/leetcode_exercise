using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;


namespace leetcode_exercise
{
    /// <summary>
    /// 110. 平衡二叉树
    /// </summary>
    internal class _IsBalanced
    {
        public bool IsBalanced(TreeNode root)
        {
            bool flag = true;
             GetDepth(root,0,ref flag);
            return flag;
        }

        int GetDepth(TreeNode root, int i,ref bool flag)
        {
            if(!flag)
            {
                return -1;
            }
            if (root != null)
            {
                ++i;
                int leftHeight = GetDepth(root.left, i,ref flag);
                int rightHeight= GetDepth(root.right, i,ref flag);
                if (Math.Abs(leftHeight - rightHeight) > 1)
                {
                    flag= false;
                    return -1;
                }
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
            {
                TreeNode root = Utils.Make([10,9,null,8,null] );
             
                //root.right.right = new TreeNode(7);
                _IsBalanced i = new();
                Console.WriteLine(i.IsBalanced(root));
            }

            {
                TreeNode root = Utils.Make([3, 2,7,1, null,5,9,0,null,4,6,8,10]);

                //root.right.right = new TreeNode(7);
                _IsBalanced i = new();
                Console.WriteLine(i.IsBalanced(root));
            }
        }
    }
}
