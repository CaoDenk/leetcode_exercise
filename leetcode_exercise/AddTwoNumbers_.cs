using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2. 两数相加
    /// </summary>
    internal class AddTwoNumbers_
    {

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            var p1 =l1;
            var p2=l2;
            ListNode l=new();
            ListNode cur = l;
            int add = 0;
            while(p1!=null||p2!=null||add!=0)
            {
                int n1=p1!=null?p1.val:0;
                int n2 = p2 != null ? p2.val : 0;
                int result = n1 + n2 + add;
                cur.next = new ListNode();
                add = Math.DivRem(result, 10, out cur.next.val);
                
               
                cur = cur.next;
                if(p1!=null) { p1=p1.next; }
                if(p2!=null) { p2=p2.next; }
            }
            return l.next;
        }
        static void Main(string[] args)
        {
            AddTwoNumbers_ add = new();
            {
                ListNode n1 = Utils.MakeListNodes([2,4,3]);
                ListNode n2 = Utils.MakeListNodes([5, 6, 4]);
            }
        }
    }
}
