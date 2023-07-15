using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace leetcode_exercise
{
    internal class _Preorder
    {


        // Definition for a Node.
        public class Node
        {
            public int val;
            public IList<Node> children;

            public Node() { }

            public Node(int _val)
            {
                val = _val;
            }

            public Node(int _val, IList<Node> _children)
            {
                val = _val;
                children = _children;
            }
        }


        List<int> ret=new List<int>();
        public IList<int> Preorder(Node root)
        {
            if (root != null)
            {
                Cur(root);
            }
            return ret; 
        }
        void Cur(Node node)
        {

            ret.Add(node.val);
            foreach(var i in node.children)
            {
                if(i != null)
                Cur(i);
            }
        }
    }
}
