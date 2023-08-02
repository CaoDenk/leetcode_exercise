﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _DailyTemperatures
    {
        public int[] DailyTemperatures(int[] temperatures)
        {

            int[] res = new int[temperatures.Length];
            Stack<(int,int)> stack = new Stack<(int, int)>();
            stack.Push((temperatures[0],0));
            for (int i = 1; i < temperatures.Length ; ++i)
            {
                while (stack.Count>0&&temperatures[i]>stack.Peek().Item1)//如果比之前温度高，说明找到了
                {
                    (_,int day)= stack.Pop();
                    res[day] =i-day;

                }                
                stack.Push((temperatures[i],i));

            }

            return res;
        }
        static void Main(string[] args)
        {
            Test(new int[] { 73, 74, 75, 71, 69, 72, 76, 73 });
        }
        static void Test(int[] arr)
        {
            _DailyTemperatures d = new();
            var ret = d.DailyTemperatures(arr);
            Console.WriteLine(string.Join(",", ret));
        }

    }
}
