using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 聊天室tcp服务器端
{
    /// <summary>
    /// 用来根客户端做通信
    /// </summary>
    class Client
    {
        private Socket clientSocket;
        private Thread t;//把线程封装成一个字段 能更好进行管理

        private byte[] data = new Byte[1024];//这是一个数据容器 用来接收数据
        public Client(Socket socket)
        {
            clientSocket = socket;
            //启动一个线程 处理客户端的数据接收
            t = new Thread(ReceiveMassage);
            t.Start();
        }
        /// <summary>
        /// 客户端接收数据
        /// </summary>
        private void ReceiveMassage()
        {
            //一直接收客户端的数据
            while (true)
            {
                //在接收数据之前，判断一下socket 连接是否断开 防止接收到空的数据 一直输出
                //true 如果连接已关闭、 重置，或者终止，则返回， 否则，返回 false
                if (clientSocket.Poll(10,SelectMode.SelectRead))//是否能从客户端读取信息 判断时间为10毫秒
                {
                    Console.WriteLine("终止线程");
                    clientSocket.Close();//如果客户端断开 就关闭连接
                    break;//跳出循环 终止线程的执行
                }
                //返回 接收数据的长度
                int length = clientSocket.Receive(data);//用来接收客户端信息
                string message = Encoding.UTF8.GetString(data, 0, length);//把字符数组装换成 字符串
                //TODO:接收到数据的时候 把这个数据分发到客户端
                //广播这个消息
                Program.BroadcastMessage(message);
                Console.WriteLine("收到消息：" + message);

            }

        }
         public void SendMessage(string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);//把字符串转换为byte数组
            clientSocket.Send(data);//想客户端发送数据
        }
        /// <summary>
        /// 判断客户端是否断开连接
        /// </summary>
        public bool Connected {
            get
            {
                //true 如果 System.Net.Sockets.Socket 与截止到最近的操作的远程资源连接; 否则为 false。
                return clientSocket.Connected;
            }
        }
    }
}
