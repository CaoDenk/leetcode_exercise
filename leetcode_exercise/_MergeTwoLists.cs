using System.Collections;
using System.Collections.Generic;

namespace leetcode_exercise {


    internal class _MergeTwoLists {
        ListNode MergeTwoLists(ListNode list1, ListNode list2) {


            if (list1 == null)
            {
                return list2;
            }
            else if (list2 == null)
            {
                return list1;
            }
            else if (list1.val < list2.val)
            {
                list1.next = MergeTwoLists(list1.next, list2);
                return list1;
            }
            else
            {
                list2.next = MergeTwoLists(list1, list2.next);
                return list2;
            }

        }




        static void Main()
        {



        }


    }

    internal class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int val = 0, ListNode next = null) {
            this.val = val;
            this.next = next;
        }
    }



}