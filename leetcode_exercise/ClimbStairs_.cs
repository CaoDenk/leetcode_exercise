using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class ClimbStairs_
    {
        class Matrix
        {
            int[,] matrix { get; set; }
            public  Matrix(int[,] m) { this.matrix = m; }
            public static implicit  operator Matrix(int[,] m) { return new Matrix(m); }
            public Matrix(Matrix m) { this.matrix = (int[,])m.matrix.Clone(); }
            public int GetLength(int i) => this.matrix.GetLength(i);

            //public static explicit operator=(Matrix left, int[,] m){}
             


            public int this[int row,int col]
            {
                get => matrix[row, col]; 
                set { matrix[row, col] = value; }
            }
            public static Matrix operator *(Matrix left, Matrix right)
            {
                Debug.Assert(left.GetLength(1)==right.GetLength(0));
                int[,] ret=new int[left.GetLength(0),right.GetLength(1)];   
                for(int i=0;i<left.GetLength(0);++i)
                {

                    for(int j=0;j<right.GetLength(1);++j)
                    {
                        
                        for(int k=0;k<left.GetLength(1);++k)
                        {
                            ret[i,j] += left[i, k] * right[k, j];
                        }

                    }
                }
                return new Matrix(ret);
            }


            public static Matrix operator ^(Matrix left, int exp)
            {
                Debug.Assert(left.GetLength(0)==left.GetLength(1));
                if (exp == 1)
                    return left;
                if (exp == 2)
                    return left * left;
                Matrix m = left;
                Matrix ret=left;
                int e = exp;
                while(e!=0)
                {
                    if((e&1)==1)
                    {
                        ret *= m; 
                    }
                    m *= m;
                    e >>= 1;
                }

                return ret;
            }

        }
        public int ClimbStairs(int n)
        {
            if (n < 2)
                return 1;
            if (n == 2)
                return 2;
            if (n == 3)
                return 3;
            if (n == 4)
                return 5;
            Matrix m = new int[2, 2] { { 0, 1 }, { 1, 1 } };

            var ret = m ^ (n-2);
            var res = ret * new int[2, 1] { { 1 }, { 2 } };
            return res[0,0];


        }

        static void Main(string[] args)
        {
            ClimbStairs_ c = new();
            //Console.WriteLine(c.ClimbStairs(5));
            for (int i = 3; i < 8; ++i)
            {
                Console.WriteLine($"{i}={c.ClimbStairs(i)}");

            }


        }

    }
}
