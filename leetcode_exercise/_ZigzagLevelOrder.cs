using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace leetcode_exercise
{
    internal class _ZigzagLevelOrder
    {
        public IList<IList<int>> ZigzagLevelOrder(TreeNode root)
        {
            if (root == null) return ret;
            Cur(root, -1);
            for(int i=1;i<ret.Count;++i)
            {
                if((i&1)==1)
                {
                  ret[i]=  ret[i].Reverse().ToList();
                }
            }

            return ret;
        }
        List<IList<int>> ret = new List<IList<int>>();
   
        void Add(int level, int val)
        {
            if (ret.Count == level)
            {
                ret.Add(new List<int> { val });
            }
            else
            {
                ret[level].Add(val);
            }
        }
        void Cur(TreeNode node, int level)
        {
            if (node==null)
            {
                return;
            }
            ++level;
            Add(level, node.val);
            Cur(node.left, level);
            Cur(node.right, level);
            
       
        }
        static void Main(string[] args)
        {
            {
                TreeNode root = Utils.Make(new int?[] { 3, 9, 20, null, null, 15, 7 });
                _ZigzagLevelOrder z = new();
                var ret = z.ZigzagLevelOrder(root);
                foreach (var i in ret)
                {
                    Console.WriteLine(string.Join(",", i));
                }
            }
            {
                TreeNode root = Utils.Make(new int?[] { 1, 2, 3, 4, null, null, 5});
                _ZigzagLevelOrder z = new();
                var ret = z.ZigzagLevelOrder(root);
                foreach (var i in ret)
                {
                    Console.WriteLine(string.Join(",", i));
                }
            }
            
        }

    }
}
