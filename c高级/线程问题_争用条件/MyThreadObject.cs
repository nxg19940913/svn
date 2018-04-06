using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程问题_争用条件
{
    class MyThreadObject
    {
        private int state = 5;
        public void ChangeState()
        {
            //Console.WriteLine(  Thread.CurrentThread.ManagedThreadId );
            
            state++;
           //Console.WriteLine(state);
            //这里肯定不满足条件 近不来
            if (state == 5)//假设 a线程执行到这里
            {
                Console.WriteLine("state = 5");
                
            }state = 5;//b线程执行到这里 就会把 state的值修改 所以就进的去方法中了 解决问题就是加锁
        }
    }
}
