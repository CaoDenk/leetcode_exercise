using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// Combine
    /// </summary>
    internal class Combine_
    {
        public IList<IList<int>> Combine(int n, int k)
        {
            List<IList<int>> ans =new List<IList<int>>();
            List<int> l = new List<int>();
            Recursive(ans,l,1,n,k);
            return ans;
        }
        void Recursive(List<IList<int>> ans,List<int> l,int start,int n,int k) 
        {
            if(l.Count==k)
            {
                ans.Add(l.ToList());
                return;
            }
            for(int i=start;i<=n;++i)
            {
                l.Add(i);
                Recursive(ans,l,i+1,n,k);
                l.RemoveAt(l.Count - 1);
            }
        }
        static void Main(string[] args)
        {
            Combine_ c = new();
            var res=c.Combine(4, 2);
            foreach (var item in res)
            {
                Console.WriteLine(string.Join(",",item));
            }
        }
    }
}
