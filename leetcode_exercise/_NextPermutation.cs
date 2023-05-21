using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _NextPermutation
    {

        public void NextPermutation(int[] nums)
        {
            int len=nums.Length;

            for(int i=nums.Length-2; i>=0; i--)
            {
                //int[] t = nums[i..len];
                (bool ret,int index)=FindBigRight(nums, i);
                if(ret)
                {
                    (nums[i], nums[index]) = (nums[index], nums[i]);
                    int idex = i + 1;
                    int leng = nums.Length - idex;
                    //Span<int> ints = new Span<int>(nums,index+1,len);
                    Array.Sort(nums, idex,leng);

                    return;
                }
                
            }
            Array.Sort(nums);   
            
        }



        (bool, int) FindBigRight(int[] nums, int start)
        {
            bool ret = false;
            int mark = 0;
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
            return (ret, mark);
        }


        static void Main()
        {
            _NextPermutation n = new();
            {
                int[] nums = { 1, 2, 3 };
                n.NextPermutation(nums);
                Console.WriteLine(string.Join(",", nums.Select(x => x.ToString()).ToArray()));
            }
            {
                int[] nums = { 1, 3,2 };
                n.NextPermutation(nums);
                Console.WriteLine(string.Join(",", nums.Select(x => x.ToString()).ToArray()));
            }
        }
    }
}
