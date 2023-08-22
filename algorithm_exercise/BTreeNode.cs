using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class BTreeNode
    {
        public int value;
        public BTreeNode left;
        public BTreeNode right;
        public int height;
        public BTreeNode(int value, BTreeNode left=null, BTreeNode right=null, int height=1)
        {
            this.value = value;
            this.left = left;
            this.right = right;
            this.height = height;
        }

       public static IList<IList<int>> LevelOrder(BTreeNode root)
        {
            List<IList<int>> ret = new List<IList<int>>();
            if (root == null)
                return ret;

            Queue<BTreeNode> queue = new Queue<BTreeNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var l = new List<int>();
                int curLevel = queue.Count;
                for (int i = 0; i < curLevel; ++i)
                {
                    BTreeNode n = queue.Dequeue();
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);

                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }

                    l.Add(n.value);
                }

                ret.Add(l);
            }
            return ret;
        }
    }
}
