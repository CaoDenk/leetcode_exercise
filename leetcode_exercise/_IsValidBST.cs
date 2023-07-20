using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode_exercise._Preorder;

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
            MidVisit(root, new List<int>(),flag);             
         
            return !flag;
        }
        void MidVisit(TreeNode n,List<int> last,bool flag)
        {
            if (flag)
                return;
            if (n.left != null)
            {
                MidVisit(n.left,last,flag);
            }
            if (last.Count == 0 || last[^1] < n.val)
                last.Add(n.val);
            else
            {
                flag = true;
                return;
            }
            if (n.right != null)
                MidVisit(n.right,last,flag);
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
