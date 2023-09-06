using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 82. 删除排序链表中的重复元素 II
    /// </summary>
    internal class DeleteDuplicates_
    {
        public ListNode DeleteDuplicates(ListNode head)
        {

            return Recursive(head);
        }

        ListNode Recursive(ListNode head)
        {
            if (head == null||head.next==null)
                return head;

            int val = head.val;
            ListNode h = head.next;
            
            if(h!=null&&h.val==val)
            {
                do
                {
                    h = h.next;
                }
                while (h != null && h.val == val);
                head.next=Recursive(h);
                head=head.next;
            }else
            {
                head.next = Recursive(h);
            }
            return head;
        }

        static void Main(string[] args)
        {
            ListNode node= Utils.MakeListNodes(new int[] { 1, 2, 3, 3, 4, 4, 5 });
            DeleteDuplicates_ d=new DeleteDuplicates_();
            var res=d.DeleteDuplicates(node);
            while(res!=null)
            {
                Console.WriteLine(res.val);
                res = res.next;
            }
        }
    }
}
