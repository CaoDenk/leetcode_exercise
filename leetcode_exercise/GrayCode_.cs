using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 89. 格雷编码
    /// </summary>
    internal class GrayCode_
    {
        public IList<int> GrayCode(int n)
        {
            if(n==1)
                return new List<int>() { 0,1};
            List<int> list = new List<int>() {0 };
            HashSet<int> visited = new HashSet<int>
            {
                0
            };
            int count=(int)Math.Pow(2, n);
            bool flag=false;
            Recursive(list, visited,n,count,ref flag);
            return list;
        }
        int cnt = 0;
        void Recursive(List<int> l,HashSet<int> r,int n,int count,ref bool flag)
        {

            if(l.Count==count)
            {
                int num = l[0] ^ l[^1];
                if(HammingWeight(num)==1)
                {
                    flag= true;
                    return;
                }
            }
            else
            {
                for (int  i=0; i<n;i++)
                {
                    int num = l[^1];
                    num ^= (1 << i);
                    if (r.Contains(num)||num<0||num>=count)
                    {
                        continue;
                    }
                    else 
                    {
                        l.Add(num);
                        r.Add(num);
                        
                        Recursive(l, r,n, count, ref flag);
                        if (flag)
                            return;
                        else
                        {
                            r.Remove(l[^1]);
                            l.RemoveAt(l.Count - 1);
                        }
                    }
                }

            }

        }
        public int HammingWeight(int n)
        {
            n -= ((n >> 1) & 0x55555555);
            n = (n & 0x33333333) + ((n >> 2) & 0x33333333);
            n = (n + (n >> 4)) & 0x0f0f0f0f;
            n += (n >> 8);
            n += (n >> 16);
            return (n & 0x3f);
        }

        static void Main(string[] args)
        {
            GrayCode_ g = new();
            {
                var res = g.GrayCode(3);
                Console.WriteLine(string.Join(",", res));
            }
            {
                var res = g.GrayCode(4);
                Console.WriteLine(string.Join(",", res));
            }
            {
                var res = g.GrayCode(8);
                Console.WriteLine(string.Join(",", res));
            }
        }

    }
}
