using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 143. 重排链表
    /// </summary>
    internal class ReorderList_
    {
        public void ReorderList(ListNode head)
        {
            if (head == null || head.next == null) return;
            List<ListNode> list = new();
            ListNode h = head;
            do
            {
                list.Add(h);
                h = h.next;
            } while (h != null);

            int i = 0;
            int j = list.Count - 1;
            bool flag = false;
            while (i < j)
            {
                if (!flag)
                {
                    list[i].next = list[j];
                    ++i;
                }
                else
                {
                    list[j].next = list[i];
                    --j;
                }
                flag = !flag;
            }
            list[i].next = null;
        }
    }
}
