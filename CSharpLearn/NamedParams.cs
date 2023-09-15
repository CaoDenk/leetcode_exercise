using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpLearn
{
    internal class NamedParams
    {


    }
    

    public  class TestArray
    {
        public int capacity { get; private set; }
        
        void NamedParams(int capacity,string name)
        {
            this.capacity = capacity;
        }
        void Assign(int capacity)
        {
            if(capacity<0)
            {
                NamedParams(name:"小明",capacity:10);
            }else
            {
              // NamedParams(capacity);
            }
        }
        
    }
}
