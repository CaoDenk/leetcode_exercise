using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _Flatten
    {
        public void Flatten(TreeNode root)
        {
            if(root == null)
                return;
            List<TreeNode> list = new List<TreeNode>();
            MidVistit(root, list);
            //var head = list[0];
            for(int i=0; i<list.Count-1; i++)
            {
                list[i].right = list[i+1];
                list[i].left = null;
            }
        }
        public  void MidVistit(TreeNode root, List<TreeNode> nums)
        {
            if (root.left != null)
                MidVistit(root.left, nums);
            nums.Add(root);
            if (root.right != null)
                MidVistit(root.right, nums);
        }
    }
}
