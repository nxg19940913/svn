using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamReader和StreamWrite
{
    class Program
    {
        static void Main(string[] args)
        {
            ////创建文本文件读取流                                出现中文乱码 本地电脑是GBK 所以
            //StreamReader reader = new StreamReader("TextFile2.txt",Encoding.GetEncoding("GBK"));
            ////string str = reader.ReadLine();//一次读取一行
            //while (true)
            //{
            //    string str = reader.ReadLine();
            //    if (str==null)
            //    {
            //        break;
            //    }
            //    Console.WriteLine(str);
            //}
            StreamReader reader = new StreamReader("TextFile2.txt", Encoding.GetEncoding("GBK"));
            //string str = reader.ReadToEnd();//读取到文本的结尾 会自动捕捉空格和换行符
            //Console.WriteLine(str);
           
            //while (true)
            //{
              
            //    int res = reader.Read();//读取
            //    if (res == -1)
            //    {
            //        break;
            //    }
            //    else
            //    {
            //        Console.Write((char)res);
            //    }
            //}
        StreamWriter writer = new StreamWriter("1.txt");
            while (true)
            {
                string message = Console.ReadLine();
                if (message == "q")
                {
                    break;
                }
                // writer.Write(message);
                writer.WriteLine(message);//写入并换行
            }
                writer.Close();
        }
    }
}
