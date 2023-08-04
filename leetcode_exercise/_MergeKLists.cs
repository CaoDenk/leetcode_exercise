using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 挖坑
    /// </summary>
    internal class _MergeKLists
    {
        class LNode : IComparable<LNode>
        {
            public ListNode node { get; set; }
            public int CompareTo(LNode? other)
            {
                return node.val - other.node.val;
            }
            public LNode(ListNode node)
            {
                this.node = node;
            }
        }
        public ListNode MergeKLists(ListNode[] lists)
        {
            List<LNode> list = new List<LNode>();
            foreach (var i in lists)
            {
                ListNode t = i;
                do
                {
                    list.Add(new LNode(t));
                    t = t.next;
                }while (t != null);
            }

            list.Sort();
            var head = list[0].node;
            var p=head;
            for(int i=1;i<list.Count;i++)
            {
                p.next = list[i].node;
                p= p.next;
            }
            return head;
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
