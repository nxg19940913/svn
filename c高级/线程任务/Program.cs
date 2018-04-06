using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程任务
{
    class Program
    {
        static void ThreadMethod()
        {//                                 获取当前线程    获取id
            Console.WriteLine("start:" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("end");
        }
        static void Main(string[] args)
        {
            //线程任务类  传递一个需要线程去执行的方法
            //Task t = new Task(ThreadMethod);
            //t.Start();

            //任务工厂
            //TaskFactory tf = new TaskFactory();
            //Task t = tf.StartNew(ThreadMethod);//返回一个任务的对象 并自动执行


           
            Console.WriteLine("main");
            Console.ReadKey();
        }
    }
}
