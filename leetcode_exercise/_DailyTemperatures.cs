using System;
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
            for(int i = 0;i<temperatures.Length;++i)
            {
                //for()

            }

            return null;
        }
        static void Main(string[] args)
        {
            UpStack<Temp> upStack = new();
            Temp temp;
            temp.day = 0;
            temp.temperature = 20;
            upStack.Push(temp);
             
            Console.WriteLine(upStack.Count);
        }
    }
    struct Temp:IComparable<Temp>
    {
        public int temperature;
        public int day;



        public int CompareTo(Temp other)
        {
            return temperature - other.temperature;
        }

      
    }

    class UpStack<T>  where T:IComparable<T>
    {
        Stack<T> stack = new Stack<T>();  
        public void Push(T item)
        {
            if(stack.Count==0)
                stack.Push(item);
            else if(item.CompareTo(stack.Peek())>0)
            {
                stack.Push(item);
            }
            
        }
        public T Pop()=>stack.Pop();
        public int Count => stack.Count;    

    }

   


}
