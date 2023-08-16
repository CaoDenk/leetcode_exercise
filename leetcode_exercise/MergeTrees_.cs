using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 接着挖坑
    /// </summary>
    internal class MergeTrees_
    {
        public TreeNode MergeTrees(TreeNode root1, TreeNode root2)
        {
            if (root1 == null)return root2;
            if (root2 == null) return root1;
            MergeTreesRecursive(root1, root2);
            return root1;
        }

        void MergeTreesRecursive(TreeNode root1, TreeNode root2)
        {

            root1.val += root2.val;
            if (root1.left == null)
            {
                if (root2.left != null)
                {
                    root1.left = root2.left;
                }
            }
            else
            {
                if (root2.left != null)
                {
                    MergeTreesRecursive(root1.left, root2.left);
                }
            }

            if (root1.right == null)
            {
                if (root2.right != null)
                {
                    root1.right = root2.right;
                }
            }
            else
            {
                if (root2.right != null)
                {
                    MergeTreesRecursive(root1.right, root2.right);
                }
            }

        }
    }
}
