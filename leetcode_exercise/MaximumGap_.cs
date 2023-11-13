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
            public int maxValue;
            public int minValue;
            public Bucket(int value)
            {
                minValue= maxValue= value;
            }
        }
        public int MaximumGap(int[] nums)
        {
            if(nums.Length<2) return 0;
            if(nums.Length==2) return Math.Abs(nums[0] - nums[1]);
      
            int min = nums[0];
            int max = nums[0];
            int pos = 0;
            for(int i=1;i<nums.Length;++i)
            {
                if (nums[i]>max)
                {
                    max= nums[i];
                    pos = i;
                }
                else if (nums[i]<min)
                {
                    min= nums[i];
                }
            }
            if(max==min) return 0;
            Bucket[] buckets;
            int res=0;
            if (max-min>nums.Length-1)
            {
                buckets=new Bucket[nums.Length-1];
                int bucketLen = (max - min) / (nums.Length - 1);
                res = bucketLen;
                buckets[^1] = new Bucket(nums[pos]);
                for (int i = 0; i < nums.Length; ++i)
                {
                    int no = (nums[i] - min) / (bucketLen);
                    if (no >= buckets.Length)
                    {
                        if (nums[i] < buckets[^1].minValue)
                        {
                            buckets[^1].minValue = nums[i];
                        }
                        continue;
                    }
                    buckets[no] = buckets[no] ?? new Bucket(nums[i]);
                    if (nums[i] > buckets[no].maxValue)
                    {
                        buckets[no].maxValue = nums[i];
                    }
                    else if (nums[i] < buckets[no].minValue)
                    {
                        buckets[no].minValue = nums[i];
                    }
                }
                int ii = 0;
                int jj = ii + 1;
                while (jj < buckets.Length)
                {
                    if (buckets[jj] == null)
                    {
                        ++jj;
                    }
                    else
                    {
                        res = Math.Max(res, buckets[jj].minValue - buckets[ii].maxValue);
                        ii = jj;
                        ++jj;
                    }
                }
            }
            else
            {
                int?[] arr = new int?[max - min+1];
                for(int i=0;i<nums.Length;i++)
                {
                    if (arr[nums[i]-min]==null)
                    {
                        arr[nums[i] - min] = nums[i]; ;
                    }
                }
                int ii = 0;
                int jj = ii + 1;
                while (jj < arr.Length)
                {
                    if (arr[jj] == null)
                    {
                        ++jj;
                    }
                    else
                    {
                        res = Math.Max(res, arr[jj].Value - arr[ii].Value);
                        ii = jj;
                        ++jj;
                    }

                }
            }
            return res;
        }
        static void Main(string[] args)
        {
            MaximumGap_ m = new();
            Console.WriteLine(m.MaximumGap([3, 6, 9, 1]));
            Console.WriteLine(m.MaximumGap([1, 3, 100]));
            Console.WriteLine(m.MaximumGap([100, 3, 2, 1]));
            Console.WriteLine(m.MaximumGap([1, 1, 1, 1, 1, 5, 5, 5, 5, 5]));

        }

    }
}
