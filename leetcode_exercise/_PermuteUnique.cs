using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 47. 全排列 II
    /// </summary>
    internal class _PermuteUnique
    {
        public IList<IList<int>> PermuteUnique(int[] nums)
        {   
           
            IList<IList<int>> list = new List<IList<int>>();
            if (nums.Length == 1)
            {
                list.Add(nums.ToList());
                return list;
            }
            Array.Sort(nums);
            Qn(nums, 0, nums.Length - 1, list);
            return list;
        }

        static void Q2(int[] arr, int l, int r, IList<IList<int>> list)
        {

            AddList(arr, list);
            Swap(ref arr[l], ref arr[r]);
            AddList(arr, list);
            Swap(ref arr[l], ref arr[r]);
        }

        static void Swap(ref int i, ref int j)
        {
            (j, i) = (i, j);
        }
        private static void AddList(int[] arr, IList<IList<int>> list)
        {
            List<int> l = arr.ToList();
            list.Add(l);
        }

        void Qn(int[] arr, int l, int r, IList<IList<int>> list)
        {
            if (r - l > 1)
            {
      
                Qn(arr, l + 1, r, list);
                for (int i = l + 1; i <= r; ++i)
                {


                    Swap(ref arr[l], ref arr[i]);                
                    Qn(arr, l + 1, r, list);
                    Swap(ref arr[l], ref arr[i]);
                }

            }
            else
            {
                Q2(arr, l, r, list);

            }

        }

        static void Print( IList<IList<int>> list)
        {
            foreach (var i in list)
            {
                foreach(var  j in i)
                {
                    Console.Write($"{j},");
                }
                Console.WriteLine();
            }
      

        }
        static void Main()
        {
            _PermuteUnique _Permute = new();
            //{
            //    int[] arr =new int[] { -1, 2, -1, 2, 1, -1, 2, 1 };
            //    var ret= _Permute.PermuteUnique(arr);
            //    Console.WriteLine(ret.Count);
            //    //_Permute.Print(ret);
                

            //}
            {
                int[] arr = new int[] { 1, 1, 2 };
                var ret = _Permute.PermuteUnique(arr);
                Console.WriteLine(ret.Count);
                Print(ret);
            }
            

        }
    }
}
