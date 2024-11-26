using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 605. 种花问题
    /// </summary>
    internal class CanPlaceFlowers_
    {
        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0) return true;
            if (flowerbed.Length == 1)
            {
                if (flowerbed[0] == 0)
                {
                    return n == 1;
                }
                else
                    return false;
            }
            else if (flowerbed.Length == 2)
            {
                if (n == 1)return flowerbed[0] == 0 && flowerbed[1] == 0;
                else return false;
            }
            else
            {
                if (flowerbed[0] != 1 && flowerbed[1] == 0)
                {
                    if (n == 1) return true;
                    --n;
                    flowerbed[0] = 1;
                }
                return Dfs(flowerbed, n, 2);
            }

        }
        bool Dfs(int[] flowerbed, int n, int start)
        {
            for (int i = start; i < flowerbed.Length - 1; ++i)
            {
                if (flowerbed[i - 1] == 0 && flowerbed[i] == 0 && flowerbed[i + 1] == 0)
                {
                    flowerbed[i] = 1;
                    if (n == 1)
                        return true;
                    return Dfs(flowerbed, --n, i + 2);
                }
            }
            if (n == 1 && flowerbed[^1] == 0 && flowerbed[^2] == 0)
            {
                return true;
            }
            return false;
        }
        static void Main(string[] args)
        {
            CanPlaceFlowers_ c = new();
            {
                int[] flowered = [1, 0, 0, 0, 1];
                Console.WriteLine(c.CanPlaceFlowers(flowered, 2) == false);
            }
            {
                int[] flowered = [1, 0, 1, 0, 1, 0, 1];
                Console.WriteLine(c.CanPlaceFlowers(flowered, 2) == false);
            }
            {
                int[] flowered = [1, 0, 1, 0, 1, 0, 1];
                Console.WriteLine(c.CanPlaceFlowers(flowered, 0) == true);
            }
            {
                int[] flowered = [0, 0, 1, 0, 1];
                Console.WriteLine(c.CanPlaceFlowers(flowered, 1) == true);
            }
            {
                int[] flowered = [1];
                Console.WriteLine(c.CanPlaceFlowers(flowered, 1) == false);
            }
            {
                int[] flowered = [1, 0];
                Console.WriteLine(c.CanPlaceFlowers(flowered, 1) == false);
            }
            {
                int[] flowered = [0,1, 0];
                Console.WriteLine(c.CanPlaceFlowers(flowered, 1) == false);
            }
        }
    }
}
