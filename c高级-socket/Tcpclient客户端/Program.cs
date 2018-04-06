using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Tcpclient客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            //当我们创建tcpclient对象时，就会跟server去建立连接
            TcpClient client = new TcpClient("192.168.1.100", 7788);
            NetworkStream stream = client.GetStream();//通过网络流进行数据的交换
            while (true)//循环写入数据
            {
            //Read 用来读数据 write用来写入数据
            string message = Console.ReadLine();
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);

            }

            stream.Close();
            client.Close();
            Console.ReadKey();
        }
    }
}
