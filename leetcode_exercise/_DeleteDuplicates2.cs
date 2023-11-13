using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 83. 删除排序链表中的重复元素
    /// </summary>
    internal class _DeleteDuplicates2
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            ListNode p=head;
            ListNode next;//= null;
            while (p.next!=null)
            {
                 next = p.next;
                if (p.val==next.val)
                {
                    p.next = next.next;
                    continue;
                }
                if (p.next==null) break;
                p =p.next;
            }           
            return head;
        }
        static void Main(string[] args)
        {
            _DeleteDuplicates2 d = new();
            {
                ListNode head = Utils.Init(new int[] { 1, 1, 2 });
                d.DeleteDuplicates(head);
                Utils.Print(head);
            }
            {
                ListNode head = Utils.Init(new int[] { 1, 1, 2, 3, 3 });
                d.DeleteDuplicates(head);
                Utils.Print(head);
            }
            {
                ListNode head = Utils.Init(new int[] { 1, 1,1 });
                d.DeleteDuplicates(head);
                Utils.Print(head);
            }

        }

    }
}
