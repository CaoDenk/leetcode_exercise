using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _Permute
    {
        public IList<IList<int>> Permute(int[] nums)
        {
            IList<IList<int>> list = new List<IList<int>>();
            if(nums.Length==1)
            {
                list.Add(nums.ToList());
                return list;
            }

            qn(nums, 0,nums.Length - 1,list);
            return list;
        }

 
        void q2(int[] arr,int l,int r, IList<IList<int>> list)
        {

            AddList(arr, list);
            Swap(ref arr[l],ref arr[r]);
            AddList(arr, list);
            Swap(ref arr[l], ref arr[r]);
        }

        private void AddList(int[] arr, IList<IList<int>> list)
        {

            List<int> l = arr.ToList();
            list.Add(l);
           
        }
        void   qn(int[] arr, int l, int r, IList<IList<int>> list)
        {
           if(r-l>1)
            {
                qn(arr,l+1,r,list);
                for(int i=l+1;i<=r;++i)
                {
                    Swap(ref arr[l],ref arr[i]);
                    qn(arr, l + 1, r, list);
                    Swap(ref arr[l], ref arr[i]);
                }

            }else
            {
                q2(arr,l,r,list);

            }

        }

        void Swap(ref int i,ref int j)
        {
            (j, i) = (i, j);
        }
        void Print(int[] arr, IList<IList<int>> list)
        {
            foreach (int i in arr)
            {
                Console.Write(i);
            }
            Console.WriteLine();

        }
        static void Main()
        {
            _Permute p = new();
            //p.Perm(new int[] { 1, 2, 3}, 0, 3);
            int[] arr = new int[] { 1, 2, 3,4 };
            //p.qn(arr, 0, 3);


        }

    }
}
