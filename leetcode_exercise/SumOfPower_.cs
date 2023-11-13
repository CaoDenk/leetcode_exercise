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
    /// </summary>
    internal class SumOfPower_
    {
        public int SumOfPower(int[] nums) 
        {
            const int mod = 10_0000_0000 + 7;
            if (nums.Length==1)
                return (int)(BigInteger.Pow(nums[0], 3) % mod);
            Array.Sort(nums);
            long res = nums[^1];
            long lastNum=0;
            long t = (long)nums[^1] * nums[^1]%mod;
            res *= t;
            int i = nums.Length - 2;
            while(true)
            {
                lastNum += t;
                var square = (long)nums[i] * nums[i] ;
                var n= (lastNum +square) % mod* nums[i]%mod ;//在可能取值超出的都取模
                res += n;
                if (i == 0)
                    break;

                t = square;
                lastNum = lastNum % mod * 2;
                --i;
            }

            return (int)(res % mod);
        }
        static void Main(string[] args)
        {
            SumOfPower_ s = new();
            {
                var res = s.SumOfPower([1, 2, 4]);
                Console.WriteLine(res);
            }
            {
                var res = s.SumOfPower([1, 1, 1]);
                Console.WriteLine(res);
            }
            {
                var res = s.SumOfPower([658, 489, 777, 2418, 1893, 130, 2448, 178, 1128, 2149, 1059, 1495, 1166, 608, 2006, 713, 1906, 2108, 680, 1348, 860, 1620, 146, 2447, 1895, 1083, 1465, 2351, 1359, 1187, 906, 533, 1943, 1814, 1808, 2065, 1744, 254, 1988, 1889, 1206]);
                Console.WriteLine(res);
            }
            {
                var res = s.SumOfPower([2342, 1892, 2349, 1217, 2073, 73, 813, 68, 1569, 1041, 1912, 43, 838, 1315, 2290, 18, 2283, 2374, 1815, 1433, 544, 505, 1881, 1876, 293, 160, 1327, 408, 1913, 2415, 94, 256, 222, 2434, 2103, 1483, 2038, 213, 900, 2218, 212, 514, 955, 1968, 1344, 1409]);
                Console.WriteLine(res);
            }
        }
    }
}
