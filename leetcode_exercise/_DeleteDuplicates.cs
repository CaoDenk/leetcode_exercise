using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _DeleteDuplicates
    {
        public ListNode DeleteDuplicates(ListNode head)
        {
            if (head == null) return null;
            //HashSet<ListNode> nodes=
            var dict = MakeDict(head);
            var set = dict.Keys;

            var list =set.ToList();
            head = dict[list[0]];
            for(int i=0;i<list.Count-1;++i)
            {
                dict[list[i]].next = dict[list[i + 1]];
            }
            return head;
            
        }

        Dictionary<int, ListNode> MakeDict(ListNode head) {
            var ret=new HashSet<ListNode>();
            Dictionary<int,ListNode> dict = new Dictionary<int,ListNode>();
            do
            {
                dict[head.val] = head;
                head=head.next;
            }while (head != null);
            return dict;
        
        }

    }
}
