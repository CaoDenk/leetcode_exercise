﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    /// <summary>
    /// 65. 有效数字
    /// DFA
    /// </summary>
    internal class IsNumber2
    {
        
        enum State
        {
            S0,
            S1,
            S2,
            S3,
            S4,
            S5,
            S6,
            S7,
            ERROR
        }

        enum Condition
        {
            DOT,
            SIGN,
            E,
            NUM,
            ERR
        }

        public bool IsNumber(string s)
        {
            State state = State.S0;
            int i = 0;
            for (;i<s.Length;++i)
            {
                Condition condition = GetCondition(s,ref i);

                state = GetState(state, condition);
                if(state==State.ERROR)
                    return false;
            }

            return state is State.S2 or State.S6 or State.S7;
        }
        
        Condition GetCondition(string s,ref int i)
        {
            if(s[i] is '+' or '-')
                return Condition.SIGN;
            if (s[i] =='.')
                return Condition.DOT;
            if(s[i] is 'e' or 'E')
                return Condition.E;
            if (char.IsDigit(s[i]))
            {
                do
                {
                    ++i;
                } while (i < s.Length && char.IsDigit(s[i]));
                --i;
                 return Condition.NUM;
            }
               
            return Condition.ERR;
        }


        State GetState(State  state,Condition c)
        {

            return (state, c) switch
            {
                (State.S0, Condition.SIGN) => State.S1,
                (State.S0,Condition.NUM)=>State.S2,
                (State.S0,Condition.DOT)=>State.S3,
                (State.S1,Condition.NUM)=>State.S2,
                (State.S1,Condition.DOT)=>State.S3,
                (State.S2,Condition.NUM)=>State.S2,
                (State.S2,Condition.E)=>State.S4,
                (State.S2,Condition.DOT)=>State.S7,
                (State.S3,Condition.NUM)=>State.S7,
                (State.S4,Condition.SIGN)=>State.S5,
                (State.S4,Condition.NUM)=>State.S6,
                (State.S5,Condition.NUM)=>State.S6,
                (State.S6,Condition.NUM)=>State.S6,
                (State.S7,Condition.NUM)=>State.S7,
                (State.S7,Condition.E)=>State.S4,
                _=> State.ERROR
            };
      
        }
        static void Main(string[] args)
        {
            IsNumber2 i = new();
            //Console.WriteLine(i.IsNumber(".1"));
            Console.WriteLine(i.IsNumber(".2e81"));
        }


    }
}
