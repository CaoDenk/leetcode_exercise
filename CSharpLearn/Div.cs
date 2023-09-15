using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    internal class Div
    {
        public static List<int> GetPrimeFactors(int n)
        {
            List<int> factors = new List<int>();
            int i = 2;

            while (i * i <= n)
            {
                if (n % i == 0)
                {
                    factors.Add(i);
                    n /= i;
                }
                else
                {
                    i++;
                }
            }

            if (n > 1)
            {
                factors.Add(n);
            }

            return factors;
        }

       static bool Can(int n,int m)
        {
            var res = GetPrimeFactors(m);
            List<int> v=new List<int>();
            for (int i = n; i >= 2; --i)
            {
                v.Add(i);
            }
            for (int i = 0; i < v.Count; ++i)
            {
                for (int j = res.Count - 1; j >= 0; --j)
                {
                    if (v[i] != 0 && v[i] % res[j] == 0)
                    {
                        v[i] = v[i] / res[j];
                        res.RemoveAt(j);
                    }
                }

            }

            return res.Count == 0;

        }
        static void Main(string[] args)
        {
            Console.WriteLine(Can(10,81));
        }
    }
}
