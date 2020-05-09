using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ipLocal = IPAddress.Parse("192.168.1.7");
            TcpListener tcpListener = new TcpListener(ipLocal, 5000);
            tcpListener.Start();
            Console.WriteLine("Server Start In :" + tcpListener.LocalEndpoint);
            Console.WriteLine("Waiting the Connect...");
            while (true)
            {
                Socket socket = tcpListener.AcceptSocket();
                Console.WriteLine(socket.RemoteEndPoint + " connected");
                byte[] data = new byte[1024];
                socket.Receive(data);
                ASCIIEncoding encoding = new ASCIIEncoding();
                string str = encoding.GetString(data);
                socket.Send(encoding.GetBytes("Hello" + str));
            }
            

        }
    }
}
