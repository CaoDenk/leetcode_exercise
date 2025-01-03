﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 9. 删除链表的倒数第 N 个结点
    /// </summary>
    internal class RemoveNthFromEnd_
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
                var head = Utils.MakeListNodes([1, 2, 3, 4, 5,]);
                RemoveNthFromEnd_ r = new();
                var ret = r.RemoveNthFromEnd(head, 2);
                Utils.Print(ret);
            }
            {
                var head = Utils.MakeListNodes([1,]);
                RemoveNthFromEnd_ r = new();
                var ret = r.RemoveNthFromEnd(head, 1);
                Utils.Print(ret);
            }
            {
                var head = Utils.MakeListNodes([1, 2]);
                RemoveNthFromEnd_ r = new();
                var ret = r.RemoveNthFromEnd(head, 1);
                Utils.Print(ret);
            }
        }
    }
}
