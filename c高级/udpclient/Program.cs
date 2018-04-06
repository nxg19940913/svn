using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace udpclient
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建udpclient 绑定ip跟端口号
            UdpClient udpClient = new UdpClient(new IPEndPoint(IPAddress.Parse("192.168.1.100"), 7788));
            //接收数据
            IPEndPoint point = new IPEndPoint(IPAddress.Any, 0);
           byte[] data = udpClient.Receive(ref point);//通过point确定数据来自哪个ip的哪个端口号 返回值是一个字节数组 就是我们的数据
        }
    }
}
