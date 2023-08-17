using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace leetcode_exercise
{

    /// <summary>
    /// 98. 验证二叉搜索树
    /// </summary>
    internal class _IsValidBST
    {

        public bool IsValidBST(TreeNode root)
        {
            if(root == null) return true;
            if(root.left==null&&root.right==null) return true;
            
            bool flag = false;
            long max = long.MinValue;
            MidVisit(root, ref max,ref flag);             
         
            return !flag;
        }
        void MidVisit(TreeNode n,ref long max,ref bool flag)
        {
            if (flag)
                return;
            if (n.left != null)
            {
                MidVisit(n.left,ref max,ref flag);
            }
            if (max <n.val)
                max=n.val;
            else
            {
                flag = true;
                return;
            }
            if (n.right != null)
                MidVisit(n.right,ref max,ref flag);
        }

        static void Main(string[] args)
        {



            {
                TreeNode root = Utils.Make(new int?[] { 5, 4, 6, null, null, 3, 7 });
                _IsValidBST isValidBST = new _IsValidBST();
                Console.WriteLine(isValidBST.IsValidBST(root));

            }
            //{
            //    TreeNode root = Utils.Make(new int?[] { 2, 2, 2 });
            //    _IsValidBST isValidBST = new _IsValidBST();
            //    Console.WriteLine(isValidBST.IsValidBST(root));
            //}
            //{
            //    TreeNode root = Utils.Make(new int?[] { 2, 1, 3 });
            //    _IsValidBST isValidBST = new _IsValidBST();
            //    Console.WriteLine(isValidBST.IsValidBST(root));
            //}
        }
    }
}
