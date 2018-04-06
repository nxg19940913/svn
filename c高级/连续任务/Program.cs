using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 连续任务
{
    class Program
    {
        static void ThreadMethod()
        {//                                 获取当前线程    获取id
            Console.WriteLine("start:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("end");
        }
        static void ThreadMethod1(Task t)//必须要有一个 线程参数
        {//                                 获取当前线程    获取id
            Console.WriteLine("start:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("end");
        }
        static void Main(string[] args)
        {
            //线程任务 连续任务 当t1执行完才会去执行t2
            Task t1 = new Task(ThreadMethod);
            Task t2 = t1.ContinueWith(ThreadMethod1);
            t1.Start();

            Thread.Sleep(5000);
            Console.ReadKey();
        }
    }
}
