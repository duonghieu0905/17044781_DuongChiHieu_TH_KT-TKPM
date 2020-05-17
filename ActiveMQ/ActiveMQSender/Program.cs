using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apache.NMS;
using Apache.NMS.ActiveMQ;
using Apache.NMS.ActiveMQ.Commands;

namespace ActiveMQSender
{
    class Program
    {
        static void Main(string[] args)
        {
            IConnectionFactory factory = new ConnectionFactory("tcp://localhost:61616");
            IConnection connection = factory.CreateConnection("admin", "admin");
            connection.Start();
            ISession session = connection.CreateSession(AcknowledgementMode.AutoAcknowledge);
            IMessageProducer producer = session.CreateProducer(new ActiveMQQueue("17044781_DuongChiHieu"));
            while (true)
            {
                Console.WriteLine("Nhap thong tin");
                string s = Console.ReadLine();
                producer.Send(producer.CreateTextMessage(s));
            }
        }
    }
}
