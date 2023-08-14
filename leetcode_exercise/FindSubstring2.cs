using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace leetcode_exercise
{
    internal class FindSubstring2
    {
        public IList<int> FindSubstring(string s, string[] words)
        {
            IList<int> res = new List<int>();
            Dictionary<string, int> dict = new();

            int wordLen = words[0].Length;
            int wordsCount = words.Length;
            foreach (var word in words)
            {
                if (dict.ContainsKey(word))
                    dict[word]++;
                else dict[word] = 0;
            }
            Dictionary<string, int> window = new();
            int wordLenCount = wordsCount * wordLen;
            for (int i = 0; i < wordLen; i++)
            {
                int count = 0;
                int start = i;
                for (int j = i; j <= s.Length - wordLen; j += wordLen)
                {
                    if (j - start >= wordsCount * wordLen)
                    {
                        string startStr = s.Substring(j -wordLenCount , wordLen);
                        if (window.ContainsKey(startStr))
                        {
                            if (window[startStr] == 0)
                            {
                                window.Remove(startStr);
                                count--;
                            }
                            else
                            {
                                if (--window[startStr] < dict[startStr])
                                {
                                    count--;
                                }
                            }
                        }
                    }
                    var substr = s.Substring(j, wordLen);
                    if (!dict.ContainsKey(substr))
                    {
                        window.Clear();
                        count = 0;
                        start = j;
                        continue;
                    }
                    else
                    {
                        if (window.ContainsKey(substr))
                        {
                            if (++window[substr] <= dict[substr])
                            {
                                count++;
                                if (count == wordsCount)
                                {
                                    res.Add(j - (wordsCount - 1) * wordLen);
                                }
                            }                            
                        }
                        else
                        {
                            window[substr] = 0;
                            count++;
                            if (count == wordsCount)
                            {
                                res.Add(j - wordLenCount+wordLen);
                            }
                        }
                       
                    }
                }
                window.Clear();
            }
            return res;
        }

        static void Main(string[] args)
        {
            FindSubstring2 f = new();
            {
                var res = f.FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" });
                Console.WriteLine(string.Join(",", res));
            }
            //{
            //    var res = f.FindSubstring("barfoofoobarthefoobarman", new string[] { "bar", "foo", "the" });
            //    Console.WriteLine(string.Join(",", res));
            //}
            //{
            //    var res = f.FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "good" });
            //    Console.WriteLine(string.Join(",", res));
            //}
            //{
            //    var res = f.FindSubstring("aaaaaaaaaaaaaa", new string[] { "aa", "aa" });
            //    Console.WriteLine(string.Join(",", res));
            //}
            //{
            //    var str = "pjzkrkevzztxductzzxmxsvwjkxpvukmfjywwetvfnujhweiybwvvsrfequzkhossmootkmyxgjgfordrpapjuunmqnxxdrqrfgkrsjqbszgiqlcfnrpjlcwdrvbumtotzylshdvccdmsqoadfrpsvnwpizlwszrtyclhgilklydbmfhuywotjmktnwrfvizvnmfvvqfiokkdprznnnjycttprkxpuykhmpchiksyucbmtabiqkisgbhxngmhezrrqvayfsxauampdpxtafniiwfvdufhtwajrbkxtjzqjnfocdhekumttuqwovfjrgulhekcpjszyynadxhnttgmnxkduqmmyhzfnjhducesctufqbumxbamalqudeibljgbspeotkgvddcwgxidaiqcvgwykhbysjzlzfbupkqunuqtraxrlptivshhbihtsigtpipguhbhctcvubnhqipncyxfjebdnjyetnlnvmuxhzsdahkrscewabejifmxombiamxvauuitoltyymsarqcuuoezcbqpdaprxmsrickwpgwpsoplhugbikbkotzrtqkscekkgwjycfnvwfgdzogjzjvpcvixnsqsxacfwndzvrwrycwxrcismdhqapoojegggkocyrdtkzmiekhxoppctytvphjynrhtcvxcobxbcjjivtfjiwmduhzjokkbctweqtigwfhzorjlkpuuliaipbtfldinyetoybvugevwvhhhweejogrghllsouipabfafcxnhukcbtmxzshoyyufjhzadhrelweszbfgwpkzlwxkogyogutscvuhcllphshivnoteztpxsaoaacgxyaztuixhunrowzljqfqrahosheukhahhbiaxqzfmmwcjxountkevsvpbzjnilwpoermxrtlfroqoclexxisrdhvfsindffslyekrzwzqkpeocilatftymodgztjgybtyheqgcpwogdcjlnlesefgvimwbxcbzvaibspdjnrpqtyeilkcspknyylbwndvkffmzuriilxagyerjptbgeqgebiaqnvdubrtxibhvakcyotkfonmseszhczapxdlauexehhaireihxsplgdgmxfvaevrbadbwjbdrkfbbjjkgcztkcbwagtcnrtqryuqixtzhaakjlurnumzyovawrcjiwabuwretmdamfkxrgqgcdgbrdbnugzecbgyxxdqmisaqcyjkqrntxqmdrczxbebemcblftxplafnyoxqimkhcykwamvdsxjezkpgdpvopddptdfbprjustquhlazkjfluxrzopqdstulybnqvyknrchbphcarknnhhovweaqawdyxsqsqahkepluypwrzjegqtdoxfgzdkydeoxvrfhxusrujnmjzqrrlxglcmkiykldbiasnhrjbjekystzilrwkzhontwmehrfsrzfaqrbbxncphbzuuxeteshyrveamjsfiaharkcqxefghgceeixkdgkuboupxnwhnfigpkwnqdvzlydpidcljmflbccarbiegsmweklwngvygbqpescpeichmfidgsjmkvkofvkuehsmkkbocgejoiqcnafvuokelwuqsgkyoekaroptuvekfvmtxtqshcwsztkrzwrpabqrrhnlerxjojemcxel";
            //    var res = f.FindSubstring(str, new string[] { "dhvf", "sind", "ffsl", "yekr", "zwzq", "kpeo", "cila", "tfty", "modg", "ztjg", "ybty", "heqg", "cpwo", "gdcj", "lnle", "sefg", "vimw", "bxcb" });
            //    Console.WriteLine(string.Join(",", res));
            //    //Console.WriteLine(str.IndexOf("dhvfsindffslyekrzwzqkpeollcilatftyybtylnleztjgmodggdcjvimwsefgheqgbxcbcpwo"));
            //}
            {
                var str = "abbaccaaabcabbbccbabbccabbacabcacbbaabbbbbaaabaccaacbccabcbababbbabccabacbbcabbaacaccccbaabcabaabaaaabcaabcacabaa";
                {
                    var res = f.FindSubstring(str, new string[] { "cac", "aaa", "aba", "aab", "abc" });
                    Console.WriteLine(string.Join(",", res));
                }

                //for (var start = 80; start <= 96; ++start)
                //{
                //    var res = f.FindSubstring(str.Substring(start), new string[] { "cac", "aaa", "aba", "aab", "abc" });
                //    //aaa abc aab cac aba
                //    //Console.WriteLine(str.Substring(94,15));
                //    Console.WriteLine($"start={start},result= " + string.Join(",", res));
                //}
            }

        }
    }
}
