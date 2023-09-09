using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 所有出栈顺序
    /// 挖坑
    /// </summary>
    internal class PopStack
    {
        

        static void  Recursive(Stack<int> stack, List<int> list,int start,List<List<int>> ans,List<int> l)
        {

            if(stack.Count==0)//只能进栈
            {
                if(start < list.Count)
                {
                    stack.Push(list[start]);
                    Recursive(stack, list, start + 1, ans, l);
                    stack.Pop();                   
                }else
                {
                    ans.Add(l.ToList());
                }
            }else if(start==list.Count)//只能出栈
            {
                int count=stack.Count;
                l.AddRange(stack.ToList());
                ans.Add(l.ToList());
                l.RemoveRange(l.Count-count,count);

            }else
            {
                stack.Push(list[start]);
                Recursive(stack, list, start + 1, ans, l);//先进栈
                stack.Pop();

                int v = stack.Pop();
                l.Add(v);
                Recursive(stack, list, start, ans, l);//后出栈
                l.RemoveAt(l.Count-1);
                stack.Push(v);
            }
        }

        static void Main(string[] args)
        {
            List<int> list = new();
            for(int i=0;i<5;++i)
            {
                list.Add(i);
            }
            List<List<int>> ans = new();
            Recursive( new Stack<int>(), list,0,ans,new List<int>());
            //Console.WriteLine(ans.Count);
            foreach (var item in ans)
            {
                Console.WriteLine(string.Join(",",item));
            }
        }




    }
}
