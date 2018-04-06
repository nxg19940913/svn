using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace socket编程_tcp协议_客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、创建socket               第一个参数 是枚举类型 这里表示内网（ip4）
            //                            第二个参数是一个SocketType 表示以什么东西来做通信
            //                           第三个参数表示以什么做协议 ProtocolType 这里使用tcp协议
            Socket tcpClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //2、发起建立连接的请求
            IPAddress ipAddress = IPAddress.Parse("192.168.1.100");//可以吧一个字符串的ip地址装换成一个ipAddress
            EndPoint point = new IPEndPoint(ipAddress,17878);//端口号一定要和绑定的端口号一致
            tcpClient.Connect(point);//通过ip+端口号 定位一个需要连接到的服务器端

            //3、接收服务器端的消息
            byte[] data = new byte[1024];
            int length = tcpClient.Receive(data);//这里的byte数组 实际上是用来接收数据的
            //length 表示返回值接收了多少字节的数据

            //把字节数组装换成字符串 根据utf-8编码格式 0表示索引开始 length表示 结束的索引
           string message = Encoding.UTF8.GetString(data,0,length);//值转换接收到的数据
            Console.WriteLine(message);
            //向服务器端发生消息
            string message2 = Console.ReadLine();//读取用户的输入 发生到客户端
            tcpClient.Send(Encoding.UTF8.GetBytes(message2));//把字符串转换成字节数组发送到服务器端
            Console.ReadKey();//暂停main方法
        }
    }
}
