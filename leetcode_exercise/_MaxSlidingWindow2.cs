
using Nito.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{

    class MyQueue
    {
        Deque
       // PriorityQueue<int,int> priorityQueue = new();

        List<int> queue = new();
        //Queue<int> queue = new Queue<int>();
        //public void Pop()
        //{
        //    queue.RemoveFromFront();
        //}
 
        public void Push(int item)
        {
            while (queue.Count > 0&&item>queue.Last()) 
            {
                queue.RemoveAt(queue.Count-1);
            }
            queue.Add(item);

        }
        public void Poll(int item)
        {
            if(queue.Count > 0&&item==queue.First())
            {
                queue.RemoveAt(0);
            }

        }
        public int Front=>queue.First();

    }
    internal class _MaxSlidingWindow2
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int[] result = new int[nums.Length-k+1];
            int num = 0;
            MyQueue myQueue = new MyQueue();
            for(int i = 0; i <k;++i)
            {
                myQueue.Push(nums[i]);
                
            }
            result[num++] = myQueue.Front;
            for (int i = k; i < nums.Length; ++i)
            {
                myQueue.Poll(nums[i-k]);
                myQueue.Push(nums[i]);
                result[num++] = myQueue.Front;
            }


            
            return result;
        }
        static void Main(string[] args)
        {
            _MaxSlidingWindow2 maxSlidingWindow2 = new();
            //{
            //    var ret = maxSlidingWindow2.MaxSlidingWindow(new int[] { 1, 3, -1, -3, 5, 3, 6, 7 }, 3);
            //    Console.WriteLine(string.Join(",", ret));
            //}
            {
                var ret = maxSlidingWindow2.MaxSlidingWindow(new int[] { 1, 3, 1, 2, 0, 5 }, 3);
                Console.WriteLine(string.Join(",", ret));
            }
        }
    }

}
