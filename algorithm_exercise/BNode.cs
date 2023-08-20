using leetcode_exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    public class BNode
    {
        public int val;
        public BNode left;
        public BNode right;
        //public int height;
        //public int level;
        public BNode parent;
        public BNode(int val = 0, BNode left = null, BNode right = null,BNode parent=null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
            this.parent = parent;
            //this.height = height;
            //this.level = level;
        }


    }
}
