using System;
using System.Net;
using System.Net.Sockets;

namespace SocketClient
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            NetClient clientA = new NetClient("Jim");

            NetClient clientB = new NetClient("Rock");

            NetClient clientC = new NetClient("Tom");

            

            clientA.Send("hello by Jim");

            clientB.Send("hello by Rock");
            clientC.Send("hello by Tom");

            while (true)
            {
                clientC.Send("bobo");
            }
           
        }
    }
}
