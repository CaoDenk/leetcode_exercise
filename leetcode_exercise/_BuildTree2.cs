using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 前序和中序 构建二叉树span
    /// </summary>
    internal class _BuildTree2
    {
        public TreeNode BuildTree(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
                return null;

            return Cur(preorder, inorder);

        }
        int Find(int[] arr, int val)
        {
            int i = 0;
            for (; i < arr.Length; i++)
            {
                if (arr[i] == val)
                    break;
            }
            return i;
        }
        TreeNode Cur(int[] preorder, int[] inorder)
        {
            if (preorder.Length == 0)
                return null;

            TreeNode root = new TreeNode(preorder[0]);

            int index = Find(inorder, preorder[0]);//找到主根

            if (index + 1 <= preorder.Length)
            {
                root.left = Cur(preorder[1..(index + 1)], inorder[0..(index)]);
                root.right = Cur(preorder[(index + 1)..], inorder[(index + 1)..]);
            }


            return root;
        }

    }
}
