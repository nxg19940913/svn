using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace udpclient客户端
{
    class Program
    {
        static void Main(string[] args)
        {
            //创建updclient对象
            UdpClient client = new UdpClient();
            while (true)
            {

            string message = Console.ReadLine();
            byte[] data = Encoding.UTF8.GetBytes(message);

            client.Send(data, data.Length, new IPEndPoint(IPAddress.Parse("192.168.1.100"), 7788));
            }
            client.Close();
            Console.ReadKey();
        }
    }
}
