using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 108. 将有序数组转换为二叉搜索树
    /// </summary>
    internal class _SortedArrayToBST
    {
        public TreeNode SortedArrayToBST(int[] nums)
        {
            if (nums == null)
                return null;
            if(nums.Length == 1)
                return new TreeNode(nums[0]);
            int mid = (nums.Length - 1) / 2;
           
            TreeNode root=new TreeNode(nums[mid]);
            root.left = Cur(nums,0, mid - 1);
            root.right=Cur(nums,mid + 1,nums.Length - 1);
            return root;
        }

        TreeNode Cur(int[] nums,int start,int end) 
        {
            if (end < start)
                return null;
            if(end==start)
                return new TreeNode(nums[start]);
            int mid = (start + end) / 2;
            TreeNode root=new TreeNode(nums[mid]);
            root.left=Cur(nums,start,mid-1);
            root.right = Cur(nums, mid + 1, end);
            return root;
        }

     
        static void Main(string[] args)
        {
            _SortedArrayToBST s = new();
            var root= s.SortedArrayToBST(new int[] { -10, -3, 0, 5, 9 });
            //Utils.
            Utils.PreVisit(root);
        }
    }
}
