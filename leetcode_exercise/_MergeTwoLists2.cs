using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _MergeTwoLists2
    {

        /// <summary>
        /// out of memory
        /// </summary>
        /// <param name="list1"></param>
        /// <param name="list2"></param>
        /// <returns></returns>
        ListNode MergeTwoLists(ListNode list1, ListNode list2)
        {


            if (list1 == null)
            {
                return list2;
            }
            else if (list2 == null)
            {
                return list1;
            }
           
            List<MyNode> list = new List<MyNode>();
            while(list1!=null)
            {
                MyNode m = new MyNode(list1);
                list.Add(m);

                list1 = list1.next;
            }
            while (list2 != null)
            {
                MyNode m = new MyNode(list2);
                list.Add(m);
                list2 = list2.next;

            }

            list.Sort();

            //ListNode ret = list[0].n;
            for(int i=0;i<list.Count-1; i++)
            {
                list[i].n.next = list[i + 1].n;

            }



            return list[0].n;

        }




    }
    internal class MyNode : IComparable
    {
        public ListNode n;
        public int CompareTo(object? obj)
        {
            MyNode n = obj as MyNode;
            return this.n.val - n.n.val;
        }
         public MyNode(ListNode n)
        {
            this.n = n;
        }

    }



}
