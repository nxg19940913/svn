using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 使用File读写文件
{
    class Program
    {
        static void Main(string[] args)
        {
            //读取文件，把每一行文本读取成一个字符串，最后组成一个字符数组
            //string[] strArray = File.ReadAllLines("TextFile1.txt");
            //foreach (var item in strArray)
            //{
            //    Console.WriteLine(item);
            //}

            //把整个文件读取成一个字符串 里面会自动匹配空格换行符等
            //string str =  File.ReadAllText("TextFile1.txt");
            //  Console.WriteLine(str);

            //读取图片
            //byte[] data = File.ReadAllBytes("test.png");
            //foreach (var item in data)
            //{
            //    Console.Write(item);
            //}


            ////写文件 如果文件名相同 会覆盖 
            //File.WriteAllText("text.txt", "你好\n\r hello");
            ////文件会放到新的一行
            //File.WriteAllLines("text1.txt",new string[]{ "dsf","dfsdf","dsf是大法官"});
            byte[] data = File.ReadAllBytes("test.png");//获取图片
            File.WriteAllBytes("1.png", data);
        }
    }
}
