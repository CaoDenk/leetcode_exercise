using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class ReverseBetween_
    {
        public ListNode ReverseBetween(ListNode head, int left, int right)
        {
            if(left==1)
                return ReverseList( head, left, right);
            ListNode h = head;
            for(int i=1;i<left-1;++i)
            {
                h = h.next;
            }
            h.next= ReverseList(h.next, left, right);
            return head;
        }
        public ListNode ReverseList(ListNode head,int left,int right)
        {
            ListNode pnext = head.next;
            ListNode tmp=  head;
            for (; left<right; ++left)
            {
                ListNode ret = pnext.next;
                pnext.next = head;
                head = pnext;
                pnext = ret;
            }
            tmp.next = pnext;
            return head;
        }


        static void Main(string[] args)
        {
            ReverseBetween_ r = new();
           
            {
                int[] arr = new int[] { 1,2,3,4,5,6};
                var node= Utils.MakeListNodes(arr);
                var n= r.ReverseBetween(node, 2, 4);
                while(n!=null)
                {
                    Console.Write(n.val+",");
                    n=n.next;
                }
            }
           

        }

    }
}
