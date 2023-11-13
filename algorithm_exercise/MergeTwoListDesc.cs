using leetcode_exercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class MergeTwoListDesc
    {

        ListNode Megre(ListNode node1, ListNode node2)
        {

            ListNode h =null;
            while(node1!=null && node2!=null)
            {
                if(node1.val>node2.val)
                {
                    var t = node1.next;
                    node1.next = h;
                    h = node1;
                    node1 = t;
                }else
                {
                    var t = node2.next;
                    node2.next = h;
                    h = node2;
                    node2 = t;
                }
            }
            while(node1!=null)
            {
                var t = node1.next;
                node1.next = h;
                h = node1;
                node1 = t;
            }
            while (node2 != null)
            {
                var t = node2.next;
                node2.next = h;
                h = node2;
                node2 =t;

            }
            return h;
        }

        static void Main(string[] args)
        {
            var node1= Utils.MakeListNodes([8,5, 3, 1]);
            var node2= Utils.MakeListNodes([9,4,2]);
            MergeTwoListDesc m = new();
            var res=m.Megre(node1, node2);
            Utils.Print(res);
        }
    }
}
