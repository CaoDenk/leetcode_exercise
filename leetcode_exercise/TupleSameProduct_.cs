using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1726. 同积元组
    /// </summary>
    internal class TupleSameProduct_
    {
        public int TupleSameProduct(int[] nums)
        {
            //Dictionary<int, (int, int)> dict = new();
            Dictionary<int,int> freq=new();
            
            for(int i=0;i<nums.Length;++i)
            {
                for(int j=i+1;j<nums.Length;++j)
                {
                    freq[nums[j] * nums[i]] = freq.GetValueOrDefault(nums[i] * nums[j]) + 1;
                }
            }
            int res = 0;
            foreach((_,var i) in  freq)
            {
                if (i == 1)
                    continue;
                 res += 4 * i * (i - 1);
            }

            return res;
        }
        
    }
}
