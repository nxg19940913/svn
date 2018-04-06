using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace 聊天室tcp服务器端
{
    class Program
        
    {
        static List<Client> clients = new List<Client>();
        /// <summary>
        /// 广播消息方法
        /// </summary>
        /// <param name="message"></param>
       public static void BroadcastMessage(string message)
        {
            var notConnectedList = new List<Client>();//这里用来存储 断开连接的客户端
            //遍历集合 去给每一个客户端发送消息
            foreach (var client in clients)
            {
                if (client.Connected)//如果客户端没有断开连接，就发送消息
                {

                client.SendMessage(message);
                }
                else
                {
                    notConnectedList.Add(client);
                }
            }
            foreach (var item in notConnectedList)
            {
                clients.Remove(item);//移除之前集合中已经断开连接的客户端
            }
        }
        static void Main(string[] args)
        {
            //创建socket
            Socket tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //绑定ip              封装ip和端口                    创建ip 和端口
            tcpServer.Bind(new IPEndPoint(IPAddress.Parse("192.168.1.100"), 7788));
            //监听
            tcpServer.Listen(100);//最多100个连接
            Console.WriteLine("server running...");
            //使用while 死循环 接收多个 客户端
            while (true)
            {
                Socket clientSocket = tcpServer.Accept();//暂停线程方法 有连接 会自动开启 返回一个 Socket
                Console.WriteLine("a client is connected!");
                //利用socket 创建一个client
                Client client = new Client(clientSocket);//把与每个客户端通信的逻辑（收发消息）放到client类中进行处理
                clients.Add(client);//把socket 添加到集合中去

            }

        }
    }
}
