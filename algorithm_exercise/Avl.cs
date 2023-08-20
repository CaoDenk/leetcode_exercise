using leetcode_exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 怎么调整平衡二叉树
    /// 挖坑   调整后依然不平衡 ？？？
    /// </summary>
    public class Avl
    {

        BNode root = null;
        public BNode Root { get => root; }
    
        public int GetHeight(BNode node)
        {
            if (node == null)
                return 0;
            return 1 + Math.Max(GetHeight(node.left), GetHeight(node.right));
        }
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

        void Insert(ref BNode node, int i)
        {
            BNode parent = null;
            while (node != null)
            {
                parent = node;
                if (node.val == i)
                {
                    return;
                }
                else if (node.val > i)
                {
                    node = ref node.left;
                  
                }
                else
                {
                    node = ref node.right;
                }
            }
            node = new BNode(i,parent:parent);
            //Adjust(parent);
            //BNodeUtils.LevelVisit(Root);
        }
        public void Insert(int i) => Insert(ref root, i);
        
       void LLRotate( BNode node)
        {
            BNode T = node;
            BNode L = T.left;
            T.left = L.right;
            if(L.right!=null)
            {
                L.right.parent = T;
            }
            L.right = T;
            T.parent = L;
            L.parent = T.parent;
            if (node == root)
            {
                root = L;
            }
        }
        void RRRotate(BNode node)
        {
            BNode T = node;
            BNode R = T.right;

            T.right = R.left; 
            if(R.left!=null)
            {
                R.left.parent = T;
            }
            R.left = T;
            T.parent = R;
            R.parent = T.parent;
            if (node == root)
                root = R;
        }
        void Adjust(BNode node)
        {
            while(node != null)
            {
                int factor = GetBalancedFactor(node);
                if (factor == 2)
                {
                    int leftNodeFactor = GetBalancedFactor(node.left);
                    if (leftNodeFactor == 1)//LL
                    {
                        LLRotate(node);
             
                    }
                    else //LR
                    {
                        BNode T = node;
                        BNode L = T.left;
                        BNode LR = L.right;

                        L.right = LR.left;
                        LR.left = L;
                        T.left = LR;
                        LLRotate(node);
                      
                    }
                    return;
                }
                if (factor == -2)
                {
                    int rightNodeFactor = GetBalancedFactor(node.right);
                    if (rightNodeFactor == -1)//RR
                    {
                        RRRotate( node);
                    }
                    else//RL
                    {
                        BNode T = node;
                        BNode R = T.right;
                        BNode RL = R.left;

                        R.left = RL.right;
                        RL.right = R;
                        T.right = RL;
                        RRRotate(node);
                    }
                    return;
                }
                 node = node.parent;
            }


        }
        //void Adjust(ref BNode node)
        //{

        //    if (node==null) return;
        //    int factor = GetBalancedFactor(node);
        //    if (factor==2)
        //    {
        //        int leftNodeFactor = GetBalancedFactor(node.left);
        //        if (leftNodeFactor==1)//LL
        //        {
        //            LLRotate(ref node);
        //            return;
        //        }
        //        else if(leftNodeFactor == -1) //LR
        //        {
        //            BNode T = node;
        //            BNode L = T.left;
        //            BNode  LR= L.right;

        //            L.right = LR.left;
        //            LR.left = L;
        //            T.left= LR;
        //            LLRotate(ref node);
        //            return;
        //        }
        //        Adjust(ref node.left);
        //    }
        //    else if(factor==-2)
        //    {
        //        int rightNodeFactor = GetBalancedFactor(node.right);
        //        if (rightNodeFactor == -1)//RR
        //        {
        //            RRRotate(ref node);
        //            return;
        //        }
        //        else if (rightNodeFactor == 1)//RL
        //        {
        //            BNode T= node;
        //            BNode R= T.right;
        //            BNode RL = R.left;

        //            R.left=RL.right;
        //            RL.right = R;
        //            T.right=RL;
        //            RRRotate(ref node);
        //            return;
        //        }
        //        Adjust(ref node.right);
        //    }else
        //    {
        //        Adjust(ref node.left);
        //        Adjust(ref node.right);
        //    }
        //}

        static void Main(string[] args)
        {
            //Avl.BuildTree(new int[] { 10, 9, 8, 7, 6 });
            Avl avl = new();
            for (int i = 10; i >= 8; --i)
            {
                avl.Insert(i);
            }
            //avl.Insert(10);
            //avl.Insert(9);
            //avl.Insert(8);

            //avl.Adjust(ref avl.root);
            //avl.Adjust(ref avl.root.left);
            BNodeUtils.LevelVisit(avl.root);
            //BNodeUtils.PreVisitNode(avl.Root);
            //Console.WriteLine();
            //BNodeUtils.MidVisitNode(avl.Root);
            //avl.Insert(10);
            //avl.Insert(9);
            //Utils.PreVisit(avl.root);
        }




    }


}
