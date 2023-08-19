using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 114. 二叉树展开为链表
    /// </summary>
    internal class Flatten_
    {
        public void Flatten(TreeNode root)
        {
            if(root==null) return;
             Recursive(root);
        }

        void Recursive(TreeNode root)
        {
            TreeNode right = root.right;
            TreeNode left=root.left;
            root.left = null;
            if(left != null)
            {
                root.right = left;
                TreeNode last = FindLast(left);
                last.right = right;
                Recursive(left);  
            }
            if(right != null)
            {
                Recursive(right);
            }
        }  
        TreeNode FindLast(TreeNode root)
        {
            while(true)
            {
                if (root.right != null)
                {
                   root=root.right;
                }
                else if (root.left != null)
                {
                   root= root.left;
                }else
                    return root;
            }
        }
        static void Main(string[] args)
        {
            {
                TreeNode root = Utils.Make(new int?[] { 1, 2, 5, 3, 4, null, 6 });
                Flatten_ f = new();
                f.Flatten(root);
                Utils.PreVisit(root);
                Console.WriteLine();
            }
            {
                TreeNode root = Utils.Make(new int?[] { 1, 2, 3});
                Flatten_ f = new();
                f.Flatten(root);
                Utils.PreVisit(root);
                Console.WriteLine();
            }


        }

    }
}
