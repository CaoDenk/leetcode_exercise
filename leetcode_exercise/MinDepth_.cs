using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MinDepth_
    {
        public int MinDepth(TreeNode root)
        {
            if (root == null) return 0;
            if(root.left == null&&root.right==null) return 1;
            return Math.Min( GetDepth(root.left, 1),GetDepth(root.right,1));
        }
    

        int GetDepth(TreeNode root, int i)
        {
           if(root == null) return int.MaxValue;
           if(root.left==null&&root.right==null)
            {
                ++i;
                return i;
            }else
            {
                return Math.Min(GetDepth(root.left, i), GetDepth(root.right, i));
            }
          

        }

        static void Main()
        {

            TreeNode root = new TreeNode(2);
            root.right = new TreeNode(3);
            
        }
    }
}
