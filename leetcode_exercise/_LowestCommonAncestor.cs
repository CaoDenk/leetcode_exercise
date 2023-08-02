using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _LowestCommonAncestor
    {
        public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q)
        {
            var fatherList = FindNode(root, p);
            foreach (var father in fatherList)
            {
                if (IsFather(father, q))
                    return father;
            }

            return null;
        }
        /// <summary>
        /// 判断p是不是q的父亲节点
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        bool IsFather(TreeNode p, TreeNode q)
        {
            bool flag = false;
            PreVisit(p, q,ref flag);
            return flag;
        }

        void PreVisit(TreeNode root, TreeNode q,ref bool flag)
        {
            //if(p==q)   return true;
            if (flag)
                return;
            if(root.val==q.val)
            {
               flag = true;
            }
            if(root.left!=null)
            {
                PreVisit(root.left, q, ref flag);
            }
          
            if(root.right!=null)
            {
                PreVisit(root.right, q, ref flag);
            }



        }

        List<TreeNode>  FindNode(TreeNode root,TreeNode p)
        {
            List<TreeNode> route = new();
            bool flag = false;
            
            PreVisitNode(root, p, ref flag, new Stack<TreeNode>(), route);
            return route;
        }

        void PreVisitNode(TreeNode p, TreeNode q, ref bool flag,Stack<TreeNode> nodes,List<TreeNode> nodeLists)
        {
            //if(p==q)   return true;
            nodes.Push(p);
             
            if (p.val == q.val)
            {
                flag = true;
                nodeLists.Add(nodes.Pop());
                return;
            }

            if(p.left!=null)
            {
                PreVisitNode(p.left, q, ref flag, nodes, nodeLists);
            }

            if (flag)
            {
                nodeLists.Add(nodes.Pop());
                return;
            }
            if (p.right!=null)
            {
                PreVisitNode(p.right, q, ref flag, nodes, nodeLists);
            }
            if (flag)
            {
                nodeLists.Add(nodes.Pop());
                return;
            }
            nodes.Pop();


        }

        static void Main(string[] args)
        {
            //{
            //    var root = Utils.Make(new int?[] { 3, 5, 1, 6, 2, 0, 8, null, null, 7, 4 });
            //    _LowestCommonAncestor l = new();
            //    //var list=l.FindNode(root,new TreeNode(7));
            //    //Console.WriteLine(string.Join(",",list.Select(x=>x.val)));
            //    var ret = l.LowestCommonAncestor(root, new TreeNode(5), new TreeNode(1));
            //    Console.WriteLine(ret.val);
            //}
            {
                var root = Utils.Make(new int?[] { 1,2 });
                _LowestCommonAncestor l = new();
                //var list=l.FindNode(root,new TreeNode(7));
                //Console.WriteLine(string.Join(",",list.Select(x=>x.val)));
                var ret = l.LowestCommonAncestor(root, new TreeNode(1), new TreeNode(2));
                Console.WriteLine(ret.val);
            }
        }
        



    }
}
