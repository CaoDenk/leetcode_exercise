using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 198. 打家劫舍
    /// </summary>
    internal class Rob_
    {

        public int Rob(int[] nums)
        {
            if(nums.Length==1)return nums[0];
            int[] dp=new int[nums.Length];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);
            for(int i=2;i<nums.Length;++i)
            {
                dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            }

            return  dp[^1];
        }


        int max = 0;
        public int Rob2(int[] nums)
        {
            if(nums.Length == 1) return nums[0];
            bool[] vis = new bool[nums.Length];
            Recursive(nums, 0, nums[0]);
            Recursive(nums, 1, nums[1]);

            return max;
        }

        Dictionary<int, int> cut = new();
        void Recursive(int[] nums, int start,  int sum)
        {
      
             if(start+2<nums.Length) 
            {
                int tsum = sum + nums[start + 2];
                if (!cut.ContainsKey(start + 2) || tsum > cut[start+2]) {
                    cut[start + 2] = tsum;
                    Recursive(nums, start + 2, tsum);
                }
              
            }else
            {
                max=Math.Max(max, sum);
            }
            if (start + 3 < nums.Length)
            {
                int tsum = sum + nums[start + 3];
                if (!cut.ContainsKey(start + 3) || tsum > cut[start + 3])
                {
                    cut[start+3] = tsum;
                    Recursive(nums, start + 3, tsum);
                }
            }
            else
            {
                max = Math.Max(max, sum);
            }

        }
        static void Main(string[] args)
        {
            Rob_ r = new();
            {
                int[] nums = [1, 2, 3, 1];
                Console.WriteLine(r.Rob(nums));
            }
            {
                int[] nums = [2, 1, 2, 2];
                Console.WriteLine(r.Rob(nums));
            }
            {
                int[] nums = [2, 7, 9, 3, 1];
                Console.WriteLine(r.Rob(nums));
            }
            {
                int[] nums = [82, 217, 170, 215, 153, 55, 185, 55, 185, 232, 69, 131, 130, 102];//1082
                Console.WriteLine(r.Rob(nums));
            }
            {
                int[] nums = [226, 174, 214, 16, 218, 48, 153, 131, 128, 17, 157, 142, 88, 43, 37, 157, 43, 221, 191, 68, 206, 23, 225, 82, 54, 118, 111, 46, 80, 49, 245, 63, 25, 194, 72, 80, 143, 55, 209, 18, 55, 122, 65, 66, 177, 101, 63, 201, 172, 130, 103, 225, 142, 46, 86, 185, 62, 138, 212, 192, 125, 77, 223, 188, 99, 228, 90, 25, 193, 211, 84, 239, 119, 234, 85, 83, 123, 120, 131, 203, 219, 10, 82, 35, 120, 180, 249, 106, 37, 169, 225, 54, 103, 55, 166, 124];
                Console.WriteLine(r.Rob(nums));
            }

        }


    }
}
