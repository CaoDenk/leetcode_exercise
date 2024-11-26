using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// LCR 136. 删除链表的节点
    /// </summary>
    internal class DeleteNode_
    {
        public ListNode DeleteNode(ListNode head, int val)
        {
            if (head == null) return null;
            if (head.val == val) return DeleteNode(head.next, val);

            ListNode p = head;
            ListNode next = p.next;

            while (next != null)
            {
                if (next.val == val) p.next = next.next;
                if (p.next == null)break;
                p = p.next;
                next = p.next;

            }
            return head;
        }


    }
}
