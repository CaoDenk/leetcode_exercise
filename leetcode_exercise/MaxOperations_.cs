using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class MaxOperations_
    {
        public int MaxOperations(int[] nums, int k)
        {

            Dictionary<int,int> dict = new(); //(int,int) k- ,pos
            int count = 0;
            
            for(int i = 0;i<nums.Length;++i)
            {
                if (dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }else
                {
                    dict[nums[i]]=1;
                }

                int key = k - nums[i];
                if (dict.ContainsKey(key))
                {

                    if (key == nums[i])
                    {
                        if (dict[key]>=2)
                        {
                            dict[key] -= 2;
                            if (dict[key] == 0)
                            {
                                dict.Remove(key);
                            }
                            ++count;
                        }
                    }
                    else
                    {
                        --dict[key];
                        --dict[nums[i]];
                        if (dict[key] == 0)
                        {
                            dict.Remove(key);
                        }
                        if (dict[nums[i]] == 0)
                        {
                            dict.Remove(nums[i]);
                        }
                        count++;
                    }

              
                }

            }

            return count;

        }
        static void Main(string[] args)
        {
            MaxOperations_ m = new();
            //{
            //    int[] nums = { 1, 2, 3, 4 };
            //    Console.WriteLine(m.MaxOperations(nums, 5));
            //}
            {
                int[] nums = { 3, 1, 3, 4, 3 };
                Console.WriteLine(m.MaxOperations(nums, 6));
            }

            //{
            //    int[] nums = { 2, 5, 4, 4, 1, 3, 4, 4, 1, 4, 4, 1, 2, 1, 2, 2, 3, 2, 4, 2 };
            //    Console.WriteLine(m.MaxOperations(nums, 3));
            //}

        }
    }
}
