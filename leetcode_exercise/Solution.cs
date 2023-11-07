using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 117. 填充每个节点的下一个右侧节点指针 II
    /// </summary>
    internal class Solution
    {

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
        }



        public Node Connect(Node root)
        {
            if (root == null) return null;
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                int count = queue.Count;
                Node? last = null;
                for (int i = 0; i < count; ++i)
                {
                    Node n = queue.Dequeue();
                    if (n.left != null) queue.Enqueue(n.left);
                    if (n.right != null) queue.Enqueue(n.right);
                    if (last != null) last.next = n;
                    last = n;
                }
            }
            return root;
        }
    }
}
