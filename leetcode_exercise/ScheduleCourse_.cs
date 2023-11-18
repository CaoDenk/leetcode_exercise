using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 630. 课程表 III
    /// </summary>
    internal class ScheduleCourse_
    {
        public int ScheduleCourse(int[][] courses)
        {
            Array.Sort(courses, (o1, o2) => o1[1] - o2[1]);
            PriorityQueue<int, int> priorityQueue = new( Comparer<int>.Create((o1,o2)=>o2.CompareTo(o1)));
            int total = 0;
            foreach(var item in courses)
            {
                if (total + item[0] <= item[1])
                {
                    total += item[0];
                    priorityQueue.Enqueue(item[0], item[0]);
                }else if (priorityQueue.Count > 0 && priorityQueue.Peek() > item[0]) //为啥直接装了？
                {
                    total -= total - priorityQueue.Dequeue() + item[0];
                    if (total < item[1])
                    priorityQueue.Enqueue(item[0], item[0]);
                    
                }
            }
            return priorityQueue.Count;
        }


        static void Main(string[] args)
        {
            ScheduleCourse_ s = new();
            {//[[100,200],[200,1300],[1000,1250],[2000,3200]]
                int[][] courses =
                [
                    [100, 200],
                    [200, 1300],
                    [1000, 1250],
                    [2000, 3200],
                ];
                int res = s.ScheduleCourse(courses);
                Console.WriteLine(res);
            }
            //{
            //    int[][] courses = new int[10][];
            //    courses[0] = new int[2] { 7, 16 };
            //    courses[1] = new int[2] { 2, 3 };
            //    courses[2] = new int[2] { 3, 12 };
            //    courses[3] = new int[2] { 3, 14 };
            //    courses[4] = new int[2] { 10, 19 };
            //    courses[5] = new int[2] { 10, 16 };
            //    courses[6] = new int[2] { 6, 8 };
            //    courses[7] = new int[2] { 6, 11 };
            //    courses[8] = new int[2] { 3, 13 };
            //    courses[9] = new int[2] { 6, 16 };

            //    int res = s.ScheduleCourse(courses);
            //    Console.WriteLine(res);
            //}
            //{
            //    int[][] courses = new int[8][];
            //    courses[0] = new int[2] { 5, 15 };
            //    courses[1] = new int[2] { 3, 19 };
            //    courses[2] = new int[2] { 6, 7 };
            //    courses[3] = new int[2] { 2, 10 };
            //    courses[4] = new int[2] { 5, 16 };
            //    courses[5] = new int[2] { 8, 14 };
            //    courses[6] = new int[2] { 10, 11 };
            //    courses[7] = new int[2] { 2, 19 };
            //    int res = s.ScheduleCourse(courses);
            //    Console.WriteLine(res);
            //}
            //{
            //    int[][] courses = new int[3][];
            //    courses[0] = new int[2] { 5, 5 };
            //    courses[1] = new int[2] { 4, 6 };
            //    courses[2] = new int[2] { 2, 6 };
            //    int res = s.ScheduleCourse(courses);
            //    Console.WriteLine(res);
            //}
            //{
            //    int[][] courses = new int[7][];
            //    courses[0] = new int[2] { 7, 17 };
            //    courses[1] = new int[2] { 3, 12 };
            //    courses[2] = new int[2] { 10, 20 };
            //    courses[3] = new int[2] { 9, 10 };
            //    courses[4] = new int[2] { 5, 20 };
            //    courses[5] = new int[2] { 10, 19 };
            //    courses[6] = new int[2] { 4, 18 };
            //    int res = s.ScheduleCourse(courses);
            //    Console.WriteLine(res);
            //}
        }

       
    }
}
