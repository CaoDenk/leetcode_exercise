using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{

    /// <summary>
    /// 100. 相同的树
    /// </summary>
    internal class IsSameTree_
    {

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            try
            {
                Dfs(p, q);
            }catch 
            {
                return false;
            }
            return true;
        }

        void Dfs(TreeNode p, TreeNode q)
        {
            if (p.val == q.val)
            {
                if (p.left != null)
                {
                    Dfs(p.left, q.left);
                }
                if (p.right != null)
                {
                    Dfs(p.right, q.right);
                }
            }
            else throw new Exception();
            
        }

        static void Main()
        {
            IsSameTree_ isSameTree = new IsSameTree_();
            var p = new TreeNode
            {
                val = 1
            };
            var q = new TreeNode
            {
                val = 1,
                right = new TreeNode(1)
            };
            q.right.val = 2;

            Console.WriteLine(isSameTree.IsSameTree(p,q));


        }
    }
}
