using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 131. 分割回文串
    /// 挖坑，坑还挺多
    /// 留给明天
    /// </summary>
    internal class Partition_
    {
        public IList<IList<string>> Partition(string s)
        {
            //i和j都包含
            List<IList<string>> ans=new();
            List<string> l=new();
            StringBuilder sb = new();
            int start=0;
            for (int i=0;i<s.Length;++i)
            {
                for(int j=i;j<s.Length;++j)
                {
                    if(j==i)
                    {

                    }

                }

            }


            return null;
        }


        void Recursive(List<IList<string>> ans,List<string> l,string s,StringBuilder sb,int start) 
        {
            if(start>=s.Length)
            {
                ans.Add(l.ToList());
            }


            for (int i = start+1; i < s.Length; ++i)
            {

            }

        }



    }
}
