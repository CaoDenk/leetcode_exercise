using leetcode_exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            }
            else if (Tparent.left == T)
            {
                Tparent.left = L;
            }
            else
            {
                Tparent.right = L;
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
            else if (Tparent.left == T)
            {
                Tparent.left = R;
            }
            else 
            {
                Tparent.right = R;
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
                        RL.parent = T;
                        RRRotate(node);
        
                    }
                    return;
                }
                 node = node.parent;
            }


        }
        int GetMax(BNode node)
        {
            while (node.right != null)
            {
                node = node.right;
            }
            return node.val;
        }
        int GetMin(BNode node)
        {
            while (node.left != null)
            {
                node = node.left;
            }
            return node.val;
        }
    
        BNode Delete(int value)
        {
            if (root == null)
                return null;
            return Delete(ref root,root,value);
        }
        /// <summary>
        /// 删除有bug
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="node"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        BNode Delete(ref BNode parent,BNode node,int value) //删除后返回根节点
        {
            if (node == null) //删除空树
            {
                return null;
            }else if(value<node.val)
            {
                node.left=Delete(ref parent.left,node.left,value);
            }else if(value>node.val)
            {
                node.right=Delete(ref parent.right,node.right,value);
            }
            else//找到
            {
                if (node.left == null && node.right == null) //删除叶子结点
                {
                    parent = null;//没用代码
                    return null;
                }
                else if (node.left == null) //说明root.right!=null
                {
                    parent = null;
                    return node.right;

                }else if (root.right == null)
                {
                    parent = null;
                    return node.left;
                }else
                {
                    int leftHeight = GetHeight(node.left);
                    int rightHeight = GetHeight(node.right);
                    BNode ret;
                    if (leftHeight >= rightHeight)
                    {
                        int max=GetMax(node.left);
                        BNode bnode=  Delete(ref node.left, node.left, max);

                        bnode.right = node.right;
                        node.right.parent = bnode;
                        #region
                        //if(node.parent.left==node)
                        //{
                        //    node.parent.left = bnode;
                        //    bnode.parent = node.parent;
                        //}else
                        //{
                        //    node.parent.right = bnode;
                        //    bnode.parent = node.parent;
                        //}
                        #endregion
                        parent = bnode;
                        bnode.parent = node.parent;
                        ret = bnode;
                      
                    }else                
                    {
                        int min = GetMin(node.right);
                        BNode bnode= Delete(ref node.right,node.right,min);

                        bnode.right=node.left;
                        node.right.parent = bnode;
                        parent = bnode;
                        bnode.parent = node.parent;
                        ret = bnode;
                    }


                    return ret;
                }
            }
 
            return node;
        }

        static void RandomInsert(int num,int maxNum)
        {
            Avl avl = new Avl();
            HashSet<int> keys = new HashSet<int>();
            List<int> values = new List<int>();
            for(int i=0;i< num; i++)
            {
                Random random = new Random();
                int rand=random.Next(maxNum);
                while (keys.Contains(rand))
                {
                   rand=random.Next(maxNum);
                }
                keys.Add(rand);
                avl.Insert(rand);
                values.Add(rand);
            }
            BNodeUtils.LevelVisit(avl.root);
            Console.WriteLine(string.Join(",",values));
        }
        static Avl InsertbasingList(List<int> list)
        {
            Avl avl = new Avl();
  
            for (int i = 0; i < list.Count; i++)
            {
                avl.Insert(list[i]);
                //BNodeUtils.LevelVisit(avl.root);
                //Console.WriteLine();
            }

            return avl;
            //Console.WriteLine(string.Join(",", values));
        }
        static void DeleteTest(Avl avl,int value)
        {
            //avl.Delete(ref avl.,avl.root ,value);
           
        }

        static void BugTest()
        {
            List<int> list = new List<int> { 39, 9, 1, 27, 93, 2, 10, 88, 28, 29, 81, 48, 47, 56, 46, 64, 5, 20, 54, 74, 60, 43, 59, 97, 35, 87, 65, 58, 3, 8, 0, 68, 32, 41, 38, 99, 30, 98, 75, 92, 69, 95, 18, 7, 14, 71, 50, 85, 57, 25 };
            Avl avl = InsertbasingList(list);
            BNodeUtils.LevelVisit(avl.root);
            for (int i = 0; i < list.Count; ++i)
            {
                Console.WriteLine($"删除{list[i]}");
                DeleteTest(avl, list[i]);
                BNodeUtils.PreVisitNode(avl.root);
                BNodeUtils.LevelVisit(avl.root);
                Console.WriteLine();
            }

        }
        static void Main(string[] args)
        {
            //List<int> list = new List<int> { 39, 9, 1, 27, 93, 2, 10, 88, 28, 29, 81, 48, 47, 56, 46, 64, 5, 20, 54, 74, 60, 43, 59, 97, 35, 87, 65, 58, 3, 8, 0, 68, 32, 41, 38, 99, 30, 98, 75, 92, 69, 95, 18, 7, 14, 71, 50, 85, 57, 25 };
            //Avl avl = InsertbasingList(list);

            BugTest();
            //BNodeUtils.LevelVisit(avl.root);
            //for (int i = 0; i < list.Count; ++i)
            //{
            //    DeleteTest(avl, list[i]);
            //    Console.WriteLine($"删除{list[i]}");
            //    BNodeUtils.LevelVisit(avl.root);
            //}


        }

    }


}
