using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{

    

 

    internal class _IsSameTree
    {

        public bool IsSameTree(TreeNode p, TreeNode q)
        {
            try
            {
                Recur(p, q);
            }catch (Exception e)
            {
                return false;
            }
            
            return true;

        }

        void Recur(TreeNode p, TreeNode q)
        {
            if (p.val == q.val)
            {
                if (p.left != null)
                {
                    Recur(p.left, q.left);
                }
                if (p.right != null)
                {
                    Recur(p.right, q.right);
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
