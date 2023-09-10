using leetcode_exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NNode
{
    // Definition for a Node.
    /// <summary>
    /// 116. 填充每个节点的下一个右侧节点指针
    /// </summary>
    public class Node
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() { }

        public Node(int _val)
        {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next)
        {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
        public Node Connect(Node root)
        {
            if (root == null) return null;
            LevelOrder(root);
            return root ;
        }

        void LevelOrder(Node node)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(node);
            List<Node> list = new List<Node>();
            while (queue.Count > 0)
            {
                list.Clear();
                int count = queue.Count;
                for (int i = 0; i < count; ++i)
                {
                    Node n = queue.Dequeue();
                    if (n.left != null)
                    {
                        queue.Enqueue(n.left);

                    }
                    if (n.right != null)
                    {
                        queue.Enqueue(n.right);
                    }

                    list.Add(n);
                }
                Connect(list);

            }
        }
        
        void Connect(List<Node> list)
        {

            for (int i = 1; i < list.Count; ++i)
            {
                list[i - 1].next = list[i];
            }

        }
    }
}
