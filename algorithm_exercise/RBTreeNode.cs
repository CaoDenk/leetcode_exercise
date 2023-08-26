using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    enum Color
    {
        RED = 0,
        BLACK = 1,
    }
    internal class RBTreeNode
    {
        public Color color;
        public int key;
        public RBTreeNode left;
        public RBTreeNode right;
        public RBTreeNode parent;
        public RBTreeNode(int key, Color color=Color.RED, RBTreeNode left=null, RBTreeNode right=null,RBTreeNode parent=null)
        {
            this.key = key;
            this.color = color;
            this.left = left;
            this.right = right;
            this.parent = parent;
        }

    }
}
