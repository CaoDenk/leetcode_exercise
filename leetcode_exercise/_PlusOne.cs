using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    public class _PlusOne
    {

        public int[] PlusOne(int[] digits)
        {
            for (int i=digits.Length-1;i>0;i--)
            {            
                if (digits[i] == 9)
                {
                    digits[i] = 0;  
                }
                else
                {
                    digits[i]++;
                    return digits;
                }
            }
           
            if (digits[0] == 9)
            {
                int[] result = new int[digits.Length + 1] ;
                result[0] = 1;
                return result;
            }
            else
                digits[0]++;
            return digits;
        }



        public static void Main()
        {

            _PlusOne p = new();
           var res= p.PlusOne([9,9,9]);
           var res1= p.PlusOne([9]);
           var res2= p.PlusOne([8,9,9]);
            foreach (int i in res)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            foreach (int i in res1)
            {
                Console.Write(i);
            }
            Console.WriteLine();
            foreach (int i in res2)
            {
                Console.Write(i);
            }

        }

    }
}
