using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class AvlTree
    {
       BTreeNode root;
       public BTreeNode Root { get => root; private set { root = value; } }

        int GetHeight(BTreeNode node)
        {
            if (node == null)
                return 0;
            else
                return node.height;
        }
        int GetBalanceFactor(BTreeNode node)
        {
            if (node == null)
                return 0;
            return node.left.height - node.right.height;
        }
        public BTreeNode Insert(BTreeNode node, int value)
        {
            if(node == null) 
                return new BTreeNode(value);
            if(value==node.value)
            {
                return node;
            }
            else if(value<node.value)
            {
                node.left=Insert(node.left, value);
            }else 
            {
                node.right=Insert(node.right, value);
            }
            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));//从插入点开始弹栈向上更新高度

            int balancedFactor = GetBalanceFactor(node);
            if(balancedFactor>1)
            {
                //挖坑
            }
            
            return node;
            
        }

        BTreeNode LeftRotate(BTreeNode node)
        {


            return node;
        }
    }
}
