using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class Utils
    {

        public static ListNode Init(int[] arr)
        {
            ListNode head = new ListNode();
            head.val = arr[0];
            ListNode p = head;

            for (int i = 1; i < arr.Length; ++i)
            {
                p.next = new ListNode(arr[i]);
                p = p.next;
            }
            return head;
        }
        public static void Print(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val+",");
                head = head.next;
            }
            Console.WriteLine();
        }

        
    }
}
