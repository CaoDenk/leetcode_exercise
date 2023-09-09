using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 80. 删除有序数组中的重复项 II
    /// </summary>
    internal class RemoveDuplicates2
    {
        public int RemoveDuplicates(int[] nums)
        {
            if (nums.Length <= 2)
                return nums.Length;
            int startHole1 = 0, endHole1 = 0;
            bool flag = false;
            for(int i=1;i<nums.Length-1;++i)
            {
                if (nums[i] == nums[i - 1]&& nums[i] == nums[i + 1])
                {
                    int startHole2 = i + 1;
                    do
                    {
                        ++i;
                    } while (i + 1 < nums.Length && nums[i] == nums[i + 1]);                      
                    if(flag)
                    {
                        for (int k = endHole1 + 1; k < startHole2; ++k)
                        {
                            nums[startHole1++] = nums[k];
                        }
                    }
                    else
                    {
                        startHole1 = startHole2;
                        flag = true;
                    }
                    endHole1 = i;
                }
            }
            if(!flag) return nums.Length;
            for (int k = endHole1 + 1; k < nums.Length; ++k)
            {
                nums[startHole1++] = nums[k];
            }
            return startHole1;
        }
        public int RemoveDup(int[] nums)
        {
            if(nums.Length<=2) return nums.Length;

            int count = 2;
            for(int i=2;i<nums.Length;++i)
            {
                if (nums[i] == nums[i-2])
                {

                }else
                {
                    nums[count] = nums[i];
                    count++;
                }
            }

            return count; ;
        }
        static void Main(string[] args)
        {
            RemoveDuplicates2 r = new();
            //{
            //    int[] arr = new int[] { 1, 1, 1, 2, 2, 3 };
            //    var res = r.RemoveDuplicates(arr);
            //    Console.WriteLine(string.Join(",", arr));
            //    Console.WriteLine(res);
            //}
            {
                int[] arr = new int[] { 0, 0, 1, 1, 1, 1, 2, 3, 3 };
                var res = r.RemoveDuplicates(arr);
                Console.WriteLine(string.Join(",", arr));
                Console.WriteLine(res);
            }
            {
                int[] arr = new int[] { 1, 1, 1, 2, 2, 2, 3, 3 };
                var res = r.RemoveDuplicates(arr);
                Console.WriteLine(string.Join(",", arr));
                Console.WriteLine(res);
            }
        }
    }
}
