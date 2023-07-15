using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 提高速度
    ///  93. 复原 IP 地址
    /// </summary>
    internal class _RestoreIpAddresses2
    {
        Dictionary<int, List<int[]>> dict = new Dictionary<int, List<int[]>>{ {4,new List<int[]>(){
         new int[]{1,1,2,1,3,1},
 }},
 {5,new List<int[]>(){
         new int[]{1,1,2,1,3,2},
         new int[]{1,1,2,2,4,1},
         new int[]{1,2,3,1,4,1},
         new int[]{2,1,3,1,4,1},
 }},
 {6,new List<int[]>(){
         new int[]{1,1,2,1,3,3},
         new int[]{1,1,2,2,4,2},
         new int[]{1,1,2,3,5,1},
         new int[]{1,2,3,1,4,2},
         new int[]{1,2,3,2,5,1},
         new int[]{1,3,4,1,5,1},
         new int[]{2,1,3,1,4,2},
         new int[]{2,1,3,2,5,1},
         new int[]{2,2,4,1,5,1},
         new int[]{3,1,4,1,5,1},
 }},
 {7,new List<int[]>(){
         new int[]{1,1,2,2,4,3},
         new int[]{1,1,2,3,5,2},
         new int[]{1,2,3,1,4,3},
         new int[]{1,2,3,2,5,2},
         new int[]{1,2,3,3,6,1},
         new int[]{1,3,4,1,5,2},
         new int[]{1,3,4,2,6,1},
         new int[]{2,1,3,1,4,3},
         new int[]{2,1,3,2,5,2},
         new int[]{2,1,3,3,6,1},
         new int[]{2,2,4,1,5,2},
         new int[]{2,2,4,2,6,1},
         new int[]{2,3,5,1,6,1},
         new int[]{3,1,4,1,5,2},
         new int[]{3,1,4,2,6,1},
         new int[]{3,2,5,1,6,1},
 }},
 {8,new List<int[]>(){
         new int[]{1,1,2,3,5,3},
         new int[]{1,2,3,2,5,3},
         new int[]{1,2,3,3,6,2},
         new int[]{1,3,4,1,5,3},
         new int[]{1,3,4,2,6,2},
         new int[]{1,3,4,3,7,1},
         new int[]{2,1,3,2,5,3},
         new int[]{2,1,3,3,6,2},
         new int[]{2,2,4,1,5,3},
         new int[]{2,2,4,2,6,2},
         new int[]{2,2,4,3,7,1},
         new int[]{2,3,5,1,6,2},
         new int[]{2,3,5,2,7,1},
         new int[]{3,1,4,1,5,3},
         new int[]{3,1,4,2,6,2},
         new int[]{3,1,4,3,7,1},
         new int[]{3,2,5,1,6,2},
         new int[]{3,2,5,2,7,1},
         new int[]{3,3,6,1,7,1},
 }},
 {9,new List<int[]>(){
         new int[]{1,2,3,3,6,3},
         new int[]{1,3,4,2,6,3},
         new int[]{1,3,4,3,7,2},
         new int[]{2,1,3,3,6,3},
         new int[]{2,2,4,2,6,3},
         new int[]{2,2,4,3,7,2},
         new int[]{2,3,5,1,6,3},
         new int[]{2,3,5,2,7,2},
         new int[]{2,3,5,3,8,1},
         new int[]{3,1,4,2,6,3},
         new int[]{3,1,4,3,7,2},
         new int[]{3,2,5,1,6,3},
         new int[]{3,2,5,2,7,2},
         new int[]{3,2,5,3,8,1},
         new int[]{3,3,6,1,7,2},
         new int[]{3,3,6,2,8,1},
 }},
 {10,new List<int[]>(){
         new int[]{1,3,4,3,7,3},
         new int[]{2,2,4,3,7,3},
         new int[]{2,3,5,2,7,3},
         new int[]{2,3,5,3,8,2},
         new int[]{3,1,4,3,7,3},
         new int[]{3,2,5,2,7,3},
         new int[]{3,2,5,3,8,2},
         new int[]{3,3,6,1,7,3},
         new int[]{3,3,6,2,8,2},
         new int[]{3,3,6,3,9,1},
 }},
 {11,new List<int[]>(){
         new int[]{2,3,5,3,8,3},
         new int[]{3,2,5,3,8,3},
         new int[]{3,3,6,2,8,3},
         new int[]{3,3,6,3,9,2},
 }},
 {12,new List<int[]>(){
         new int[]{3,3,6,3,9,3},
 }},
};


    public IList<string> RestoreIpAddresses(string s)
        {         
            List<string> ipaddr = new List<string>();
            if (s.Length < 4||s.Length>12)
                return ipaddr;
            var possibleLen = dict[s.Length];
            foreach (var len in possibleLen)
            {
                var strs = Valid(len, s);
                if (strs.Item1)
                {
                    ipaddr.Add(string.Join(".", strs.Item2.AsEnumerable()));
                }
            }
            return ipaddr;
        }

 

        (bool,string[]?) Valid(int[] len, string str)
        {
            string[] chars = new string[4];
            //chars[0] = str.Substring(0,len[0]);
            if ((len[0]>1&& str[0] == '0') || int.Parse((chars[0] = str.Substring(0, len[0]))) > 255)
                return (false, null);
            if ((len[1]>1 &&str[len[0]] == '0') || int.Parse((chars[1] = str.Substring(len[0], len[1]))) > 255)
                return (false, null);
            if ((len[3]>1&& str[len[2]] == '0') || int.Parse((chars[2] = str.Substring(len[2], len[3]))) > 255)
                return (false, null);
            if ((len[5]>1 &&str[len[4]] == '0') || int.Parse((chars[3] = str.Substring(len[4], len[5]))) > 255)
                return (false, null);
            return (true, chars);
            
        }
   


        static void Main(string[] args)
        {
            {
                _RestoreIpAddresses2 r = new();
                var ret = r.RestoreIpAddresses("25525511135");
                foreach (var i in ret)
                {
                    Console.WriteLine(i);
                }
            }
            {
                _RestoreIpAddresses2 r = new();
                var ret = r.RestoreIpAddresses("0000");
                foreach (var i in ret)
                {
                    Console.WriteLine(i);
                }
                //Console.WriteLine("end");
            }
        }
    }
}
