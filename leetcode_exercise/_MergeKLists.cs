using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 23. 合并 K 个升序链表
    /// </summary>
    internal class _MergeKLists
    {
      
        public ListNode MergeKLists(ListNode[] lists)
        {
            
            PriorityQueue<ListNode,int> priorityQueue = new PriorityQueue<ListNode,int>();
           
            foreach(var l in lists)
            {
                if (l != null)
                    priorityQueue.Enqueue(l, l.val);
            }
            ListNode head=new ListNode(0);
            ListNode tail = head;

            while(priorityQueue.Count>0)
            {
                var node=  priorityQueue.Dequeue();
                tail.next = node;
                tail=tail.next;
                if(node.next!=null)
                {
                    priorityQueue.Enqueue(node.next, node.next.val);
                }
            }

            return head.next;
        }
        static void Main(string[] args)
        {
            //[[1,4,5],[1,3,4],[2,6]]
            List<int[]> ints = new List<int[]>() { new int[]{ 1, 4, 5 }, new int[]{ 1, 3, 4 }, new int[]{ 2, 6 } };
            ListNode[] nodes=new ListNode[ints.Count];
            int idx = 0;
            foreach(var i in ints)
            {
                nodes[idx]= Utils.MakeListNodes(i);
                ++idx;
            }
            _MergeKLists m = new();
            var res= m.MergeKLists(nodes);
            while(res != null)
            {
                Console.WriteLine(res.val);
                res = res.next;
            }
        }
    }

    

}
