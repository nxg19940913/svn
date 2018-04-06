using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程问题_争用条件
{
    class Program
    {
        static void ChangeState(Object o) {
            //使用锁时 会有可能出现死锁现象 慎用

            //把object装换成 MyThreadObject
            MyThreadObject my = o as MyThreadObject;
            while (true)
            {
                // 对当前对象加锁 里面的所有代码执行完毕 自动解锁
                //如果my对象没有锁定， 那么可以锁定my 如果my锁定了 这个语句会暂停 知道申请到my对象
                lock (my)
                {
                    //在同一时刻 只有个一个线程在执行这个方法
                my.ChangeState();
                }//释放my的锁定
            }
        }
        static void Main(string[] args)
        {
            MyThreadObject my = new MyThreadObject();
            Thread t = new Thread(ChangeState);
            t.Start(my);
            //发起两个线程 去执行该方法
            new Thread(ChangeState).Start(my);
           
            Console.ReadKey();
        }
    }
}
