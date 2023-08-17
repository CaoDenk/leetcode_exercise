using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace algorithm_exercise
{
    internal class Kmp
    {

        public int FindString(string str,string fstr)
        {
            int[] nextJ=GetNextJ(fstr);

            int j = 0;
            int i = 0;

            while(i<str.Length)
            {
                if (str[i] == fstr[j])
                {
                    ++i;
                    ++j;
                }else
                {
                    if (j > 0)
                    {
                        j = nextJ[j - 1];
                    }else
                    {
                        ++i;
                    }
                    continue;
                }
                if(j>=fstr.Length)
                {
                    return i-fstr.Length;
                }

            }
            return -1;
        }
        int[] GetNextJ(string fstr)
        {
            int[] nextj = new int[fstr.Length];
            nextj[0] = -1;
            for(int i = 1;i<fstr.Length;++i)
            {
                if (fstr[i] == fstr[i-1])
                {
                    nextj[i] = nextj[i-1]+1;
                }                 
                else 
                {
                    nextj[i] = 0;
                }
            }
            for(int j=0;j<fstr.Length;++j)
            {
                ++nextj[j];
            }
            return nextj;
        }

        static void Main(string[] args)
        {

        }
    }
}
