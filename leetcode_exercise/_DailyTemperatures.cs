using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 
    /// </summary>
    internal class _DailyTemperatures
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
            int[] res = new int[temperatures.Length];
            for (int i = temperatures.Length - 2; i >= 0; --i)
            {
                for (int j = i + 1; j < temperatures.Length; j += res[j])
                {
                    if (temperatures[j] > temperatures[i])
                    {
                        res[i] = j - i;
                        break;
                    }
                    else if (res[j] == 0)
                    {
                        break;
                    }

                }

            }

            return res;
        }
        static void Main(string[] args)
        {
            Test(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
        }
        static void Test(int[] arr)
        {
            _DailyTemperatures d = new();
            var ret=d.DailyTemperatures(arr);
            Console.WriteLine(string.Join(",",ret));
        }

    }
}
