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
        static void DownloadFile()
        { //                                 获取当前线程     获取线程id
            Console.WriteLine("开始下载" + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");
        }
        static void Main(string[] args)
        {
            Thread t = new Thread(DownloadFile);//创建线程
            t.Start();//开启线程
            Console.WriteLine("Main");
        }
    }
}
