using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class _CanConstruct
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            Dictionary<char, int> note = new();
            Dictionary<char, int> mag = new();
            foreach (char c in magazine) 
            {
                if(mag.ContainsKey(c))
                {
                    ++mag[c] ;
                }else
                {
                    mag[c] = 1 ;
                }
            }
            foreach (char c in ransomNote)
            {
                if (note.ContainsKey(c))
                {
                    ++note[c];
                }
                else
                {
                    note[c] = 1;
                }
            }

            var noteKey = note.Keys;
            foreach (var k in noteKey)
            {
                if (!mag.ContainsKey(k))
                    return false;
                if (mag[k] < note[k])
                {
                    return false;
                }
            }

            return true;

        }
    }
}
