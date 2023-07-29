using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 99. 恢复二叉搜索树
    /// </summary>
    internal class _RecoverTree
    {
        public void RecoverTree(TreeNode root)
        {
            List<TreeNode> lists = new List<TreeNode>();
            TreeNode treeNode = new TreeNode(int.MinValue);
            TreeNode next = null;
            MidVistit(root, ref treeNode,ref next, lists);
            if(lists.Count ==2) 
            {
                (lists[0].val, lists[1].val) = (lists[1].val, lists[0].val);
            }else
                (lists[0].val, next.val) = (next.val, lists[0].val);


        }
        public  void MidVistit(TreeNode root,ref TreeNode lastNode,ref TreeNode next, List<TreeNode> disorder)
        {
  
            if (root.left != null)
                MidVistit(root.left,ref lastNode,ref next, disorder);
            if (disorder.Count == 2)
                return;
            if ( lastNode.val < root.val)
            {
                lastNode = root;
            }else
            {
                if(disorder.Count == 0)
                {
                    disorder.Add(lastNode);
                    lastNode = root;
                    next = root; 
                }else
                {
                    disorder.Add(root);
                    return;
                }               
            }

            if (root.right != null)
                MidVistit(root.right,ref lastNode,ref next, disorder);
        }

        static void Main(string[] args)
        {
            //{
            //    TreeNode root = Utils.Make(new int?[] { 1, 3, null, null, 2 });
            //    _RecoverTree r = new _RecoverTree();
            //    r.RecoverTree(root);
            //    List<int> list = new List<int>(); 
            //    Utils.MidVistit(root,list);
            //    Console.WriteLine(string.Join(",",list));
            //}

            {
                TreeNode root = Utils.Make(new int?[] { 3, 1, 4, null, null, 2 });
                _RecoverTree r = new _RecoverTree();
                r.RecoverTree(root);
                List<int> list = new List<int>();
                Utils.MidVistit(root, list);
                Console.WriteLine(string.Join(",", list));
            }
        }
    }
}
