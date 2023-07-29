using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _GetIntersectionNode
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            HashSet<ListNode> nodes = new HashSet<ListNode>();
            while (headA != null)
            {
                nodes.Add(headA);
                headA = headA.next;
            }
            while(headB!=null)
            {
                if (nodes.Contains(headB))
                    return headB;
                else
                    nodes.Add(headB);
                headB = headB.next;
            }
            return null;
        }
    }
}
