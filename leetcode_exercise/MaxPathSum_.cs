using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 124. 二叉树中的最大路径和
    ///效率真低
    /// 双循环 挖坑
    /// </summary>
    internal class MaxPathSum_
    {
        public int MaxPathSum(TreeNode root)
        {
            if(root == null) return 0;
            int refRootMax = int.MinValue;
            RootRecursive(root, ref refRootMax);
            return refRootMax;
        }

        void RootRecursive(TreeNode root,ref int refRootMax)
        {
            int leftMax = int.MinValue;
            int rightMax = int.MinValue;
            int sum = root.val;
            if(root.left != null)
            {
                Recursive(root.left, ref leftMax, root.left.val);
                RootRecursive(root.left, ref refRootMax);
            }
            if (root.right != null)
            {
                Recursive(root.right, ref rightMax,root.right.val);
                RootRecursive(root.right, ref refRootMax);
            }
            if(leftMax>0)
            {
                sum += leftMax;
            }
            if (rightMax>0)
            {
                sum += rightMax;
            }
            refRootMax =Math.Max(refRootMax, sum);
        }
        void Recursive(TreeNode root,ref int refMax, int max ) 
        {
            refMax=Math.Max(refMax, max);
            if( root.left != null)
            {
                Recursive(root.left,ref refMax, root.left.val+max);
            }
            if(root.right != null)
            {
                Recursive(root.right, ref refMax, root.right.val+max);
            }

        }
        static void Main(string[] args)
        {
            MaxPathSum_ m = new();
            {
                var root = Utils.Make([1,2,3]);
                Console.WriteLine(m.MaxPathSum(root));
            }
            {
                var root = Utils.Make([-10, 9, 20, null, null, 15, 7]);
                Console.WriteLine(m.MaxPathSum(root));
            }
            {
                var root = Utils.Make([1, 2, null, 3, null, 4, null, 5]);
                Console.WriteLine(m.MaxPathSum(root));
            }
        }
    }
}
