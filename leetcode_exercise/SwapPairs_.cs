using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class SwapPairs_
    {
        public ListNode SwapPairs(ListNode head)
        {
            //if (head  ==null||head.next==null)
            //{
            //    return head;
            //}
            //var t=head.next.next;
            //(head.val,head.next.val)=(head.next.val,head.val);

            //while(t!=null&&t.next!=null)
            //{
            //    (t.val, t.next.val) = (t.next.val, t.val);
            //    t = t.next.next;
            //}
            //return head;
            ListNode pre=new ListNode();
            pre.next = head;
            var t = pre;
          
      
            while (head != null && head.next != null)
            {

                t.next = head.next;
                var tmp = head.next.next;

                head.next.next = head;

                head.next= tmp;

                t = head;
                head = tmp;

            }

            return pre.next;


        }
        ListNode Swap(ref ListNode node1,ref ListNode node2) {
            (node1.val,node2.val)=(node2.val,node1.val);
            
            return node2.next;
        }


        static void Main(string[] args)
        {
           var head= Utils.MakeListNodes(new int[] { 1, 2, 3, 4,5 });
            SwapPairs_ s = new();
            Utils.Print(head);
            var ans=s.SwapPairs(head);
            Utils.Print(ans);

        }


    }
}
