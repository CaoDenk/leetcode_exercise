using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{

    

     class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
         {
             this.val = val;
             this.left = left;
             this.right = right;
       }
    }

    internal class _IsSameTree
    {

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            try
            {
                Cur(p, q);
            }catch (Exception e)
            {
                return false;
            }
            
            return true;

        }

        void Cur(TreeNode p, TreeNode q)
        {
            if (p.val == q.val)
            {
                if (p.left != null)
                {
                    Cur(p.left, q.left);
                }
                if (p.right != null)
                {
                    Cur(p.right, q.right);
                }
            }
            else
                throw new Exception();
            
        }

        static void Main()
        {
            _IsSameTree isSameTree = new _IsSameTree();

            var p=new TreeNode();
            p.val = 1;
            var q=new TreeNode();
            q.val = 1;
            q.right=new TreeNode(1);
            q.right.val = 2;

            Console.WriteLine(isSameTree.IsSameTree(p,q));


        }
    }
}
