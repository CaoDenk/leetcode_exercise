using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 125. 验证回文串
    /// </summary>
    internal class IsPalindrome__
    {
        public bool IsPalindrome(string s)
        {
            var l=s.Select(x => char.ToLower(x)).Where(x => char.IsLetterOrDigit(x)).ToList();
            if (l.Count <= 1)
                return true;

            char[] arr= l.ToArray();
            l.Reverse();
            for(int i=0;i<arr.Length;++i)
            {
                if(arr[i] != l[i]) return false;
            }
            return true;
        }


    }
}
