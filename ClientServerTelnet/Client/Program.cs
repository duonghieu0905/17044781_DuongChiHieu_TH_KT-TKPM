using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpClient = new TcpClient();
            tcpClient.Connect("192.168.1.7",5000);
            Console.WriteLine("Connect Successful");
            Stream stream = tcpClient.GetStream();
            ASCIIEncoding encoding = new ASCIIEncoding();
            //send
            byte[] data = encoding.GetBytes(Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString());
            stream.Write(data, 0, data.Length);
            data = new byte[1024];
            //receive
            stream.Read(data, 0, 1024);
            Console.WriteLine(encoding.GetString(data));
            Console.ReadKey();
        }
    }
}
