using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 42. 接雨水
    /// </summary>
    internal class _Trap2
    {
        public int Trap(int[] height)
        {
            Stack<(int, int)> stack = new();
            int ans = 0;
            stack.Push((height[0], 0));//height,position
            for(int i=1;i<height.Length;++i)
            {
                while(stack.Count > 0 && stack.Peek().Item1 < height[i])
                {
                    (int h,int pos)=stack.Pop();//洼地的高度
                    if (stack.Count > 0) //还有左墙
                    {
                        (int leftWallHeight,int leftWallPos)=stack.Peek();
                        int min = Math.Min(leftWallHeight, height[i]);
                        ans += (min-h) * (i - leftWallPos - 1);

                    }
                    else
                    {
                        break;
                    }
                }
                stack.Push((height[i], i));

            }
            return ans;
        }

        static void Main(string[] args)
        {
            _Trap2 trap = new _Trap2();
            Console.WriteLine(trap.Trap([0,1,0,2]));
            Console.WriteLine(trap.Trap([4, 2, 0, 3, 2, 5]));
        }
    }
}
