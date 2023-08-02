using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
<<<<<<< HEAD
=======
    /// <summary>
    /// 
    /// </summary>
>>>>>>> 2ab0e3a4674bfeda346dc84def565260ad9315ea
    internal class _DailyTemperatures
    {
        public int[] DailyTemperatures(int[] temperatures)
        {
<<<<<<< HEAD
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

   


=======
            int[] res = new int[temperatures.Length];
            for (int i = temperatures.Length - 2; i >= 0; --i)
            {
                for (int j = i + 1; j < temperatures.Length; j += res[j])
                {
                    if (temperatures[j] > temperatures[i])
                    {
                        res[i] = j - i;
                        break;
                    }
                    else if (res[j] == 0)
                    {
                        break;
                    }

                }

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
            var ret=d.DailyTemperatures(arr);
            Console.WriteLine(string.Join(",",ret));
        }

    }
>>>>>>> 2ab0e3a4674bfeda346dc84def565260ad9315ea
}
