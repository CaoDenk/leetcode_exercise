using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _FourSum2
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            Array.Sort(nums);
            List<IList<int>> ans=new List<IList<int>>();
            for (int i=0; i<nums.Length-3;++i)
            {
                if (i > 0 && nums[i] == nums[i - 1])
                    continue;
                for(int j=i+1; j<nums.Length-2;++j)
                {
                    if (j > i+1 && nums[j] == nums[j - 1])
                        continue;
                    int sum = nums[i]+nums[j];
                    int targ=target-sum;
                    int k = j + 1;
                    int q = nums.Length - 1;
                    while(k<q)
                    {

                        
                        if (nums[k] + nums[q] < targ)
                        {
                            k++;
                        }
                        else if (nums[k] + nums[q] > targ)
                        {
                            q--;
                        }
                        else
                        {
                            if ((long)nums[i] + nums[j] + nums[k] + nums[q]>int.MaxValue)
                            {
                               
                            }else
                                ans.Add(new List<int>() { nums[i], nums[j], nums[k], nums[q] });

                            while (k < q && nums[k] == nums[k + 1])
                                k++;
                            while (k < q && nums[q] == nums[q - 1])
                                q--;
                            ++k;
                            --q;

                        }
                    }

                }
            }
            return ans;
        }

        static void Main(string[] args)
        {
            _FourSum2 f = new();
            var ret= f.FourSum(new int[] { -1000000000, -1000000000, 1000000000, -1000000000, -1000000000 }, 294967296);
            foreach( var i in ret )
            {
                Console.WriteLine(string.Join(",",i));
            }
        }
    }
}
