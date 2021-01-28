using System;
using System.Net;
using System.Net.Sockets;
namespace SocketClient
{
    public class NetClient
    {

        private string clientName = "";
        public NetClient(string clientName)
        {
            this.clientName = clientName;
            this.Connection();
        }

        public Socket socket;

        const int BUFFER_SIZE = 1024;
        public byte[] readBuff = new byte[BUFFER_SIZE];

        

        public void Connection()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            socket.Connect("127.0.0.1",1234);

            socket.BeginReceive(readBuff,0,BUFFER_SIZE,SocketFlags.None, ReceiveCb, null);
        }

        /// <summary>
        /// 接收回调
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveCb(IAsyncResult ar)
        {
            try
            {
                int count = socket.EndReceive(ar);

                string str = System.Text.Encoding.UTF8.GetString(readBuff,0,count);
               

                Console.WriteLine(str+"\n");

                socket.BeginReceive(readBuff, 0, BUFFER_SIZE, SocketFlags.None, ReceiveCb, null);

            }
            catch (Exception e)
            {
                Console.WriteLine("连接断开");
                socket.Close();
            }
        

        }
        /// <summary>
        /// 发送数据
        /// </summary>
        public void Send(string message)
        {

            if (socket == null)
            {
                Console.WriteLine("没有连接");
            }

            byte[] bytes = System.Text.Encoding.Default.GetBytes(message);
            try
            {
                socket.Send(bytes);
            }
            catch (Exception e)
            {
                Console.WriteLine("发送异常");
            }
            
        }
    }
}
