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
    }
}
