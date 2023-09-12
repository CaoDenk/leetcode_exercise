using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 164. 最大间距
    /// </summary>
    internal class MaximumGap_
    {

        class Bucket
        {
            public int maxValue=int.MinValue;
            public int minValue=int.MaxValue;
        }
        public int MaximumGap(int[] nums)
        {
            if(nums.Length<2) return 0;
            if(nums.Length==2) return Math.Abs(nums[0] - nums[1]);
      
            int min = nums[0];
            int max = nums[0];
            //int pos = 0;
            for(int i=1;i<nums.Length;++i)
            {
                if (nums[i]>max)
                {
                    max= nums[i];
                    //pos = i;
                }
                else if (nums[i]<min)
                {
                    min= nums[i];
                }
            }
            if(max==min) return 0;
            int BucketLen = 0;
            Bucket[] buckets;
            if (max-min<nums.Length-1)
            {
                BucketLen = (max - min) / (nums.Length - 1);
            }else
            {
                Bucket
                 buckets = new Bucket[nums.Length - 1];
            }
          
            
            int res = BucketLen;
   
            buckets[^1]=new Bucket();
            for(int i=0;i<nums.Length;++i)
            {
                int no = (nums[i]-min)/(BucketLen);
                if(no>=buckets.Length)
                {
                    //if (nums[i] > buckets[^1].maxValue)
                    //{
                    //    buckets[^1].maxValue = nums[i];
                    //}
                    if (nums[i] < buckets[^1].minValue)
                    {
                        buckets[^1].minValue = nums[i];
                    }
                    continue;
                }
                buckets[no]=buckets[no] ?? new Bucket();
                if (nums[i]> buckets[no].maxValue)
                {
                    buckets[no].maxValue = nums[i];
                }
                if (nums[i]< buckets[no].minValue)
                {
                    buckets[no].minValue = nums[i];
                }

            }
           
            int ii = 0;
            int jj = ii + 1;
            while (jj < buckets.Length)
            {
                if (buckets[jj]==null)
                {
                    ++jj;
                }
                else
                {
                    res=Math.Max(res, buckets[jj].minValue - buckets[ii].maxValue);
                    ii = jj;
                    ++jj;
                }

            }
            return res;
        }
        static void Main(string[] args)
        {
            MaximumGap_ m = new();
            Console.WriteLine(m.MaximumGap(new int[] { 3, 6, 9, 1 }));
            Console.WriteLine(m.MaximumGap(new int[] { 1, 3, 100 }));
            Console.WriteLine(m.MaximumGap(new int[] { 100, 3, 2, 1 }));
            Console.WriteLine(m.MaximumGap(new int[] { 1, 1, 1, 1, 1, 5, 5, 5, 5, 5 }));

        }

    }
}
