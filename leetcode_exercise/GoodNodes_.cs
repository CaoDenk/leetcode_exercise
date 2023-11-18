using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1448. 统计二叉树中好节点的数目
    /// 挖坑
    /// </summary>
    internal class GoodNodes_
    {
        public int GoodNodes(TreeNode root)
        {
            int ans = 0;
            Dfs(root, int.MinValue, ref ans);
            return ans;
        }
        void Dfs(TreeNode root,int max,ref int count)
        {
            if(root == null) return;
            if(root.val>=max)
            {
                ++count;
                Dfs(root.left,root.val,ref count);
                Dfs(root.right,root.val,ref count);
            }else
            {
                Dfs(root.left,max, ref count);
                Dfs(root.right,max, ref count);
            }

        }
        static void Main(string[] args)
        {
            GoodNodes_ g = new();
            {
                var root = Utils.Make([2, null, 4, 10, 8, null, null, 4]);
                Console.WriteLine(g.GoodNodes(root));
            }

        }

    }
}
