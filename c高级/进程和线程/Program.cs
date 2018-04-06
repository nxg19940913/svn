using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 进程和线程
{
    class Program
    {
        //一般我们会为比较耗时的操作开启单独的线程去执行 比如下载
        static int Test(int i)
        {
            Console.WriteLine("test"+i);
            Thread.Sleep(900);//让当前线程休眠 单位毫秒
            return i;
        }
        static void Main(string[] args)
        {
            ////通过委托开启一个线程  委托就是一个线程
            //Func<int, int> a = Test;
            ////如果有返回值
            //IAsyncResult ar = a.BeginInvoke(100, null, null);//开启一个新的线程去执行a所引用的方法 可以认为线程是同时执行的（异步执行）
            //Console.WriteLine("main");
            //// while (ar.IsCompleted == false)//如果当前线程没有执行完毕
            //// {
            ////     Console.Write(".");
            ////     Thread.Sleep(10);//可以控制线程的监测频率 这里是让main线程休息
            //// }
            //// int res = a.EndInvoke(ar);//取得异步线程的返回值
            //// Console.WriteLine(res);

            ////检测线程结束
            //bool isEnd = ar.AsyncWaitHandle.WaitOne(1000);//表示等待当前线程结束 参数为超时时间 表示1秒后 线程结束了返回true 没有结束返回false
            //Console.WriteLine(isEnd);
            //if (isEnd)//如果线程结束 输出结果
            //{
            //    int res = a.EndInvoke(ar);
            //    Console.WriteLine(res);
            //}


            //通过回调检测线程结束
            Func<int, int> a = Test;
            //第一个参数就是 传递的参数
            //第二个参数是一个委托传递的是 线程结束时 会调用的方法（回调函数）
            //最后一个参数 用来给回调函数 传递参数
            // IAsyncResult ar = a.BeginInvoke(100, OnCallBack, a);
            //改成 lambda表达式
            IAsyncResult ar = a.BeginInvoke(100, o =>
            {
                int res = a.EndInvoke(o);
                Console.WriteLine(res + "lambda表达式 取得结果");
            }, null);
            Console.ReadKey();
        }
        //会自动传递这个参数 IAsyncResult
        static void OnCallBack(IAsyncResult ar)
        {
            // Console.WriteLine("子线程结束");
           Func<int,int> a = ar.AsyncState as Func<int, int>;
           int res = a.EndInvoke(ar);
            Console.WriteLine(res + "回调函数中取得结果");
        }
    }
}
