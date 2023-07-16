using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode_exercise._Preorder;

namespace leetcode_exercise
{

    
    internal class _IsValidBST
    {

        public bool IsValidBST(TreeNode root)
        {
            if(root == null) return true;
            try
            {
                PreVisit(root.left,root.val,root.val);
                PreVisit(root.right,root.val,root.val);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        void PreVisit(TreeNode n,int max,int min)
        {
           
            if (n.left != null)
            {

                if (n.val > n.left.val)
                    PreVisit(n.left,max,min);
                else
                    throw new Exception();
            }
            if (n.right != null)
            {
                if (n.val < n.right.val)
                    PreVisit(n.right,max,min);
                else
                    throw new Exception();
            }
                

        }

        static void Main(string[] args)
        {
           TreeNode root= Utils.Make(new int?[] { 5, 4, 6, null, null, 3, 7 });

            _IsValidBST isValidBST = new _IsValidBST();
            {
                Console.WriteLine(isValidBST.IsValidBST(root));
                
            }

        }
    }
}
