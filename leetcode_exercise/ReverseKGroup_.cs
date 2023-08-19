using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 25. K 个一组翻转链表
    /// </summary>
    internal class ReverseKGroup_
    {
        public ListNode ReverseKGroup(ListNode head, int k)
        {
            ListNode pre = new();
            (bool b,ListNode tail)=CountK(head,k);
            if(!b )
            {
                pre.next = head;                
            }else
            {
                pre.next = tail;
                var tmp = tail.next;
                SwapK(head,k);
                head.next=ReverseKGroup(tmp, k);
            }
            return pre.next;
        }

        void SwapK(ListNode head,int k)
        {
            ListNode l1=head;
            ListNode l2=head.next;
            for(int i=0;i<k-1;i++) 
            {
                ListNode res=l2.next;
                l2.next=l1;
               (l1,l2) =(l2, res);
            }
        }
       

        (bool,ListNode) CountK(ListNode head,int k)
        {
            int count = 0;
            while (head != null)
            {
                count++;
                if (count == k)
                    return (true, head);
                head = head.next;
              
            }
            return (false, null);
        }

        static void Main(string[] args)
        {
            {
                var head = Utils.MakeListNodes(new int[] { 1, 2, 3, 4, 5,6,7 });
                ReverseKGroup_ s = new();
                Utils.Print(head);
                var ans = s.ReverseKGroup(head, 3);
                Utils.Print(ans);
            }
            {
                var head = Utils.MakeListNodes(new int[] { 1, 2, 3, 4, 5 });
                ReverseKGroup_ s = new();
                Utils.Print(head);
                var ans = s.ReverseKGroup(head, 2);
                Utils.Print(ans);
            }
        }
    }
}
