using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class Permute
    {
        public void NextPermutation(int[] nums)
        {
            //int len = nums.Length;

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                //int[] t = nums[i..len];
                (bool ret, int index) = FindBigRight(nums, i);
                if (ret)
                {
                    (nums[i], nums[index]) = (nums[index], nums[i]);
                    int idex = i + 1;
                    int leng = nums.Length - idex;
                    //Span<int> ints = new Span<int>(nums,index+1,len);
                    Array.Sort(nums, idex, leng);

                    return;
                }

            }
            Array.Sort(nums);

        }



        (bool, int) FindBigRight(int[] nums, int start)
        {
            bool ret = false;
            int mark = 0;
            for (int i = start + 1; i < nums.Length; ++i)
            {
                if (nums[i] > nums[start])
                {
                    if (ret)
                    {
                        if (nums[i] < nums[mark])
                            mark = i;

                    }
                    else
                    {
                        ret = true;
                        mark = i;
                    }

                }

            }
            return (ret, mark);
        }
       
        int fact(int n) {
            int ret = 1;
            while(n>1)
            {
                ret *= n;
                --n;

            }
            return ret;
        
        }
        static void Main()
        {

            Permute p = new();
            {

                int[] nums = { 1, 2, 3, 4,5,6 };
                int size = p.fact(nums.Length);
                HashSet<int[]> set = new HashSet<int[]>
                {
                    (int[])nums.Clone()
                };
                for (int i = 0; i < size-1; ++i)
                {

                    p.NextPermutation(nums);
                    string s=string.Join(',',nums.Select(x=>x.ToString()).ToArray());
                    Console.WriteLine(s);
                    set.Add((int[])nums.Clone());
                }
                Console.WriteLine(set.Count);

            }

        }

        

    }
}
