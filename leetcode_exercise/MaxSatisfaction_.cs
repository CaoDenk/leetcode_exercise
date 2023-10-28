using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1402. 做菜顺序
    /// </summary>
    internal class MaxSatisfaction_
    {
        public int MaxSatisfaction(int[] satisfaction)
        {
            Array.Sort(satisfaction,(o1,o2)=> o2.CompareTo(o1));
            int sum = 0;
            int total = 0;
            for(int i = 0; i < satisfaction.Length;++i)
            {
                total += satisfaction[i];
                if (satisfaction[i] > 0 || total > 0)
                {
                    sum += total;
                }
                else break;
            }
            return sum;
        }
        static void Main(string[] args)
        {
            MaxSatisfaction_ m = new();
            {
                int res = m.MaxSatisfaction([-1, -8, 0, 5, -9]);
                Console.WriteLine(res);
            }
            {
                int res = m.MaxSatisfaction([4, 3, 2]);
                Console.WriteLine(res);
            }
        }
    }
}
