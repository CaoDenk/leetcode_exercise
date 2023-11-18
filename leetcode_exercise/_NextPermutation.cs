using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 31. 下一个排列
    /// </summary>
    internal class _NextPermutation
    {

        public void NextPermutation(int[] nums)
        {

            for(int i=nums.Length-2; i>=0; i--)
            {
                int index=FindBigRight(nums, i);
                if(index>=0)
                {
                    (nums[i], nums[index]) = (nums[index], nums[i]);
                    int idex = i + 1;
                    int leng = nums.Length - idex;
                    Array.Sort(nums, idex,leng);
                    return;
                }
            }
            Array.Sort(nums);              
        }

        int FindBigRight(int[] nums, int start)
        {
            bool ret = false;
            int mark = -1;
            for (int i = start + 1; i < nums.Length ; ++i)
            {
                if (nums[i] > nums[start])
                {
                    if(ret)
                    {
                        if (nums[i] < nums[mark])
                            mark = i;

                    }else
                    {
                        ret = true;
                        mark = i;
                    }
                }                 
            }
            return mark;
        }


        static void Main()
        {
            _NextPermutation n = new();
            {
                int[] nums = [1, 2, 3];
                n.NextPermutation(nums);
                Console.WriteLine(string.Join(",", nums.Select(x => x.ToString()).ToArray()));
            }
            {
                int[] nums = [1, 3,2];
                n.NextPermutation(nums);
                Console.WriteLine(string.Join(",", nums.Select(x => x.ToString()).ToArray()));
            }
        }
    }
}
