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
    internal class HasCycle_
    {

        public bool HasCycle(ListNode head)
        {
            if(head == null) return false;
            if(head.next == null) return false;
            HashSet<ListNode> visited = new HashSet<ListNode>();
            ListNode p= head;
            do
            {
                if(!visited.Add(p)) return true;
                 else p = p.next;
            } while (p != null);
            return false;

        }
    }
}
