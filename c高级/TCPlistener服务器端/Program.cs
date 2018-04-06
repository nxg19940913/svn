using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TCPlistener服务器端
{
    class Program
    {
        static void Main(string[] args)
        {
            //最socket 进行了一层封装 ，这个类里面自己回去创建socket对象
            TcpListener listener = new TcpListener(IPAddress.Parse("192.168.1.100"), 7788);
            listener.Start();//开始进行监听
             //等待客户端连接过来
            TcpClient client = listener.AcceptTcpClient();
            //取得客户端发送过来的数据
            NetworkStream stream = client.GetStream();//得到一个网络流 从这个网络流可以取得客户端发送过来的数据
            byte[] data = new byte[1024];//创建一个数据的容器，用来承接数据
            while (true)//循环读取数据
            {
                                         //0:表示从数组的那个索引开始存放数据
                                         //1024: 表示最大读取的字节数
            int length = stream.Read(data, 0, 1024);//读取数据 这里最多一次读取1024个字节 超出了会报错
            string message = Encoding.UTF8.GetString(data, 0, length);
            Console.WriteLine("收到消息:" + message);
            }
            stream.Close();//关闭流
            client.Close();//关闭客户端
            listener.Stop();//停止监听
            Console.ReadKey();
        }
    }
}
