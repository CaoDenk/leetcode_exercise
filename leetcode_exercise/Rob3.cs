using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 337. 打家劫舍 III
    /// </summary>
    internal class Rob3
    {
        public int Rob(TreeNode root)
        {
            int[] ret=Dfs(root);

            return Math.Max(ret[0],ret[1]);
        }

        int[] Dfs(TreeNode root)
        {
            if (root == null) { return new int[] { 0, 0 }; }
            int[] l = Dfs(root.left);//第一个选中，第二未选
            int[] r = Dfs(root.right);
            int selected = l[1] + r[1]+root.val;
            int unselected = Math.Max(l[0], l[1]) + Math.Max(r[0], r[1]);
              
            return new int[] {selected, unselected };

        }


        static void Main(string[] args)
        {
            Rob3 r = new Rob3();
            {
                int?[] node = { 3, 4, 5, 1, 3, null, 1 };
                var root = Utils.Make(node);
                Console.WriteLine(r.Rob(root));
            }

        }

    }
}
