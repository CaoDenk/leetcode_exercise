using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{

    /// <summary>
    ///  //86. 分隔链表
    /// 挖坑
    /// </summary>
    internal class Partition86
    {
        public ListNode Partition(ListNode head, int x)
        {

            if (head == null || head.next == null)
                return head;
            ListNode hair=new ListNode();
            hair.next = head;
            ListNode h=hair;
            while (h.next!=null)
            {
                if(h.next.val>=x)
                {
                    break;
                }
                h = h.next;
            }

            if (h.next == null)
                return head;
            ListNode p = h;
            while(h.next!=null)
            {
                if(h.next.val<x)
                {
                    var save=h.next;
                    h.next = h.next.next;

                    save.next = p.next;
                    p.next = save;
                    p = p.next;
                  
                }else
                    h=h.next;
            }
            return hair.next;

        }
        static void Main(string[] args)
        {
            Partition86 p = new();
            //{
            //    int[] arr = { 1, 4, 3, 2, 5, 2 };
            //    int x = 3;
            //    var node = Utils.MakeListNodes(arr);
            //    var res = p.Partition(node, x);
            //    while (res != null)
            //    {
            //        Console.Write(res.val+",");
            //        res = res.next;
            //    }
            //    Console.WriteLine();
            //}
            //{
            //    int[] arr = { 1,2};
            //    int x = 2;
            //    var node = Utils.MakeListNodes(arr);
            //    var res = p.Partition(node, x);
            //    while (res != null)
            //    {
            //        Console.Write(res.val + ",");
            //        res = res.next;
            //    }
            //    Console.WriteLine();
            //}
            //{
            //    int[] arr = { 3,1 };
            //    int x = 2;
            //    var node = Utils.MakeListNodes(arr);
            //    var res = p.Partition(node, x);
            //    while (res != null)
            //    {
            //        Console.Write(res.val + ",");
            //        res = res.next;
            //    }
            //    Console.WriteLine();
            //}
            //{
            //    int[] arr = { 1,2,3 };
            //    int x = 3;
            //    var node = Utils.MakeListNodes(arr);
            //    var res = p.Partition(node, x);
            //    while (res != null)
            //    {
            //        Console.Write(res.val + ",");
            //        res = res.next;
            //    }
            //    Console.WriteLine();
            //}
            {
                int[] arr = [1, 1];
                int x = 2;
                var node = Utils.MakeListNodes(arr);
                var res = p.Partition(node, x);
                while (res != null)
                {
                    Console.Write(res.val + ",");
                    res = res.next;
                }
                Console.WriteLine();
            }
        }



    }
}
