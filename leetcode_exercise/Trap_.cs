using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class Trap_
    {
        /// <summary>
        /// 假设左边低，右边高
        /// 填谷
        /// </summary>
        /// <param name="height"></param>
        /// <returns></returns>
        public int Trap(int[] height)
        {
            int[] arrHeight=new int[height.Length];
            FindMax(height, 1, height.Length, arrHeight);
            int left = 0;
            int[] newHeight= new int[height.Length];
            int diff = 0;
            //int k = 1;
            //newHeight[^1] = height[^1];
            for(int i=0;i<height.Length-1;++i)
            {
                
                if (height[i] < arrHeight[i])
                {
                    left = Math.Max(left, height[i]);
                    newHeight[i] =left;
                    diff += left - height[i]; 
                }else
                {               
                    
            
                    newHeight[i] =height[i];
                    left = arrHeight[i];
                       
                     
                }
               
            }


            Console.WriteLine(string.Join(",", height));
            Console.WriteLine(string.Join(",", newHeight));
            return diff;

        }
        /// <summary>
        /// 包含start 不包含end
        /// </summary>
        /// <param name="num"></param>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        void FindMax(int[] num,int start,int end, int[] ret)
        {
            if(end-start<=1) return;
       
            //if(end-start==2)
            //{
            //    ret[start] = num[start + 1];
              
            //}
            int maxpos = start;
            int max = num[start];
 
            for(int i=start+1;i<end;i++)
            {
                if (num[i] > max)
                {
                    maxpos= i;
                    max = num[i];
                }
            }
            Array.Fill(ret, max, start-1, maxpos - start+1);
            //FindMax(num, start, maxpos, ret);
            FindMax(num, maxpos+1, end, ret);

        }
        static void Main(string[] args)
        {
            {

                var arr = new int[] { 4, 2, 3 };
                var ret = new int[arr.Length];
                var t = new Trap_();
                t.FindMax(arr, 1, arr.Length, ret);
                Console.WriteLine(string.Join(",", ret));
            }
            {
                var arr = new int[] { 2, 0, 2 };
                var ret = new int[arr.Length];
                var t = new Trap_();
                t.FindMax(arr, 1, arr.Length, ret);
                Console.WriteLine(string.Join(",", ret));
            }
        
            //Test();

        }

        static void Test()
        {
            Trap_ t = new();
            //{
            //   var ret= t.Trap(new int[] { 4, 2, 0, 3, 2, 5 });
            //    Console.WriteLine(ret);
            //}
            //{
            //    var ret = t.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 });
            //    Console.WriteLine(ret);
            //}
            //{
            //    var ret = t.Trap(new int[] { 5, 4, 1, 2 });
            //    Console.WriteLine(ret);
            //}
            //{
            //    var ret = t.Trap(new int[] { 6, 4, 2, 0, 3, 2, 0, 3, 1, 4, 5, 3, 2, 7, 5, 3, 0, 1, 2, 1, 3, 4, 6, 8, 1, 3 });
            //    Console.WriteLine(ret);
            //}

            {
                var ret = t.Trap(new int[] { 4, 2, 3 });
                Console.WriteLine(ret);
            }

        }
    }
}
