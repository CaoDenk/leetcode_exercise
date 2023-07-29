using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class IsPalindrome_
    {
        public bool IsPalindrome(ListNode head)
        {

            List<ListNode> list = new List<ListNode>();
            ListNode listNode = head;
            while (listNode != null)
            {
                list.Add(listNode);
                listNode = listNode.next;
            }

            int i=0,j=list.Count-1;
            while (i<j)
            {
                if (list[i].val != list[j].val)
                    return false;
                i++;
                j--;
            }

            return true;
        }
    }
}
