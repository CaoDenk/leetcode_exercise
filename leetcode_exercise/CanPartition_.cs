using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 416. 分割等和子集
    /// </summary>
    internal class CanPartition_
    {

        public bool CanPartition(int[] nums)
        {
            int sum = nums.Sum();
            int half = sum / 2;
            if(sum!=half*2)
                return false;
            int[,] dp=new int[nums.Length, half+1 ]; //dp[i,j] 表示容量为j的背包最大价值 ,第i个物品

            for(int i = nums[0];i< dp.GetLength(1); ++i)
            {
                dp[0,i] = nums[0];
            }
            
            for (int i = 1; i < nums.Length; i++)
            { 
                for (int j = 0; j <= half; j++)
                { 
                    if (j < nums[i]) dp[i,j] = dp[i - 1,j];//不装
                    else dp[i,j] = Math.Max(dp[i - 1,j], dp[i - 1,j - nums[i]] + nums[i]);// Max(装第i个物品,不装该物品) 装物品的最大价值dp[i-1,j-nums[i]]+nums[i]
                }

            }
            return dp[nums.Length-1,half]==half;
        }

        public bool CanPartition2(int[] nums)
        {
            int sum=nums.Sum();
            int half = sum/ 2;
            if(half*2!=sum)
                return false;
            bool flag = false;
            Recursive(nums, 0,half,0,ref flag);
            return flag;
        }

        void Recursive(int[] nums,int start,int target,int sum,ref bool flag) 
        {
            if(sum>target||start>=nums.Length)
            {
                return;
            }          
            if(sum==target)
            {
                flag = true;
                return;
            }
            Recursive(nums, start + 1, target, sum + nums[start],ref flag);//选
            if (flag)
                return;
            Recursive(nums, start + 1, target, sum ,ref flag);//不选

        }
        static void Main(string[] args)
        {
            CanPartition_ c = new();
            Console.WriteLine(c.CanPartition(new int[] { 1, 5, 11, 5 }));
        }

    }
}
