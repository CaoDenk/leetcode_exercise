using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 1289. 下降路径最小和 II
    /// 困难
    /// 挖坑
    /// </summary>
    internal class MinFallingPathSum_
    {
  
        public int MinFallingPathSum(int[][] grid)
        {

            if(grid.Length==1)
                return grid[0][0];
            
            int[,] dp = new int[grid.Length,4];//minvalue0, minvalue1,minpos0,minpos1
            int len = grid.Length - 1;

            int[,] tmpArr = new int[ 2, grid.Length];
            for(int i=0;i< grid.Length;++i)
            {
                tmpArr[0,i]= grid[0][i];
                tmpArr[1, i] = i;
            }

            SortTwo(tmpArr,len);
            dp[0,0] = tmpArr[0, len];
            dp[0,1] = tmpArr[0, len - 1];
            dp[0,2] = tmpArr[1, len];
            dp[0,3] = tmpArr[1, len - 1];
            
            int disArrLen = 2 * len;
            for (int i=1; i<=len;++i)
            {
                int[,] disArr = new int[2,disArrLen]; //[0,i] =>value  ,[1,i]=>pos
                int count = 0;
                for(int j=0;j<=len;++j)
                {
                    if (dp[i-1,2] == j)
                        continue;
                    disArr[0,count] = dp[i - 1,0]+grid[i][j];
                    disArr[1,count] = j;
                    ++count;
                }
                for (int j = 0; j <= len; ++j)
                {
                    if (dp[i-1,3] == j)
                        continue;             
                    disArr[0, count] = dp[i-1,1] + grid[i][j];
                    disArr[1, count] = j;
                    ++count;
                }

                int sortLen = disArrLen - 1;
                SortTwo(disArr,sortLen);
                int pos1 = disArr[1, sortLen];
                dp[i, 0] = disArr[0, disArrLen - 1];
                dp[i, 2] = pos1;
                int pos2 = disArr[1, disArrLen - 2];
                
                if(pos1 == pos2)
                {
                    sortLen -= 2;
                    do
                    {
                        --sortLen;
                        MinHeapfy(disArr, 0, sortLen);
                        (disArr[0, sortLen], disArr[0, 0]) = (disArr[0, 0], disArr[0, sortLen]);//交换值
                        (disArr[1, sortLen], disArr[1, 0]) = (disArr[1, 0], disArr[1, sortLen]);//交换坐标
                        pos2 = disArr[1, sortLen];
                    }while(pos2 == pos1);
                    dp[i,1]= disArr[0, sortLen];
                }
                else
                {
                    dp[i, 1] = disArr[0, disArrLen - 2];
                }
                dp[i, 3] = pos2;
            }
            return dp[grid.Length-1,0];
        }

        void BuildMinHeap(int[,] nums, int len)
        {
            for (int i = len / 2; i >= 0; --i)
            {
                MinHeapfy(nums, i, len);
            }
        }

        void SortTwo(int[,] nums,int len)
        {
            BuildMinHeap(nums, len);
            (nums[0,len], nums[0,0]) = (nums[0,0], nums[0,len]);//交换值
            (nums[1,len], nums[1,0]) = (nums[1,0], nums[1,len]);//交换坐标
            MinHeapfy(nums,0, --len);
            (nums[0,len], nums[0,0]) = (nums[0,0], nums[0,len]);//交换值
            (nums[1,len], nums[1,0]) = (nums[1,0], nums[1,len]);//交换坐标
        }
            
        void MinHeapfy(int[,] nums, int i, int len)
        {
            while ((i << 1) + 1 <= len)
            {
                int min = i;
                int lson = (i << 1) + 1;
                int rson = (i << 1) + 2;
                if (lson <= len && nums[0,lson] < nums[0,i])
                {
                    min = lson;
                }
                if (rson <= len && nums[0,rson] < nums[0,min])
                {
                    min = rson;
                }
                if (min != i)
                {
                    (nums[0, min], nums[0,i]) = (nums[0,i], nums[0, min]);
                    (nums[1, min], nums[1,i]) = (nums[1,i], nums[1, min]);
                    i = min;
                }
                else break;

            }
        }

        static void Main(string[] args)
        {
            MinFallingPathSum_ m = new();
            {
                int[][] grid = [[1, 2, 3], [4, 5, 6], [7, 8, 9]];
                Console.WriteLine(m.MinFallingPathSum(grid));
            }
            {
                int[][] grid = [[1, 99, 99], [0, 2, 1], [99, 99, 4]];
                Console.WriteLine(m.MinFallingPathSum(grid));
            }
            {//[[-37,51,-36,34,-22],[82,4,30,14,38],[-68,-52,-92,65,-85],[-49,-3,-77,8,-19],[-60,-71,-21,-62,-73]]
                int[][] grid =
                [
                    [-37, 51, -36, 34, -22],
                    [82, 4, 30, 14, 38],
                    [-68, -52, -92, 65, -85],
                    [-49, -3, -77, 8, -19],
                    [-60, -71, -21, -62, -73],
                ];
                Console.WriteLine(m.MinFallingPathSum(grid));
            }

        }




    }
}
