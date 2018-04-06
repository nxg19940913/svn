using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace socket编程_udp协议_客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            
            //创建socket
            Socket udpClient = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            while (true)//重复发送信息
            {
            //发送数据
            EndPoint serverPoint = new IPEndPoint(IPAddress.Parse("192.168.1.100"),7788);
            string message = Console.ReadLine();//存放数据
            byte[] data = Encoding.UTF8.GetBytes(message);
            udpClient.SendTo(data, serverPoint);//发送

            }
            udpClient.Close();
            Console.ReadKey();
        }
    }
}
