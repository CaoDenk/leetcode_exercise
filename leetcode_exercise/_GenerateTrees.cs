using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _GenerateTrees
    {
        public IList<TreeNode> GenerateTrees(int n)
        {
            return Qn(0,n);
        }

        IList<TreeNode> Qn(int start,int end)
        {
            if (end==start)
                return new List<TreeNode>() { null };
            if (end -start==1)
            {
                return new List<TreeNode>
                {
                    new TreeNode(start+1)
                };
            }
            List<TreeNode> tree = new List<TreeNode>();
            for (int i = start; i < end; i++)
            {
                var left = Qn(start,i);
                var right = Qn(i + 1, end);
                foreach (var l in left )
                {
                    foreach(var r in right)
                    {
                        TreeNode t = new TreeNode(i + 1)
                        {
                            left = l,
                            right = r
                        };
                        tree.Add(t);
                    }
                }
            }
            return tree;
        }

        void MidVistitAssign(TreeNode root, ref int i)
        {
            if (root.left != null)
                MidVistitAssign(root.left, ref i);
            root.val = i;
            ++i;
            if (root.right != null)
                MidVistitAssign(root.right, ref i);
        }
        static void Main(string[] args)
        {
            {
                _GenerateTrees g = new();
                var ret = g.GenerateTrees(2);
                foreach (var t in ret)
                {
                    List<int> ints = new List<int>();
                    Utils.MidVistit(t, ints);
                    Console.WriteLine(string.Join(",", ints));
                }
            }
            {
                _GenerateTrees g = new();
                var ret = g.GenerateTrees(3);
                foreach (var t in ret)
                {
                    List<int> ints = new List<int>();
                    Utils.MidVistit(t, ints);
                    Console.WriteLine(string.Join(",", ints));
                }
            }
        }
    }
}
