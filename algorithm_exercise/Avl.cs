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
            Adjust(parent);
        }
        public void Insert(int i) => Insert(ref root, i);
        
       void LLRotate( BNode node)
        {

            BNode T = node;
            BNode L = T.left;
            T.left = L.right;

            BNode Tparent = T.parent;

            if(L.right!=null)
            {
                L.right.parent = T;
            }

            L.right = T;
            L.parent = T.parent;
            
            if (node == root)
            {
                root = L;
            }else
            {
                if (Tparent.left == T)
                {
                    Tparent.left = L;
                }
                else
                {
                    Tparent.right = L;
                }
              
            }
            T.parent = L;
   
        }
        void RRRotate(BNode node)
        {
            BNode T = node;
            BNode R = T.right;

            T.right = R.left;
            BNode Tparent = T.parent;
            if (R.left!=null)
            {
                R.left.parent = T;
            }
            R.left = T;
            R.parent = T.parent;
          
            if (node == root)
                root = R;
            else
            {
                if (Tparent.left == T)
                {
                    Tparent.left = R;
                }
                else 
                {
                    Tparent.right = R;
                }
            }
            T.parent = R;

        }
        void Adjust(BNode node)
        {
            while(node != null)
            {
                int factor = GetBalancedFactor(node);
                if (factor == 2)
                {
                    int leftNodeFactor = GetBalancedFactor(node.left);
                    if (leftNodeFactor >= 1)//LL
                    {
                        LLRotate(node);
                        
                    }
                    else //LR
                    {
                       
                        BNode T = node;
                        BNode L = T.left;
                        BNode LR = L.right;

                        L.right = LR.left;
                        if(LR.left != null)
                        {
                            LR.left.parent = L;
                        }

                        LR.left = L;
                        L.parent = LR;

                        T.left = LR;
                        LR.parent = T;
                        LLRotate(node);
        
                    }
                    return;
                }
                if (factor == -2)
                {
                    int rightNodeFactor = GetBalancedFactor(node.right);
                    if (rightNodeFactor <=-1)//RR
                    {
                        RRRotate( node);
                    }
                    else//RL
                    {
                        BNode T = node;
                        BNode R = T.right;
                        BNode RL = R.left;
                        R.left = RL.right;
                        if (RL.right != null)
                        {
                            RL.right.parent = R;
                        }
                        RL.right = R;
                        R.parent = RL;

                        T.right = RL;
                        RL.parent = RL;
                        RRRotate(node);
        
                    }
                    return;
                }
                 node = node.parent;
            }


        }
        
        BNode Delete(BNode node,int value) 
        {   

            while(node!=null)
            {
                if(node.val == value)
                {
                    if(node.left==null&&node.right==null)//删除的是叶子结点
                    {
                        if(node.val==node.parent.left.val)
                        {
                            node.parent.left = null;
                        }else
                        {
                            node.parent.right = null;
                        }
                    }else //删除非叶子结点
                    {

                        if(node.left==null) 
                        {

                            if(node.parent.left.val==node.val) //=》 后续优化可以直接比较指针，相比比较val代码量更少
                            {


                            }

                            return root;
                        }
                        if(root.right==null)//左子树不为空,右子树为空
                        {
                            return null;
                        }

                        int leftHeight=GetHeight(node.left);
                        int rightHeight=GetHeight(node.right);
                        if(leftHeight>rightHeight)
                        {
                            return root;
                        }
                        if(leftHeight<rightHeight)
                        {
                            return root;
                        }
                        //随缘

                    }


                }
                else if (node.val > value)
                {
                    node = node.left;
                }
                else
                {
                    node = node.right;
                }

            }
            
            return root;
        }
        BNode Delete(int value)
        {
            if (root == null) //删除空树
                return null;
            if(root.val== value) //删除根
            {
                if(root.left == null)
                {
                    if (root.right != null)
                    {
                        root.right.parent = null;
                        return root.right;
                    }
                    else
                        return null;
       
                }
                if(root.right == null)
                {
                    if (root.right != null)
                    {
                        root.right.parent = null;
                        return root.right;
                    }
                    else
                        return null;
                }

                int leftHeight = GetHeight(root.left);
                int rightHeight = GetHeight(root.right);
                if(leftHeight> rightHeight)
                {
                    root.left.parent = null;
                    root.left.right=root.right;
                    root.right.parent = root.left;

                    return root.left;
                }
                if(rightHeight> leftHeight)
                {
                    root.right.parent = null;
                    root.right.left=root.left;

                    root.left.parent=root.right;
                    return root.right;
                }

                if ((new Random().Next() & 1) == 0)//随缘  奇数字时候左子树第一个为父节点
                {
                    root.left.parent = null;
                    root.left.right = root.right;
                    root.right.parent = root.left;

                    return root.left;
                }else
                {
                    root.right.parent = null;
                    root.right.left = root.left;

                    root.left.parent = root.right;
                    return root.right;
                }

            }else
            {
                if(root.val>value)
                {
                    if (root.left != null)
                    {
                        return Delete(root.left, value);
                    }
                    else
                        return root;
                   
                }else
                {
                    if (root.right != null)
                    {
                        return Delete(root.right, value);
                    }
                    else
                        return root;
                }
            }
        }
        static void Main(string[] args)
        {
            //Avl.BuildTree(new int[] { 10, 9, 8, 7, 6 });
            Avl avl = new();
            //for (int i = 10; i >= -10; --i)
            //{
            //    avl.Insert(i);
            //}

            var l = new int[] { 3, 46, 21, 47, 36, 19, 35, 31, 15, 9, 8, 27, 13, 45, 25, 29, 2, 17, 26, 43 };
            //var l2 = new int[] { 5, 25, 27, 7,12};
            HashSet<int> s = new();
            //foreach (int i in l)
            //{
            //    //Console.WriteLine($"**********{i}**********");
            //    avl.Insert(i);
            //    //s.Add(i);
            //    //BNodeUtils.PreVisitNode(avl.Root);
            //    if (i == 34)
            //        break;
            //}
            //Console.WriteLine($"count {s.Count}");
            BNodeUtils.LevelVisit(avl.root);
            List<int> allNums = new();
            for (int i = 0; i < 50;)
            {
                int rand = new Random().Next(100);
                if (s.Contains(rand))
                    continue;
                s.Add(rand);
                ++i;
                avl.Insert(rand);
                allNums.Add(rand);
                BNodeUtils.LevelVisit(avl.root);
            }
            Console.WriteLine(string.Join(",", allNums));
            //BNode last=BNodeUtils.GetLast(avl.Root);
            //BNodeUtils.VisitParent(last);
            //avl.Insert(10);
            //avl.Insert(9);
            //avl.Insert(8);

            //avl.Adjust(ref avl.root);
            //avl.Adjust(ref avl.root.left);

            //BNodeUtils.PreVisitNode(avl.Root);
            //Console.WriteLine();
            //BNodeUtils.MidVisitNode(avl.Root);
            //avl.Insert(10);
            //avl.Insert(9);
            //Utils.PreVisit(avl.root);
        }




    }


}
