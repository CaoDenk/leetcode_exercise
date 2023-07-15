using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 107. 二叉树的层序遍历 II
    /// </summary>
    internal class _LevelOrderBottom
    {
        public IList<IList<int>> LevelOrderBottom(TreeNode root)
        {
            List<IList<int>> ret = new List<IList<int>>();
            if (root == null)
                return ret;

            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var l = new List<int>();
                int curLevel = queue.Count;
                for (int i = 0; i < curLevel; ++i)
                {
                    TreeNode n = queue.Dequeue();
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);

                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }

                    l.Add(n.val);
                }

                ret.Add(l);
            }
            ret.Reverse();
            return ret;
        }
    }
}
