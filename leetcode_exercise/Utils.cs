
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    public class Utils
    {

        public static ListNode Init(int[] arr)
        {
            ListNode head = new ListNode();
            head.val = arr[0];
            ListNode p = head;

            for (int i = 1; i < arr.Length; ++i)
            {
                p.next = new ListNode(arr[i]);
                p = p.next;
            }
            return head;
        }
        public static void Print(ListNode head)
        {
            while (head != null)
            {
                Console.Write(head.val+",");
                head = head.next;
            }
            Console.WriteLine();
        }

        public static TreeNode? Make(int?[] nums)
        {
            if (nums.Length == 0 || nums[0] == null)
                return null;
            TreeNode root = new TreeNode(nums[0]!.Value);
            Queue<TreeNode> que = new Queue<TreeNode>();
            que.Enqueue(root);
            LevelMake(que, nums);
            return root;
        }
        public static  void LevelMake(Queue<TreeNode> lastLevelNodes, int?[] nums)
        {

            for (int i = 1; i < nums.Length; i += 2)
            {
                TreeNode node = lastLevelNodes.Dequeue();
                if (nums[i] != null)
                {
                    node.left = new TreeNode(nums[i].Value);
                    lastLevelNodes.Enqueue(node.left);
                }
                if (i + 1 < nums.Length && nums[i + 1] != null)
                {
                    node.right = new TreeNode(nums[i + 1].Value);
                    lastLevelNodes.Enqueue(node.right);
                }
            }

        }
        public static void PreVisit(TreeNode n)
        {
            Console.Write(n.val+",");
            if (n.left != null)
            {
                PreVisit(n.left);
            }
            if (n.right != null)
                PreVisit(n.right);

        }
        public static void MidVistit(TreeNode root,  List<int> nums)
        {
            if (root.left != null)
                MidVistit(root.left, nums);
            nums.Add(root.val);
            if (root.right != null)
                MidVistit(root.right,  nums);
        }

        public static ListNode MakeListNodes(int[] arr)
        {
            
            ListNode list = new ListNode();
            ListNode ret = list;
            list.val = arr[0];
           for(int i=1; i<arr.Length; i++)
            {
                list.next=new ListNode(arr[i]);
                list=list.next;
            }
           return ret;
        }


    
    }
}
