using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 2034. 股票价格波动
    /// 错误，，。。
    /// 结果不对
    /// </summary>
    public class StockPrice
    {
        SortedDictionary<int,__Node> stockPrices;
        SortedList<__Node,int> stockPricesList;
        int lastest = 0;
        int current = 0;
        public StockPrice()
        {
            stockPrices = new();
            stockPricesList=new();
        }

        public void Update(int timestamp, int price)
        {
            if (stockPrices.TryGetValue(timestamp, out var node))
            {
                if (timestamp == lastest)
                    current = price;
                stockPricesList.Remove(node);
                node.value = price;
                stockPricesList.Add(node, node.value);
            }
            else
            {
                var n = new __Node() { value = price };
                stockPrices[timestamp] = n;
                if(timestamp> lastest)
                {
                    current = price;
                }
                stockPricesList.Add(n,n.value);
            }
            
            
        }

        public int Current()
        {
            return current;
        }

        public int Maximum()
        {
            return stockPricesList.Last().Value;
        }

        public int Minimum()
        {
            
            return stockPricesList.First().Value;
        }
    }

    class __Node:IComparable<__Node>
    {
        public int value;


        public int CompareTo(__Node y)
        {
            return this.value.CompareTo(y.value);
        }
    }
}
