using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _MaxDepth
    {
        public int MaxDepth(TreeNode root)
        {
            return GetDepth(root,0);
        }

        int GetDepth(TreeNode root, int i)
        {
            if (root != null)
            {
                ++i;
                return Math.Max(GetDepth(root.left, i), GetDepth(root.right, i));
            }
            else
                return i;

        }

    }
}
