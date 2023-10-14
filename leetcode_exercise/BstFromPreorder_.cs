using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1008. 前序遍历构造二叉搜索树
    /// </summary>
    internal class BstFromPreorder_
    {
        public TreeNode BstFromPreorder(int[] preorder)
        {
            TreeNode root = null;
            for (int i = 0; i < preorder.Length; ++i)
            {
                Dfs(ref root, preorder, i);
            }
            return root;
        }

        void Dfs(ref TreeNode root, int[] preorder, int i)
        {
            if (root == null)
                root = new TreeNode(preorder[i]);
            else if (preorder[i] < root.val)
            {
                root = ref root.left;
                Dfs(ref root, preorder, i);
            }
            else
            {
                root = ref root.right;
                Dfs(ref root, preorder, i);
            }
        }
    }
}
