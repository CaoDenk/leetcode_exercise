using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// LCR 023. 相交链表
    /// </summary>
    internal class GetIntersectionNode_
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {

            HashSet<ListNode> nodeA = new HashSet<ListNode>();
            HashSet<ListNode> nodeB = new HashSet<ListNode>();

            while(headA!=null||headB!=null)
            {
                if(headA!=null)
                {
                    if(nodeB.Contains(headA))
                    {
                        return headA;
                    }
                    nodeA.Add(headA);
                    headA = headA.next;
                }
                if(headB!=null)
                {
                    if(nodeA.Contains(headB))
                    {
                        return headB;
                    }
                    nodeB.Add(headB);
                    headB = headB.next;
                }
            }
            return null;
        }
    }
}
