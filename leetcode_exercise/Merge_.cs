using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 56. 合并区间
    /// 挖坑
    /// </summary>
    internal class Merge_
    {
        public int[][] Merge(int[][] intervals)
        {
           
            
            return null;
        }
        

        /// <summary>
        /// 得需要一个自动扩容排序的容器。
        /// </summary>
        class Result
        {
            List<int[]> list = new();


            int min = 0;
            int max = 0;
            
            public void Add(int[] num)
            {
                if(list.Count==0)
                {
                    list.Add(num);
                    min = num[0];
                    max= num[1];
                }else
                {
                    if (num[1] < min )
                    {
                        list.Add(num);
                        min = num[0];
                    }else if (num[0]>max)
                    {
                        list.Add(num);
                        max = num[1];
                    }else
                    {
                        //合并 这样合并必定效率低下  n个数需要U(n^2) 时间复杂度,万一链式反应
                        //思考，如果使用
                    }


                }
            }

        }
    }
}
