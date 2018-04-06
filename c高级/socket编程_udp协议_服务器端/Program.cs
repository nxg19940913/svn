using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace socket编程_udp协议_服务器端
{
    class Program
    {
        private static Socket udpServer;
        static void Main(string[] args)
        {//创建socket
            udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            //绑定ip根端口号
            udpServer.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.100"), 7788));
            new Thread(ReceiveMessage) { IsBackground = true }.Start();//创建一个线程 设置为后台线程 并开启

           // udpServer.Close();
            Console.ReadKey();
        }
        static void ReceiveMessage()
        {
            while (true)
            {
            //接收数据
            EndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 0);//存储发送数据的ip 所以不需要赋值
            byte[] data = new byte[1024];//用来存放数据
                                         //ref 表示可以对这个 类型做修改
                                  //这个方法会等到 只有接受到一条数据才会继续向下运行
            int length = udpServer.ReceiveFrom(data, ref remoteEndPoint);//这个方法会把数据的来源(ip:port)放到第二个参数上
            string message = Encoding.UTF8.GetString(data, 0, length);

            Console.WriteLine("从ip：" + (remoteEndPoint as IPEndPoint).
                // 获取ip                                         获取端口号
                Address.ToString() + ":" + (remoteEndPoint as IPEndPoint).Port + "收到了数据：" + message);
            }
        }
    }
}
