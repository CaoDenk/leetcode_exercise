using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 93. 复原 IP 地址
    /// </summary>
    internal class RestoreIpAddresses_
    {
       
        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> ipaddr = new List<string>();
            if (s.Length < 4 || s.Length > 12)
                return ipaddr;
            var possibleLen = SplitLen(s.Length);
            foreach(var len in possibleLen)
            {
               string[] strs=  ToSplit(len, s);
               if(Valid(strs))
               {
                    ipaddr.Add(string.Join(".", strs));
               }
            }


            return ipaddr;
        }

        List<int[]> SplitLen(int len)
        {
            List<int[]> ret = new List<int[]>();
            int maxI = Math.Min(3, len - 3);
            for (int i = 1; i <= maxI; i++)
            {
                int maxJ = Math.Min(3, len - i - 2);
                for (int j = 1; j <= maxJ; ++j)
                {
                    int maxK = Math.Min(3, len - i - j - 1);
                    for (int k = 1; k <= maxK; ++k)
                    {

                        int m = len - i - j - k;
                        if (m <= 3)
                        {
                            ret.Add(new int[] { i, j, k, m });
                        }

                    }
                }

            }
            return ret;

        }

    
        bool Valid(string[] s)
        {
            foreach (string s1 in s)
            {
                if (s1.Length>1&&s1[0] == '0')
                    return false;
                if(int.Parse(s1)>255)
                    return false;
            }
            return true;
        }

        string[] ToSplit(int[] len, string str)
        {
            string[] ret= new string[4];
            ret[0] = str.Substring(0, len[0]);
            ret[1] = str.Substring(len[0],  len[1]);
            ret[2] = str.Substring(len[0] + len[1], len[2]);
            ret[3] = str.Substring(len[0] + len[1] + len[2], len[3]); ;
            return ret;
        }
        static void Main(string[] args)
        {
           
            //{
            //    _RestoreIpAddresses r = new();
            //    var ret = r.RestoreIpAddresses("25525511135");
            //    foreach(var i in ret)
            //    {
            //        Console.WriteLine(i);
            //    }
            //}
            {
                RestoreIpAddresses_ r = new();
                var ret = r.RestoreIpAddresses("0000");
                foreach (var i in ret)
                {
                    Console.WriteLine(i);
                }
            }

        }
    }
}
