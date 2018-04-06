using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 通过Thread发起线程
{
    class MyThread
    {
        private string filename;
        private string filepath;

        public MyThread(string filename, string filepath)
        {
            this.filename = filename;
            this.filepath = filepath;
        }
        public void DownFile()
        {
            Console.WriteLine("开始下载" + filename+ filepath);
            
            Thread.Sleep(2000);
            Console.WriteLine("下载完成");
        }
    }
}
