using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class PopStackOrder
    {
        static void Order<T>(List<T> s1, List<T> s2, List<T> s3)
        {
            if (s1.Count == 0 && s2.Count == 0)
            {
                Console.WriteLine(string.Join(",",s3));
                return;
            }
            if (s1.Count > 0)
            {
                var _s1=s1.ToList();
                var c = _s1[^1];
                _s1.RemoveAt(_s1.Count - 1);
                var _s2=s2.ToList();
                _s2.Add(c);
                Order(_s1,_s2, s3);
            }
            if (s2.Count > 0)
            {
                var _s2=s2.ToList();
                var c = _s2[^1];
                _s2.RemoveAt(_s2.Count - 1);
                var _s3=s3.ToList();
                _s3.Add(c);
                Order(s1,_s2, _s3);
            }
        }
        static void Order(string s1, string s2, string s3)
        {
            if (s1.Length == 0 && s2.Length == 0)
            {
                Console.WriteLine(s3.ToString());
            }
            if (s1.Length > 0)
            {
                char c = s1[^1];
                Order(s1.Remove(s1.Length - 1), s2 + c, s3);
            }
            if (s2.Length > 0)
            {
                char c = s2[^1];
                Order(s1, s2.Remove(s2.Length - 1), s3 + c);
            }
        }
        static void Main(string[] args)
        {
            //Order("abce", "", "");
            Order<int>([1, 2, 3, 4], [], []);
        }
    }
}
