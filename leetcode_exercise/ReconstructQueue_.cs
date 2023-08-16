using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class ReconstructQueue_
    {
        public int[][] ReconstructQueue(int[][] people)
        {
            List<int[]> peopleList = new() ;
            int i = 1;
            bool flag = false;
            Adjust(peopleList, i-1,people,ref i,ref flag );
            
            return peopleList.Select(x => x[0..2]).ToArray();
        }
        static void Main(string[] args)
        {
            int[][] people = new int[][] { new int[]  { 7, 0 }, new int[] { 4, 4 }, new int[] { 7, 1 }, new int[] { 5, 0 }, new int[] { 6, 1 }, new int[] { 5, 2 } };
            //int[][] people = new int[][] { new int[]  { 7, 0 },  new int[] { 5, 0 } };
            ReconstructQueue_ r=new();
            var ret=r.ReconstructQueue(people);
            foreach(var i in ret)
            {
                Console.Write($"{{{string.Join(",",i)}}}");
            }
            Console.WriteLine();
        }
        #region
        //class MyComparer : IComparer<int[}>
        //{
        //    //int[} Data {  get; set; }
        //    public int Compare(int[] x, int[] y)
        //    {
        //        if (x[1] == y[1])
        //            return x[0] - y[0];
        //        else
        //            return x[1] - y[1];

        //    }
        //}
        #endregion
        void Insert(List<int[]> pls,int pos,int[] person,int higher)
        {
            pls.Insert(pos,new int[] { person[0], person[1],higher });


        }
        void Insert(List<int[]> pls, int pos, int[] person)
        {
            int higher = 0;
            foreach(var i in pls)
            {
                if (i[0] >= person[0])
                {
                    higher++;
                }
            }

            pls.Insert(pos, new int[] { person[0], person[1],higher });


        }



        void Adjust(List<int[]> pls, int idx, int[][] people, ref int i,ref bool flag)
        {
            if(idx<0)
            {
                Insert(pls, 0, people[i], 0);
                ++i;
            }
            if(i==people.Length)
            {
                flag = true;
                return;
            }
            if(flag)
            {
                return;
            }
            while (people[i][0] == pls[idx][0])
            {
                if (people[i][1] > pls[idx][1]) //人数比之前多
                {
                    pls.Insert(idx + 1, people[i]);
                    break;
                }
                ++pls[idx-1][2];
                --idx;
            }
                //先比身高 
            if(people[i][0] > pls[idx][0])//如果比之前身高高
            {
                if (people[i][1] >= pls[idx][1]) //人数比之前多
                {
                    pls.Insert(idx+1, people[i]);
                     
                }else
                {
                    int tryPos = i;

                    if (pls[idx - 1][2] < pls[idx - 1][1])
                    {
                        ++pls[idx - 1][2];//加入往前探索，这时的左边更高数量得加1

                        Adjust(pls, idx - 1, people, ref i, ref flag); //往前探索

                        var backup = pls.ToList();
                        //不确定，
                        if (!flag)//探索失败.回滚
                        {
                            i = tryPos;
                            pls.Clear();
                            pls.AddRange(backup);
                            --pls[idx - 1][2];
                        }
                        
                    }else
                    {


                    }

                   
                }

            }else //比之前矮
            {
                if (people[i][1] <=pls[idx][1]) //人数比之前多
                {
                    pls.Insert(idx+1, people[i]);
                }
                else
                {
                    //不确定
                }
            }


        }
        bool Check(int[][] people)
        {
            if(people[0][1]!=0)
            {
                return false;
            }
            int lastHeight = people[0][0];
            int moreCount = people[0][1];
            Stack<int> stack = new Stack<int>();
            int[,] dp=new int[lastHeight,moreCount];
            PriorityQueue<int, int> queue = new();
            queue.Enqueue(lastHeight,moreCount);


            for(int i=1;i<people.Length; i++)
            {
                if (people[i][0] > people[i - 1][0])
                {

                }
            }

            return true;

        }



    }
}
