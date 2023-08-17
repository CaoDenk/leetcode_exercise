using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace leetcode_exercise
{
    internal class ReverseList_
    {
        public ListNode ReverseList(ListNode head)
        {
            if (head == null || head.next == null)
                return head;
            List<ListNode> list = new List<ListNode>();
            while (head != null)
            {
                list.Add(head);
                head = head.next;
            }
            list.Reverse();

            
            for(int i=0;i<list.Count-1;++i )
            {
                list[i].next = list[i+1];
            }
            list[^1].next = null;
            return list[0];

        }
    }
}
