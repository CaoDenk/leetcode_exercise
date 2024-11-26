using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 142. 环形链表 II
    /// </summary>
    internal class DetectCycle_
    {
        public ListNode DetectCycle(ListNode head)
        {
            HashSet<ListNode> visited = new HashSet<ListNode>();
            while (head != null)
            {
                if (!visited.Add(head))
                    return head;
                head = head.next;
            }
            return null;
        }
    }
}
