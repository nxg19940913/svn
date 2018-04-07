using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileStream读写文件
{
    class Program
    {
        static void Main(string[] args)
        {
            ////创建文件流 用来操作文件
            //FileStream stream = new FileStream("TextFile1.txt", FileMode.Open);
            ////读取或写入数据
            //byte[] data = new byte[1024];//数据容器
            //// 0:开始读取位置 1024 表示最大读取 返回实际读取int
            ////1byte = 1字节 1024byte = 1KB
            ////这里表示对多一次读取1kb  如果超出了文件的大小 比如文件有好几百兆这样可以分多次读取
            ////这样就得循环读取
            //while (true)//判断是否读取万
            //{

            //   int length = stream.Read(data, 0, 1024);
            //    if (length == 0)
            //    {
            //        Console.WriteLine("读取结束");
            //        break;
            //    }
            //    for (int i = 0; i < length; i++)
            //    {
            //        Console.WriteLine(data[i]+" ");
            //    }
            //}

            //使用fileStream完成文件复制
            FileStream readStream = new FileStream("test.png", FileMode.Open);//读

            FileStream writeStream = new FileStream("test副本.png", FileMode.Create);//写 所以选择创建

            byte[] data = new byte[1024];//数据容器
            while (true)
            {
               int length = readStream.Read(data, 0, data.Length);
                if (length == 0)
                {
                    Console.WriteLine("读取结束");
                    break;
                }
                else
                {
                    writeStream.Write(data, 0, length);//写入
                }
            }
            //关闭流
            readStream.Close();
            writeStream.Close();
        }
    }
}
