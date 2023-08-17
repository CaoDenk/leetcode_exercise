using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 55. 跳跃游戏
    /// </summary>
    internal class CanJump_
    {
        public bool CanJump(int[] nums)
        {

            bool[] covered=new bool[nums.Length];
            covered[0]=true;

            for(int i=0;i<nums.Length;++i)
            {
                if (covered[i])
                {
                    int len = nums[i];
                    if (len + i >= nums.Length)
                        return true;
                    Array.Fill(covered, true, i+1, len);
                }
                else
                    return false;
            }

            return covered[^1];
        }

        static void Main(string[] args)
        {
            CanJump_ can = new();
            Console.WriteLine(can.CanJump(new int[] { 2, 3, 1, 1, 4 }));
        }
    }
}
