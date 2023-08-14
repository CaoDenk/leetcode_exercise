using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode_exercise._Preorder;

namespace leetcode_exercise
{
    /// <summary>
    /// 层序遍历
    /// </summary>
    internal class _LevelOrder
    {
        List<IList<int>> ret= new List<IList<int>>();
        public IList<IList<int>> LevelOrder(Node root)
        {
            if (root == null) return ret;
            //Add(1, root.val);
            Cur( root,-1);
            return ret;
        }

        void Add(int level,int val)
        {
            if(ret.Count==level)
            {
                ret.Add(new List<int> { val });
            }else
            {
                ret[level].Add(val);
            }
        }
        void Cur(Node node,int level)
        {
            ++level;
            Add(level, node.val);


            if(node.children != null)
            {
                foreach (var i in node.children)
                {                
                    Cur(i, level);                    
                }
            }          
        }

        static void Main()
        {
            var root = new Node(1);
            root.children = new List<Node>
            {
                new Node(3),
                new Node(2),
                new Node(4)
            };
            root.children[0].children = new List<Node>
            {
                new Node(5),
                new Node(6),
            };

            _LevelOrder l = new();
            var ret=l.LevelOrder(root);
            foreach(var i in ret)
            {
               var s= string.Join(",", i);
                Console.WriteLine(s);
            }
            
        }
    }
}
