using leetcode_exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 怎么调整平衡二叉树
    /// 挖坑
    /// </summary>
    public class Avl
    {
        
        BNode root=null;
        int height = 0;

        int GetHeight(BNode node) => height - node.level;
        public static BNode BuildTree(int[] nums)
        {
            Avl tree = new Avl();
            foreach(var i in nums)
            {
                tree.Insert(i);
            }
            return tree.root;
        }

        int GetBalancedFactor(BNode node)
        {
            if(node==null) return 0;
            return  GetHeight(node.left)-GetHeight(node.right);
        }
        /// <summary>
        /// LL旋转使其为avl
        /// 
        /// </summary>
        /// <param name="treeNode"></param>
        void LL(BNode treeNode)
        {
            BNode parent = GetFatherNode(treeNode);
            //parent.left = treeNode.left;
            //TreeNode t = treeNode.left;
            //treeNode.left = treeNode.left.right;
            //t.right = treeNode;

            //parent.

        }
        /// <summary>
        /// 获取父亲结点
        /// 挖坑
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        BNode GetFatherNode(BNode node)
        {
            return root;
        }
        public void Insert(int i) => Insert(ref root, i);
   
        private void Insert(ref BNode node, int i)
        {
            int level = 0;
            while (node != null)
            {
                if (node.val == i)
                {
                    return;
                }
                else if (node.val > i)
                {
                    node =ref node.left;
                }
                else
                {
                    node = ref node.right;
                }
                ++level;
            }
            height = Math.Max(height, level);
            node =new BNode(i,level:level);
        }

        void Adjust(BNode node)
        {
            if (node==null) return;
            int factor = GetBalancedFactor(root);
            if (GetBalancedFactor(root) is 2 or -2)
            {


            }else
            {
                Adjust(root.left);
                Adjust(root.right);
            }

        }


        public int MaxDepth(BNode node) => GetDepth(node, 0);
        int GetDepth(BNode root, int i)
        {
            if (root == null)
                return i;
            ++i;
            return Math.Max(GetDepth(root.left, i), GetDepth(root.right, i));
        }

        /// <summary>
        /// 找到失衡的结点
        /// </summary>
        /// <param name="root"></param>
        /// <returns></returns>
        BNode FindInBalaned(BNode root) => root;

        static void Main(string[] args)
        {
            //Avl.BuildTree(new int[] { 10, 9, 8, 7, 6 });
            Avl avl = new();
            for (int i = 10; i > 0; --i)
            {
                avl.Insert(i);
            }
            BNodeUtils.PreVisitNode(avl.root);
            //avl.Insert(10);
            //avl.Insert(9);
            //Utils.PreVisit(avl.root);
        }




    }


}
