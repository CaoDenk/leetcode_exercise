using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    /// <summary>
    /// 所有出栈顺序
    /// </summary>
    internal class PopStack<T> where T:IEquatable<T>
    {


        internal List<List<T>> Dfs(List<T> list)
        {
            List<List<T>> ans = new();
            Dfs(new Stack<T>(),list , 0, ans, new List<T>());
            return ans;
        }
        void  Dfs(Stack<T> stack, List<T> list,int start,List<List<T>> ans,List<T> l)
        {

            if(stack.Count==0)//只能进栈
            {
                if(start < list.Count)
                {
                    stack.Push(list[start]);
                    Dfs(stack, list, start + 1, ans, l);
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
                Dfs(stack, list, start + 1, ans, l);//先进栈
                stack.Pop();

                var v = stack.Pop();
                l.Add(v);
                Dfs(stack, list, start, ans, l);//后出栈
                l.RemoveAt(l.Count-1);
                stack.Push(v);
            }
        }

        public bool Judge(List<List<T>> ans,List<T> arr) 
        {
            for(int i=0;i<ans.Count;++i)
            {
                if (Judge(ans[i],arr))
                    return true;
            }
            return false;
        }
        bool Judge(List<T> sample,List<T> arr)
        {
            return sample.SequenceEqual(arr);
        }

    }
    class PopStack
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 2, 3, 4 };

            PopStack<int> pstack = new PopStack<int>();
            var res = pstack.Dfs(list);

            bool judge = pstack.Judge(res, new List<int> { 3,1,2,4 });
            Console.WriteLine(judge);

            foreach (var i in res)
            {
                Console.WriteLine(string.Join(",", i));
            }


        }
    }
}
