using leetcode_exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class BNodeUtils
    {
        static void PreVisit(BNode node)
        {
            if(node == null) return;
            Console.WriteLine($"[val={node.val}]");
            if(node.left!=null&& node.left.parent!=node)
            {
                throw new Exception($"{node.val}  乱了");
            }
            if (node.right != null && node.right.parent != node)
            {
                throw new Exception($"{node.val}  乱了");
            }
            PreVisit(node.left);
            PreVisit(node.right);
           
        }
        public static void PreVisitNode(BNode node)
        {
            PreVisit(node);
            //Console.WriteLine();
        }

        static void MidVisit(BNode node)
        {
            if (node == null) return;
            MidVisit(node.left);
            Console.WriteLine($"[val={node.val}]");
            MidVisit(node.right);
        }
        public static void MidVisitNode(BNode node)
        {
            MidVisit(node);
            //Console.WriteLine();
        }

        static IList<IList<int>> LevelOrder(BNode root)
        {
            List<IList<int>> ret = new List<IList<int>>();
            if (root == null)
                return ret;

            Queue<BNode> queue = new Queue<BNode>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var l = new List<int>();
                int curLevel = queue.Count;
                for (int i = 0; i < curLevel; ++i)
                {
                    BNode n = queue.Dequeue();
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);

                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }

                    l.Add(n.val);
                }

                ret.Add(l);
            }
            return ret;
        }

        public static void LevelVisit(BNode node)
        {
           var i= LevelOrder(node);
           foreach(var l in i)
           {
                Console.WriteLine(string.Join(",",l));
           }
            Console.WriteLine("*********************************");
        }

       public static void VisitParent(BNode node)
        {
            while(node!=null)
            {
                Console.WriteLine(node.val);
                node = node.parent;
            }
        }

        public static BNode GetLast(BNode node)
        {
            while(node!=null&&node.left!=null)
            {
                node = node.left;
            }
            return node;
        }



       



    }
}
