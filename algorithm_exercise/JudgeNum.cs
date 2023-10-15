using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    enum Operator
    {
        Add=0,
        Min,
        Mul,
        Div
    }

    internal class JudgeNum
    {
        bool Judge(List<double>  nums,int target)
        {
            if(nums.Count==1) return Math.Abs(nums[0] - target) <= 10e-6;
            for(int i=0;i<nums.Count-1;++i)
            {
                double d1 = nums[i];
                double d2 = nums[i + 1];
                for (int j=0;j<4;++j)
                {
                    Operator op = (Operator)j;
                    List<double> t = nums.ToList();
                    double n = op switch
                    {
                        Operator.Add => d1 + d2,
                        Operator.Min => d1 - d2,
                        Operator.Mul => d1 * d2,
                        Operator.Div => d1 / d2,
                    }; 
                    t[i] = n;
                    t.RemoveAt(i + 1);
                    if (Judge(t, target))
                        return true;
                }
            }
            return false;
        }
        bool Judge(List<int> nums,int target)
        {
            List<double> doubles = (from i in nums select  (double)i).ToList() ;
            return Judge(doubles, target);
        }
       public bool StartJudge(int[] nums,int target)
       {
            var res = Permutation.Permute(nums);
            foreach (var item in res)
            {
                if (Judge(item, 24)) return true;
            }
            return false;
        }


        static void Main(string[] args)
        {
            JudgeNum j = new();
            {
                int[] arr = [2, 2, 2,3, 4];
                Console.WriteLine(j.StartJudge(arr,24));
            }
            {
                int[] arr = [1,2,3,8];
                Console.WriteLine(j.StartJudge(arr, 24));
            }
            {
                int[] arr = [1,1,1,1];
                Console.WriteLine(j.StartJudge(arr, 5));
            }
            {
                int[] arr = [5,5,5,5];
                Console.WriteLine(j.StartJudge(arr, 24));
            }
        }

    }
}
