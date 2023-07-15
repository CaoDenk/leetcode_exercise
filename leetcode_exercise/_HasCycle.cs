using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 141. 环形链表
    /// </summary>
    internal class _HasCycle
    {

        public bool HasCycle(ListNode head)
        {
            if(head == null) return false;
            if(head.next == null) return false;
            HashSet<ListNode> visited = new HashSet<ListNode>();
            ListNode p= head;
            do
            {
                if(visited.Contains(p)) return true;
                visited.Add(p);
                p = p.next;
            } while (p != null);
            return false;

        }
    }
}
