using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{

    /// <summary>
    /// 206. 反转链表
    /// </summary>
    internal class _ReverseList
    {

        public ListNode? ReverseList(ListNode head)
        {
            if (head == null)
                return null;
            ListNode? pnext = head.next;
            head.next = null;
            for (; pnext != null;)
            {
                (head, pnext) = Swap(head, pnext);
               
            }

            return head;
        }
        (ListNode? head, ListNode? next) Swap(ListNode p1,ListNode p2) {
            ListNode? ret = p2.next;
            p2.next = p1;
            return (p2,ret);
            
        }

        ListNode init(int[] arr)
        {
            
            ListNode[] listNode = new ListNode[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                listNode[i] = new ListNode();
            }
            listNode[0].val = arr[0];
            for (int i = 0; i < arr.Length - 1; ++i)
            {
                listNode[i].next = listNode[i + 1];
                listNode[i + 1].val = arr[i + 1];
            }
    
            
            return listNode[0];
        }
        static void Main()
        {

            var arr = new int[] { 1, 2, 3, 4, 5 };
            _ReverseList r = new();
            var ret=r.init(arr);
            var revret=r.ReverseList(ret);
            while(revret != null)
            {
                Console.WriteLine(revret.val);
                revret = revret.next;
            }
        
        }



    }
}
