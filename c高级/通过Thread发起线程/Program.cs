using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 通过Thread发起线程
{
    class Program
    {
        static void DownloadFile(Object name) //线程的参数必须是Object
        { //                                 获取当前线程     获取线程id
            Console.WriteLine("开始下载" + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(name);
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");
        }
        static void Main(string[] args)
        {
            //Thread t = new Thread(DownloadFile);//创建线程
            //t.Start();//开启线程
            //Console.WriteLine("Main");

            //通过lambda表达式
            //Thread t = new Thread(() =>
            //{
            //    Console.WriteLine("开始下载,id:" + Thread.CurrentThread.ManagedThreadId);
            //    Thread.Sleep(2000);
            //    Console.WriteLine("下载完成");
            //});
            //t.Start();
            //Console.WriteLine("Main");

            //传递参数
            //Thread t = new Thread(DownloadFile);//创建线程
            //t.Start("xxx");//开启线程  通过start方法传递参数
            //Console.WriteLine("Main");

            //自定义线程 传递参数
            //MyThread my = new MyThread("xxx", "http:xxx.html");
            //new Thread(my.DownFile).Start();//构造一个thread 对象时，可以传递一个静态方法，也可以传递一个普通方法


            //前台线程和后台线程
            Thread t = new Thread(DownloadFile);//这个是前台线程
            Console.WriteLine("main");
            t.IsBackground = true;//设置为后台线程 前台线程结束 后台线程 会被杀死
            t.Abort();//终止这个线程 把他杀死
            t.Join();//让当前线程睡眠，等待t线程执行完，然后继续运行下面的代码
            Console.ReadKey();
        }
    }
}
