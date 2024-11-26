using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 203. 移除链表元素
    /// </summary>
    internal class RemoveElements_
    {


        public ListNode RemoveElements(ListNode head, int val)
        {
            return Rm(head, val);
        }
        ListNode Rm(ListNode head, int val)
        {
            if (head == null)
                return null;
            if (head.val == val) return Rm(head.next, val);
            else
            {
                ListNode p = head;
                ListNode next = p.next;
                while (next != null)
                {
                    if (next.val == val)
                    {
                        next = next.next;
                        p.next = next;
                    }
                    else
                    {
                        next = next.next;
                        p = p.next;
                    }
                }

                return head;
            }
        }
        ListNode Init(int[] arr)
        {
            ListNode head = new ListNode();
            head.val = arr[0];
            ListNode p = head;

            for(int i=1;i<arr.Length;++i)
            {
                p.next=new ListNode(arr[i]);
                p = p.next;
            }
            return head;
        }
        void Print(ListNode head)
        {
            while(head != null)
            {
                Console.WriteLine(head.val);
                head = head.next;
            }
        }
        static void Main()
        {
           
            RemoveElements_ r = new();
            //{
            //    int[] arr = { 1, 2, 6, 3, 4, 5, 6 };
            //    ListNode head= r.Init(arr);
            //   var ret= r.RemoveElements(head, 6);
            //    r.Print(ret);
            //}

            //{
            //    int[] arr = { 1 };
            //    ListNode head = r.Init(arr);
            //    var ret = r.RemoveElements(head, 2);
            //    r.Print(ret);
            //}

            {
                int[] arr = { 1,2,2,1 };
                ListNode head = r.Init(arr);
                var ret = r.RemoveElements(head, 2);
                r.Print(ret);
            }
        }

    }
}
