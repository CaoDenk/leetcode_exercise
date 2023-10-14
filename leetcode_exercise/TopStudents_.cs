using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static leetcode_exercise.TopStudents_;

namespace leetcode_exercise
{
    /// <summary>
    /// 2512. 奖励最顶尖的 K 名学生
    /// </summary>
    internal class TopStudents_
    {

        public int[] SortTopK(int[] nums, int k, Comparison<int> minheap, Comparison<int> cmp)
        {

            PriorityQueue<int, int> pq = new PriorityQueue<int, int>(Comparer<int>.Create(minheap));
            for (int i = 0; i < k; ++i)
            {
                pq.Enqueue(nums[i], nums[i]);
            }

            for (int i = k; i < nums.Length; ++i)
            {
                int cmpres = cmp(pq.Peek(), nums[i]);

                if (cmpres > 0)
                {
                    pq.Dequeue();
                    pq.Enqueue(nums[i], nums[i]);

                }
            }
            int[] res = new int[k];
            for (int i = 0; i < k; ++i)
            {
                res[i] = pq.Dequeue();
            }
            return res;
        }





        public IList<int> TopStudents(string[] positive_feedback, string[] negative_feedback, string[] report, int[] student_id, int k)
        {
            int[] scores = new int[student_id.Length];

            HashSet<string> positive_feedback_set = new HashSet<string>(positive_feedback);
            HashSet<string> negative_feedback_set = new HashSet<string>(negative_feedback);

            for (int i = 0; i < scores.Length; ++i)
            {
                int score = 0;
                var reportList = report[i].Split(' ').ToList();
                for (int j = 0; j < reportList.Count; ++j)
                {
                    if (positive_feedback_set.Contains(reportList[j]))
                    {
                        score += 3;
                    }
                }
                for (int j = 0; j < reportList.Count; ++j)
                {
                    if (negative_feedback_set.Contains(reportList[j]))
                    {
                        score--;
                    }
                }
                scores[i] = score;
            }
            return Sort(student_id, scores, k);
        }

        IList<int> Sort(int[] student_id, IList<int> scores, int k)
        {

            int[] range = Enumerable.Range(0, scores.Count).ToArray();

            Comparison<int> topk = (o1, o2) =>
            {
                if (scores[o1] != scores[o2])
                    return scores[o2].CompareTo(scores[o1]);
                else
                    return student_id[o1].CompareTo(student_id[o2]);
            };
            Comparison<int> minheap = (o1, o2) =>
            {
                if (scores[o1] != scores[o2])
                    return scores[o1].CompareTo(scores[o2]);
                else
                    return student_id[o2].CompareTo(student_id[o1]);
            };
            var ranged = SortTopK(range, k, minheap, topk);
            int[] res = new int[k];
            for (int i = 0; i < k; ++i)
            {
                res[i] = student_id[ranged[k - 1 - i]];
            }
            return res;
        }




        static void Main(string[] args)
        {
            TopStudents_ t = new();
            //{
            //    string[] positive_feedback = { "smart", "brilliant", "studious" };
            //    string[] negative_feedback = { "not" };
            //    string[] report = { "this student is not studious", "the student is smart" };
            //    int[] student_id = { 1, 2 };
            //    int k = 2;
            //    var res=t.TopStudents(positive_feedback,negative_feedback,report,student_id,k);
            //    Console.WriteLine(string.Join(",",res));
            //}
            {
                /*
                 positive_feedback =
["fkeofjpc","qq","iio"]
negative_feedback =
["jdh","khj","eget","rjstbhe","yzyoatfyx","wlinrrgcm"]
report =
["rjstbhe eget kctxcoub urrmkhlmi yniqafy fkeofjpc iio yzyoatfyx khj iio","gpnhgabl qq qq fkeofjpc dflidshdb qq iio khj qq yzyoatfyx","tizpzhlbyb eget z rjstbhe iio jdh jdh iptxh qq rjstbhe","jtlghe wlinrrgcm jnkdbd k iio et rjstbhe iio qq jdh","yp fkeofjpc lkhypcebox rjstbhe ewwykishv egzhne jdh y qq qq","fu ql iio fkeofjpc jdh luspuy yzyoatfyx li qq v","wlinrrgcm iio qq omnc sgkt tzgev iio iio qq qq","d vhg qlj khj wlinrrgcm qq f jp zsmhkjokmb rjstbhe"]
student_id =
[96537918,589204657,765963609,613766496,43871615,189209587,239084671,908938263]
k =
3
                 */
                string[] positive_feedback = { "fkeofjpc", "qq", "iio" };
                string[] negative_feedback = { "jdh", "khj", "eget", "rjstbhe", "yzyoatfyx", "wlinrrgcm" };
                string[] report = { "rjstbhe eget kctxcoub urrmkhlmi yniqafy fkeofjpc iio yzyoatfyx khj iio", "gpnhgabl qq qq fkeofjpc dflidshdb qq iio khj qq yzyoatfyx", "tizpzhlbyb eget z rjstbhe iio jdh jdh iptxh qq rjstbhe", "jtlghe wlinrrgcm jnkdbd k iio et rjstbhe iio qq jdh", "yp fkeofjpc lkhypcebox rjstbhe ewwykishv egzhne jdh y qq qq", "fu ql iio fkeofjpc jdh luspuy yzyoatfyx li qq v", "wlinrrgcm iio qq omnc sgkt tzgev iio iio qq qq", "d vhg qlj khj wlinrrgcm qq f jp zsmhkjokmb rjstbhe" };
                int[] student_id = { 96537918, 589204657, 765963609, 613766496, 43871615, 189209587, 239084671, 908938263 };
                int k = 3;
                var res = t.TopStudents(positive_feedback, negative_feedback, report, student_id, k);
                Console.WriteLine(string.Join(",", res));
            }


        }
    }
}
