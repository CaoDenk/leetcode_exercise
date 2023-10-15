using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 18. 四数之和
    /// </summary>
    internal class _FourSum
    {
        public IList<IList<int>> FourSum(int[] nums, int target)
        {

            HashSet<int[]> ints = new HashSet<int[]>(new MyComparer());
            List<IList<int>> ret = new List<IList<int>>();
            Span<int> span = new Span<int>(nums);

            for (int i = 0; i < nums.Length - 3; ++i)
            {

                try
                {
                    checked
                    {
                        int targ = target - nums[i];
                        for (var j = i + 1; j < nums.Length - 2; ++j)
                        {
                            var res = TwoSum(span.Slice(j + 1), targ - nums[j]);
                            foreach (var x in res)
                            {
                                ints.Add(new int[] { nums[i], nums[j], x[0], x[1] });
                            }
                        }
                    }
                }
                catch (OverflowException)
                {
                    continue;
                }
            }
            foreach (var i in ints)
            {
                ret.Add(i.ToList());
            }

            return ret;
        }
        public List<int[]> TwoSum(Span<int> nums, int target)
        {
            List<int[]> ret = new List<int[]>();
            HashSet<int> set = new();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (set.Contains(target - nums[i]))
                {
                    ret.Add(new int[] { nums[i], target - nums[i] });
                }
                else
                {
                    set.Add(nums[i]);
                }

            }
            return ret;
        }
    


        static void Main(string[] args)
        {
            //{
            //    _FourSum f = new();
            //    var res = f.FourSum(new int[] { 2, 2, 2, 2, 2 }, 8);
            //    foreach (var x in res)
            //    {
            //        Console.WriteLine(string.Join(",", x));
            //    }
            //}
            //{
            //    _FourSum f = new();
            //    var res = f.FourSum(new int[] { 0, 1, 5, -2, 2 }, 6);
            //    foreach (var x in res)
            //    {
            //        Console.WriteLine(string.Join(",", x));
            //    }
            //}
            {
                _FourSum f = new();
                var res = f.FourSum(new int[] { 1000000000, 1000000000, 1000000000, 1000000000 }, -294967296);
                foreach (var x in res)
                {
                    Console.WriteLine(string.Join(",", x));
                }
            }
        }


    }
    class MyComparer : IEqualityComparer<int[]>
    {
        public bool Equals(int[]? x, int[]? y)
        {

            if (x == null && y == null)
                return true;
            if (x == null || y == null)
                return false;
            //Array.Sort(x);
            //Array.Sort(y);
            //return x[0] == y[0] && x[1] == y[1] && x[2] == y[2] && x[3] == y[3];
            return (x[0] ^ x[1] ^ x[2] ^ x[3]) == (y[0] ^ y[1] ^ y[2] ^ y[3]);
        }

        public int GetHashCode([DisallowNull] int[] obj)
        {
            Array.Sort(obj);
            return obj[0].GetHashCode();
        }
    }

}
