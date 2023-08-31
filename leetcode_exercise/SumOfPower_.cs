using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2681. 英雄的力量
    /// 暂时没有思路
    /// </summary>
    internal class SumOfPower_
    {
        public int SumOfPower(int[] nums)
        {
            Array.Sort(nums);
            long[] square = new long[nums.Length];
            square[0] = (long)nums[0]* nums[0];
            BigInteger[] col = new BigInteger[nums.Length];
            col[0] = 1;
            col[1] = 1;
            for (int i = 2; i < nums.Length; ++i)
            {
                col[i] = col[i - 1] * 2;
            }
            for (int i = 1; i < nums.Length; ++i)
            {
                if (nums[i] == nums[i - 1])
                {
                    square[i] = square[i - 1];
                }
                else
                {
                    square[i] = (long)nums[i]*nums[i];
                }
            }
            //Console.WriteLine(string.Join(",", col));
            BigInteger res = new();
            BigInteger latNumI = BigInteger.One;
            for (int i = 0; i < nums.Length; ++i)
            {

                if (i > 0 && nums[i] == nums[i-1])
                {
                    latNumI /= 2;
                    res += latNumI;
                    //Console.WriteLine($"49 lastnumI {latNumI},res={res}");
                    continue;
                }
                latNumI = BigInteger.Zero;
                BigInteger latNum = BigInteger.Zero;
                for (int j = i; j < nums.Length; ++j)
                {
                    if (j > i && nums[j] == nums[j-1])
                    {
                        int mark = j;
                        do
                        {
                            ++mark;
                        }
                        while (mark<nums.Length && nums[mark] == nums[mark - 1]);
                        latNum *= col[mark - j];
                        latNumI += latNum;
                        j = mark -1;
                    }
                    else
                    {
                        latNum =nums[i] * square[j] * col[j - i];
                        latNumI += latNum  ;
                    }
                    //Console.WriteLine(res);
                    //Console.WriteLine($"lastnum {latNum},res={res}");
                }
                //Console.WriteLine($"69 lastnumI {latNumI},res={res}");
                res += latNumI;
            }
            return (int)(res % (10_0000_0000 + 7));
        }
        static void Main(string[] args)
        {
            SumOfPower_ s = new();
            {
                var res = s.SumOfPower(new int[] { 1, 2, 4 });
                Console.WriteLine(res);
            }
            {
                var res = s.SumOfPower(new int[] { 1,1,1 });
                Console.WriteLine(res);
            }
            //{
            //    var res = s.SumOfPower(new int[] { 625006, 846432, 764290, 653039 });
            //    Console.WriteLine(res);
            //}
        }
    }
}
