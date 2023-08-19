using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MirrorTree_
    {
        public TreeNode MirrorTree(TreeNode root)
        {
            if (root == null)
                return null;
            TreeNode newRoot=null;
            Recur(root,ref  newRoot);
            return newRoot;
        }
        void Recur(TreeNode node,ref TreeNode newNode ) 
        {   
            if(node!=null)
            {
                newNode = new TreeNode(node.val);              
                Recur(node.right,ref newNode.left);
                Recur(node.left,ref newNode.right);
            }
        }
    }
}
