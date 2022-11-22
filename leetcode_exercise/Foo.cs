namespace leetcode_exercise
{
    public class Foo
    {

        public Foo()
        {

        }
        
        AutoResetEvent first=new AutoResetEvent(false);
        AutoResetEvent second=new AutoResetEvent(false);
        public void First(Action printFirst)
        {

            // printFirst() outputs "first". Do not change or remove this line.
          

            printFirst();
            first.Set();
        }

        public void Second(Action printSecond)
        {

            // printSecond() outputs "second". Do not change or remove this line.
            first.WaitOne();
            printSecond();
            second.Set();
        }

        public void Third(Action printThird)
        {

            // printThird() outputs "third". Do not change or remove this line.
            second.WaitOne();
            printThird();
        }
    }
}
