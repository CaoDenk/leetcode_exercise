using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _DeleteNode
    {
        public ListNode DeleteNode(ListNode head, int val)
        {
           
            return Cur(head, val);
        }

        ListNode Cur(ListNode head, int val)
        {
            if (head == null) return null;
            if (head.val == val) return Cur(head.next, val);

            ListNode p = head;
            ListNode next = p.next;
            

            while (next!=null) {
                if(next.val == val)
                {
                    p.next = next.next;
                    


                }
                if (p.next == null)
                    break;
                p = p.next;

                next=p.next;
                
            }
            return head;

        }
    }
}
