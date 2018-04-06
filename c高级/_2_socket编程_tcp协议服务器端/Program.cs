using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace _2_socket编程_tcp协议服务器端
{
    class Program
    {
        static void Main(string[] args)
        {
            //1、创建socket               第一个参数 是枚举类型 这里表示内网（ip4）
            //                            第二个参数是一个SocketType 表示以什么东西来做通信
            //                           第三个参数表示以什么做协议 ProtocolType 这里使用tcp协议
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //2 绑定ip和端口号 本地的无线网ip地址为192.168.1.100
            //这个类专门用来传递 ip地址 构造可以传递一个byte[] 因为byte正好是 0-255
            IPAddress iPAddress = new IPAddress(new Byte[4] { 192, 168, 1, 100 });
            EndPoint point = new IPEndPoint(iPAddress, 17878);//IPEndPoint是对ip+端口号做了一层封装的类
            tcpServer.Bind(point);//向操作系统申请 一个可用的ip和端口号 进行绑定

            //3、开始监听（等待客户端连接）
            tcpServer.Listen(100);//参数表示 最大连接数
            Console.WriteLine("开始监听");

            //4、接收客户端的一个连接
            Socket clientSocket = tcpServer.Accept();//暂停当前线程，知道有一个客户端连接过来 之后进行下面的代码
            Console.WriteLine("一个客户端连接过来了");
           //5、向客户端发生一个消息
            //使用返回的socket 和客户端进行通信
            string message = "hello 欢迎";//发生的字符串
            Byte[] bytes =Encoding.UTF8.GetBytes(message);//最字符串做编码，得到一个字符串的字节数组

            clientSocket.Send(bytes);//发生消息
            Console.WriteLine("向客户端发送了一个消息");
            //接收客户端信息
            Byte[] data = new byte[1024];//创建一个字节数组 用来当容器，承接客户端发送过来的数据
            int length = clientSocket.Receive(data);
            string message2 = Encoding.UTF8.GetString(data, 0, length);
            Console.WriteLine("接受到了一个消息"+ message2);
            Console.ReadKey();//暂停main方法
        }
    }
}
