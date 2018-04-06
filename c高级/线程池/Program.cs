using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程池
{
    class Program
    {
        static void ThreadMethod(Object state)
        {//                                 获取当前线程    获取id
            Console.WriteLine("start:"+ Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("end");
        }
        static void Main(string[] args)
        {
            //线程池    分配线程执行方法   必须有参数的方法 可以传递数据 也可以不传递
            //线程池的线程都是后台线程 前台线程结束，会立即结束后台线程 不能修改为前台线程 只适合做一个时间短的小任务
            ThreadPool.QueueUserWorkItem(ThreadMethod);//开启一个工作线程
            ThreadPool.QueueUserWorkItem(ThreadMethod, 32);
            ThreadPool.QueueUserWorkItem(ThreadMethod, 32);
            ThreadPool.QueueUserWorkItem(ThreadMethod, 32);
            ThreadPool.QueueUserWorkItem(ThreadMethod, 32);

            ThreadPool.QueueUserWorkItem(ThreadMethod, 32);
            Thread.Sleep(5000);//让主线程 休息10秒
            Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        }
    }
}
