

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{

    public class MaxSlidingWindow__
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            int[] result = new int[nums.Length - k + 1];
            int num = 0;
            Deque myQueue = new();
            for (int i = 0; i < k; ++i)
            {
                myQueue.AddBack(nums[i]);
            }
            result[num++] = myQueue.Front;
            for (int i = k; i < nums.Length; ++i)
            {
                myQueue.Poll(nums[i - k]);
                myQueue.AddBack(nums[i]);
                result[num++] = myQueue.Front;
            }

            return result;
        }
        static void Main(string[] args)
        {
            MaxSlidingWindow__ maxSlidingWindow2 = new();
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

    internal class Deque
    {
        int[] _Data = new int[128];
        int Offset = 31;
        int len = 0;

        public void AddBack(int value)
        {

            while (len > 0 && Last < value)
            {
                PopBack();
            }
            _Data[Offset + len] = value;
            len++;
            if (Offset + len >= _Data.Length)
            {
                Grow();
            }
        }

        void Grow()
        {
            int newLen = _Data.Length * 2;
            var newData = new int[newLen];

            Array.Copy(_Data, Offset, newData, 31, len);
            _Data = newData;
            Offset = 31;
        }

        public void AddFront(int value)
        {
            --Offset;
            _Data[Offset] = value;
            len++;
            if (Offset == 0)
            {
                Grow();
            }
        }
        public void Poll(int value)
        {
            if (len > 0 && value == Front)
            {
                PopFront();
            }
        }
        int PopBack()
        {
            --len;
            return _Data[Offset + len];
        }

        int PopFront()
        {
            int ret = _Data[Offset];
            Offset++;
            len--;
            return ret;
        }

        public int Front => _Data[Offset];
        int Last => _Data[Offset + len - 1];
    }

}


