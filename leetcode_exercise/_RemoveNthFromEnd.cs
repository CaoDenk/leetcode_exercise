using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _RemoveNthFromEnd
    {
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {
            int nodeCount =0;
            ListNode p= head;
            while (p.next!=null)
            {
                nodeCount++;
                p = p.next;
            }
            
            ++nodeCount;
            if(nodeCount == n)
                return head.next;
            p= head;
            int no = nodeCount - n-1;
            for(int i = 0; i <no;++i)
            {
                p= p.next;
            }  
            p.next = p.next.next;        
            return head;
        }

        static void Main(string[] args)
        {
            {
                var head = Utils.MakeListNodes(new int[] { 1, 2, 3, 4, 5, });
                _RemoveNthFromEnd r = new();
                var ret = r.RemoveNthFromEnd(head, 2);
                Utils.Print(ret);
            }
            {
                var head = Utils.MakeListNodes(new int[] { 1, });
                _RemoveNthFromEnd r = new();
                var ret = r.RemoveNthFromEnd(head, 1);
                Utils.Print(ret);
            }
            {
                var head = Utils.MakeListNodes(new int[] { 1, 2});
                _RemoveNthFromEnd r = new();
                var ret = r.RemoveNthFromEnd(head, 1);
                Utils.Print(ret);
            }
        }
    }
}
