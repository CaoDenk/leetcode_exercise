using leetcode_exercise;
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
            return GetHeight(node.left)-GetHeight(node.right);
        }
        BTreeNode RightRotate(BTreeNode node)
        {
            BTreeNode T = node;
            BTreeNode L = T.left;

            T.left = L.right;
            L.right = T;

            T.height = 1 + Math.Max(GetHeight(T.left), GetHeight(T.right));
            L.height=1 + Math.Max(GetHeight(L.left), GetHeight(L.right));
            return L;
        }
        BTreeNode LeftRotate(BTreeNode node)
        {
            BTreeNode T = node;
            BTreeNode R = T.right;

            T.right = R.left;
            R.left = T;

            T.height = 1 + Math.Max(GetHeight(T.left), GetHeight(T.right));
            R.height = 1  + Math.Max(GetHeight(R.left), GetHeight(R.right));
            return R;
        }
        BTreeNode Insert(BTreeNode node, int value,ref bool flag)
        {
            if(node == null) 
                return new BTreeNode(value);
            if(value==node.value)
            {
                flag = true;
                return node;
            }
            else if(value<node.value)
            {
                node.left=Insert(node.left, value,ref flag);
            }else 
            {
                node.right=Insert(node.right, value, ref flag);
            }
            if(flag)          //说明有个相同结点 不进行旋转更新操作。
            {
                return node;
            }

            node.height = 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));//从插入点开始弹栈向上更新高度

            int balancedFactor = GetBalanceFactor(node);
            if(balancedFactor>1)
            {
                if(value<node.left.value) //LL型，需要右旋
                {
                    return RightRotate(node);
                }else //LR型
                {
                    node.left = LeftRotate(node.left);
                    return RightRotate(node);

                }
            }else if(balancedFactor<-1)
            {
                if (value > node.right.value) //RR型，需要右旋
                {
                    return LeftRotate(node);
                }
                else //RL型 先右旋再左旋
                {
                    node.right = RightRotate(node.right);
                    return LeftRotate(node);
                }

            }
            
            return node;
        }
        BTreeNode GetMinValueNode(BTreeNode node)
        {
            if (node == null || node.left == null)
                return node;
            return GetMinValueNode(node.left);
        }
        void Delete(int value)
        {
            bool flag = false;//没找到删除的value
            root = Delete(root, value,ref flag);
        }
        BTreeNode Delete(BTreeNode node,int value,ref bool flag)
        {
            if (node == null)
            {
                return node;
            } else if(value<node.value)
            {
                node.left=Delete(node.left, value,ref flag);
            }else if(value>node.value)
            {
                node.right=Delete(node.right, value,ref flag);
            }else //找到
            {
                if(node.left==null)
                {
                    var tmp = node.right;
                    //node = null;
                    return tmp;
                }else if(node.right==null)
                {
                    var tmp = node.left;
                    //node = null;
                    return tmp;
                }

            }
            //if(flag)
            //{
            //    return node;
            //}    
            return node;
        }

        static void BugTest()
        {
            List<int> list = new List<int> { 39, 9, 1, 27, 93, 2, 10, 88, 28, 29, 81, 48, 47, 56, 46, 64, 5, 20, 54, 74, 60, 43, 59, 97, 35, 87, 65, 58, 3, 8, 0, 68, 32, 41, 38, 99, 30, 98, 75, 92, 69, 95, 18, 7, 14, 71, 50, 85, 57, 25 };
            AvlTree avlTree = new AvlTree();
            foreach(var i in list)
            {
                //if (i == 27)
                //    break;
                avlTree.Insert(i);
                var res = BTreeNode.LevelOrder(avlTree.Root);
                foreach (var j in res)
                {
                    Console.WriteLine(string.Join(",", j));
                }
                Console.WriteLine($"**************插入{i}***************");
            }
          
        }
        public void Insert(int value)
        {
            bool flag= false;
            root= Insert(root, value, ref flag);
        }

        static void Main(string[] args)
        {
            BugTest();
        }
    }
}
