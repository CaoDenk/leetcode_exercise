using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 207. 课程表
    /// 挖坑、
    /// 检测能否成为环
    /// </summary>
    internal class CanFinish_
    {
        public bool CanFinish(int numCourses, int[][] prerequisites)
        {

            bool[,] course= new bool[numCourses,numCourses];
            for(int i=0;i<prerequisites.Length;++i)
            {
                //if (course[prerequisites[i][0]])
                //    return false;
                //course[prerequisites[i][0]] = true;
                //course[prerequisites[i][0]] = true;
             

            }
            return true;
        }
        static void Main(string[] args)
        {
            CanFinish_ canFinish_ = new();
            {
                int[][] prerequisites = new int[1][];
                prerequisites[0] = new int[] { 1, 0 };
                Console.WriteLine(canFinish_.CanFinish(2, prerequisites));
            }
            {
                int[][] prerequisites = new int[2][];
                prerequisites[0] = new int[] { 1, 0 };
                prerequisites[1] = new int[] { 0, 1 };
                Console.WriteLine(canFinish_.CanFinish(2, prerequisites));
            }
            {
                int[][] prerequisites = new int[2][];
                prerequisites[0] = new int[] { 2, 1 };
                prerequisites[1] = new int[] { 1, 0 };
                Console.WriteLine(canFinish_.CanFinish(3, prerequisites));
            }
        }
    }
}
