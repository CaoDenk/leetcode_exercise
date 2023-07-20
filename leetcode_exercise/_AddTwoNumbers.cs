using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _AddTwoNumbers
    {

        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            int carry = 0;
            var p1=l1;
            var p2=l2;
            ListNode l=new ListNode();
            while(p1!=null&&p2!=null)
            {
                (carry,l.val)=(p1.val,p2.val);
                p1 = p1.next;
                p2=p2.next;
                 l = l.next;
            }
            return l;
        }
        (int ,int) Add(int i1,int i2,int carry)
        {
            int num = i1 + i2+carry;
            if(num>9)
            {
                return (1, num - 10);
            }else
                return (0, num);
        }
    }
}
